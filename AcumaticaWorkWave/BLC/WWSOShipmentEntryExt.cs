using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.DataProxy;
using AcumaticaWorkWave.API.Domain;
using AcumaticaWorkWave.API.Domain.Orders;
using AcumaticaWorkWave.API.Domain.Routes;
using AcumaticaWorkWave.API.Provider;
using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.DAC;
using AcumaticaWorkWave.Helpers;
using AcumaticaWorkWave.Plugin;
using AcumaticaWorkWave.Resources;
using Newtonsoft.Json;
using PX.Api;
using PX.Common;
using PX.Concurrency;
using PX.CS.Contracts.Interfaces;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.CS.DAC;
using PX.Objects.IN;
using PX.Objects.SO;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using static PX.Objects.CS.BranchMaint;
using Location = PX.Objects.CR.Location;
using P = PX.Data.BQL.P;
using ShipmentActions = PX.Objects.SO.SOShipmentEntryActionsAttribute;

namespace AcumaticaWorkWave.BLC
{
    public class WWSOShipmentEntryExt : PXGraphExtension<SOShipmentEntry>, WWISyncWWEntity
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Private

        [InjectDependency]
        private IWWCarrierPluginChecker Checker { get; set; }

        private int _processedLinesCount = 0;

        #endregion Private

        #region Views

        public SelectFrom<WWOrder>.
                    Where<WWOrder.wwEntityID.IsEqual<SOShipment.noteID.AsOptional>>.View WWOrders;

        public SelectFrom<WWOrder>
                   .Where<WWOrder.wwRequestID.IsEqual<@P.AsGuid>
                     .And<WWOrder.wwDeliveryStatus.IsEqual<WWOrderStatus.pending>>>.View WWOrderByRequestID;

        public SelectFrom<SOShipment>
                   .Where<SOShipment.noteID.IsEqual<@P.AsGuid>>.View SOShipmentByNoteID;

        public SelectFrom<SOShipment>
                   .Where<WWSOShipmentExt.usrLastRequestID.IsEqual<@P.AsGuid>>.View SOShipmentByRequestID;

        public SelectFrom<CarrierPlugin>
               .InnerJoin<Carrier>.On<CarrierPlugin.carrierPluginID.IsEqual<Carrier.carrierPluginID>>
                   .Where<Carrier.carrierID.IsEqual<@P.AsString>>.View CarrierPluginByShipVia;

        public SelectFrom<CarrierLabelHistory>.View CarrierLabelHistoryRecords;

        #endregion Views

        [PXOverride]
        public virtual void CreateShipment(CreateShipmentArgs args, Action<CreateShipmentArgs> baseMethod)
        {
            baseMethod(args);
            if (args.ShipmentList == null)
            {
                if (Base.Transactions.Select().Count > 1)
                {

                    DateTime? startSec = null;
                    DateTime? endSec = null;

                    var shipment = Base.Document.Current;


                    Location currentLocation =
                        PXSelectBase<Location,
                        PXSelect<Location,
                        Where<Location.bAccountID, Equal<Required<Location.bAccountID>>,
                        And<Location.locationID, Equal<Required<Location.locationID>>>>>.Config>.
                        Select(base.Base, shipment.CustomerID, shipment.CustomerLocationID);

                    var currentLocationExt = currentLocation.GetExtension<WWLocationExt>();
                    if (currentLocationExt != null)
                    {
                        startSec = currentLocationExt.UsrWWStartSec;
                        endSec = currentLocationExt.UsrWWEndSec;
                    }

                    Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrWWStartSec>(shipment, startSec);
                    Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrWWEndSec>(shipment, endSec);
                    Base.Document.Update(shipment);
                }
                return;
            }
            foreach (var shipment in args.ShipmentList)
            {
                var extOrder = args.Order.GetExtension<WWSOOrderExt>();
                Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrWWStartSec>(shipment, extOrder.UsrWWStartSec);
                Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrWWEndSec>(shipment, extOrder.UsrWWEndSec);
                Base.Document.Update(shipment);
                Base.Save.Press();
            }
        }

        #region Actions

        public PXAction<SOShipment> getDeliveryStatus;

        [PXProcessButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Get Delivery Status", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected virtual IEnumerable GetDeliveryStatus(PXAdapter adapter)
        {
            if (Base.Document.Current == null) return adapter.Get();
            if (!(adapter.View.Cache.Current is SOShipment shipment)) return adapter.Get();
            Base.Save.Press();
            
            Base.LongOperationManager.StartOperation(ct =>
            {                
                var graph = PXGraph.CreateInstance<SOShipmentEntry>();
                var graphExt = graph.GetExtension<WWSOShipmentEntryExt>();
                shipment = graph.Document.Search<SOShipment.shipmentType, SOShipment.shipmentNbr>(shipment.ShipmentType, shipment.ShipmentNbr);
                var carrierPluginInfo = GetCarrierPluginInfo(shipment, graph);

                        try
                        {
                            var routeProvider = WWProviderLocator.Instance.Get<WWRouteProvider>(carrierPluginInfo.options);
                            var wwOrders = graphExt.WWOrders.Select();
                            string territoryId = carrierPluginInfo.territory?.GetWWTerritoryID();
                            var routes = new CacheHelper<RouteHash>().GetOrCreate(territoryId, () =>
                                                         routeProvider.List<RouteHash>(territoryId));
                            if (routes != null)
                            {
                                foreach (WWOrder wwOrder in wwOrders)
                                {
                                    var routeData = GetOrderRouteData(routes, wwOrder.WWOrderID);
                                    routeData.UpdateWWOrder(wwOrder);
                                    graphExt.UpdatePoDAttributes(wwOrder, carrierPluginInfo.service, carrierPluginInfo.options);
                                    graphExt.WWOrders.Update(wwOrder);
                                }

                        graph.Save.Press();
                    }

                    //Set shipment status
                    UpdateShipmentDeliveryStatus(graph, shipment);

                    //Workflow step
                    PerformWorkflowStep(graph, shipment);
                }
                catch (WWRequestExceptionBase e)
                {
                    PXProcessing.SetError(e);
                }
            });
            
            return adapter.Get();
        }

        public PXAction<SOShipment> createWokWaveOrder;

        [PXProcessButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Create WorkWave Order", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected IEnumerable CreateWokWaveOrder(PXAdapter adapter)
        {
            Base.Save.Press();
            if (Base.Document.Current == null) return adapter.Get();
            if (Base.Document.Current.Status != SOShipmentStatus.Open)
            {
                throw new PXException(WWMessages.ShipmentIsNotOpen);
            }
            if (!(adapter.View.Cache.Current is SOShipment shipment)) return adapter.Get();

            Base.LongOperationManager.StartOperation(ct =>
            {
                var graph = PXGraph.CreateInstance<SOShipmentEntry>();
                var syncGraph = PXGraph.CreateInstance<WWSyncMaint>();
                var carrierPluginInfo = GetCarrierPluginInfo(shipment, graph);

                try
                {
                    var orderProvider = WWProviderLocator.Instance.Get<WWOrdersProvider>(carrierPluginInfo.options);
                    var orders = GetWorkWaveOrders(shipment, graph, carrierPluginInfo);
                    var response = orderProvider.Add(carrierPluginInfo.territory?.GetWWTerritoryID(), orders);

                            //Update shipment
                            CreateWWOrder(graph, response.RequestId, orders.Orders.Select(o => o.Name));
                            WriteUseTrackingData(graph, shipment);
                            graph.Document.Cache.SetValueExt<WWSOShipmentExt.usrWWStatus>(shipment, WWOrderStatus.Pending);
                            graph.Document.Cache.SetValueExt<WWSOShipmentExt.usrLastRequestID>(shipment, response.RequestId);
                            graph.Document.Update(shipment);
                            graph.Save.Press();

                    //Update response
                    response.EntityID = shipment.NoteID;
                    syncGraph.UpdateResponse(response);
                }
                catch (WWRequestExceptionBase e)
                {
                    PXProcessing.SetError(e);
                }
            });

            return adapter.Get();
        }

        public PXAction<SOShipment> deleteShipment;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Delete Shipment")]
        protected virtual IEnumerable DeleteShipment(PXAdapter adapter)
        {
            Base.Save.Press();
            if (Base.Document.Current == null) return adapter.Get();
            if (Base.Document.Ask(WWMessages.WWShipmentHeader, WWMessages.WWShipmentDeleteAsk,
                    MessageButtons.OKCancel) == WebDialogResult.Cancel) return adapter.Get();
            if (!(adapter.View.Cache.Current is SOShipment shipment)) return adapter.Get();
                
            Base.LongOperationManager.StartOperation(ct =>
            {
                try
                {
                    var (graph, graphExt, carrierPluginInfo, tbsOrders) = InitSOActionObject(shipment);

                    //Update WWOrder statuses
                    var allOrders = UpdateWWOrdersDeliveryStatus(graphExt, carrierPluginInfo.options, carrierPluginInfo.territory, tbsOrders);

                    //Set shipment status
                    UpdateShipmentDeliveryStatus(graph, shipment);

                    if (shipment.Status == WWShipmentStatus.RoutePlanning && shipment.GetExtension<WWSOShipmentExt>().UsrWWStatus == WWOrderStatus.TBS)
                    {
                        try
                        {
                            var orderProvider = WWProviderLocator.Instance.Get<WWOrdersProvider>(carrierPluginInfo.options);
                            var territoryId = carrierPluginInfo.territory?.GetWWTerritoryID();
                            var orderIDs = tbsOrders.Select(o => o.WWOrderID).ToList();
                            using (var tr = new PXTransactionScope())
                            {
                                var allowDelete = graph.Document.Cache.AllowDelete;
                                graph.Document.Cache.AllowDelete = true;
                                graph.Delete.Press();
                                graph.Document.Cache.AllowDelete = allowDelete;

                                foreach (var orderID in orderIDs)
                                {
                                    orderProvider.Delete(territoryId, orderID.ToString());
                                }

                                tr.Complete();
                            }
                        }
                        catch (Exception e)
                        {
                            throw new PXException(WWMessages.WWOrderDeleteError, e);
                        }
                    }
                    else if (shipment.GetExtension<WWSOShipmentExt>().UsrWWStatus == WWOrderStatus.NotCreated)
                    {
                        graph.Delete.Press();
                    }
                    else
                    {
                        var orderNames = allOrders.Select(o => o.WWOrderName).ToList();
                        throw new PXException(WWMessages.WWShipmentDeleteError, string.Join(", ", orderNames));
                    }
                }
                catch (WWRequestExceptionBase e)
                {
                    throw new Exception(e.Message);
                }
            });

            return adapter.Get();
        }

        public PXAction<SOShipment> correctWWShipment;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Correct Shipment")]
        protected virtual IEnumerable CorrectWWShipment(PXAdapter adapter)
        {
            Base.Save.Press();
            if (Base.Document.Current == null) return adapter.Get();
            if (!(adapter.View.Cache.Current is SOShipment shipment)) return adapter.Get();
            
            Base.LongOperationManager.StartOperation(ct =>
            {
                
                try
                {
                    var (graph, graphExt, carrierPluginInfo, tbsOrders) = InitSOActionObject(shipment);

                    //Update WWOrder statuses
                    var allOrders = UpdateWWOrdersDeliveryStatus(graphExt, carrierPluginInfo.options, carrierPluginInfo.territory, tbsOrders);

                    //Set shipment status
                    UpdateShipmentDeliveryStatus(graph, shipment);

                    if (shipment.IsShipmentNotAssignedState())
                    {
                        var orderProvider = WWProviderLocator.Instance.Get<WWOrdersProvider>(carrierPluginInfo.options);
                        var territoryID = carrierPluginInfo.territory?.GetWWTerritoryID();

                        if (shipment.IsShipmentWorkWaveCarrier())
                        {
                            var orderInput = GetWorkWaveOrders(shipment, graph, carrierPluginInfo);
                            var orderList = new OrderList().Init(orderInput).InitIds(tbsOrders);
                            orderProvider.ReplaceOrders(territoryID, new OrderList() { Orders = orderInput.Orders });
                        }
                    }
                    else
                    {
                        var orderNames = allOrders.Select(o => o.WWOrderName).ToList();
                        throw new PXException(WWMessages.WWShipmentCorrectError, string.Join(", ", orderNames));
                    }
                }
                catch (WWRequestExceptionBase e)
                {
                    throw new Exception(e.Message);
                }
            });

            return adapter.Get();
        }

        public PXAction<SOShipment> deleteWWOrder;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Delete WorkWave Order")]
        protected virtual IEnumerable DeleteWWOrder(PXAdapter adapter)
        {
            Base.Save.Press();

            if (Base.Document.Ask(WWMessages.WWShipmentHeader,
                                  WWMessages.WWOrderDeleteAsk,
                                  MessageButtons.OKCancel) == WebDialogResult.Cancel)
            {
                return adapter.Get();
            }
            if (Base.Document.Current == null) return adapter.Get();
            if (!(adapter.View.Cache.Current is SOShipment shipment)) return adapter.Get();

            Base.LongOperationManager.StartOperation(ct =>
            {
                try
                {
                    var (graph, graphExt, carrierPluginInfo, tbsOrders) = InitSOActionObject(shipment);

                    //Update WWOrder statuses
                    var allOrders = UpdateWWOrdersDeliveryStatus(graphExt, carrierPluginInfo.options, carrierPluginInfo.territory, tbsOrders);

                    //Set shipment status
                    UpdateShipmentDeliveryStatus(graph, shipment);

                    if (shipment.IsShipmentNotAssignedState())
                    {
                        var orderProvider = WWProviderLocator.Instance.Get<WWOrdersProvider>(carrierPluginInfo.options);
                        var territoryID = carrierPluginInfo.territory?.GetWWTerritoryID();
                        try
                        {
                            using (var tr = new PXTransactionScope())
                            {
                                //Delete WWOrders
                                foreach (var wwOrder in tbsOrders)
                                {
                                    graphExt.WWOrders.Delete(wwOrder);
                                }
                                graph.Save.Press();

                                //Delete WWOrders from WorkWave
                                var orderIDs = new OrderIds().Init(tbsOrders);
                                var response = orderProvider.Delete(territoryID, orderIDs);

                                tr.Complete();
                            }
                        }
                        catch (Exception e)
                        {
                            throw new PXException(WWMessages.WWOrderDeleteError, e);
                        }
                    }
                    else
                    {
                        var orderNames = allOrders.Select(o => o.WWOrderName).ToList();
                        throw new PXException(WWMessages.WWShipmentDeleteError, string.Join(", ", orderNames));
                    }
                }
                catch (WWRequestExceptionBase e)
                {
                    throw new Exception(e.Message);
                }
            });

            return adapter.Get();
        }

        #region SOShipment action override

        //private object action;
        public PXAction<SOShipment> printLabels;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = ShipmentActions.Messages.PrintLabels, MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable PrintLabels(PXAdapter adapter)
        {
            var list = adapter.Get<SOShipment>().ToList();

            if (Checker.CheckIsWorkWavePluginType(Base, list.FirstOrDefault()?.ShipVia))
            {
                if (adapter.MassProcess)
                {
                    Base.Save.Press();

                    var printArgs = new PrintPackageFilesArgs
                    {
                        Shipments = list,
                        Adapter = adapter,
                        Category = PackageFileCategory.CarrierLabel
                    };

                    var graph = PXGraph.CreateInstance<SOShipmentEntry>();
                    Base.LongOperationManager.StartAsyncOperation(ct => graph.PrintPackageFiles(printArgs, ct));
                }
                else
                {
                    Base.PrintCarrierLabels();
                }

                return list;
            }
            else
            {
                return Base.printLabels.Press(adapter);
            }
        }

        #endregion SOShipment action override

        #endregion Actions

        #region Events

        protected virtual void _(Events.RowSelected<SOShipment> e)
        {
            if (!(e.Row is SOShipment row)) return;

            var isWorkWave = row.GetExtension<WWSOShipmentExt>().UsrIsWorkWave == true;
            var isEnabled = WWShipmentStatus.Statuses.All(s => s != row.Status);
            var isRoutePlanned = row.Status == WWShipmentStatus.RoutePlanning;
            Base.Document.Cache.AllowDelete = isEnabled;
            Base.Document.Cache.AllowUpdate = isEnabled || isRoutePlanned;

            PXUIFieldAttribute.SetEnabled<SOShipment.shipVia>(e.Cache, row, isEnabled);
            PXUIFieldAttribute.SetEnabled<SOShipment.shipmentNbr>(e.Cache, row, true);
            WWOrders.Cache.AllowSelect = isWorkWave;

        }

        protected virtual void _(Events.RowUpdated<SOShipment> e)
        {
            if (!(e.Row is SOShipment row)) return;
            if (row.Status == WWShipmentStatus.RoutePlanning
            && (e.OldRow.ShipDate != row.ShipDate || e.OldRow.ShipVia != row.ShipVia))
            {
                e.Cache.SetValueExt<WWSOShipmentExt.usrIsShipmentModified>(row, true);
            }
            e.Cache.SetValueExt<WWSOShipmentExt.usrHasWWOrders>(row, HasWWOrders());
        }

        protected virtual void _(Events.RowUpdated<SOShipmentContact> e)
        {
            if (!(e.Row is SOShipmentContact row)) return;
            SetShipmentModified();
        }

        protected virtual void _(Events.RowUpdated<SOShipmentAddress> e)
        {
            if (!(e.Row is SOShipmentAddress row)) return;
            SetShipmentModified();
        }

        protected virtual void _(Events.RowUpdated<SOPackageDetailEx> e)
        {
            if (!(e.Row is SOPackageDetailEx row)) return;
            SetShipmentModified();
        }

        protected virtual void _(Events.RowInserted<SOPackageDetailEx> e)
        {
            if (!(e.Row is SOPackageDetailEx row)) return;
            SetShipmentModified();
        }

        protected virtual void _(Events.RowDeleted<SOPackageDetailEx> e)
        {
            if (!(e.Row is SOPackageDetailEx row)) return;
            SetShipmentModified();
        }

        protected virtual void _(Events.FieldDefaulting<SOShipment, WWSOShipmentExt.usrIsWorkWave> e)
        {
            if (!(e.Row is SOShipment row)) return;
            e.NewValue = CheckIsWorkWavePluginType(row.ShipVia);
        }

        protected virtual void _(Events.FieldDefaulting<SOShipment, WWSOShipmentExt.usrWWStatus> e)
        {
            if (!(e.Row is SOShipment row)) return;
            e.NewValue = WWOrderStatus.NotCreated;
        }

        protected virtual void _(Events.FieldUpdated<SOShipment, SOShipment.shipVia> e)
        {
            if (!(e.Row is SOShipment row)) return;
            if (e.NewValue != null)
            {
                e.Cache.SetValueExt<WWSOShipmentExt.usrIsWorkWave>(row, CheckIsWorkWavePluginType(e.NewValue.ToString()));
            }
            else
            {
                e.Cache.SetValueExt<WWSOShipmentExt.usrIsWorkWave>(row, false);
            }
        }

        protected virtual void _(Events.RowInserted<SOShipLine> e)
        {
            if (!(e.Row is SOShipLine row)) return;
            Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrIsOrderTied>(Base.Document.Current, CheckIsOrderTied());
        }

        protected virtual void _(Events.RowDeleted<SOShipLine> e)
        {
            if (!(e.Row is SOShipLine row)) return;
            Base.Document.Cache.SetValueExt<WWSOShipmentExt.usrIsOrderTied>(Base.Document.Current, CheckIsOrderTied());
        }

        #endregion Events

        #region Public methods

        public void SyncWWOrder(WWSync syncRow)
        {
            var graph = Base;
            var cache = graph.Caches<WWOrder>();
            var syncCache = graph.Caches<WWSync>();
            var response = JsonConvert.DeserializeObject<WWAsyncResponse>(syncRow.WWData);

            //Processing orders error
            if (response.Data is WWApiError error)
            {
                ProcessRequestError(graph, cache, response, error);
            }
            else if (response.Data is WWAsyncResponseData data)
            {
                //Processing created orders
                if (data.Created.Any())
                {
                    ProcessRequestCreated(graph, cache, response, data);
                }

                //Processing deleted orders
                if (data.Deleted.Any())
                {
                    ProcessRequestDeleted(graph, cache, syncCache, data);
                }
            }
        }

        private void ProcessRequestError(SOShipmentEntry graph, PXCache<WWOrder> cache, WWAsyncResponse response, WWApiError error)
        {
            SOShipment shipment = SOShipmentByRequestID.SelectSingle(response.RequestId);
            var row = WWOrder.UK.ByRequestID.Find(graph, response.RequestId);

            if (shipment != null && row != null)
            {
                cache.SetValueExt<WWOrder.wwDeliveryStatus>(row, WWOrderStatus.ChangingError);
                cache.SetValueExt<WWOrder.wwErrorCode>(row, error.ErrorCode);
                cache.SetValueExt<WWOrder.wwErrorMessage>(row, error.ErrorMessage);
                cache.Update(row);
            }

            UpdateShipmentDeliveryStatus(graph, shipment);
            graph.Save.Press();
            PerformWorkflowStep(graph, shipment);
        }

        private void ProcessRequestCreated(SOShipmentEntry graph, PXCache<WWOrder> cache, WWAsyncResponse response, WWAsyncResponseData data)
        {
            SOShipment shipment = SOShipmentByRequestID.SelectSingle(response.RequestId);
            var rows = WWOrderByRequestID.Select(response.RequestId).RowCast<WWOrder>().ToArray();
            var count = 0;
            if (rows.Length > 0)
            {
                foreach (var item in data.Created)
                {
                    var row = rows[count++];
                    if (row != null)
                    {
                        cache.SetValueExt<WWOrder.wwOrderID>(row, item.Id);
                        cache.SetValueExt<WWOrder.wwOperation>(row, "created");
                        cache.SetValueExt<WWOrder.wwDeliveryStatus>(row, WWOrderStatus.TBS);
                        cache.Update(row);
                    }
                }
            }

            UpdateShipmentDeliveryStatus(graph, shipment);
            graph.Save.Press();
            PerformWorkflowStep(graph, shipment);
        }

        private void ProcessRequestDeleted(SOShipmentEntry graph, PXCache<WWOrder> cache, PXCache<WWSync> syncCache, WWAsyncResponseData data)
        {
            var orders = new List<WWOrder>();

            foreach (var item in data.Deleted)
            {
                WWOrder row = WWOrder.UK.ByOrderID.Find(graph, item);
                if (row != null)
                {
                    orders.Add(row);
                }
            }

            var orderDict = orders.GroupBy(k => k.WWEntityID).ToDictionary(k => k.Key, i => i.ToList());

            foreach (var item in orderDict)
            {
                var shipment = SOShipmentByNoteID.SelectSingle(item.Key);
                if (shipment?.Status == WWShipmentStatus.RoutePlanning)
                {
                    foreach (var order in item.Value)
                    {
                        WWSync sync = WWSync.PK.Find(graph, order.WWRequestID);
                        syncCache.Delete(sync);
                        cache.Delete(order);
                    }

                    UpdateShipmentDeliveryStatus(graph, shipment);
                    graph.Save.Press();
                    PerformWorkflowStep(graph, shipment);
                }
            }
        }

        #endregion Public methods

        #region Private methods
        private void CheckProcessedCount()
        {
            if (_processedLinesCount < 10)
            {
                _processedLinesCount++;
            }
            else
            {
                Thread.Sleep(10000);
            }
        }
        private OrderInput GetWorkWaveOrders(SOShipment shipment, SOShipmentEntry soGraph, CarrierPluginDataProxy carrierPluginInfo)
        {
            #region Get Data

            var data = GetOrderData();
            var barcodes = data.Packages.Select(p => GetBarcode(p)).ToList();

            #endregion Get Data

            #region Barcode Limit

            var barcodeLimit = carrierPluginInfo.service.BarcodeLimit;
            int packageCount = 1;
            const int packageCountLimit = 10;
            if (shipment.PackageCount != null)
            {
                packageCount = (int)shipment.PackageCount;
            }

            if (barcodeLimit.IsBarcodeLimitPrevent() && packageCount > packageCountLimit)
            {
                throw new PXException(WWMessages.WWBarcodeLimitationPreventException);
            }

            #endregion Barcode Limit

            #region Create Order Input

            var orderInput = new OrderInput().WithOrders();
            orderInput.AcceptBadGeocodes = true;
            orderInput.Strict = false;
            var skip = 0;
            var take = 10;

            if (barcodeLimit.IsBarcodeLimitAllow())
            {
                take = packageCount;
            }

            var barcodesCount = barcodes.Count > 0 ? barcodes.Count : 1;
            var number = barcodesCount > take ? 1 : 0;
            while (skip < barcodesCount)
            {
                var part = barcodes.Skip(skip).Take(take).ToList();
                Order order = CreateWWOrder(data, number);
                order.Delivery.Barcodes.AddRange(part);
                orderInput.Orders.Add(order);
                skip += take;
                number++;
            }

            return orderInput;

            #endregion Create Order Input

            #region Local functions

            string GetDeliveryAddress(IAddressBase address)
            {
                var sb = new StringBuilder();
                char delimiter = ',';
                char whiteSpace = ' ';

                sb.TryAppend(address.AddressLine1, delimiter, whiteSpace);
                sb.TryAppend(address.AddressLine2, delimiter, whiteSpace);
                sb.TryAppend(address.City, delimiter, whiteSpace);
                sb.TryAppend(address.CountryID, delimiter, whiteSpace);
                sb.TryAppend(address.State, delimiter, whiteSpace);
                sb.TryAppend(address.PostalCode, delimiter, whiteSpace);

                return sb.ToString().TrimEnd(delimiter);
            }

            string GetOrderName(OrderDataProxy dataObj, int nbr)
            {
                //Return 0312232 - Shipment contact full name
                //Or     0312232 - Shipment contact full name #1
                var name = $"{dataObj.Shipment.ShipmentNbr} - {dataObj.DeliveryContact.FullName}";
                if (nbr == 0)
                    return name;
                else
                    return $"{name} #{nbr}";
            }

            string GetBarcode(SOPackageDetailEx pkg)
            {
                return $"{shipment.ShipmentNbr}{carrierPluginInfo.service.BarcodeDelimeter}{pkg.LineNbr}";
            }

            Dictionary<string, string> GetCustomFields(List<WWCustomFieldMapping> customFieldMappings)
            {
                var result = new Dictionary<string, string>();
                //Validate: each OrderStep cannot contain more than 20 custom fields
                if (customFieldMappings.Count > 20)
                {
                    throw new PXException(WWMessages.WWCustomFieldMappingCountMoreThen20);
                }

                foreach (var mapping in customFieldMappings)
                {
                    var key = mapping.WWCustomFieldName;
                    var value = soGraph.GetFieldValue(mapping.WWViewName, mapping.WWFieldName);
                    result.Add(key, value);
                }
                //Validate: The total combined size of all custom field values cannot exceed 3000 characters.
                var length = string.Join("", result.Values).Length;
                if (length > 3000)
                {
                    throw new PXException(WWMessages.WWCustomFieldMappingLengthMoreThen3000);
                }

                return result;
            }
            OrderDataProxy GetOrderData()
            {
                //Shipment
                shipment = soGraph.Document.Search<SOShipment.shipmentNbr>(shipment.ShipmentNbr);
                var shipmentContact = soGraph.Shipping_Contact.SelectSingle();
                var shipmentAddress = soGraph.Shipping_Address.SelectSingle();
                var shipmentExt = shipment.GetExtension<WWSOShipmentExt>();


                //Order
                var orderList = soGraph.OrderList.SelectSingle();
                var soOrder = SOOrder.PK.Find(soGraph, orderList?.OrderType, orderList?.OrderNbr);

                //Packages
                var packages = soGraph.Packages.Select().RowCast<SOPackageDetailEx>().ToList();

                //Custom fields mappings
                var mappings = carrierPluginInfo.mapping;

                //PickUp Address
                var warehouseID = carrierPluginInfo.territory.WWWarehouseID;
                var branchID = carrierPluginInfo.territory.WWBranchID;
                var companyID = carrierPluginInfo.territory.WWCompanyID;
                Contact contact = null;
                Address address = null;
                string notes = null;

                if (warehouseID != null)
                {
                    var warehouseGraph = PXGraph.CreateInstance<INSiteMaint>();
                    INSite warehouse = warehouseGraph.site.Search<INSite.siteID>(shipment.SiteID);
                    contact = warehouseGraph.Contact.SelectSingle();
                    address = warehouseGraph.Address.SelectSingle();
                    notes = PXNoteAttribute.GetNote(warehouseGraph.site.Cache, warehouse);
                }
                else if (branchID != null)
                {
                    var branchGraph = PXGraph.CreateInstance<BranchMaint>();
                    var branch = PX.Objects.GL.Branch.PK.Find(branchGraph, branchID);
                    if (branch != null)
                    {
                        var currentBranch = branchGraph.BAccount.Search<BranchBAccount.bAccountID>(branch.BAccountID);
                        branchGraph.BAccount.Current = currentBranch;
                        var defContactAddress = branchGraph.GetExtension<BranchMaint.DefContactAddressExt>();
                        contact = defContactAddress.DefContact.SelectSingle();
                        address = defContactAddress.DefAddress.SelectSingle();
                        notes = PXNoteAttribute.GetNote(branchGraph.BAccount.Cache, currentBranch);
                    }
                }
                else if (companyID != null)
                {
                    var companyGraph = PXGraph.CreateInstance<OrganizationMaint>();
                    var company = PX.Objects.GL.DAC.Organization.PK.Find(companyGraph, companyID);
                    if (company != null)
                    {
                        var currentOrganization = companyGraph.BAccount.Search<OrganizationBAccount.acctCD>(company.OrganizationCD);
                        companyGraph.BAccount.Current = currentOrganization;
                        var defContactAddress = companyGraph.GetExtension<OrganizationMaint.DefContactAddressExt>();
                        contact = defContactAddress.DefContact.SelectSingle();
                        address = defContactAddress.DefAddress.SelectSingle();
                        notes = PXNoteAttribute.GetNote(companyGraph.BAccount.Cache, currentOrganization);
                    }
                }

                return new OrderDataProxy
                {
                    Service = carrierPluginInfo.service,
                    Shipment = shipment,
                    ShipmentNotes = PXNoteAttribute.GetNote(soGraph.Document.Cache, shipment),
                    DeliveryContact = shipmentContact,
                    DeliveryAddress = shipmentAddress,
                    Order = soOrder,
                    Packages = packages,
                    WarehouseNotes = notes,
                    PickUpContact = contact,
                    PickUpAddress = address,
                    CustomFieldMappings = mappings,
                    TimeWindows =
                        new List<TimeWindow>()
                            { new TimeWindow() {
                                StartSec = shipmentExt.UsrWWStartSec.HasValue ? (int)shipmentExt.UsrWWStartSec?.TimeOfDay.TotalSeconds : 0,
                                EndSec = shipmentExt.UsrWWEndSec.HasValue ? (int)shipmentExt.UsrWWEndSec?.TimeOfDay.TotalSeconds : 0
                                }
                            }
                };
            }

            Order CreateWWOrder(OrderDataProxy dataObj, int nbr)
            {
                var orderObj = new Order().WithEligibility()
                                          .WithDelivery(d => d.WithLocation()
                                                              .WithBarcodes()
                                                              .WithCustomFields())
                                          .WithPickup(d => d.WithLocation()
                                                            .WithTimeWindows()
                                          );

                orderObj.Name = GetOrderName(dataObj, nbr);
                orderObj.Priority = dataObj.Order?.Priority.GetValueOrDefault() ?? default;

                orderObj.Eligibility.Type = dataObj.Service.EligibilityType;
                orderObj.Eligibility.ByDate = dataObj.Shipment.ShipDate.ToWWDate();

                orderObj.Delivery.Phone = dataObj.DeliveryContact.Phone1;
                orderObj.Delivery.Email = dataObj.DeliveryContact.Email;
                orderObj.Delivery.Notes = dataObj.ShipmentNotes;
                orderObj.Delivery.Location.Address = GetDeliveryAddress(dataObj.DeliveryAddress);
                orderObj.Delivery.CustomFields = GetCustomFields(dataObj.CustomFieldMappings);

                orderObj.Pickup.Phone = dataObj.PickUpContact.Phone1;
                orderObj.Pickup.Email = dataObj.PickUpContact.EMail;
                orderObj.Pickup.Notes = dataObj.WarehouseNotes;
                orderObj.Pickup.Location.Address = GetDeliveryAddress(dataObj.PickUpAddress);
                orderObj.Pickup.TimeWindows = dataObj.TimeWindows;
                return orderObj;
            }

            #endregion Local functions
        }

        private bool CheckIsWorkWavePluginType(string shipVia)
        {
            var plugin = CarrierPluginByShipVia.SelectSingle(shipVia);
            var isWorkWave = plugin?.PluginTypeName == WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME;
            return isWorkWave;
        }

        private bool HasWWOrders()
        {
            var wwOrder = WWOrders.Select().FirstTableItems;
            return wwOrder.Any();
        }

        private bool CheckIsOrderTied()
        {
            var orders = Base.Transactions.Select().FirstTableItems;
            return orders.Any();
        }

        private void CreateWWOrder(SOShipmentEntry soGraph, Guid? requestID, IEnumerable<string> orderNames)
        {
            var graphExt = soGraph.GetExtension<WWSOShipmentEntryExt>();

            foreach (var orderName in orderNames)
            {
                var wwOrderRow = graphExt.WWOrders.Insert();
                if (wwOrderRow != null)
                {
                    wwOrderRow.WWRequestID = requestID;
                    wwOrderRow.WWOrderName = orderName;
                    wwOrderRow.WWDeliveryStatus = WWOrderStatus.Pending;
                }
            }
        }

        private void WriteUseTrackingData(SOShipmentEntry graph, SOShipment shipment)
        {
            var packages = graph.Packages.Select().RowCast<SOPackageDetailEx>();
            var graphExt = graph.GetExtension<WWSOShipmentEntryExt>();

            var shipViaCode = Carrier.PK.Find(graph, shipment.ShipVia);
            var carrier = CarrierPlugin.PK.Find(graph, shipViaCode?.CarrierPluginID);

            foreach (var package in packages)
            {
                var record = graphExt.CarrierLabelHistoryRecords.Insert();
                var recordExt = record.GetExtension<WWCarrierLabelHistoryExt>();

                record.ShipmentNbr = shipment.ShipmentNbr;
                record.LineNbr = package.LineNbr;
                record.PluginTypeName = carrier?.PluginTypeName;
                record.ServiceMethod = shipViaCode?.PluginMethod;
                record.RateAmount = shipment.CuryFreightAmt;
                recordExt.UsrCarrier = carrier?.CarrierPluginID;
            }
        }

        private string GetShipmentDeliveryStatus(IEnumerable<string> deliveryStatuses)
        {
            var statuses = deliveryStatuses.ToList();
            if (statuses.Any(d => d == WWOrderStatus.ChangingError))
                return WWOrderStatus.ChangingError;
            else if (statuses.Any(d => d == WWOrderStatus.Pending))
                return WWOrderStatus.Pending;
            else if (statuses.Any(d => d == WWOrderStatus.TBS))
                return WWOrderStatus.TBS;
            else if (statuses.Any(d => d == WWOrderStatus.RouteAssigned))
                return WWOrderStatus.RouteAssigned;
            else if (statuses.Any(d => d == WWOrderStatus.Rescheduled))
                return WWOrderStatus.Rescheduled;
            else if (statuses.Any(d => d == WWOrderStatus.DeliveredIssue))
                return WWOrderStatus.DeliveredIssue;
            else if (statuses.Any(d => d == WWOrderStatus.Delivered))
                return WWOrderStatus.Delivered;
            else return WWOrderStatus.NotCreated;
        }

        private void UpdateShipmentDeliveryStatus(SOShipmentEntry graph, SOShipment shipment)
        {
            var graphExt = graph.GetExtension<WWSOShipmentEntryExt>();
            var deliveryStatuses = graphExt.WWOrders.Select(shipment.NoteID)
                                                    .RowCast<WWOrder>()
                                                    .Select(o => o.WWDeliveryStatus);

            var wwOrderStatus = GetShipmentDeliveryStatus(deliveryStatuses);
            shipment.GetExtension<WWSOShipmentExt>().UsrWWStatus = wwOrderStatus;
            graph.Document.Update(shipment);
        }

        private void PerformWorkflowStep(SOShipmentEntry graph, SOShipment shipment)
        {
            var graphWorkflowExt = graph.GetExtension<WWSOShipmentEntryWorkflowExt>();
            var shipmentStatus = shipment.Status;
            var wwOrderStatus = shipment.GetExtension<WWSOShipmentExt>().UsrWWStatus;

            //PartiallyRouted -> Error
            if (shipmentStatus == WWShipmentStatus.PartiallyRouted && wwOrderStatus == WWOrderStatus.ChangingError)
            {
                shipment.Status = WWShipmentStatus.RouteError;
                graph.Document.Update(shipment);
                graph.Persist();
                graphWorkflowExt.orderCreatedFailure.Press();
                return;
            }

            //PartiallyRouted -> RoutePlanning
            if (shipmentStatus == WWShipmentStatus.PartiallyRouted && wwOrderStatus == WWOrderStatus.TBS)
            {
                graphWorkflowExt.orderCreatedSuccess.Press();
                if (shipment.Status == WWShipmentStatus.PartiallyRouted)
                {
                    ForceUpdateShipmentStatus(graph, shipment, WWShipmentStatus.RoutePlanning);
                }
                return;
            }

            //RoutePlanning -> Open
            if (shipmentStatus == WWShipmentStatus.RoutePlanning && wwOrderStatus == WWOrderStatus.NotCreated)
            {
                shipment.Status = WWShipmentStatus.Open;
                graph.Document.Update(shipment);
                graph.Persist();
                graphWorkflowExt.orderRouteDeleted.Press();
                return;
            }

            //RoutePlanning -> RouteAssigned
            if (shipmentStatus == WWShipmentStatus.RoutePlanning && wwOrderStatus == WWOrderStatus.RouteAssigned)
            {
                graphWorkflowExt.orderRouteAssigned.Press();
                return;
            }

            if (shipmentStatus == WWShipmentStatus.RoutePlanning && (wwOrderStatus == WWOrderStatus.Delivered
                                                                 || wwOrderStatus == WWOrderStatus.DeliveredIssue))
            {
                graphWorkflowExt.orderRouteAssigned.Press();
                ToDeliveredStatus();
                return;
            }

            //RouteAssigned -> RoutePlanning
            if (shipmentStatus == WWShipmentStatus.RouteAssigned && wwOrderStatus == WWOrderStatus.TBS)
            {
                graphWorkflowExt.orderRouteUnAssigned.Press();
                return;
            }

            //RouteAssigned -> RouteDelivered
            if (shipmentStatus == WWShipmentStatus.RouteAssigned && (wwOrderStatus == WWOrderStatus.Delivered
                                                                  || wwOrderStatus == WWOrderStatus.DeliveredIssue))
            {
                ToDeliveredStatus();
                return;
            }

            void ToDeliveredStatus()
            {
                graphWorkflowExt.orderRouteDelivered.Press();

                PXLongOperation.StartOperation(Base, () =>
                {
                    var g = PXGraph.CreateInstance<SOShipmentEntry>();
                    g.Document.Search<SOShipment.shipmentNbr>(shipment.ShipmentNbr);
                    g.confirmShipmentAction.Press();
                });
            }
        }

        private void ForceUpdateShipmentStatus(SOShipmentEntry graph, SOShipment shipment, string status)
        {
            shipment.Status = status;
            graph.Document.Update(shipment);
            graph.Save.Press();
        }

        private RouteDataProxy GetOrderRouteData(RouteHash routes, Guid? wwOrderID)
        {
            var routeData = new RouteDataProxy();
            var route = routes.Routes.Where(x => x.Value.Steps.Any(s => s.OrderId == wwOrderID)).FirstOrDefault();

            if (route.Value != null)
            {
                routeData.Step = route.Value.Steps.Where(x => x.OrderId == wwOrderID
                                                           && x.Type == WWTrackingDataStatuses.Delivery).LastOrDefault();

                routeData.TrackingLink = route.Value.Steps.Where(x => x.OrderId == wwOrderID
                                                           && x.Type == WWTrackingDataStatuses.Pickup).LastOrDefault()?.TrackingLink;


                routeData.DeliveryDate = DateTime.ParseExact(route.Value.Date, "yyyyMMdd", CultureInfo.InvariantCulture);
            }

            return routeData;
        }

        private CarrierPluginDataProxy GetCarrierPluginInfo(SOShipment shipment, SOShipmentEntry graph)
        {
            var carrierGraph = PXGraph.CreateInstance<CarrierPluginMaint>().GetExtension<WWCarrierPluginMaintExt>();
            var plugin = CarrierPluginByShipVia.SelectSingle(shipment.ShipVia);
            WorkWaveCarrier service = CarrierPluginMaint.CreateCarrierService(graph, plugin).Result as WorkWaveCarrier;

            var options = service.GetApiOptions();
            var territory = carrierGraph.GetTerritoryID(plugin, shipment.SiteID);
            var mapping = carrierGraph.CustomFieldMappingByShipVia.Select(shipment.ShipVia).RowCast<WWCustomFieldMapping>().ToList();

            return new CarrierPluginDataProxy(service, options, territory, mapping);
        }

        private void UpdatePoDAttributes(WWOrder wwOrder, WorkWaveCarrier service, WWRestOptions options)
        {
            if (wwOrder.WWDeliveryStatus == WWOrderStatus.Delivered || wwOrder.WWDeliveryStatus == WWOrderStatus.DeliveredIssue)
            {
                var cache = WWOrders.Cache;
                var graph = PXGraph.CreateInstance<UploadFileMaintenance>();
                var podProvider = WWProviderLocator.Instance.Get<WWPoDProvider>(options);

                if (service.StorePodDriverNotes == true && !string.IsNullOrEmpty(wwOrder.WWNoteValue))
                {
                    PXNoteAttribute.SetNote(cache, wwOrder, wwOrder.WWNoteValue);
                }

                if (service.StorePodPictures == true && !string.IsNullOrEmpty(wwOrder.WWPictureValue))
                {
                    var tokens = wwOrder.WWPictureValue.Split('|');
                    var tokenNotes = wwOrder.WWPictureNoteValue.Split('|');
                    UploadFile(cache, graph, podProvider, tokens, tokenNotes, WWMessages.PicturePrefix);
                }

                if (service.StorePodSignature == true && !string.IsNullOrEmpty(wwOrder.WWSignatureValue))
                {
                    var tokens = wwOrder.WWSignatureValue.Split('|');
                    var tokenNotes = wwOrder.WWSignatureNoteValue.Split('|');
                    UploadFile(cache, graph, podProvider, tokens, tokenNotes, WWMessages.SignaturePrefix);
                }

                if (service.StorePodGps == false)
                {
                    wwOrder.WWGPS = null;
                }
            }

            void UploadFile(PXCache cache, UploadFileMaintenance graph, WWPoDProvider podProvider, string[] tokens, string[] tokenNotes, string prefix)
            {
                var i = 0;
                foreach (var token in tokens)
                {
                    var fileData = podProvider.GetPoD(token);
                    var fileComment = tokenNotes[i++];
                    var fileName = $"{prefix}{token}";
                    var file = new FileInfo(Guid.NewGuid(), fileName, null, fileData, fileComment);
                    graph.SaveFile(file, FileExistsAction.CreateVersion);
                    PXNoteAttribute.SetFileNotes(cache, wwOrder, file.UID.GetValueOrDefault());
                }
            }
        }

        private void SetShipmentModified()
        {
            var parent = Base.Document.Current;
            var cache = Base.Document.Cache;
            if (parent?.Status == WWShipmentStatus.RoutePlanning)
            {
                cache.SetValueExt<WWSOShipmentExt.usrIsShipmentModified>(parent, true);
            }
        }

        private List<WWOrder> UpdateWWOrdersDeliveryStatus(WWSOShipmentEntryExt graphExt, WWRestOptions options, WWCarrierTerritory territory, List<WWOrder> tbsOrders)
        {
            var routeProvider = WWProviderLocator.Instance.Get<WWRouteProvider>(options);
            var wwOrders = graphExt.WWOrders.Select();
            var routes = routeProvider.List<RouteHash>(territory?.GetWWTerritoryID());
            var wwOrderList = new List<WWOrder>();

            if (routes != null)
            {
                foreach (WWOrder wwOrder in wwOrders)
                {
                    wwOrderList.Add(wwOrder);
                    var routeData = GetOrderRouteData(routes, wwOrder.WWOrderID);
                    routeData.UpdateWWOrder(wwOrder);
                    if (wwOrder.WWDeliveryStatus == WWOrderStatus.TBS)
                    {
                        tbsOrders.Add(wwOrder);
                    }
                }
            }

            return wwOrderList;
        }

        private (SOShipmentEntry graph,
                WWSOShipmentEntryExt graphExt,
                CarrierPluginDataProxy carrierPluginInfo,
                List<WWOrder> tbsOrders)
                InitSOActionObject(SOShipment shipment)
        {
            var graph = PXGraph.CreateInstance<SOShipmentEntry>();
            var graphExt = graph.GetExtension<WWSOShipmentEntryExt>();
            shipment = graph.Document.Search<SOShipment.shipmentType, SOShipment.shipmentNbr>(shipment.ShipmentType, shipment.ShipmentNbr);
            var carrierPluginInfo = GetCarrierPluginInfo(shipment, graph);
            var tbsOrders = new List<WWOrder>();

            return (graph, graphExt, carrierPluginInfo, tbsOrders);
        }

        #endregion Private methods

        #region  Methods from SOShipmentEntry

        [PXOverride]
        public virtual bool UseFreightCalculator(SOShipment row, Carrier carrier, Func<SOShipment, Carrier, bool> baseMethod)
        {
            var applyFreightRates = (carrier?.IsExternal).GetValueOrDefault() && CheckIsWorkWavePluginType(carrier?.CarrierID);

            return applyFreightRates || baseMethod(row, carrier);
        }

        [PXOverride]
        public void LoadPackageFiles(PrintPackageFilesArgs printArg)
        {
            /* TODO: Added for print labels without packages & files.
              * Need attention after update to next Acumatica version
              * Current version: 23.203.0040 */
            
            if (printArg.RedirectToReport != null) return;
            
            var userDefinedPrinterID = SMPrintJobMaint.GetPrintSettings(printArg.Adapter)?.PrinterID;
            PXReportRequiredException reportRedirect = null;
            var printerToReportsMap = new Dictionary<Guid, ShipmentRelatedReports>();
            var notificationUtility = new NotificationUtility(Base);
            var searchPrinter = Func.Memorize(
                (string shipVia) => SearchPrinter(SONotificationSource.Customer, printArg.PrintFormID, Base.Accessinfo.BranchID, shipVia));
            var searchReport = Func.Memorize(
                (int? customerID) => notificationUtility.SearchCustomerReport(printArg.PrintFormID, customerID, Base.Accessinfo.BranchID));

            {
                foreach (SOShipment shiporder in printArg.Shipments)
                {
                    var printerID = userDefinedPrinterID ?? searchPrinter(shiporder.ShipVia ?? string.Empty) ?? Guid.Empty;
                    var reports = printerToReportsMap.Ensure(printerID, () => new ShipmentRelatedReports());
                    var packagesResultset = PXSelect<SOPackageDetailEx, Where<SOPackageDetailEx.shipmentNbr, Equal<Required<SOShipment.shipmentNbr>>>>.Select(Base, shiporder.ShipmentNbr);

                    var actualReportID = searchReport(shiporder.CustomerID);
                    var parameters = new Dictionary<string, string>
                    {
                        [$"{nameof(SOShipment)}.{nameof(SOShipment.ShipmentNbr)}"] = shiporder.ShipmentNbr
                    };
                    reports.ReportRedirect = PXReportRequiredException.CombineReport(reports.ReportRedirect, actualReportID, parameters);
                    reportRedirect = PXReportRequiredException.CombineReport(reportRedirect, actualReportID, parameters);
                    reportRedirect.Mode = PXBaseRedirectException.WindowMode.New;
                }
            }
            
            printArg.RedirectToReport = reportRedirect;
        }

        protected virtual Guid? SearchPrinter(string source, string reportID, int? branchID, string shipVia)
        {
            NotificationSetupUserOverride userSetup =
                SelectFrom<NotificationSetupUserOverride>
                    .InnerJoin<NotificationSetup>.On<NotificationSetupUserOverride.FK.DefaultSetup>
                    .Where<NotificationSetupUserOverride.userID.IsEqual<AccessInfo.userID.FromCurrent>
                        .And<NotificationSetupUserOverride.active.IsEqual<True>>
                        .And<NotificationSetup.active.IsEqual<True>>
                        .And<NotificationSetup.sourceCD.IsEqual<@P.AsString>>
                        .And<NotificationSetup.reportID.IsEqual<@P.AsString>>
                        .And<NotificationSetupUserOverride.shipVia.IsEqual<@P.AsString>>
                        .And<NotificationSetup.nBranchID.IsEqual<@P.AsInt>.Or<NotificationSetup.nBranchID.IsNull>>>
                    .OrderBy<NotificationSetup.nBranchID.Desc>
                    .View.Select(Base, source, reportID, shipVia, branchID);
            if (userSetup?.DefaultPrinterID != null)
                return userSetup.DefaultPrinterID;

            if (source != null && reportID != null)
            {
                NotificationSetup setup =
                    SelectFrom<NotificationSetup>
                        .Where<NotificationSetup.active.IsEqual<True>
                            .And<NotificationSetup.sourceCD.IsEqual<@P.AsString>>
                            .And<NotificationSetup.reportID.IsEqual<@P.AsString>>
                            .And<NotificationSetup.shipVia.IsEqual<@P.AsString>>
                            .And<NotificationSetup.nBranchID.IsEqual<@P.AsInt>.Or<NotificationSetup.nBranchID.IsNull>>>
                        .OrderBy<NotificationSetup.nBranchID.Desc>
                        .View.SelectWindowed(Base, 0, 1, source, reportID, shipVia, branchID);
                if (setup?.DefaultPrinterID != null)
                    return setup.DefaultPrinterID;
            }

            return new NotificationUtility(Base).SearchPrinter(source, reportID, branchID);
        }

        #endregion Methods from SOShipmentEntry

    }
}