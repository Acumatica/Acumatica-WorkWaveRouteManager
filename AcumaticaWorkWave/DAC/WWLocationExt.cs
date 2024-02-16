using PX.Data;
using PX.Data.BQL;
using System;
using PX.Objects.CR;
using PX.Objects.CS;

namespace AcumaticaWorkWave.DAC
{
    public sealed class WWLocationExt : PXCacheExtension<Location>
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
