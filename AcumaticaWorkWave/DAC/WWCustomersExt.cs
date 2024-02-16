using PX.Data;
using PX.Data.BQL;
using PX.Objects.AR;
using PX.Objects.CS;
using System;

namespace AcumaticaWorkWave.DAC
{
    public sealed class WWCustomerExt : PXCacheExtension<Customer>
    {
        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #region usrWWStartSec
        [PXDBTime(DisplayMask = "t", InputMask = "t", UseTimeZone = false)]
        [PXUIField(DisplayName = "Time Window Start")]
        public DateTime? UsrWWStartSec { get; set; }
        public abstract class usrWWStartSec : BqlDateTime.Field<usrWWStartSec> { }
        #endregion

        #region usrWWEndSec
        [PXDBTime(DisplayMask = "t", InputMask = "t", UseTimeZone = false)]
        [PXUIField(DisplayName = "Time Window End")]
        public DateTime? UsrWWEndSec { get; set; }
        public abstract class usrWWEndSec : BqlDateTime.Field<usrWWEndSec> { }
        #endregion
    }
}
