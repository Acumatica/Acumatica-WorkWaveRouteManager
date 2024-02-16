using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.BQL;
using PX.Objects.CS;
using System;

namespace AcumaticaWorkWave
{
    [Serializable]
    [PXCacheName("Custom Field Mapping")]
    public class WWCustomFieldMapping : IBqlTable
    {
        #region WWCarrierLineNbr

        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(CarrierPlugin))]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? WWCarrierLineNbr { get; set; }

        public abstract class wwCarrierLineNbr : BqlInt.Field<wwCarrierLineNbr> { }

        #endregion WWCarrierLineNbr

        #region WWCarrierPluginID

        [PXParent(typeof(Select<CarrierPlugin,
                          Where<CarrierPlugin.carrierPluginID, Equal<Current<wwCarrierPluginID>>>>))]
        [PXDefault(typeof(CarrierPlugin.carrierPluginID))]
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Carrier Plugin ID")]
        public virtual string WWCarrierPluginID { get; set; }

        public abstract class wwCarrierPluginID : BqlString.Field<wwCarrierPluginID> { }

        #endregion WWCarrierPluginID

        #region WWScreenAreaID

        [PXDBInt]
        [PXUIField(DisplayName = "Screen Area Name", Required = true)]
        [WWScreenAreaSelector(typeof(WWCustomFieldMapping.wwFieldName))]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual int? WWScreenAreaID { get; set; }

        public abstract class wwScreenAreaID : BqlInt.Field<wwScreenAreaID> { }

        #endregion WWScreenAreaID

        #region WWScreenAreaName

        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Screen Area Name")]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual string WWScreenAreaName { get; set; }

        public abstract class wwScreenAreaName : BqlString.Field<wwScreenAreaName> { }

        #endregion WWScreenAreaName

        #region WWViewName

        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "View Name", Visible = false)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual string WWViewName { get; set; }

        public abstract class wwViewName : BqlString.Field<wwViewName> { }

        #endregion WWViewName

        #region WWDACName

        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "DAC Name", Visible = false)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual string WWDACName { get; set; }

        public abstract class wwDACName : BqlString.Field<wwDACName> { }

        #endregion WWDACName

        #region WWFieldName

        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field Name", Required = true)]
        [PXCheckUnique(typeof(wwScreenAreaName), 
                       typeof(wwViewName), 
                       typeof(wwDACName), 
                       typeof(wwFieldName),
                       typeof(wwCustomFieldName),
                       ErrorMessage = WWMessages.WWCantDuplicateCustomFieldMapping, 
                       ClearOnDuplicate = false)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual string WWFieldName { get; set; }

        public abstract class wwFieldName : BqlString.Field<wwFieldName> { }

        #endregion WWFieldName

        #region WWCustomColumnName

        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Custom Field Name", Required = true)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        public virtual string WWCustomFieldName { get; set; }

        public abstract class wwCustomFieldName : BqlString.Field<wwCustomFieldName> { }

        #endregion WWCustomColumnName

        #region WWActive

        [PXDBBool()]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? WWActive { get; set; }

        public abstract class wwActive : BqlBool.Field<wwActive> { }

        #endregion WWActive

        #region Tstamp

        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }

        public abstract class tstamp : BqlByteArray.Field<tstamp> { }

        #endregion Tstamp

        #region CreatedByID

        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }

        public abstract class createdByID : BqlGuid.Field<createdByID> { }

        #endregion CreatedByID

        #region CreatedByScreenID

        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }

        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }

        #endregion CreatedByScreenID

        #region CreatedDateTime

        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }

        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }

        #endregion CreatedDateTime

        #region LastModifiedByID

        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }

        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }

        #endregion LastModifiedByID

        #region LastModifiedByScreenID

        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }

        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }

        #endregion LastModifiedByScreenID

        #region LastModifiedDateTime

        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }

        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }

        #endregion LastModifiedDateTime

        #region Noteid

        [PXNote()]
        public virtual Guid? Noteid { get; set; }

        public abstract class noteid : BqlGuid.Field<noteid> { }

        #endregion Noteid
    }
}