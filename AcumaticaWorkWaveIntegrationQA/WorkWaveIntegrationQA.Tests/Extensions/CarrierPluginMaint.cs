using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Controls.CheckBox;
using Controls.Editors.DropDown;
using Controls.Editors.Selector;
using Controls.Input;
using Controls.LeftPanel;
using Core.Core.Browser;
using Core.Log;
using OpenQA.Selenium;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;
using WorkWaveIntegrationQA.Tests.Entity;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class CarrierPluginMaint : CS207700_CarrierPluginMaint
    {
        public c_plugin_form MainForm => base.Plugin_form;
        public c_details_pxgridsettings PlugInParametersGrid => base.Details_PXGridSettings;
        public c_carrierterritories_cstcarrierterritories WorkWaveTerritoriesGrid => base.CarrierTerritories_cstCarrierTerritories;
        private int _timeout = 10000;
        public CarrierPluginMaint()
        {
            ToolBar.Test.WaitAction = () => { };
        }

        private string _expectedMessageTestConnetion = "The connection to the carrier was successful.";

        private string _errorMessage =
            "Cannot duplicate WorkWave Territory record. Combination of Company/Branch/Warehouse/Territory should be unique";

        public bool SearchCarrierId(string carrierId = "WW")
        {
            Log.Information($"Search the carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Open();
            var actualCarrierList = MainForm.CarrierPluginID.Grid.Columns
                .DynamicControl<SelectorColumnFilter>("Carrier ID").GetValues().ToList();
            MainForm.CarrierPluginID.Close();
            var foundCarrier = actualCarrierList.FirstOrDefault(r => r.Equals(carrierId.ToUpper()));
            if (foundCarrier == null)
            {
                Log.Information($"Carrier is not found by id: {carrierId}");
                return false;
            }
            Log.Information("Carrier is found");
            return true;
        }

        public Carrier GenerateTestCarrier(string apiKey = "615b4b7b-c597-42bd-95d5-661f4e6408aa", string territory = "API DEMO")
        {
            Log.Information("Generate the test WorkWave carrier");
            var plugInParameters = new List<CarrierPlugInParameter<dynamic>>()
            {
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "API KEY",
                    Description = "API Key",
                    Value = apiKey
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "URL",
                    Description = "WorkWave URL",
                    Value = "wwrm.workwave.com"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "CALLBACK URL",
                    Description = "CallBack URL",
                    Value = "https://webhook.site/68dc8220-7b1d-4fbe-be56-7f163df8a65c"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "WWRM ELIGIBILITY TYPE",
                    Description = "WWRM Eligibility Type",
                    Value = "by"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "WWRM ROUTE TYPE",
                    Description = "WWRM Route Type",
                    Value = "Pick-up & Drop-off"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "BARCODE LIMIT",
                    Description = "BarCode Limit",
                    Value = "Split"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "BARCODE DELIMITER",
                    Description = "BarCode Delimiter",
                    Value = ";"
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "STORE POD SIGNATURE",
                    Description = "Store PoD Signature",
                    Value = true
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "STORE POD PICTURES",
                    Description = "Store PoD Pictures",
                    Value = true
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "STORE POD GPS",
                    Description = "Store PoD GPS",
                    Value = true
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "STORE POD DRIVER NOTES",
                    Description = "Store PoD Driver notes",
                    Value = true
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "DRIVER NOTE INTERNAL",
                    Description = "Driver Note Internal",
                    Value = true
                },
                new CarrierPlugInParameter<dynamic>()
                {
                    Id = "SIGNATURE PASSWORD",
                    Description = "Signature Password",
                    Value = "123456"
                },
            };
            var workWaveTerritories = new List<CarrierWorkWaveTerritory>()
            {
                new CarrierWorkWaveTerritory()
                {
                    Company = "PRODUCTS",
                    Branch = "PRODWHOLE",
                    Warehouse = "WHOLESALE",
                    Territory = territory,
                    Active = true
                },
            };
            var carrier = new Carrier()
            {
                CarrierId = "WW",
                Description = "WorkWave",
                PlugInType = "AcumaticaWorkWave.Plugin.WorkWaveCarrier",
                CarrierUnits = "SI Units (Kilogram/Centimeter)",
                Kilogram = "KG",
                Centimeter = "CM",
                Warehouse = "",
                PlugInParameters = plugInParameters,
                CarrierWorkWaveTerritories = workWaveTerritories
            };
            return carrier;
        }

        public void SetBarcodeLimit(string carrierId = "WW", string barcodeLimitOption = "Split")
        {
            Log.Information($"Set the Barcode Limit for carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(carrierId);
            var plugInParameterList = PlugInParametersGrid.AllPageData().ToList();
            if (!plugInParameterList.Any())
                throw new Exception("Plug-In parameters are not found");
            var barcodeLimit = plugInParameterList.FirstOrDefault(r => r.DetailID.Value.Equals("BARCODE LIMIT"));
            if (barcodeLimit == null)
                throw new Exception("Record is not found by id: BARCODE LIMIT");
            var actualValue = barcodeLimit.Value.Value;
            if (!actualValue.Equals(barcodeLimitOption))
            {
                PlugInParametersGrid.SelectRow(PlugInParametersGrid.Columns.DetailID, barcodeLimit.DetailID.Value);
                PlugInParametersGrid.Row.Value.DynamicControl<DropDown>().Select(barcodeLimitOption);
                Log.Information("Wait the enabled Save button");
                WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                Save();
                WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            }
        }

        public void SetPodParameters(Dictionary<string, bool> dataDictionary, string carrierId = "WW")
        {
            Log.Information($"Set the POD Store parameters for carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(carrierId);
            var plugInParameterList = PlugInParametersGrid.AllPageData().ToList();
            if (!plugInParameterList.Any())
                throw new Exception("Plug-In parameters are not found");
            foreach (var pair in dataDictionary)
            {
                Log.Information($"Set the parameter: {pair.Key}: {pair.Value}");
                var tempParameter = plugInParameterList.FirstOrDefault(r => r.DetailID.Value.Equals(pair.Key));
                if (tempParameter == null)
                    throw new Exception($"Record is not found by id: {pair.Key}");
                var actualValue = Convert.ToBoolean(tempParameter.Value.Value);
                if (!actualValue.Equals(pair.Value))
                {
                    PlugInParametersGrid.SelectRow(PlugInParametersGrid.Columns.DetailID, tempParameter.DetailID.Value);
                    PlugInParametersGrid.Row.Value.DynamicControl<CheckBox>().Set(pair.Value);
                    Log.Information("Wait the enabled Save button");
                    WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                    Save();
                    WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
                }
            }
        }

        public void CheckErrorMessageDuplicateWorkWaveTerritory(CarrierWorkWaveTerritory dataWorkWaveTerritory, string carrierId = "WW")
        {
            Log.Information($"Validate the error message of the duplicate combination for carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(carrierId);
            Log.Information("Add a new row (existing combination)");
            WorkWaveTerritoriesGrid.ClickAndAddNewRow();
            WorkWaveTerritoriesGrid.SelectRow(WorkWaveTerritoriesGrid.Columns.WWCompanyID, "");
            WorkWaveTerritoriesGrid.Row.WWCompanyID.Select(dataWorkWaveTerritory.Company);
            if (!string.IsNullOrEmpty(dataWorkWaveTerritory.Branch))
                WorkWaveTerritoriesGrid.Row.WWBranchID.Select(dataWorkWaveTerritory.Branch);
            if (!string.IsNullOrEmpty(dataWorkWaveTerritory.Warehouse))
                WorkWaveTerritoriesGrid.Row.WWWarehouseID.Select(dataWorkWaveTerritory.Warehouse);
            WorkWaveTerritoriesGrid.Row.WWTerritoryID.Select(dataWorkWaveTerritory.Territory);
            WorkWaveTerritoriesGrid.Row.WWActive.Set(dataWorkWaveTerritory.Active);
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Log.Information("Check the error message");
            VerifyAlert(ToolBar.Save.Click, _errorMessage);
            GetErrors().VerifyAnyOfValuesContains(_errorMessage);
            Cancel();
        }

        public void SetWorkWaveTerritory(CarrierWorkWaveTerritory dataWorkWaveTerritory, string carrierId = "WW")
        {
            Log.Information($"Set the WorkWave territory for carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(carrierId);
            Log.Information("Set the WorkWave Territories");
            if (WorkWaveTerritoriesGrid.ToolBar.UploadTerritories.IsEnabled())
            {
                Log.Information("Upload the WorkWave territories");
                WorkWaveTerritoriesGrid.UploadTerritories();
                WaitBase.WaitForCondition(() => !WorkWaveTerritoriesGrid.ToolBar.UploadTerritories.IsEnabled(),
                    WaitBase.LongTimeOut);
            }
            Log.Information("The WorkWave territories are uploaded");
            var territories = WorkWaveTerritoriesGrid.AllPageData().ToList();
            foreach (var item in territories)
            {
                Log.Information("Remove previous rows");
                WorkWaveTerritoriesGrid.SelectRow(WorkWaveTerritoriesGrid.Columns.WWCompanyID, item.WWCompanyID.Value);
                WorkWaveTerritoriesGrid.Delete();
            }
            Log.Information("Add a new row");
            WorkWaveTerritoriesGrid.ClickAndAddNewRow();
            WorkWaveTerritoriesGrid.SelectRow(WorkWaveTerritoriesGrid.Columns.WWCompanyID, "");
            WorkWaveTerritoriesGrid.Row.WWCompanyID.Select(dataWorkWaveTerritory.Company);
            if (!string.IsNullOrEmpty(dataWorkWaveTerritory.Branch))
                WorkWaveTerritoriesGrid.Row.WWBranchID.Select(dataWorkWaveTerritory.Branch);
            if (!string.IsNullOrEmpty(dataWorkWaveTerritory.Warehouse))
                WorkWaveTerritoriesGrid.Row.WWWarehouseID.Select(dataWorkWaveTerritory.Warehouse);
            WorkWaveTerritoriesGrid.Row.WWTerritoryID.Select(dataWorkWaveTerritory.Territory);
            WorkWaveTerritoriesGrid.Row.WWActive.Set(dataWorkWaveTerritory.Active);
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public void CreateNewWorkWaveCarrier(Carrier carrier)
        {
            Log.Information($"Create/update the carrier: {carrier.CarrierId}");
            if (SearchCarrierId(carrier.CarrierId))
            {
                OpenScreen();
                Log.Information("Update existing carrier. Set parameters of main form");
                MainForm.CarrierPluginID.Select(carrier.CarrierId);

            }
            else
            {
                OpenScreen();
                Log.Information("Create a new carrier. Set parameters of main form");
                MainForm.CarrierPluginID.Type(carrier.CarrierId);
            }
            MainForm.Description.Type(carrier.Description);
            MainForm.PluginTypeName.Select(carrier.PlugInType);
            MainForm.UnitType.Select(carrier.CarrierUnits);
            MainForm.KilogramUOM.Select(carrier.Kilogram);
            MainForm.CentimeterUOM.Select(carrier.Centimeter);
            if (!string.IsNullOrEmpty(carrier.Warehouse))
                MainForm.SiteID.Select(carrier.Warehouse);
            Log.Information("Set the Plug-In Parameters");
            var plugInParameterList = PlugInParametersGrid.AllPageData().ToList();
            foreach (var item in carrier.PlugInParameters)
            {
                var foundParameter = plugInParameterList.FirstOrDefault(r => r.DetailID.Value.Equals(item.Id));
                if (foundParameter == null)
                    throw new Exception($"Parameter is not found by Id: {item.Id}");
                PlugInParametersGrid.SelectRow(PlugInParametersGrid.Columns.DetailID, foundParameter.DetailID.Value);
                var unchangedItemList = new List<string>() { "WWRM ELIGIBILITY TYPE", "WWRM ROUTE TYPE" };
                if (unchangedItemList.Contains(item.Id))
                {
                    PlugInParametersGrid.Row.Value.GetValue().VerifyEquals(item.Value.ToString());
                    continue;
                }
                if(item.Value.GetType().Equals(typeof(bool)))
                    PlugInParametersGrid.Row.Value.DynamicControl<CheckBox>().Set(item.Value);
                else
                {
                    var selectedItemList = new List<string>() { "BARCODE LIMIT" };
                    if (selectedItemList.Contains(item.Id))
                    {
                        PlugInParametersGrid.Row.Value.DynamicControl<DropDown>().Select(item.Value);
                    }
                    else
                    {
                        PlugInParametersGrid.Row.Value.DynamicControl<Input>().Type(item.Value.ToString());
                    }
                }
                PlugInParametersGrid.Row.Value.PressTab();
                if (MessageBox.Message.IsVisible())
                {
                    Log.Information("Wait the enabled MessageBox Ok button");
                    WaitBase.WaitForCondition(
                        () => MessageBox.Buttons.Ok.IsVisible() && MessageBox.Buttons.Ok.IsEnabled(),
                        WaitBase.LongTimeOut);
                    MessageBox.Ok();
                }
            }
            Log.Information("Set the WorkWave Territories");
            if (WorkWaveTerritoriesGrid.ToolBar.UploadTerritories.IsEnabled())
            {
                Log.Information("Upload the WorkWave territories");
                WorkWaveTerritoriesGrid.UploadTerritories();
                WaitBase.WaitForCondition(() => !WorkWaveTerritoriesGrid.ToolBar.UploadTerritories.IsEnabled(),
                    WaitBase.LongTimeOut);
            }
            Log.Information("The WorkWave territories are uploaded");
            var territories = WorkWaveTerritoriesGrid.AllPageData().ToList();
            foreach (var item in territories)
            {
                Log.Information("Remove previous rows");
                WorkWaveTerritoriesGrid.SelectRow(WorkWaveTerritoriesGrid.Columns.WWCompanyID, item.WWCompanyID.Value);
                WorkWaveTerritoriesGrid.Delete();
            }
            Log.Information("Add new rows");
            foreach (var item in carrier.CarrierWorkWaveTerritories)
            {
                WorkWaveTerritoriesGrid.ClickAndAddNewRow();
                WorkWaveTerritoriesGrid.SelectRow(WorkWaveTerritoriesGrid.Columns.WWCompanyID, "");
                WorkWaveTerritoriesGrid.Row.WWCompanyID.Select(item.Company);
                WorkWaveTerritoriesGrid.Row.WWBranchID.Select(item.Branch);
                WorkWaveTerritoriesGrid.Row.WWWarehouseID.Select(item.Warehouse);
                WorkWaveTerritoriesGrid.Row.WWTerritoryID.Select(item.Territory);
                WorkWaveTerritoriesGrid.Row.WWActive.Set(item.Active);
            }

            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public void TestConnection(string carrierId)
        {
            Log.Information($"Test connection for carrier: {carrierId}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(carrierId);
            Log.Information("Wait the enabled Test Connection button");
            WaitBase.WaitForCondition(() => ToolBar.Test.IsVisible() && ToolBar.Test.IsEnabled(),
                WaitBase.LongTimeOut);
            Test();
            WaitBase.WaitForCondition(() => !string.IsNullOrEmpty(MessageBox.Message.GetValue().ToString()), WaitBase.LongTimeOut);
            var message = MessageBox.Message.GetValue();
            message.VerifyEquals(_expectedMessageTestConnetion);
            WaitBase.WaitForCondition(() => MessageBox.Buttons.Ok.IsEnabled(), WaitBase.LongTimeOut);
            MessageBox.Ok();
            WaitBase.WaitForCondition(() => !MessageBox.Buttons.Ok.IsVisible(), WaitBase.LongTimeOut);
        }

        public void DeleteCarrier(string id)
        {
            Log.Information($"Remove a carrier: {id}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(id);
            Log.Information("Wait the enabled Delete button");
            WaitBase.WaitForCondition(() => ToolBar.Delete.IsVisible() && ToolBar.Delete.IsEnabled(),
                WaitBase.LongTimeOut);
            Delete();
        }

        public string GetBarcodeDelimiter(string id = "WW")
        {
            Log.Information($"Get the barcode limiter for carrier: {id}");
            OpenScreen();
            MainForm.CarrierPluginID.Select(id);
            var plugInParameterList = PlugInParametersGrid.AllPageData().ToList();
            var barcodeDelimiterRecord =
                plugInParameterList.FirstOrDefault(r => r.DetailID.Value.Equals("BARCODE DELIMITER"));
            if (barcodeDelimiterRecord == null)
                throw new Exception("Record is not found by id BARCODE DELIMITER");
            return barcodeDelimiterRecord.Value.Value.Trim();
        }

        public void AssertPlugInTypeDropDownList(string expectedValue, bool displayed = true)
        {
            Log.Information($"Validate the Plug-In Type drop-down list: {expectedValue}. Should be displayed: {displayed}");
            OpenScreen();
            Insert();
            MainForm.PluginTypeName.Open();
            var actualCarrierTypeList = MainForm.PluginTypeName.Grid.Columns
                .DynamicControl<InputColumnFilter>("Type Name").GetValues().ToList();
            MainForm.PluginTypeName.Close();
            var foundRecord = actualCarrierTypeList.FirstOrDefault(r => r.Equals(expectedValue));
            if (displayed)
            {
                if (foundRecord == null)
                    Log.Error($"Record is not found: {expectedValue}");
            }
            else
            {
                if (foundRecord != null)
                    Log.Error($"Hidden record is found: {expectedValue}");
            }
        }
    }
}
