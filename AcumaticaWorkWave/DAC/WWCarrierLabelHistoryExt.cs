using PX.Data;
using PX.Objects.CS;
using PX.Objects.SO;

namespace AcumaticaWorkWave.DAC
{
    public sealed class WWCarrierLabelHistoryExt : PXCacheExtension<CarrierLabelHistory>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region UsrCarrier

        [PXDBString(1024, IsUnicode = true)]
        public string UsrCarrier { get; set; }
        public abstract class usrCarrier : PX.Data.BQL.BqlString.Field<usrCarrier> { }

        #endregion UsrCarrier
    }
}