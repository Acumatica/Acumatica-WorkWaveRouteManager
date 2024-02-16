using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Objects.CS;
using System;

namespace AcumaticaWorkWave
{
    [Serializable]
    [PXCacheName("Territory")]
    public class WWTerritory : IBqlTable
    {
        #region WWCarrierPluginID

        [PXParent(typeof(Select<CarrierPlugin,
                          Where<CarrierPlugin.carrierPluginID, Equal<Current<WWTerritory.wwCarrierPluginID>>>>))]
        [PXDefault(typeof(CarrierPlugin.carrierPluginID))]
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Carrier Plugin", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWCarrierPluginID { get; set; }

        public abstract class wwCarrierPluginID : PX.Data.BQL.BqlString.Field<wwCarrierPluginID> { }

        #endregion WWCarrierPluginID

        #region WWTerritoryID

        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Territory ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWTerritoryID { get; set; }

        public abstract class wwTerritoryID : PX.Data.BQL.BqlGuid.Field<wwTerritoryID> { }

        #endregion WWTerritoryID

        #region WWApiKey

        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "ApiKey ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWApiKey { get; set; }

        public abstract class wwApiKey : PX.Data.BQL.BqlGuid.Field<wwApiKey> { }

        #endregion WWTerritoryID

        #region WWTerritoryName

        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Territory Name", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWTerritoryName { get; set; }

        public abstract class wwTerritoryName : PX.Data.BQL.BqlString.Field<wwTerritoryName> { }

        #endregion WWTerritoryName

        #region WWCenterOne

        [PXDBInt()]
        [PXUIField(DisplayName = "Center One", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual int? WWCenterOne { get; set; }

        public abstract class wwCenterOne : PX.Data.BQL.BqlInt.Field<wwCenterOne> { }

        #endregion WWCenterOne

        #region WWCenterTwo

        [PXDBInt()]
        [PXUIField(DisplayName = "Center Two", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual int? WWCenterTwo { get; set; }

        public abstract class wwCenterTwo : PX.Data.BQL.BqlInt.Field<wwCenterTwo> { }

        #endregion WWCenterTwo

        #region WWTimeZoneCode

        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Time Zone Code", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWTimeZoneCode { get; set; }

        public abstract class wwTimeZoneCode : PX.Data.BQL.BqlString.Field<wwTimeZoneCode> { }

        #endregion WWTimeZoneCode

        #region WWLanguageCode

        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Language Code", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWLanguageCode { get; set; }

        public abstract class wwLanguageCode : PX.Data.BQL.BqlString.Field<wwLanguageCode> { }

        #endregion WWLanguageCode

        #region Tstamp

        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }

        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }

        #endregion Tstamp

        #region CreatedByID

        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }

        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }

        #endregion CreatedByID

        #region CreatedByScreenID

        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }

        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }

        #endregion CreatedByScreenID

        #region CreatedDateTime

        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }

        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }

        #endregion CreatedDateTime

        #region LastModifiedByID

        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }

        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }

        #endregion LastModifiedByID

        #region LastModifiedByScreenID

        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }

        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }

        #endregion LastModifiedByScreenID

        #region LastModifiedDateTime

        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }

        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }

        #endregion LastModifiedDateTime

        #region Noteid

        [PXNote()]
        public virtual Guid? Noteid { get; set; }

        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }

        #endregion Noteid
    }
}