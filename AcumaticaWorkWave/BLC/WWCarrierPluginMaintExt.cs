using AcumaticaWorkWave.API.Domain.Territories;
using AcumaticaWorkWave.API.Provider;
using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.DAC;
using AcumaticaWorkWave.Helpers;
using AcumaticaWorkWave.Plugin;
using AcumaticaWorkWave.Resources;
using PX.CarrierService;
using PX.Commerce.Core;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcumaticaWorkWave.BLC
{
    public class WWCarrierPluginMaintFeatureExt : PXGraphExtension<CarrierPluginMaint>
    {
        #region IsActive

        public static bool IsActive() => !PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Events

        [PXMergeAttributes(Method = MergeMethod.Replace)]
        [WWPXProviderTypeSelector(typeof(ICarrierService))]
        [PXDBString(255)]
        [PXDefault]
        [PXUIField(DisplayName = WWPluginDefaulValues.PLUGIN_TYPE_NAME)]
        protected virtual void _(Events.CacheAttached<CarrierPlugin.pluginTypeName> e) { }

        protected virtual void _(Events.RowPersisting<CarrierPlugin> e)
        {
            if (!(e.Row is CarrierPlugin)) return;
            if (e.Row.PluginTypeName.Equals(WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME))
            {
                var message = string.Format(WWMessages.WWFeatureNotActiveException, WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME, WWMessages.WWFeatureName);
                throw new PXRowPersistingException(WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME, e.Row.PluginTypeName, message);
            }            
        }

        #endregion Events
    }

    public class WWCarrierPluginMaintExt : PXGraphExtension<CarrierPluginMaint>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();
            if (!PXAccess.FeatureInstalled<FeaturesSet.branch>())
            {
                PXUIFieldAttribute.SetVisible<WWCarrierTerritory.wwBranchID>(CarrierTerritories.Cache, null, false);
            }
        }

        #endregion Overrides

        #region Views

        public SelectFrom<WWCarrierTerritory>
                   .Where<WWCarrierTerritory.wwCarrierPluginID.IsEqual<CarrierPlugin.carrierPluginID.AsOptional>>.View CarrierTerritories;

        public SelectFrom<WWCustomFieldMapping>
                   .Where<WWCustomFieldMapping.wwCarrierPluginID.IsEqual<CarrierPlugin.carrierPluginID.AsOptional>>.View CustomFieldMappings;

        public SelectFrom<WWTerritory>.View Territories;

        public SelectFrom<WWTerritory>
                   .Where<WWTerritory.wwCarrierPluginID.IsEqual<@P.AsString>
                     .And<WWTerritory.wwTerritoryID.IsEqual<@P.AsGuid>>
                     .And<WWTerritory.wwApiKey.IsEqual<@P.AsGuid>>>.View TerritoriesByParams;

        public SelectFrom<WWTerritory>
                   .Where<WWTerritory.wwCarrierPluginID.IsEqual<@P.AsString>
                     .And<WWTerritory.wwApiKey.IsEqual<@P.AsGuid>>>.View TerritoriesByCarrierAndApiKey;

        public SelectFrom<CarrierPluginDetail>
                   .Where<CarrierPluginDetail.carrierPluginID.IsEqual<@P.AsString>>.View CarrierPluginDetailByCarrierId;

        public SelectFrom<CarrierPlugin>
               .InnerJoin<Carrier>.On<CarrierPlugin.carrierPluginID.IsEqual<Carrier.carrierPluginID>>
                   .Where<Carrier.carrierID.IsEqual<@P.AsString>>.View CarrierPluginByShipVia;

        public SelectFrom<CarrierPlugin>
                .Where<CarrierPlugin.pluginTypeName.IsEqual<WWPluginDefaulValues.pluginAssemblyName>>.View WWCarrierPlugins;

        public SelectFrom<CarrierPluginDetail>
                .Where<CarrierPluginDetail.carrierPluginID.IsEqual<@P.AsString>
                    .And<CarrierPluginDetail.detailID.IsEqual<@P.AsString>>>.View WWCarrierPluginDetailByCarrierIDAndDetailID;

        public SelectFrom<WWCustomFieldMapping>
               .InnerJoin<CarrierPlugin>.On<CarrierPlugin.carrierPluginID.IsEqual<WWCustomFieldMapping.wwCarrierPluginID>>
               .InnerJoin<Carrier>.On<CarrierPlugin.carrierPluginID.IsEqual<Carrier.carrierPluginID>>
                   .Where<Carrier.carrierID.IsEqual<@P.AsString>
                     .And<WWCustomFieldMapping.wwActive.IsEqual<True>>>.View CustomFieldMappingByShipVia;

        public SelectFrom<INSite>.Where<INSite.siteID.IsEqual<@P.AsInt>>.View INSites;

        private bool _isActionCall = false;

        #endregion Views

        #region Actions

        public PXAction<CarrierPlugin> uploadTerritories;

        [PXProcessButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Upload Territories", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected IEnumerable UploadTerritories(PXAdapter adapter)
        {
            if (Base.Plugin.Current != null)
            {
                _isActionCall = true;
                Base.Save.Press();
                //PXLongOperation.StartOperation(Base, delegate ()
                //{
                    

                    if (adapter.View.Cache.Current is CarrierPlugin row)
                    {
                        WorkWaveCarrier service = CarrierPluginMaint.CreateCarrierService(Base, row).Result as WorkWaveCarrier;
                        Base.LongOperationManager.StartOperation( ct =>
                        {   
                            if (service != null)
                            {
                                var graph = PXGraph.CreateInstance<CarrierPluginMaint>()
                                    .GetExtension<WWCarrierPluginMaintExt>();
                                var options = service.GetApiOptions();
                                var provider = WWProviderLocator.Instance.Reset<WWTerritoriesProvider>()
                                    .Get<WWTerritoriesProvider>(options);
                                var territoryHash = provider.List<TerritoryHash>();
                                graph.UpdateTerritories(row, territoryHash, options.ApiKey);
                            }
                        });
                    }
                //});
            }

            return adapter.Get();
        }

        public PXAction<CarrierPlugin> test;

        [PXProcessButton]
        [PXUIField(DisplayName = "Test connection", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        public virtual void Test()
        {
            _isActionCall = true;
            Base.test.Press();
        }

        #endregion Actions

        #region Event Handlers

        #region CarrierPlugin

        [PXMergeAttributes(Method = MergeMethod.Replace)]
        [WWPXProviderOtherTypeSelector(typeof(ICarrierService))]
        [PXDBString(255)]
        [PXDefault]
        [PXUIField(DisplayName = WWPluginDefaulValues.PLUGIN_TYPE_NAME)]
        protected virtual void _(Events.CacheAttached<CarrierPlugin.pluginTypeName> e) { }

        protected virtual void _(Events.RowSelecting<CarrierPlugin> e)
        {
            if (!(e.Row is CarrierPlugin row)) return;

            using (new PXConnectionScope())
            {
                var territory = SelectFrom<WWTerritory>
                                    .Where<WWTerritory.wwCarrierPluginID.IsEqual<@P.AsString>>
                                    .View.Select(Base, row.CarrierPluginID).ToList(); ;

                row.GetExtension<WWCarrierPluginExt>().UsrWWTerritoryLoaded = territory.Any();
            }
        }

        protected virtual void _(Events.FieldUpdated<CarrierPlugin, CarrierPlugin.pluginTypeName> e)
        {
            if (e.NewValue is string newValue && newValue == WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME)
            {
                Base.CustomerAccounts.View.AllowSelect = false;
            }
        }

        protected virtual void _(Events.RowSelected<CarrierPlugin> e, PXRowSelected baseHandler)
        {
            baseHandler?.Invoke(e.Cache, e.Args);

            if (!(e.Row is CarrierPlugin row)) return;

            CarrierResult<ICarrierService> service = CarrierPluginMaint.CreateCarrierService(Base, row);
            if (service != null)
            {
                var territoryLoaded = row.GetExtension<WWCarrierPluginExt>().UsrWWTerritoryLoaded.GetValueOrDefault();
                var enabled = service.Result?.Attributes.Contains(WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME) == true;
                uploadTerritories.SetVisible(enabled);
                uploadTerritories.SetEnabled(!territoryLoaded);

                CarrierTerritories.View.AllowSelect = enabled;
                CarrierTerritories.View.AllowInsert = territoryLoaded;

                CustomFieldMappings.View.AllowSelect = enabled;
                CustomFieldMappings.View.AllowInsert = enabled;
                CustomFieldMappings.View.AllowUpdate = enabled;
                CustomFieldMappings.View.AllowDelete = enabled;
            }
            else
            {
                CarrierTerritories.View.AllowSelect = false;
                CustomFieldMappings.View.AllowSelect = false;
                uploadTerritories.SetVisible(false);
            }

            Base.CustomerAccounts.View.AllowSelect = row.PluginTypeName != WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME;
        }

        protected virtual void _(Events.RowPersisting<CarrierPlugin> e)
        {
            if (!(e.Row is CarrierPlugin row)) return;

            if (!_isActionCall && e.Operation == PXDBOperation.Update)
            {
                var mappedTerritories = CarrierTerritories.Select().RowCast<WWCarrierTerritory>().Any();
                var mappedTerritoriesActive = CarrierTerritories.Select().RowCast<WWCarrierTerritory>().Any(t => t.WWActive == true);
                if (mappedTerritories && !mappedTerritoriesActive)
                {
                    throw new PXRowPersistingException(nameof(WWCarrierTerritory), null, WWMessages.WWWorkWaveTerritoriesNotAnyActiveRow);
                }
            }
        }       
        #endregion CarrierPlugin

        #region WWCarrierTerritory

        protected virtual void _(Events.FieldUpdated<WWCarrierTerritory, WWCarrierTerritory.wwCompanyID> e)
        {
            if (!(e.Row is WWCarrierTerritory row)) return;
            e.Cache.SetValueExt<WWCarrierTerritory.wwBranchID>(row, null);
        }

        protected virtual void _(Events.FieldUpdated<WWCarrierTerritory, WWCarrierTerritory.wwBranchID> e)
        {
            if (!(e.Row is WWCarrierTerritory row)) return;
            e.Cache.SetValueExt<WWCarrierTerritory.wwWarehouseID>(row, null);
        }

        protected virtual void _(Events.RowInserting<WWCarrierTerritory> e)
        {
            if (!(e.Row is WWCarrierTerritory row)) return;

            if (ValidateRowIdentical(row, out string exceptionMessage))
            {
                e.Cancel = true;
                e.Cache.RaiseExceptionHandling<WWCarrierTerritory.wwTerritoryID>(row, null, new PXSetPropertyException(exceptionMessage));
            }
        }

        protected virtual void _(Events.RowUpdated<WWCarrierTerritory> e)
        {
            if (!(e.Row is WWCarrierTerritory row)) return;
            if (ValidateRowIdentical(row, out string exceptionMessage))
            {
                e.Cache.RaiseExceptionHandling<WWCarrierTerritory.wwTerritoryID>(row, null, new PXSetPropertyException(exceptionMessage));
            }
        }

        protected virtual void _(Events.RowPersisting<WWCarrierTerritory> e)
        {
            if (!(e.Row is WWCarrierTerritory row)) return;
            if (e.Row.WWCompanyID == null)
            {
                throw new PXRowPersistingException(typeof(WWCarrierTerritory).Name, null, WWMessages.WWCompanyFieldCannotBeEmpty);
            }

            if ((e.Operation & PXDBOperation.Command) != PXDBOperation.Delete && e.Row != null)
            {
                if (ValidateRowIdentical(row, out string exceptionMessage))
                {
                    e.Cancel = true;
                    throw new PXRowPersistingException(
                        typeof(WWCarrierTerritory.wwTerritoryID).Name,
                        null,
                        exceptionMessage,
                        typeof(WWCarrierTerritory.wwTerritoryID).Name);
                }
            }
        }

        #endregion WWCarrierTerritory

        #region CarrierPluginDetail

        protected virtual void _(Events.RowSelected<CarrierPluginDetail> e)
        {
            if (!(e.Row is CarrierPluginDetail row)) return;

            if (row.DetailID == WWPluginProperties.WWRM_ELIGIBILITY_TYPE
             || row.DetailID == WWPluginProperties.WWRM_ROUTE_TYPE)
            {
                PXUIFieldAttribute.SetReadOnly<CarrierPluginDetail.value>(e.Cache, row, true);
            }

            if (row.DetailID == WWPluginProperties.API_KEY
             || row.DetailID == WWPluginProperties.URL
             || row.DetailID == WWPluginProperties.CALLBACK_URL)
            {
                PXDefaultAttribute.SetPersistingCheck<CarrierPluginDetail.value>(e.Cache, row, PXPersistingCheck.NullOrBlank);
            }
        }

        protected virtual void _(Events.RowUpdating<CarrierPluginDetail> e)
        {
            if (!(e.Row is CarrierPluginDetail row)) return;
            var carrierPluginRow = Base.Plugin.Current;

            if (row.DetailID == WWPluginProperties.API_KEY)
            {
                if (e.NewRow.Value == e.Row.Value || e.Row.Value == null) return;

                //Check new value
                var apiKey = row.Value.ToGuid();
                var newApiKey = e.NewRow.Value.ToGuid();
                if (apiKey == null || newApiKey == null)
                {
                    throw new PXException(WWMessages.WWAPIKeyShouldBeGuid);
                }

                if (Base.Plugin.Ask(WWMessages.WWAPIKeyChangedHeader,
                                    WWMessages.WWAPIKeyChanged,
                                    MessageButtons.OKCancel, MessageIcon.Warning) == WebDialogResult.OK)
                {
                    //Delete Workwave orders
                    foreach (var wt in CarrierTerritories.Select())
                    {
                        CarrierTerritories.Delete(wt);
                    }

                    //Delete workwave terrirories
                    foreach (var t in TerritoriesByCarrierAndApiKey.Select(carrierPluginRow.CarrierPluginID, apiKey))
                    {
                        TerritoriesByCarrierAndApiKey.Delete(t);
                    }

                    //Clearing service locator
                    WWProviderLocator.Instance.Clear();

                    //Reset LoadTerritory field
                    carrierPluginRow.GetExtension<WWCarrierPluginExt>().UsrWWTerritoryLoaded = false;
                }
            }
        }

        protected virtual void _(Events.RowPersisting<CarrierPluginDetail> e)
        {
            if (!(e.Row is CarrierPluginDetail row)) return;

            if ((row.DetailID == WWPluginProperties.API_KEY ||
                row.DetailID == WWPluginProperties.URL ||
                row.DetailID == WWPluginProperties.SIGNATURE_PASSWORD) && string.IsNullOrWhiteSpace(row.Value))
            {
                e.Cache.RaiseExceptionHandling<CarrierPluginDetail.value>(row,
                                                                          row.Value,
                                                                          new PXSetPropertyException(ErrorMessages.FieldIsEmpty,
                                                                                                     PXErrorLevel.RowError,
                                                                                                     row.DetailID));
            }

            if (row.DetailID == WWPluginProperties.API_KEY)
            {
                try
                {
                    var guid = new Guid(row.Value);
                }
                catch (Exception)
                {
                    e.Cache.RaiseExceptionHandling<CarrierPluginDetail.value>(row,
                                                                              row.Value,
                                                                              new PXSetPropertyException(WWMessages.WWAPIKeyShouldBeGuid,
                                                                                                                         PXErrorLevel.RowError,
                                                                                                                         WWPluginProperties.API_KEY));
                }
            }
        }

        #endregion CarrierPluginDetail

        #endregion Event Handlers

        #region Public methods

        public WWCarrierTerritory GetTerritoryID(CarrierPlugin plugin, int? siteID)
        {
            var territories = CarrierTerritories.Select(plugin.CarrierPluginID)
                                                .RowCast<WWCarrierTerritory>()
                                                .Where(i => i.WWActive == true)
                                                .ToList();

            var warehouse = INSites.SelectSingle(siteID);
            var branch = PX.Objects.GL.Branch.PK.Find(Base, warehouse.BranchID);

            WWCarrierTerritory territory = null;

            territory = territories.FirstOrDefault(t => t.WWWarehouseID == warehouse.SiteID)
                     ?? territories.FirstOrDefault(t => t.WWWarehouseID == null && t.WWBranchID == warehouse.BranchID)
                     ?? territories.FirstOrDefault(t => t.WWWarehouseID == null && t.WWBranchID == null && t.WWCompanyID == branch.OrganizationID);

            if (territory == null)
            {
                var sb = new StringBuilder();
                sb.Append($"Territory not found for ");
                if (branch != null)
                {
                    sb.Append($"Branch {branch?.BranchCD.Trim()}");
                }

                if (warehouse != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.Append($"Warehouse {warehouse?.SiteCD.Trim()}");
                }
                sb.AppendLine(".");
                sb.Append("Check Carrier WorkWave Territories settings");

                throw new PXException(sb.ToString());
            }

            return territory;
        }

        #endregion Public methods

        #region Private methods

        public List<KeyValuePair<string, string>> GetWWSignaturePasswordAndCallbackUrl()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            PXResultset<CarrierPlugin> carrierPlugins = WWCarrierPlugins.Select(this);

            foreach (CarrierPlugin plugin in carrierPlugins)
            {
                string callbackURL = WWCarrierPluginDetailByCarrierIDAndDetailID.SelectSingle(plugin.CarrierPluginID, WWPluginProperties.CALLBACK_URL)?.Value;
                string signPasswd = WWCarrierPluginDetailByCarrierIDAndDetailID.SelectSingle(plugin.CarrierPluginID, WWPluginProperties.SIGNATURE_PASSWORD)?.Value;
                result.Add(new KeyValuePair<string, string>(callbackURL, signPasswd));
            }

            return result;
        }

        private void UpdateTerritories(CarrierPlugin row, TerritoryHash territoryHash, Guid apiKey)
        {
            using (var tr = new PXTransactionScope())
            {
                foreach (var item in territoryHash.Territories)
                {
                    var territory = TerritoriesByParams.SelectSingle(row.CarrierPluginID, item.Key, apiKey);
                    if (territory != null)
                    {
                        PopulateRow(item, territory);
                        Territories.Update(territory);
                    }
                    else
                    {
                        territory = Territories.Insert();
                        territory.WWCarrierPluginID = row.CarrierPluginID;
                        territory.WWTerritoryID = item.Key;
                        territory.WWApiKey = apiKey;

                        PopulateRow(item, territory);
                    }
                }

                tr.Complete();
            }

            Base.Actions.PressSave();

            void PopulateRow(KeyValuePair<Guid, Territory> item, WWTerritory territory)
            {
                territory.WWTerritoryName = item.Value.Name;
                territory.WWCenterOne = item.Value.Center[0];
                territory.WWCenterTwo = item.Value.Center[1];
                territory.WWLanguageCode = item.Value.LanguageCode;
                territory.WWTimeZoneCode = item.Value.TimeZoneCode;
            }
        }

        private bool ValidateRowIdentical(WWCarrierTerritory row, out string exceptionMessage)
        {
            var data = CarrierTerritories.Select().FirstTableItems.Where(t => t.WWCarrierLineNbr != row.WWCarrierLineNbr);
            var rowIdentical = data.FirstOrDefault(r => r.RowsAreIdentical(row));
            exceptionMessage = null;

            if (rowIdentical != null)
            {
                if (row.WWTerritoryID != rowIdentical.WWTerritoryID)
                {
                    exceptionMessage = WWMessages.WWDuplicateCompanyBranchWarehousetDifferentTerritory;
                }
                else
                {
                    exceptionMessage = WWMessages.WWDuplicateWorkWaveTerritory;
                }

                return true;
            }

            return false;
        }

        #endregion Private methods
    }
}