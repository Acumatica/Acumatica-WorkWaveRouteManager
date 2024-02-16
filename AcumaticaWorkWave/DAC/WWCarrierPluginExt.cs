using PX.Data;
using PX.Objects.CS;

namespace AcumaticaWorkWave.DAC
{
    public sealed class WWCarrierPluginExt : PXCacheExtension<CarrierPlugin>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region UsrWWTerritoryLoaded

        [PXBool]
        public bool? UsrWWTerritoryLoaded { get; set; }

        public abstract class usrWWTerritoryLoaded : PX.Data.BQL.BqlBool.Field<usrWWTerritoryLoaded> { }

        #endregion UsrWWTerritoryLoaded
    }
}