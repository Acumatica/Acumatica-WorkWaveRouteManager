using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Core.Browser;
using Core.Log;
using OpenQA.Selenium;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class InvoiceShipment : SO503000_SOInvoiceShipment
    {
        public c_filter_form FilterForm => base.Filter_form;
        public c_orders_grid ResultGrid => base.Orders_grid;
        public c_processingview_griddetails ProcessingGridDetails => base.ProcessingView_gridDetails;

        private int _timeout1 = 5000;
        private int _timeout2 = 2400000;
        private string _processShipmentActionPrintLabels = "Print Labels";
        private int _timeout = 60000;

        public InvoiceShipment()
        {
            ToolBar.Process.WaitAction = () => { };
        }

        public List<c_orders_grid.c_grid_row> GetRowListByAction(string actionName = "Create WorkWave Order")
        {
            Log.Information($"Get shipments by action: {actionName}");
            OpenScreen();
            FilterForm.Action.Select(actionName);
            if (actionName.Equals(_processShipmentActionPrintLabels))
                FilterForm.ShowPrinted.Set(true);
            var rows = ResultGrid.AllPageData().ToList();
            if (!rows.Any())
                throw new Exception($"Records are not found by action: {actionName}");
            return rows;
        }

        public c_orders_grid.c_grid_row SearchShipmentByNumber(string shipmentNumber, string actionName = "Create WorkWave Order")
        {
            Log.Information($"Search a shipment by number: {shipmentNumber} for action: {actionName}");
            var rows = GetRowListByAction(actionName);
            var foundRecord = rows.FirstOrDefault(r => r.ShipmentNbr.Value.Equals(shipmentNumber));
            if (foundRecord == null)
            {
                Log.Information("Record is not found");
                return null;
            }
            Log.Information("Record is found");
            return foundRecord;
        }

        public void ProcessShipment(string shipmentNumber, string actionName = "Create WorkWave Order", bool waitPanelContent = true, 
            bool waitNewTab = false)
        {
            Log.Information($"Process a shipment by number: {shipmentNumber} for action: {actionName}");
            var foundRecord = SearchShipmentByNumber(shipmentNumber, actionName);
            if (foundRecord == null)
                throw new Exception($"Record is not found for processing: {shipmentNumber}");
            ResultGrid.SelectRow(ResultGrid.Columns.ShipmentNbr, foundRecord.ShipmentNbr.Value);
            ResultGrid.Row.Selected.Set(true);
            int previousWinCount = Browser.WebDriver.WindowHandles.Count;
            Log.Information("Wait the enabled Process button");
            WaitBase.WaitForCondition(() => ToolBar.Process.IsVisible() && ToolBar.Process.IsEnabled(),
                WaitBase.LongTimeOut);
            Process();
            if (waitNewTab)
            {
                Thread.Sleep(_timeout / 3);
                Log.Information("Wai the next browser window");
                WaitBase.WaitForCondition(() => Browser.WebDriver.WindowHandles.Count.Equals(previousWinCount + 1),
                    _timeout / 3);
                Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.Last());
            }
            if (waitPanelContent)
            {
                if (waitNewTab)
                    Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.First());
                WaitStatusClass();
                Log.Information("Wait the enabled Close button");
                WaitBase.WaitForCondition(() => ProcessingGridDetails.Buttons.Close.IsEnabled(),
                    WaitBase.LongTimeOut);
                ProcessingGridDetails.Close();
                Log.Information("Wait the hidden Close button of the Processing window");
                WaitBase.WaitForCondition(() => !ProcessingGridDetails.Buttons.Close.IsVisible(),
                    WaitBase.LongTimeOut);
                if (waitNewTab)
                    Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.Last());
            }
        }

        public void CloseNextWindow()
        {
            Browser.WebDriver.Close();
            Log.Information("Wait a closing of the new browser window");
            WaitBase.WaitForCondition(() => Browser.WebDriver.WindowHandles.Count.Equals(1), _timeout / 3);
            Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.First());
        }

        public void WaitStatusClass(string expectedStatus = "StatusCompleted")
        {
            Log.Information($"Wait the '{expectedStatus}' class for web element with the 'PanelContent' id");
            Thread.Sleep(_timeout1);
            WaitBase.WaitForCondition(() =>
            {
                try
                {
                    return Browser.WebDriver.FindElement(By.Id("PanelContent")).GetAttribute("class").Equals(expectedStatus);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }, _timeout2);
        }
    }
}
