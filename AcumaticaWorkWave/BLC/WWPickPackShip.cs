using AcumaticaWorkWave.Helpers;
using AcumaticaWorkWave.Resources;
using PX.BarcodeProcessing;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.SO;
using PX.Objects.SO.WMS;
using System.Collections;

namespace AcumaticaWorkWave.BLC
{
    public class WWPickPackShip : WorksheetPicking.ScanExtension
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Private

        [InjectDependency]
        private IWWCarrierPluginChecker Checker { get; set; }

        #endregion Private

        #region Views

        public SelectFrom<SOShipment>
              .Where<SOShipment.shipmentNbr.IsEqual<@P.AsString>>
              .View Shipments;

        #endregion Views

        #region Actions
        public PXAction<ScanHeader> CreateWorkWaveOrder;

        [PXButton]
        [PXUIField(DisplayName = "Create WorkWave Order")]
        protected virtual IEnumerable createWorkWaveOrder(PXAdapter adapter)
        {
            Base.Save.Press();
            if (!(Base.Document.Current is SOShipment shipment)) return adapter.Get();
            if (shipment == null) return adapter.Get();
            if (shipment.Status != SOShipmentStatus.Open)
            {
                throw new PXException(WWMessages.ShipmentIsNotOpen);
            }            

            Base.LongOperationManager.StartOperation(ct =>
            {                
                if (shipment != null)
                {
                    var shGraph = PXGraph.CreateInstance<SOShipmentEntry>();
                    var shGrapxExt = shGraph.GetExtension<WWSOShipmentEntryExt>();
                    shGraph.Document.Current = shGraph.Document.Search<SOShipment.shipmentNbr>(shipment.ShipmentNbr);
                    if (shGraph.Document.Current != null)
                    {
                        shGrapxExt.createWokWaveOrder.Press();
                        PXLongOperation.WaitCompletion(shGraph);
                    }
                }

                var header = Basis.HeaderView.Current;
                if (header != null)
                {
                    Basis.HeaderView.Cache.SetValueExt<WWHeaderExt.usrShipmentIsOpenState>(header, false);
                }
            });
                
            return adapter.Get();
        }

        #endregion Actions

        #region Event Handlers

        protected void _(Events.RowUpdated<ScanHeader> e)
        {
            if (!(e.Row is ScanHeader row)) return;

            var shipment = Shipments.SelectSingle(row.Barcode);
            if (shipment != null)
            {
                var isWorkWave = Checker.CheckIsWorkWavePluginType(Base, shipment.ShipVia);
                var isOpenState = shipment.Status == SOShipmentStatus.Open;

                e.Cache.SetValueExt<WWHeaderExt.usrShipViaCarrierIsWorkWave>(row, isWorkWave);
                e.Cache.SetValueExt<WWHeaderExt.usrShipmentIsOpenState>(row, isOpenState);
            }
        }

        #endregion Event Handlers

        #region WWHeaderExt

        [PXHidden]
        public sealed class WWHeaderExt : PXCacheExtension<ScanHeader>
        {
            #region IsActive

            public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

            #endregion IsActive

            #region UsrShipViaCarrierIsWorkWave

            [PXBool]
            public bool? UsrShipViaCarrierIsWorkWave { get; set; }

            public abstract class usrShipViaCarrierIsWorkWave : BqlBool.Field<usrShipViaCarrierIsWorkWave>
            { }

            #endregion UsrShipViaCarrierIsWorkWave

            #region UsrShipmentIsOpenState

            [PXBool]
            public bool? UsrShipmentIsOpenState { get; set; }

            public abstract class usrShipmentIsOpenState : BqlBool.Field<usrShipmentIsOpenState>
            { }

            #endregion UsrShipmentIsOpenState
        }

        #endregion WWHeaderExt
    }
}