using AcumaticaWorkWave.DAC;
using AcumaticaWorkWave.Helpers;
using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.SO;
using System;
using System.Collections;
using static PX.Objects.SO.SOOrderEntry;

namespace AcumaticaWorkWave.BLC
{
    public class WWSOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Private
        [InjectDependency]
        private IWWCarrierPluginChecker Checker { get; set; }

        #endregion Private

        #region Event handlers

        protected virtual void _(Events.FieldUpdated<SOOrder.customerID> e)
        {
            if (!(e.Row is SOOrder row)) return;
            var customer = Base.customer.Current;
            if (customer == null) return;
            var extCustomer = customer.GetExtension<WWCustomerExt>();

            e.Cache.SetValueExt<WWSOOrderExt.usrWWStartSec>(row, extCustomer.UsrWWStartSec);
            e.Cache.SetValueExt<WWSOOrderExt.usrWWEndSec>(row, extCustomer.UsrWWEndSec);
        }

        protected virtual void _(Events.RowUpdated<SOOrder> e)
        {
            if (!(e.Row is SOOrder row)) return;

            var soOrderEntryExt = Base.GetExtension<SOQuickProcess>();
            var quickRow = soOrderEntryExt.QuickProcessParameters.Current;
            var quickCache = soOrderEntryExt.QuickProcessParameters.Cache;

            var isQuickProcessEnabled = Checker.CheckIsWorkWavePluginType(Base, row.ShipVia) == false;
            quickCache.SetValueExt<SOQuickProcessParameters.confirmShipment>(quickRow, isQuickProcessEnabled);
            quickCache.SetValueExt<SOQuickProcessParameters.updateIN>(quickRow, isQuickProcessEnabled);
            quickCache.SetValueExt<SOQuickProcessParameters.prepareInvoiceFromShipment>(quickRow, isQuickProcessEnabled);
        }

        protected virtual void _(Events.RowSelecting<SOQuickProcessParameters> e)
        {
            if (!(e.Row is SOQuickProcessParameters row)) return;
            var cache = e.Cache;
            var order = Base.Document.Current;

            bool isQuickProcessEnabled = true;
            using (new PXConnectionScope())
            {
                isQuickProcessEnabled = Checker.CheckIsWorkWavePluginType(Base, order.ShipVia) == false;
            }

            cache.SetValueExt<SOQuickProcessParameters.confirmShipment>(row, isQuickProcessEnabled);
            cache.SetValueExt<SOQuickProcessParameters.updateIN>(row, isQuickProcessEnabled);
            cache.SetValueExt<SOQuickProcessParameters.prepareInvoiceFromShipment>(row, isQuickProcessEnabled);
        }

        protected virtual void _(Events.RowSelected<SOQuickProcessParameters> e)
        {
            if (!(e.Row is SOQuickProcessParameters row) || !(Base.Document.Current is SOOrder soOrder)) return;

            var isWorkWavePluginType = Checker.CheckIsWorkWavePluginType(Base, soOrder.ShipVia);
            var isQuickProcessEnabled = isWorkWavePluginType == false;
            PXUIFieldAttribute.SetEnabled<SOQuickProcessParameters.confirmShipment>(e.Cache, row, isQuickProcessEnabled);
            PXUIFieldAttribute.SetEnabled<SOQuickProcessParametersReportsExt.printLabels>(e.Cache, row, isWorkWavePluginType);
        }

        #endregion Event handlers

        [PXOverride]
        public virtual void CalcFreightCost(SOOrder row, Carrier carrier, FreightCalculator freightCalculator)
        {

            if (carrier == null || IsWorkWavePlugin(carrier))
            {
                freightCalculator.CalcFreightCost<SOOrder, SOOrder.curyFreightCost>(Base.Document.Cache, row);
                row.FreightCostIsValid = true;
            }
            else
            {
                row.FreightCostIsValid = false;
            }
        }

        [PXOverride]
        public virtual IEnumerable CalculateFreight(PXAdapter adapter, Func<PXAdapter, IEnumerable> BaseMethod)
        {
            Carrier carrier = Carrier.PK.Find(Base, Base.Document.Current.ShipVia);

            if (IsWorkWavePlugin(carrier))
            {
                if (Base.Document.Current != null && Base.Document.Current.IsManualPackage != true && Base.Document.Current.IsPackageValid != true)
                {
                    Base.CarrierRatesExt.RecalculatePackagesForOrder(Base.Document.Current);
                }
                return adapter.Get();
            }
            else
            {
                return BaseMethod?.Invoke(adapter);
            }

        }

        [PXOverride]
        public virtual void ApplyFreightTerms(SOOrder row, Carrier carrier, FreightCalculator freightCalculator)
        {
            if (row.OverrideFreightAmount != true && (carrier == null || carrier.IsExternal != true || IsWorkWavePlugin(carrier) || freightCalculator.IsFlatRate(Base.Document.Cache, row)))
            {
                PXResultset<SOLine> pXResultset = Base.Transactions.Select();
                freightCalculator.ApplyFreightTerms<SOOrder, SOOrder.curyFreightAmt>(Base.Document.Cache, row, pXResultset.Count);
            }
        }

        private bool IsWorkWavePlugin(Carrier carrier)
        {
            bool isWorkWavePlugin = false;
            if (carrier != null)
            {
                var carrierPlugin = CarrierPlugin.PK.Find(Base, carrier.CarrierPluginID);
                isWorkWavePlugin = carrierPlugin?.PluginTypeName == WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME;
            }

            return isWorkWavePlugin;
        }
    }
}