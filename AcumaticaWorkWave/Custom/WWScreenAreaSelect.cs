using PX.Data;
using System;

namespace AcumaticaWorkWave.Custom
{
    [Serializable]
    [PXHidden]
    public class WWScreenAreaSelect : IBqlTable
    {
        #region ScreenAreaId

        [PXInt(IsKey = true)]
        public virtual int? ScreenAreaId { get; set; }

        public abstract class screenAreaId : IBqlField { }

        #endregion ScreenAreaId

        #region ScreenAreaName

        [PXString(64, IsUnicode = true)]
        [PXUnboundDefault]
        [PXUIField(DisplayName = "Screen Area")]
        public virtual string ScreenAreaName { get; set; }

        public abstract class screenAreaName : IBqlField { }

        #endregion ScreenAreaName

        #region ViewName

        [PXString(64, IsUnicode = true)]
        [PXUnboundDefault]
        [PXUIField(DisplayName = "View Name")]
        public virtual string ViewName { get; set; }

        public abstract class viewName : IBqlField { }

        #endregion ViewName

        #region DAC

        [PXString(64, IsUnicode = true)]
        [PXUnboundDefault]
        [PXUIField(DisplayName = "DAC")]
        public virtual string DAC { get; set; }

        public abstract class dac : IBqlField { }

        #endregion DAC
    }
}