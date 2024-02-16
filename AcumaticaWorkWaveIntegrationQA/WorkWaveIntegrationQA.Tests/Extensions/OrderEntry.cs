using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.Wrappers;
using Controls.ToolBarButton;
using Core.Core.Browser;
using Core.Log;
using Newtonsoft.Json;
using OpenQA.Selenium;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Entity;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class OrderEntry : SO301000_SOOrderEntry
    {
        private int _timeout = 60000;
        public c_document_form MainForm => base.Document_form;
        public c_transactions_grid DocumentDetailsGrid => base.Transactions_grid;
        public c_currentdocument_formdeliverysettings ShippingSettingsTab => base.CurrentDocument_formDeliverySettings;
        public c_soparamfilter_formcreateshipment ShipmentParameters => base.Soparamfilter_formCreateShipment;
        public c_quickprocessparameters_fromquickprocess QuickProcessForm => base.QuickProcessParameters_fromQuickProcess;
        public c_currentdocument_formfreightinfo TotalsTab => base.CurrentDocument_formFreightInfo;
        public c_processingresults ProcessingResults => base.ProcessingResults;

        public string CreateNewSalesOrder(string customerID = "AACUSTOMER", string inventoryID = "AACOMPUT01", string quantity = "1", string shipVia = "WW")
        {
            Log.Information($"Create a new sales order for customer: {customerID}");
            OpenScreen();
            Insert();
            MainForm.CustomerID.Select(customerID);
            DocumentDetailsGrid.ClickAndAddNewRow();
            DocumentDetailsGrid.SelectRow(DocumentDetailsGrid.Columns.InventoryID, "");
            DocumentDetailsGrid.Row.InventoryID.Select(inventoryID);
            DocumentDetailsGrid.Row.OrderQty.Type(quantity);
            if (!string.IsNullOrEmpty(shipVia))
                ShippingSettingsTab.ShipVia.Select(shipVia);
            SaveChanges();
            return MainForm.OrderNbr.GetValue().ToString();
        }

        public void SaveChanges()
        {
            Log.Information("Wait the enabled Save button");
            WaitBase.WaitForCondition(() => ToolBar.Save.IsVisible() && ToolBar.Save.IsEnabled(),
                WaitBase.LongTimeOut);
            Save();
            Log.Information("Wait the disabled Save button");
            WaitBase.WaitForCondition(() => !ToolBar.Save.IsEnabled(), WaitBase.LongTimeOut);
        }

        public string CreateNewSalesOrder(List<Dictionary<string, dynamic>> inventoryItemList, string customerID = "AACUSTOMER", string shipVia = "WW")
        {
            Log.Information($"Create a new sales order for customer: {customerID}");
            OpenScreen();
            Insert();
            MainForm.CustomerID.Select(customerID);
            foreach (var item in inventoryItemList)
            {
                DocumentDetailsGrid.ClickAndAddNewRow();
                DocumentDetailsGrid.SelectRow(DocumentDetailsGrid.Columns.InventoryID, "");
                DocumentDetailsGrid.Row.InventoryID.Select(item["InventoryID"].ToString());
                DocumentDetailsGrid.Row.OrderQty.Type(item["OrderQty"].ToString());
            }
            if (!string.IsNullOrEmpty(shipVia))
                ShippingSettingsTab.ShipVia.Select(shipVia);
            SaveChanges();
            return MainForm.OrderNbr.GetValue().ToString();
        }

        public string CreateShipmentEntry(string orderNumber)
        {
            Log.Information($"Create a shipment for {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            Log.Information("Wait the enabled 'Create shipment' button");
            WaitBase.WaitForCondition(() => ToolBar.CreateShipmentIssue.IsVisible() && ToolBar.CreateShipmentIssue.IsEnabled(),
                WaitBase.LongTimeOut);
            CreateShipmentIssue();
            Log.Information("Wait the enabled confirmation button of shipment parameters");
            WaitBase.WaitForCondition(
                () => ShipmentParameters.Buttons.Ok.IsVisible() && ShipmentParameters.Buttons.Ok.IsEnabled(),
                WaitBase.LongTimeOut);
            ShipmentParameters.Ok();
            var shipment = new ShipmentEntry();
            return shipment.GetShipmentNumber();
        }

        public string QuickProcessByOrderNumber(string orderNumber, bool withWorkWaveCarrier = true)
        {
            Log.Information($"Quick process for sales order: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            Log.Information($"Wait the enabled {ToolBar.QuickProcess.ControlName} button");
            //WaitBase.WaitForCondition(() => ToolBar.QuickProcess.IsVisible() && ToolBar.QuickProcess.IsEnabled(), _timeout);
            QuickProcess();
            Log.Information($"Wait the enabled {QuickProcessForm.Buttons.QuickProcessOk.ControlName} button");
            WaitBase.WaitForCondition(() => QuickProcessForm.Buttons.QuickProcessOk.IsVisible() 
                                            && QuickProcessForm.Buttons.QuickProcessOk.IsEnabled(), _timeout);
            if (withWorkWaveCarrier)
            {
                QuickProcessForm.ConfirmShipment.GetValue().VerifyEquals(false);
                QuickProcessForm.ConfirmShipment.IsEnabled().VerifyEquals(false);
            }
            else
            {
                QuickProcessForm.ConfirmShipment.IsEnabled().VerifyEquals(true);
                QuickProcessForm.ConfirmShipment.Set(true);
                WaitBase.WaitForCondition(() => QuickProcessForm.ConfirmShipment.GetValue().Equals(true), _timeout);
                QuickProcessForm.UpdateIN.Click();
                QuickProcessForm.UpdateIN.Set(false);
                QuickProcessForm.PrepareInvoiceFromShipment.Set(false);
            }
            QuickProcessForm.Buttons.QuickProcessOk.Click();
            Log.Information($"Wait the enabled {ProcessingResults.Buttons.Ok.ControlName} button");
            WaitBase.WaitForCondition(() => ProcessingResults.Buttons.Ok.IsVisible() && ProcessingResults.Buttons.Ok.IsEnabled(), _timeout);
            var content = ProcessingResults.Content.GetValue().ToString();
            if (!content.Contains("is created"))
                throw new Exception($"Shipment is not created for sales order: {orderNumber}");
            var link = ProcessingResults.Content.Element.FindElement(By.TagName("a"));
            var shipmentNumber = link.Text;
            ProcessingResults.Buttons.Ok.Click();
            Log.Information($"Shipment number: {shipmentNumber}");
            return shipmentNumber;
        }

        public string QuickProcessPrintLabelByOrderNumber(string orderNumber)
        {
            Log.Information($"Quick process (print labels) for sales order: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            Log.Information($"Wait the enabled {ToolBar.QuickProcess.ControlName} button");
            //WaitBase.WaitForCondition(() => ToolBar.QuickProcess.IsVisible() && ToolBar.QuickProcess.IsEnabled(), _timeout);
            QuickProcess();
            Log.Information($"Wait the enabled {QuickProcessForm.Buttons.QuickProcessOk.ControlName} button");
            WaitBase.WaitForCondition(() => QuickProcessForm.Buttons.QuickProcessOk.IsVisible() 
                                            && QuickProcessForm.Buttons.QuickProcessOk.IsEnabled(), _timeout);
            QuickProcessForm.PrintLabels.Set(true);
            QuickProcessForm.Buttons.QuickProcessOk.Click();
            Log.Information($"Wait the enabled {ProcessingResults.Buttons.Ok.ControlName} button");
            WaitBase.WaitForCondition(() => ProcessingResults.Buttons.Ok.IsVisible() && ProcessingResults.Buttons.Ok.IsEnabled(), _timeout);
            var content = ProcessingResults.Content.GetValue().ToString();
            if (!content.Contains("is created"))
                throw new Exception($"Shipment is not created for sales order: {orderNumber}");
            var links = ProcessingResults.Content.Element.FindElements(By.TagName("a")).ToList();
            if (!links.Any())
                throw new Exception("Links are not found");
            var shipmentNumber = links.First().Text;
            Log.Information($"Shipment number: {shipmentNumber}");
            var previousWindowsAmount = Browser.WebDriver.WindowHandles.Count;
            var labelLink = links.Last();
            labelLink.Click();
            WaitBase.WaitForCondition(() => Browser.WebDriver.WindowHandles.Count == previousWindowsAmount + 1,
                WaitBase.LongTimeOut);
            Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.Last());
            return shipmentNumber;
        }

        public void SetTimeWindowInputs(string orderNumber, string timeWindowStart, string timeWindowEnd)
        {
            Log.Information($"Set Time Window Start and End inputs for Sales Order: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            ShippingSettingsTab.UsrWWStartSec.Select(timeWindowStart);
            ShippingSettingsTab.UsrWWEndSec.Select(timeWindowEnd);
            SaveChanges();
        }

        public void AssertTimeWindowsInputs(string orderNumber, string timeWindowStartString, string timeWindowEndString)
        {
            Log.Information($"Validate Time Window Start and End inputs for Sales Order: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            var timeWindowStart = ShippingSettingsTab.UsrWWStartSec.GetValue().ToString();
            var timeWindowEnd = ShippingSettingsTab.UsrWWEndSec.GetValue().ToString();
            var expectedTimeWindowStartList = timeWindowStartString.Split(' ').ToList();
            var expectedTimeWindowEndList = timeWindowEndString.Split(' ').ToList();
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.First());
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.Last());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.First());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.Last());
        }

        public void SetShippingZone(string orderNumber, string shippingZone = "CENTRAL")
        {
            Log.Information($"Set the Shipping Zone: {shippingZone}. Order Number: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            ShippingSettingsTab.ShipZoneID.Select(shippingZone);
            SaveChanges();
        }

        public void SetFreightCost(string orderNumber, double cost = 200.00)
        {
            Log.Information($"Set the Freight Cost: {cost}. Order Number: {orderNumber}");
            OpenScreen();
            MainForm.OrderNbr.Select(orderNumber);
            TotalsTab.CuryFreightCost.Type(cost);
            SaveChanges();
        }

    }
}
