using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.BQL;
using PX.Objects.AR;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.SO;
using System;

namespace AcumaticaWorkWave.DAC
{
    public sealed class WWSOShipmentExt : PXCacheExtension<SOShipment>
    {
        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #region UsrWWStatus

        [PXDBString(1)]
        [PXUIField(DisplayName = "WorkWave Order Status", FieldClass = WWMessages.WWFeatureFieldClass)]
        [WWOrderStatus.List]
        [PXDefault(PersistingCheck = PXPersistingCheck.Nothing)]
        public string UsrWWStatus { get; set; }

        public abstract class usrWWStatus : BqlString.Field<usrWWStatus> { }

        #endregion UsrWWStatus

        #region UsrIsWorkWave

        [PXDBBool]
        [PXUIField(DisplayName = "IsWorkWave", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public bool? UsrIsWorkWave { get; set; }

        public abstract class usrIsWorkWave : BqlBool.Field<usrIsWorkWave> { }

        #endregion UsrIsWorkWave

        #region UsrIsOrderTied

        [PXDBBool]
        [PXUIField(DisplayName = "UsrIsOrderTied", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public bool? UsrIsOrderTied { get; set; }

        public abstract class usrIsOrderTied : BqlBool.Field<usrIsOrderTied> { }

        #endregion UsrIsOrderTied

        #region UsrHasWWOrders

        [PXDBBool]
        [PXUIField(DisplayName = "UsrHasWWOrders", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public bool? UsrHasWWOrders { get; set; }

        public abstract class usrHasWWOrders : BqlBool.Field<usrHasWWOrders> { }

        #endregion UsrHasWWOrders

        #region UsrLastRequestID

        [PXDBGuid]
        [PXUIField(DisplayName = "WW Last RequestID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public Guid? UsrLastRequestID { get; set; }

        public abstract class usrLastRequestID : BqlGuid.Field<usrLastRequestID> { }

        #endregion UsrLastRequestID

        #region UsrIsShipmentModified

        [PXBool]
        [PXUnboundDefault(false)]
        public bool? UsrIsShipmentModified { get; set; }

        public abstract class usrIsShipmentModified : BqlBool.Field<usrIsShipmentModified> { }

        #endregion UsrIsShipmentModified

        #region UsrShipmentNbr

        [PXString(15, IsUnicode = true, InputMask = ">CCCCCCCCCCCCCCC")]
        [PXUIField(DisplayName = usrShipmentNbr.DisplayName, Visibility = PXUIVisibility.SelectorVisible)]
        [PXSelector(typeof(Search2<SOShipment.shipmentNbr,
            InnerJoin<INSite, On<SOShipment.FK.Site>,
            LeftJoinSingleTable<Customer, On<SOShipment.customerID, Equal<Customer.bAccountID>>>>,
            Where2<Match<INSite, Current<AccessInfo.userName>>,
            And<Where<Customer.bAccountID, IsNull, Or<Match<Customer, Current<AccessInfo.userName>>>>>>,
            OrderBy<Desc<SOShipment.shipmentNbr>>>))]
        public string UsrShipmentNbr { get; set; }

        public abstract class usrShipmentNbr : BqlString.Field<usrShipmentNbr>
        {
            public const string DisplayName = "Shipment Nbr.";
        }

        #endregion UsrShipmentNbr

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