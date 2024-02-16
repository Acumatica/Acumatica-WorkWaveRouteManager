using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Editors.Selector;
using Core.Log;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;
using WorkWaveIntegrationQA.Tests.Entity;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class CarrierMaint: CS207500_CarrierMaint
    {
        public c_carrier_form MainForm => base.Carrier_form;
        public c_carriercurrent_tab DetailsTab => base.CarrierCurrent_tab;
        public c_freightrates_gridfreightrates FreightRatesTab => base.FreightRates_gridFreightRates;

        public ShipViaCode GenerateShipViaCode(string id = "WW")
        {
            var shipViaCode = new ShipViaCode()
            {
                Id = id,
                Description = "WorkWave",
                ExternalPlugIn = true,
                Carrier = "WW",
                ServiceMethod = "NA",
                CommonCarrier = true,
                CalculateFreightOnReturns = false,
                ConfirmationForEachBoxIsRequired = false,
                AtLeastOnePackageIsRequired = true,
                GenerateReturnLabelAutomatically = false,
                FreightSalesAccount = "10100",
                FreightSalesSub = "000-000",
                FreightExpenseAccount = "10100",
                FreightExpenseSub = "000-000"
            };
            return shipViaCode;
        }

        public bool SearchShipViaCode(string shipViaCodeId = "WW")
        {
            Log.Information($"Search the ship via code: {shipViaCodeId}");
            OpenScreen();
            MainForm.CarrierID.Open();
            var actualShipViaCodeList = MainForm.CarrierID.Grid.Columns.DynamicControl<SelectorColumnFilter>("Ship Via")
                .GetValues().ToList();
            MainForm.CarrierID.Close();
            var foundRecord = actualShipViaCodeList.FirstOrDefault(r => r.Equals(shipViaCodeId.ToUpper()));
            if (foundRecord == null)
            {
                Log.Information($"Record is not found by {shipViaCodeId}");
                return false;
            }
            Log.Information("Record is found");
            return true;
        }

        public void CreateUpdateShipViaCode(ShipViaCode shipViaCode)
        {
            Log.Information($"Create/update the ship via code: {shipViaCode.Id}");
            if (SearchShipViaCode(shipViaCode.Id))
            {
                Log.Information("Update the existing ship via code");
                OpenScreen();
                MainForm.CarrierID.Select(shipViaCode.Id);
            }
            else
            {
                Log.Information("Create a new ship via code");
                OpenScreen();
                MainForm.CarrierID.Type(shipViaCode.Id);
            }
            Log.Information("Set parameters of the main form");
            MainForm.Description.Type(shipViaCode.Description);
            MainForm.IsExternal.Set(shipViaCode.ExternalPlugIn);
            Log.Information("Details Tab. Set values");
            if (!string.IsNullOrEmpty(shipViaCode.Calendar))
                DetailsTab.CalendarID.Select(shipViaCode.Calendar);
            if (!string.IsNullOrEmpty(shipViaCode.Carrier))
                DetailsTab.CarrierPluginID.Select(shipViaCode.Carrier);
            if (!string.IsNullOrEmpty(shipViaCode.ServiceMethod))
                DetailsTab.PluginMethod.Select(shipViaCode.ServiceMethod);
            DetailsTab.IsCommonCarrier.Set(shipViaCode.CommonCarrier);
            //DetailsTab.CalcFreightOnReturn.Set(shipViaCode.CalculateFreightOnReturns);
            DetailsTab.ConfirmationRequired.Set(shipViaCode.ConfirmationForEachBoxIsRequired);
            DetailsTab.PackageRequired.Set(shipViaCode.AtLeastOnePackageIsRequired);
            DetailsTab.ReturnLabel.Set(shipViaCode.GenerateReturnLabelAutomatically);
            if (!string.IsNullOrEmpty(shipViaCode.TaxCategory))
                DetailsTab.TaxCategoryID.Select(shipViaCode.TaxCategory);
            if (!string.IsNullOrEmpty(shipViaCode.FreightSalesAccount))
                DetailsTab.FreightSalesAcctID.Select(shipViaCode.FreightSalesAccount);
            DetailsTab.FreightSalesSubID.Type(shipViaCode.FreightSalesSub);
            if (!string.IsNullOrEmpty(shipViaCode.FreightExpenseAccount))
                DetailsTab.FreightExpenseAcctID.Select(shipViaCode.FreightExpenseAccount);
            DetailsTab.FreightExpenseSubID.Type(shipViaCode.FreightExpenseSub);
            SaveChanges();
        }

        public void SaveChanges()
        {
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
            Save();
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public void DeleteShipViaCodeById(string id)
        {
            Log.Information($"Remove the ship via code: {id}");
            OpenScreen();
            MainForm.CarrierID.Select(id);
            Log.Information("Wait the enabled Delete button");
            WaitBase.WaitForCondition(() => ToolBar.Delete.IsVisible() && ToolBar.Delete.IsEnabled(),
                WaitBase.LongTimeOut);
            Delete();
        }

        public string GetDescription(string id = "WW")
        {
            Log.Information($"Get a description from ship via code: {id}");
            OpenScreen();
            MainForm.CarrierID.Select(id);
            return MainForm.Description.GetValue().ToString().Trim();
        }

        public void AssertFreightRatesFields(string id)
        {
            Log.Information($"Validate elements ship via code: {id}");
            OpenScreen();
            MainForm.CarrierID.Select(id);
            DetailsTab.CalcMethod.IsVisible().VerifyEquals(true);
            DetailsTab.CalcMethod.IsEnabled().VerifyEquals(true);
            DetailsTab.BaseRate.IsVisible().VerifyEquals(true);
            FreightRatesTab.Columns.Weight.IsVisible().VerifyEquals(true);
            FreightRatesTab.Columns.Volume.IsVisible().VerifyEquals(true);
            FreightRatesTab.Columns.ZoneID.IsVisible().VerifyEquals(true);
            FreightRatesTab.Columns.Rate.IsVisible().VerifyEquals(true);
        }

        public void UpdateCalculationMethod(string id, string calculationMethod, double? baseRate = null)
        {
            Log.Information($"Update the Calculation Method for ship via code: {id}");
            OpenScreen();
            MainForm.CarrierID.Select(id);
            var method = DetailsTab.CalcMethod.GetValue().ToString();
            if (!method.Contains(calculationMethod))
            {
                DetailsTab.CalcMethod.Select(calculationMethod);
                if (baseRate != null)
                    DetailsTab.BaseRate.Type(baseRate.Value);
                SaveChanges();
            }
        }

        public void AddFreightRate(string id, double weight = 1.00, double volume = 1.00, string zoneId = "CENTRAL", double rate = 100.00)
        {
            OpenScreen();
            MainForm.CarrierID.Select(id);
            var records = FreightRatesTab.AllPageData().ToList();
            var foundRecord = records.FirstOrDefault(r => r.ZoneID.Value.Equals(zoneId));
            if (foundRecord != null)
            {
                Log.Information($"Freight Rate is found by Zone Id: {zoneId}. Update an entity");
                FreightRatesTab.SelectRow(FreightRatesTab.Columns.ZoneID, foundRecord.ZoneID.Value);
            }
            else
            {
                Log.Information($"Add the Freight Rate for ship via code: {id}");
                FreightRatesTab.New();
                FreightRatesTab.SelectRow(FreightRatesTab.Columns.ZoneID, "");
            }
            FreightRatesTab.Row.Weight.Type(weight);
            FreightRatesTab.Row.Volume.Type(volume);
            FreightRatesTab.Row.ZoneID.Select(zoneId);
            FreightRatesTab.Row.Rate.Type(rate);
            SaveChanges();
        }

        public double GetFreightRateMultiplication(string id, double volume, string zoneId = "CENTRAL")
        {
            Log.Information($"Get the Multiplication of the Freight Rates. Ship Via Code: {id}. Zone Id: {zoneId}");
            OpenScreen();
            MainForm.CarrierID.Select(id);
            var records = FreightRatesTab.AllPageData().ToList();
            var foundRecord = records.FirstOrDefault(r => r.ZoneID.Value.Equals(zoneId));
            if (foundRecord == null)
            {
                throw new Exception($"Record is not found: {zoneId}");
            }
            var weight = Convert.ToDouble(foundRecord.Weight.Value);
            var rate = Convert.ToDouble(foundRecord.Rate.Value);
            var result = 0.00;
            if (weight > volume)
                result = weight * rate;
            else
                result = volume * rate;
            Log.Information($"Multiplication: {result}");
            return result;
        }
    }
}
