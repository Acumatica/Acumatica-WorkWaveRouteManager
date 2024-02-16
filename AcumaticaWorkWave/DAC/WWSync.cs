using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using System;

namespace AcumaticaWorkWave.DAC
{
    [Serializable]
    [PXCacheName("WWSync")]
    public class WWSync : IBqlTable
    {
        public class PK : PrimaryKeyOf<WWSync>.By<wwRequestID>
        {
            public static WWSync Find(PXGraph graph, Guid? wwRequestID) => FindBy(graph, wwRequestID);
        }

        #region WWRequestID

        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Request ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWRequestID { get; set; }

        public abstract class wwRequestID : PX.Data.BQL.BqlGuid.Field<wwRequestID> { }

        #endregion WWRequestID

        #region WWTerritoryID

        [PXDBGuid()]
        [PXUIField(DisplayName = "Territory ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWTerritoryID { get; set; }

        public abstract class wwTerritoryID : PX.Data.BQL.BqlGuid.Field<wwTerritoryID> { }

        #endregion WWTerritoryID

        #region WWEvent

        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Event", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWEvent { get; set; }

        public abstract class wwEvent : PX.Data.BQL.BqlString.Field<wwEvent> { }

        #endregion WWEvent

        #region WWdata

        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Content", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWData { get; set; }

        public abstract class wwData : PX.Data.BQL.BqlString.Field<wwData> { }

        #endregion WWdata

        #region WWSyncProcessed

        [PXDBBool()]
        [PXUIField(DisplayName = "Sync Processed", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false)]
        public virtual bool? WWSyncProcessed { get; set; }

        public abstract class wwSyncProcessed : PX.Data.BQL.BqlBool.Field<wwSyncProcessed> { }

        #endregion WWSyncProcessed

        #region WWAsyncProcessed

        [PXDBBool()]
        [PXUIField(DisplayName = "Async Processed", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false)]
        public virtual bool? WWAsyncProcessed { get; set; }

        public abstract class wwAsyncProcessed : PX.Data.BQL.BqlBool.Field<wwAsyncProcessed> { }

        #endregion WWAsyncProcessed

        #region WWEntityProcessed

        [PXDBBool()]
        [PXUIField(DisplayName = "Entity Processed", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXDefault(false)]
        public virtual bool? WWEntityProcessed { get; set; }

        public abstract class wwEntityProcessed : PX.Data.BQL.BqlBool.Field<wwEntityProcessed> { }

        #endregion WWEntityProcessed

        #region WWEntityID

        [PXDBGuid()]
        [PXUIField(DisplayName = "Entity ID", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual Guid? WWEntityID { get; set; }

        public abstract class wwEntityID : PX.Data.BQL.BqlGuid.Field<wwEntityID> { }

        #endregion WWEntityID

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