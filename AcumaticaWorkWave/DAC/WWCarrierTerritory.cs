using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.GL;
using PX.Objects.GL.DAC;
using PX.Objects.IN;
using System;

namespace AcumaticaWorkWave
{
    [Serializable]
    [PXCacheName("Carrier Territory")]
    public class WWCarrierTerritory : IBqlTable
    {
        #region WWCarrierPluginID

        [PXParent(typeof(Select<CarrierPlugin,
                          Where<CarrierPlugin.carrierPluginID, Equal<Current<wwCarrierPluginID>>>>))]
        [PXDefault(typeof(CarrierPlugin.carrierPluginID))]
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Carrier Plugin", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual string WWCarrierPluginID { get; set; }

        public abstract class wwCarrierPluginID : BqlString.Field<wwCarrierPluginID> { }

        #endregion WWCarrierPluginID

        #region WWCarrierLineNbr

        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(CarrierPlugin))]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? WWCarrierLineNbr { get; set; }

        public abstract class wwCarrierLineNbr : BqlInt.Field<wwCarrierLineNbr> { }

        #endregion WWCarrierLineNbr

        #region WWCompanyID

        [PXDBInt()]
        [PXUIField(DisplayName = "Company", Required = true, FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXSelector(typeof(SearchFor<Organization.organizationID>
                                 .In<SelectFrom<Organization>
                                         .Where<Match<Organization, AccessInfo.userName.FromCurrent>>>),
                    typeof(Organization.organizationCD),
                    typeof(Organization.organizationName),
                    SubstituteKey = typeof(Organization.organizationCD))]
        public virtual int? WWCompanyID { get; set; }

        public abstract class wwCompanyID : BqlInt.Field<wwCompanyID> { }

        #endregion WWCompanyID

        #region WWBranchID

        [Branch(typeof(Search<Branch.branchID,
                        Where<Branch.organizationID, Equal<Current<WWCarrierTerritory.wwCompanyID>>>>),
                typeof(Search<Branch.branchID,
                        Where<Branch.organizationID, Equal<Current<WWCarrierTerritory.wwCompanyID>>>>), 
                addDefaultAttribute: false, 
                useDefaulting: false)]
        [PXUIField(DisplayName = "Branch", FieldClass = WWMessages.WWFeatureFieldClass)]
        public virtual int? WWBranchID { get; set; }

        public abstract class wwBranchID : BqlInt.Field<wwBranchID> { }

        #endregion WWBranchID

        #region WWWarehouseID

        [PXDBInt()]
        [PXUIField(DisplayName = "Warehouse", FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXSelector(typeof(SearchFor<INSite.siteID>
                                 .In<SelectFrom<INSite>
                                     .InnerJoin<Branch>
                                            .On<INSite.branchID.IsEqual<Branch.branchID>>
                                         .Where<wwBranchID.FromCurrent.IsNull
                                            .Or<Brackets<wwBranchID.FromCurrent.IsNotNull
                                                    .And<Branch.branchID.IsEqual<wwBranchID.FromCurrent>>>>>>),
                    typeof(INSite.siteCD),
                    typeof(INSite.descr),
                    SubstituteKey = typeof(INSite.siteCD))]
        [PXRestrictor(typeof(Where<INSite.siteID, NotEqual<SiteAttribute.transitSiteID>>), PX.Objects.IN.Messages.TransitSiteIsNotAvailable)]
        public virtual int? WWWarehouseID { get; set; }

        public abstract class wwWarehouseID : BqlInt.Field<wwWarehouseID> { }

        #endregion WWWarehouseID

        #region WWTerritoryID

        [PXDBGuid()]
        [PXUIField(DisplayName = "Territory", Required = true, FieldClass = WWMessages.WWFeatureFieldClass)]
        [PXSelector(typeof(SearchFor<WWTerritory.wwTerritoryID>
                                 .In<SelectFrom<WWTerritory>
                                         .Where<WWTerritory.wwCarrierPluginID.IsEqual<WWCarrierTerritory.wwCarrierPluginID.FromCurrent>>>),
                    typeof(WWTerritory.wwTerritoryID),
                    typeof(WWTerritory.wwTerritoryName),
                    SubstituteKey = typeof(WWTerritory.wwTerritoryName))]
        public virtual Guid? WWTerritoryID { get; set; }

        public abstract class wwTerritoryID : BqlGuid.Field<wwTerritoryID> { }

        #endregion WWTerritoryID

        #region WWActive

        [PXDBBool()]
        [PXUIField(DisplayName = "Active", FieldClass = WWMessages.WWFeatureFieldClass)]
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