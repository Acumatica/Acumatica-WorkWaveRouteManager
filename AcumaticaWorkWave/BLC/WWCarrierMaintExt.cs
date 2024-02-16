using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Objects.CS;

namespace AcumaticaWorkWave.BLC
{
    public class WWCarrierMaintExt : PXGraphExtension<CarrierMaint>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Events

        protected virtual void _(Events.RowSelected<Carrier> e)
        {
            if (!(e.Row is Carrier row)) return;

            var controlsVisible = ApplyFreightRates(row);

            Base.FreightRates.Cache.AllowSelect = controlsVisible;

            PXUIFieldAttribute.SetVisible<Carrier.calcMethod>(e.Cache, row, controlsVisible);
            PXUIFieldAttribute.SetVisible<Carrier.baseRate>(e.Cache, row, controlsVisible);
        }

        protected virtual void _(Events.FieldDefaulting<Carrier.calcMethod> e)
        {
            if (!(e.Row is Carrier row)) return;

            var controlsVisible = ApplyFreightRates(row);

            if (!controlsVisible) return;

            e.NewValue = row.CalcMethod;
        }

        #endregion Events

        #region Private Methods

        private bool ApplyFreightRates(Carrier row)
        {
            var externalPlugin = row.IsExternal.GetValueOrDefault();

            if (!externalPlugin) return true;

            var carrierPlugin = CarrierPlugin.PK.Find(Base, row.CarrierPluginID);
            var isWWCarrier = carrierPlugin?.PluginTypeName == WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME;

            return isWWCarrier;
        }

        #endregion Private Methods
    }
}