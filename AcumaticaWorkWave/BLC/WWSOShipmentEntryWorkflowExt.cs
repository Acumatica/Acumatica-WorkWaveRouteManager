using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.SO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AcumaticaWorkWave.DAC;
using PX.Common;

namespace AcumaticaWorkWave.BLC
{
    public class WWSOShipmentEntryWorkflowExt : PXGraphExtension<SOShipmentEntry>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Workflow Actions

        public PXAction<SOShipment> cancelOrder;
        public PXAction<SOShipment> orderCreatedSuccess;
        public PXAction<SOShipment> orderCreatedFailure;

        public PXAction<SOShipment> orderRouteAssigned;
        public PXAction<SOShipment> orderRouteDeleted;
        public PXAction<SOShipment> orderRouteUnAssigned;

        public PXAction<SOShipment> orderRouteDelivered;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Cancel Order")]
        protected virtual IEnumerable CancelOrder(PXAdapter adapter)
        {
            if (Base.Document.Current != null)
            {
                if (Base.Document.Ask(WWMessages.WWShipmentHeader,
                                      WWMessages.WWOrderDeleteLocally,
                                      MessageButtons.OKCancel,
                                      true) == WebDialogResult.Cancel)
                {
                    return adapter.Get();
                }

                var graphExt = Base.GetExtension<WWSOShipmentEntryExt>();
                var selectedOrdersLines = new List<int?>();
                graphExt.WWOrders.Select().RowCast<WWOrder>().Where(x => x.Selected.GetValueOrDefault()).
                                                            ForEach(x => selectedOrdersLines.Add(x.WWLineNbr));

                Base.LongOperationManager.StartOperation(ct =>
                {
                    var graph = PXGraph.CreateInstance<SOShipmentEntry>();
                    graphExt = graph.GetExtension<WWSOShipmentEntryExt>();

                    if (adapter.View.Cache.Current is SOShipment shipment)
                    {
                        shipment = graph.Document.Search<SOShipment.shipmentType, SOShipment.shipmentNbr>(shipment.ShipmentType, shipment.ShipmentNbr);
                        var wwOrders = graphExt.WWOrders.Select();
                        foreach (var wwOrder in wwOrders.Where(x => selectedOrdersLines.Contains(x.GetItem<WWOrder>().WWLineNbr)))
                        {
                            graphExt.WWOrders.Delete(wwOrder);
                        }

                        if (graphExt.WWOrders.Select().Count == 0)
                        {
                            WWSOShipmentExt shipmentExt = shipment.GetExtension<WWSOShipmentExt>();
                            if (shipmentExt != null)
                            {
                                shipmentExt.UsrHasWWOrders = false;
                                graph.Document.Update(shipment);
                            }
                        }
                        graph.Save.Press();
                    }
                });
            }

            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Created Success")]
        protected virtual IEnumerable OrderCreatedSuccess(PXAdapter adapter)
        {
            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Created Failure")]
        protected virtual IEnumerable OrderCreatedFailure(PXAdapter adapter)
        {
            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Route Deleted")]
        protected virtual IEnumerable OrderRouteDeleted(PXAdapter adapter)
        {
            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Route Assigned")]
        protected virtual IEnumerable OrderRouteAssigned(PXAdapter adapter)
        {
            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Route Unassigned")]
        protected virtual IEnumerable OrderRouteUnassigned(PXAdapter adapter)
        {
            return adapter.Get();
        }

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Order Route Delivered")]
        protected virtual IEnumerable OrderRouteDelivered(PXAdapter adapter)
        {
            return adapter.Get();
        }

        #endregion Workflow Actions
    }
}