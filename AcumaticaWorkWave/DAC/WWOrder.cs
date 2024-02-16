using System;
using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.SO;

namespace AcumaticaWorkWave.DAC
{
    [Serializable]
    [PXCacheName("WWOrder")]
    public class WWOrder : IBqlTable
    {
        public class PK : PrimaryKeyOf<WWOrder>.By<wwLineNbr, wwEntityID>
        {
            public static WWOrder Find(PXGraph graph, int? wwLineNbr,  Guid? wwEntityID) => FindBy(graph, wwLineNbr, wwEntityID);
        }
        
        public static class UK
        {
            public class ByRequestID : PrimaryKeyOf<WWOrder>.By<wwRequestID>
            {
                public static WWOrder Find(PXGraph graph, Guid? requestID) => FindBy(graph, requestID);
            }

            public class ByRequestIDAndDeliveryStatus : PrimaryKeyOf<WWOrder>.By<wwRequestID, wwDeliveryStatus>
            {
                public static WWOrder Find(PXGraph graph, Guid? requestID, string deliveryStatus) => FindBy(graph, requestID, deliveryStatus);
            }

            public class ByOrderID : PrimaryKeyOf<WWOrder>.By<wwOrderID>
            {
                public static WWOrder Find(PXGraph graph, Guid? orderID) => FindBy(graph, orderID);
            }
        }

        #region Selected
        [PXBool()]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        public abstract class selected : BqlBool.Field<selected> { }
        #endregion

        #region WWLineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(SOShipment))]
        public virtual int? WWLineNbr { get; set; }
        public abstract class wwLineNbr : BqlInt.Field<wwLineNbr> { }
        #endregion

        #region WWEntityID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Entity ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDBDefault(typeof(SOShipment.noteID), PersistingCheck = PXPersistingCheck.Nothing)]
        [PXParent(typeof(SelectFrom<SOShipment>.
                              Where<SOShipment.noteID.IsEqual<wwEntityID.FromCurrent>>))]
        public virtual Guid? WWEntityID { get; set; }
        public abstract class wwEntityID : BqlGuid.Field<wwEntityID> { }
        #endregion

        #region WWRequestID
        [PXDBGuid]
        [PXUIField(DisplayName = "Request ID", Visible = false, Visibility = PXUIVisibility.Visible, FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWRequestID { get; set; }
        public abstract class wwRequestID : BqlGuid.Field<wwRequestID> { }
        #endregion

        #region WWOrderID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Order ID", Visible = false, Visibility = PXUIVisibility.Visible, FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWOrderID { get; set; }
        public abstract class wwOrderID : BqlGuid.Field<wwOrderID> { }
        #endregion

        #region WWOrderName
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Order Name", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWOrderName { get; set; }
        public abstract class wwOrderName : BqlString.Field<wwOrderName> { }
        #endregion

        #region WWOperation
        [PXDBString(7, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Operation", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWOperation { get; set; }
        public abstract class wwOperation : BqlString.Field<wwOperation> { }
        #endregion

        #region WWErrorCode
        [PXDBInt()]
        [PXUIField(DisplayName = "Error Code", Visible = true, Visibility = PXUIVisibility.Visible, FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual int? WWErrorCode { get; set; }
        public abstract class wwErrorCode : BqlInt.Field<wwErrorCode> { }
        #endregion

        #region WWErrorMessage
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Error Message", Visible = true, Visibility = PXUIVisibility.Visible)]
        public virtual string WWErrorMessage { get; set; }
        public abstract class wwErrorMessage : BqlString.Field<wwErrorMessage> { }
        #endregion

        #region WWDeliveryStatus
        [PXDBString(1, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Delivery Status", FieldClass = WWMessages.WWFeatureFieldClass)]
        [WWOrderStatus.List]
        public virtual string WWDeliveryStatus { get; set; }
        public abstract class wwDeliveryStatus : BqlString.Field<wwDeliveryStatus> { }
        #endregion

        #region WWTrackingURL
        [PXDBString(200, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Tracking URL", Enabled = false)]
        public virtual string WWTrackingURL { get; set; }
        public abstract class wwTrackingURL : BqlString.Field<wwTrackingURL> { }
        #endregion WWTrackingURL

        #region WWDeliveryDateTime
        [PXDBDateAndTime()]
        [PXUIField(DisplayName = "Delivery DateTime", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual DateTime? WWDeliveryDateTime { get; set; }
        public abstract class wwDeliveryDateTime : BqlDateTime.Field<wwDeliveryDateTime> { }
        #endregion

        #region WWGPS
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "GPS", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWGPS { get; set; }
        public abstract class wwGPS : BqlString.Field<wwGPS> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : BqlGuid.Field<noteid> { }
        #endregion

        #region WWNoteValue
        [PXString(IsUnicode = true, InputMask = "")]
        public virtual string WWNoteValue { get; set; }
        public abstract class wwNoteValue : BqlString.Field<wwNoteValue> { }
        #endregion

        #region WWPictureValue
        [PXString(IsUnicode = true, InputMask = "")]
        public virtual string WWPictureValue { get; set; }
        public abstract class wwPictureValue : BqlString.Field<wwPictureValue> { }
        #endregion

        #region WWPictureNoteValue
        [PXString(IsUnicode = true, InputMask = "")]
        public virtual string WWPictureNoteValue { get; set; }
        public abstract class wwPictureNoteValue : BqlString.Field<wwPictureNoteValue> { }
        #endregion

        #region WWSignatureValue
        [PXString(IsUnicode = true, InputMask = "")]
        public virtual string WWSignatureValue { get; set; }
        public abstract class wwSignatureValue : BqlString.Field<wwSignatureValue> { }
        #endregion

        #region WWSignatureNoteValue
        [PXString(IsUnicode = true, InputMask = "")]
        public virtual string WWSignatureNoteValue { get; set; }
        public abstract class wwSignatureNoteValue : BqlString.Field<wwSignatureNoteValue> { }
        #endregion

    }
}