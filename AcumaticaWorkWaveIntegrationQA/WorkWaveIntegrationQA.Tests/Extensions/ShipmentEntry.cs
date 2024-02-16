using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Controls.Editors.CurrencyEditor;
using Controls.Editors.Selector;
using Controls.RichTextEdit;
using WorkWaveIntegrationQA.Tests.Wrappers;
using Controls.ToolBarButton;
using Core.Log;
using Newtonsoft.Json;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;
using Core.Core.Browser;
using OpenQA.Selenium;


namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class ShipmentEntry : SO302000_SOShipmentEntry
    {
        public c_document_form MainForm => base.Document_form;
        public c_transactions_grid DocumentDetailsGrid => base.Transactions_grid;
        public c_packages_gridpackages PackagesGrid => base.Packages_gridPackages;
        public c_wworders_cstworkwaveorders WorkWaveOrders => base.WWOrders_cstWorkWaveOrders;
        public c_currentdocument_formf ShippingSettings => base.CurrentDocument_formF;
        public c_shipping_address_formb ShipToAddress => base.Shipping_Address_formB;

        public ShipmentEntry()
        {
            ToolBar.CreateWokWaveOrder.WaitAction = () => { };
            ToolBar.PrintLabels.WaitAction = () => { };
        }

        private string _errorMessageWWOrderCreation =
            "Error: Cannot create WorkWave order as Shipment has more than 10 packages";
        private string _warningOrderCanceling = 
            "WorkWave Orders will be deleted only from Acumatica site. You must independently remove these orders from the WorkWave site.";
        private string _warningShipmentDeletion = "The current Shipment record will be deleted";
        private string _warningWorkWaveOrderDeletion = "The current WorkWave order(s) will be deleted";

        private string _openStatus = "Open";
        private int _timeout = 60000;

        public bool SearchShipmentByNumber(string shipmentNumber)
        {
            Log.Information($"Search the shipment by number: {shipmentNumber}");
            OpenScreen();
            MainForm.ShipmentNbr.Open();
            var actualShipmentNumberList = MainForm.ShipmentNbr.Grid.Columns.DynamicControl<SelectorColumnFilter>("Shipment Nbr.").GetValues().ToList();
            MainForm.ShipmentNbr.Close();
            var foundRecord = actualShipmentNumberList.FirstOrDefault(r => r.Equals(shipmentNumber.ToUpper()));
            if (foundRecord == null)
            {
                Log.Information($"Record is not found by {shipmentNumber}");
                return false;
            }
            Log.Information("Record is found");
            return true;
        }

        public string GetShipmentNumber()
        {
            Log.Information("Get a shipment number");
            var currentNumber = MainForm.ShipmentNbr.GetValue().ToString();
            Log.Information($"Shipment number: {currentNumber}");
            return currentNumber;
        }

        public void OpenShipmentByNumber(string number)
        {
            Log.Information($"Open the shipment: {number}");
            OpenScreen();
            Insert();
            MainForm.ShipmentNbr.Select(number);
        }

        public List<c_transactions_grid.c_grid_row> GetDocumentDetailRows()
        {
            Log.Information("Get the Document Details");
            var rows = DocumentDetailsGrid.AllPageData().ToList();
            if (!rows.Any())
                Log.Information("Document Details are not found");
            return rows;
        }

        public List<c_packages_gridpackages.c_grid_row> GetPackageRows()
        {
            Log.Information("Get the Packages");
            var rows = PackagesGrid.AllPageData().ToList();
            if (!rows.Any())
                Log.Information("Packages are not found");
            return rows;
        }

        public List<c_wworders_cstworkwaveorders.c_grid_row> GetWorkWaveOrderRows()
        {
            Log.Information("Get the WorkWave Orders");
            if (!WorkWaveOrders.Columns.WWOrderID.IsVisible())
                WorkWaveOrders.Columns.WWOrderID.ShowColumn();
            if (!WorkWaveOrders.Columns.WWRequestID.IsVisible())
                WorkWaveOrders.Columns.WWRequestID.ShowColumn();
            var rows = WorkWaveOrders.AllPageData().ToList();
            if (!rows.Any())
                Log.Information("WorkWave Orders are not found");
            return rows;
        }

        public List<string> GetWorkWaveOrderIdList(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Get a list of WorkWave order ids");
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            List<string> resultList = new List<string>();
            foreach (var item in workWaveOrderList)
            {
                resultList.Add(item.WWOrderID.Value);
            }
            return resultList;
        }

        public void AddPackage(string shipmentNumber, string boxId = "SMALL")
        {
            OpenShipmentByNumber(shipmentNumber);
            PackagesGrid.ClickAndAddNewRow();
            PackagesGrid.SelectRow(PackagesGrid.Columns.BoxID, "");
            PackagesGrid.Row.BoxID.Select(boxId);
            PackagesGrid.Row.Weight.Type("1");
            PackagesGrid.Row.DeclaredValue.Type("1");
            PackagesGrid.Row.Confirmed.Set(true);
            SaveChanges();
        }

        public void SetPackages(string shipmentNumber, int quantity = 11)
        {
            OpenShipmentByNumber(shipmentNumber);
            var currentPackageList = GetPackageRows();
            if (!currentPackageList.Any())
                throw new Exception("Default package is not found");
            Log.Information("Remove previous packages");
            foreach (var item in currentPackageList)
            {
                PackagesGrid.SelectRow(PackagesGrid.Columns.BoxID, item.BoxID.Value);
                PackagesGrid.Delete();
            }
            Log.Information($"Add packages: {quantity}");
            for (int i = 0; i < quantity; i++)
            {
                PackagesGrid.ClickAndAddNewRow();
                PackagesGrid.SelectRow(PackagesGrid.Columns.BoxID, "");
                PackagesGrid.Row.BoxID.Select("SMALL");
                PackagesGrid.Row.Description.Type($"Test_{i}");
                PackagesGrid.Row.Weight.Type("1");
                PackagesGrid.Row.DeclaredValue.Type("1");
                PackagesGrid.Row.Confirmed.Set(true);
            }
            SaveChanges();
        }

        public void AssertErrorMessageWorkWaveOrderCreation(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Wait the enabled 'Create WorkWave Order' button");
            WaitBase.WaitForCondition(
                () => ToolBar.CreateWokWaveOrder.IsVisible() && ToolBar.CreateWokWaveOrder.IsEnabled(),
                WaitBase.LongTimeOut);
            CreateWokWaveOrder();
            Log.Information("Wait the error message");
            WaitBase.WaitForCondition(() => !ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."), WaitBase.LongTimeOut);
            var actualErrorMessage = ToolBar.LongRun.GetValue().ToString();
            actualErrorMessage.VerifyContains(_errorMessageWWOrderCreation);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (workWaveOrderList.Any())
                throw new Exception("WorkWave Order is created");
        }

        public string GetRequestIdFromWorkWaverOrder(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("New WorkWave Order is not created");
            var requestId = workWaveOrderList.First().WWRequestID.Value;
            if (string.IsNullOrEmpty(requestId))
                throw new Exception("Request Id is not defined for WW order");
            Log.Information($"Request Id: {requestId}");
            return requestId;
        }

        public string CreateNewWorkWaveOrder(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Wait the enabled 'Create WorkWave Order' button");
            WaitBase.WaitForCondition(
                () => ToolBar.CreateWokWaveOrder.IsVisible() && ToolBar.CreateWokWaveOrder.IsEnabled(),
                WaitBase.LongTimeOut);
            CreateWokWaveOrder();
            Log.Information("Wait the successful operation");
            WaitBase.WaitForCondition(() => ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."), WaitBase.LongTimeOut);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("New WorkWave Order is not created");
            var requestId = workWaveOrderList.First().WWRequestID.Value;
            if (string.IsNullOrEmpty(requestId))
                throw new Exception("Request Id is not defined for WW order");
            Log.Information($"Request Id: {requestId}");
            return requestId;
        }

        public void ValidateAbsenceOfWorkWaveOrders(string shipmentNumber, string expectedShipmentStatus = "Open")
        {
            OpenShipmentByNumber(shipmentNumber);
            var shipmentStatus = MainForm.Status.GetValue();
            shipmentStatus.VerifyEquals(expectedShipmentStatus);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are found");
        }

        public void ValidateWorkWaveOrderAndShipment(string shipmentNumber, string expectedShipmentStatus, Dictionary<string, string> expectedWorkWaveOrderData)
        {
            OpenShipmentByNumber(shipmentNumber);
            var shipmentStatus = MainForm.Status.GetValue();
            shipmentStatus.VerifyEquals(expectedShipmentStatus);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            if (workWaveOrderList.Count > 1)
                throw new Exception($"Expected behavior: one order is created. Actual: system creates {workWaveOrderList.Count} orders");
            Log.Information($"Validate the WorkWave order");
            var actualCustomer = MainForm.CustomerID.GetValue().ToString().Split('-').Last().Trim();
            var expectedOrderName = $"{shipmentNumber} - {actualCustomer}";
            var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderName.Value.Contains(expectedOrderName) 
                                                                   && r.WWDeliveryStatus.Value.Equals(expectedWorkWaveOrderData["WWDeliveryStatus"])
                                                                   && r.WWOrderID.Value.Equals(expectedWorkWaveOrderData["WWOrderID"])
                                                                   && r.WWRequestID.Value.Equals(expectedWorkWaveOrderData["WWRequestID"])
                                                                   && r.WWGPS.Value.Equals(expectedWorkWaveOrderData["WWGPS"])
                                                                   && r.WWErrorCode.Value.Equals(expectedWorkWaveOrderData["WWErrorCode"])
                                                                   && r.WWErrorMessage.Value.Equals(expectedWorkWaveOrderData["WWErrorMessage"])
                                                                   );
            if (foundOrder == null)
                throw new Exception($"Order is not found by " +
                                    $"{string.Join(";", expectedWorkWaveOrderData.Select(x => $"{x.Key}: {x.Value}"))}");
        }

        public void ValidateWorkWaveOrderListAndShipment(string shipmentNumber, string expectedShipmentStatus, 
            List<Dictionary<string, string>> expectedWorkWaveOrderDataList)
        {
            OpenShipmentByNumber(shipmentNumber);
            var shipmentStatus = MainForm.Status.GetValue();
            shipmentStatus.VerifyEquals(expectedShipmentStatus);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            Log.Information($"Validate the WorkWave orders");
            var actualCustomer = MainForm.CustomerID.GetValue().ToString().Split('-').Last().Trim();
            var expectedOrderName = $"{shipmentNumber} - {actualCustomer}";
            for (int i = 0; i < expectedWorkWaveOrderDataList.Count; i++)
            {
                var tempOrderName = $"{expectedOrderName} #{i + 1}";
                var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderName.Value.Contains(tempOrderName)
                                                                       && r.WWDeliveryStatus.Value.Equals(expectedWorkWaveOrderDataList[i]["WWDeliveryStatus"])
                                                                       && r.WWOrderID.Value.Equals(expectedWorkWaveOrderDataList[i]["WWOrderID"])
                                                                       && r.WWRequestID.Value.Equals(expectedWorkWaveOrderDataList[i]["WWRequestID"])
                                                                       && r.WWGPS.Value.Equals(expectedWorkWaveOrderDataList[i]["WWGPS"])
                                                                       && r.WWErrorCode.Value.Equals(expectedWorkWaveOrderDataList[i]["WWErrorCode"])
                                                                       && r.WWErrorMessage.Value.Equals(expectedWorkWaveOrderDataList[i]["WWErrorMessage"])
                );
                if (foundOrder == null)
                    throw new Exception($"Order is not found by " +
                                        $"{string.Join("; ", expectedWorkWaveOrderDataList[i].Select(x => $"{x.Key}: {x.Value}"))}");
            }
        }

        public void GetUpdatedDeliveryStatus(string shipmentNumber, int timeout = 0)
        {
            OpenShipmentByNumber(shipmentNumber);
            Thread.Sleep(timeout);
            Log.Information($"Wait the enabled {ToolBar.GetDeliveryStatus.ControlName}");
            WaitBase.WaitForCondition(() => ToolBar.GetDeliveryStatus.IsVisible() && ToolBar.GetDeliveryStatus.IsEnabled(), WaitBase.LongTimeOut);
            GetDeliveryStatus();
            Log.Information("Wait the successful operation");
            WaitBase.WaitForCondition(() => ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."), WaitBase.LongTimeOut);
        }

        public string GetTheWorkWaveGPSValue(string shipmentNumber, string orderId)
        {
            OpenShipmentByNumber(shipmentNumber);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderID.Value.Equals(orderId));
            if (foundOrder == null)
                throw new Exception($"Order is not found by order id: {orderId}");
            if (string.IsNullOrEmpty(foundOrder.WWGPS.Value))
                throw new Exception("GPS is not defined");
            return foundOrder.WWGPS.Value;
        }

        public void ValidateAbsenceOfFilesAndNoteForOrderId(string shipmentNumber, string orderId)
        {
            ValidateFilesAndNoteForOrderId(shipmentNumber, orderId, "", 0);
        }

        public void ValidateFilesAndNoteForOrderId(string shipmentNumber, string orderId, string expectedNotes, int expectedImageCount)
        {
            OpenShipmentByNumber(shipmentNumber);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderID.Value.Equals(orderId));
            if (foundOrder == null)
                throw new Exception($"Order is not found by order id: {orderId}");
            Log.Information("Validate Notes");
            WorkWaveOrders.SelectRow(WorkWaveOrders.Columns.WWOrderID, foundOrder.WWOrderID.Value);
            WorkWaveOrders.Row.Notes.Click();
            var actualNotes = WorkWaveOrders.NotePanel.NoteEdit.GetValue();
            actualNotes.VerifyEquals(expectedNotes);
            WorkWaveOrders.NotePanel.Cancel();
            Log.Information("Validate a count of images");
            WorkWaveOrders.Row.Files.Click();
            var files = WorkWaveOrders.FilesUploadDialog.FilesAttached.AllPageData().ToList();
            files.Count.VerifyEquals(expectedImageCount);
        }

        public void ValidateFileNamePrefix(string shipmentNumber, string orderId, int expectedImageCount = 2,
            int expectedSignatureCount = 1)
        {
            OpenShipmentByNumber(shipmentNumber);
            //if (!WorkWaveOrders.Columns.WWOrderID.IsVisible())
            //{
            //    WorkWaveOrders.Columns.WWOrderID.ShowColumn();
            //}
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderID.Value.Equals(orderId));
            if (foundOrder == null)
                throw new Exception($"Order is not found by order id: {orderId}");
            Log.Information("Validate a count of images and signature");
            WorkWaveOrders.SelectRow(WorkWaveOrders.Columns.WWOrderID, foundOrder.WWOrderID.Value);
            WorkWaveOrders.Row.Files.Click();
            var files = WorkWaveOrders.FilesUploadDialog.FilesAttached.AllPageData().ToList();
            files.Count.VerifyEquals(expectedImageCount + expectedSignatureCount);
            var images = files.Where(r => r.FileName.Value.StartsWith("pic")).ToList();
            images.Count.VerifyEquals(expectedImageCount);
            var signatures = files.Where(r => r.FileName.Value.StartsWith("sig")).ToList();
            signatures.Count.VerifyEquals(expectedSignatureCount);
        }

        public void ValidateFileComment(string shipmentNumber, string orderId, WorkWaveExecutionEventDataHelper dataHelper)
        {
            OpenShipmentByNumber(shipmentNumber);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            var foundOrder = workWaveOrderList.FirstOrDefault(r => r.WWOrderID.Value.Equals(orderId));
            if (foundOrder == null)
                throw new Exception($"Order is not found by order id: {orderId}");
            Log.Information("Validate file comments");
            var fileTypeList = new List<string>() { "podPicture", "podSignature" };
            var fileDataList = dataHelper.SetEventDeliveryFiles(orderId, null, null)
                .Where(r=>fileTypeList.Contains(r.Type)).ToList();
            WorkWaveOrders.SelectRow(WorkWaveOrders.Columns.WWOrderID, foundOrder.WWOrderID.Value);
            WorkWaveOrders.Row.Files.Click();
            var files = WorkWaveOrders.FilesUploadDialog.FilesAttached.AllPageData().ToList();
            foreach (var fileData in fileDataList)
            {
                var foundFileByCommentText = files.FirstOrDefault(r => r.Comment.Value.Equals(fileData.Data.Text.ToString()));
                if (foundFileByCommentText == null)
                    throw new Exception($"File record is not found by comment: {fileData.Data.Text.ToString()}");
            }

        }

        public void DeleteWorkWaveOrder(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Wait the enabled Actions/Delete WorkWave Order button");
            WaitBase.WaitForCondition(() => ToolBar.DeleteWWOrder.IsEnabled(), WaitBase.LongTimeOut);
            DeleteWWOrder();
            Log.Information("Wait the displayed message box with warning");
            WaitBase.WaitForCondition(() => MessageBox.Buttons.Yes.IsVisible() && MessageBox.Buttons.Yes.IsEnabled(),
                WaitBase.LongTimeOut);
            var actualWarning = MessageBox.Message.GetValue().ToString();
            actualWarning.VerifyEquals(_warningWorkWaveOrderDeletion);
            MessageBox.Yes();
            Log.Information("Wait the hidden Yes button");
            WaitBase.WaitForCondition(() => !MessageBox.Buttons.Yes.IsVisible(), WaitBase.LongTimeOut);
            Log.Information("Wait the successful operation");
            WaitBase.WaitForCondition(() => ToolBar.LongRun.GetValue().ToString().Equals("The operation has completed."), WaitBase.LongTimeOut);
        }

        public void CheckDisabledAction(string shipmentNumber, ToolBarButton actionBarButton)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information($"Validate disabled action/button: {actionBarButton.ControlName}");
            if (actionBarButton.IsEnabled())
                throw new Exception($"Action is enabled: {actionBarButton.ControlName}");
        }

        public void DeleteWorkWaveShipment(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Wait the enabled Actions/Delete Shipment button");
            WaitBase.WaitForCondition(() => ToolBar.DeleteShipment.IsEnabled(), WaitBase.LongTimeOut);
            DeleteShipment();
            Log.Information("Wait the displayed message box with warning");
            WaitBase.WaitForCondition(() => MessageBox.Buttons.Yes.IsVisible() && MessageBox.Buttons.Yes.IsEnabled(),
                WaitBase.LongTimeOut);
            var actualWarning = MessageBox.Message.GetValue().ToString();
            actualWarning.VerifyEquals(_warningShipmentDeletion);
            MessageBox.Yes();
            Log.Information("Wait the hidden Yes button");
            WaitBase.WaitForCondition(() => !MessageBox.Buttons.Yes.IsVisible(), WaitBase.LongTimeOut);
        }

        public void CancelWorkWaveOrder(string shipmentNumber, string orderId)
        {
            OpenShipmentByNumber(shipmentNumber);
            WorkWaveOrders.SelectRow(WorkWaveOrders.Columns.WWOrderID, orderId);
            WorkWaveOrders.Row.Selected.Set(true);
            Log.Information("Wait the enabled Actions/Cancel Order button");
            WaitBase.WaitForCondition(() => ToolBar.CancelOrder.IsEnabled(), WaitBase.LongTimeOut);
            CancelOrder();
            Log.Information("Wait the displayed message box with warning");
            WaitBase.WaitForCondition(() => MessageBox.Buttons.Yes.IsVisible() && MessageBox.Buttons.Yes.IsEnabled(),
                WaitBase.LongTimeOut);
            var actualWarning = MessageBox.Message.GetValue().ToString();
            actualWarning.VerifyEquals(_warningOrderCanceling);
            MessageBox.Yes();
            Log.Information("Wait the hidden Yes button");
            WaitBase.WaitForCondition(() => !MessageBox.Buttons.Yes.IsVisible(), WaitBase.LongTimeOut);
        }

        public void CheckDisabledCancelOrderAction(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            if (ToolBar.CancelOrder.IsEnabled())
                throw new Exception($"Cancel Order must be disabled for shipment: {shipmentNumber}");
        }

        public void AssertCanceledOrderState(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            var shipmentStatus = MainForm.Status.GetValue();
            shipmentStatus.VerifyEquals(_openStatus);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (workWaveOrderList.Any())
                throw new Exception("WorkWave orders are found after canceling");
        }

        public void RemoveDocumentDetail(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information("Remove all document details");
            var rows = DocumentDetailsGrid.AllPageData().ToList();
            foreach (var item in rows)
            {
                DocumentDetailsGrid.SelectRow(DocumentDetailsGrid.Columns.InventoryID, item.InventoryID.Value);
                DocumentDetailsGrid.RemoveRow();
            }
            SaveChanges();
        }

        public void ValidateConfirmedShipment(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            ToolBar.CreateWokWaveOrder.IsVisible().VerifyEquals(false);
            MainForm.Status.GetValue().VerifyEquals("Confirmed");
        }

        public Dictionary<string, dynamic> GetDataForWorkWaveLabelReport(string shipmentNumber)
        {
            Log.Information("Get data for WorkWave Label report");
            OpenShipmentByNumber(shipmentNumber);
            var packages = GetPackageRows();
            var packageBoxIdList = new List<string>();
            foreach (var item in packages)
            {
                packageBoxIdList.Add(item.BoxID.Value);
            }

            var shipmentDate = Convert.ToDateTime(MainForm.ShipDate.GetValue().ToString());
            var shippedWeight = Math.Round(Convert.ToDouble(MainForm.ShipmentWeight.GetValue().ToString()), 2);
            var resultDict = new Dictionary<string, dynamic>()
            {
                {"ShipmentNumber", MainForm.ShipmentNbr.GetValue().ToString()},
                {"ShipmentDate", shipmentDate.ToString("M/d/yyyy")},
                {"ShipViaDescription", ShippingSettings.ShipVia.GetValue().ToString().Split('-').Last().Trim()},
                {"CustomerDescription", MainForm.CustomerID.GetValue().ToString().Split('-').Last().Trim()},
                {"WarehouseId", MainForm.SiteID.GetValue().ToString().Split('-').First().Trim()},
                {"ShippedQty", MainForm.ShipmentQty.GetValue().ToString().Split('.').First()},
                {"ShippedWeight", shippedWeight.ToString("0.0")},
                {"Packages", packageBoxIdList},
                {"ShipToAddressLine1", ShipToAddress.AddressLine1.GetValue().ToString()},
                {"ShipToAddressLine2", ShipToAddress.AddressLine2.GetValue().ToString()},
                {"ShipToCity", ShipToAddress.City.GetValue().ToString()},
                {"ShipToCountry", ShipToAddress.CountryID.GetValue().ToString().Split('-').Last()},
                {"ShipToState", ShipToAddress.State.GetValue().ToString().Split('-').First()},
                {"ShipToPostalCode", ShipToAddress.PostalCode.GetValue().ToString()},
            };
            var shipFromDict = GetWarehouseAddressByShipmentNumber(shipmentNumber);
            shipFromDict.ToList().ForEach(x => resultDict.Add(x.Key, x.Value));
            return resultDict;
        }

        public Dictionary<string, dynamic> GetWarehouseAddressByShipmentNumber(string shipmentNumber)
        {
            Log.Information("Get the Warehouse Address Details");
            OpenShipmentByNumber(shipmentNumber);
            var warehouseId = MainForm.SiteID.GetValue().ToString().Split('-').First().Trim();
            INSiteMaint warehouseScreenMaint = new INSiteMaint();
            var warehouseAddressDetail = warehouseScreenMaint.GetFullAddressDetail(warehouseId);
            return new Dictionary<string, dynamic>()
            {
                {"ShipFromAddressLine1", warehouseAddressDetail.AddressLine1},
                {"ShipFromAddressLine2", warehouseAddressDetail.AddressLine2},
                {"ShipFromCity", warehouseAddressDetail.City},
                {"ShipFromCountry", warehouseAddressDetail.Country.Split('-').Last()},
                {"ShipFromState", warehouseAddressDetail.State.Split('-').First()},
                {"ShipFromPostalCode", warehouseAddressDetail.PostalCode},
            };
        }

        public void PrintLabelsByShipmentId(string shipmentNumber)
        {
            Log.Information($"Print Labels for shipment: {shipmentNumber}");
            int previousWinCount = Browser.WebDriver.WindowHandles.Count;
            OpenShipmentByNumber(shipmentNumber);
            PrintLabels();
            Thread.Sleep(_timeout / 3);
            if (MessageBox.Buttons.Ok.IsVisible())
            {
                WaitBase.WaitForCondition(() => MessageBox.Buttons.Ok.IsEnabled(), WaitBase.LongTimeOut);
                MessageBox.Ok();
            }
            Thread.Sleep(_timeout / 3);
            Log.Information("Wai the next browser window");
            WaitBase.WaitForCondition(() => Browser.WebDriver.WindowHandles.Count.Equals(previousWinCount + 1), _timeout / 3);
            Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.Last());
            var workWaveLabelsReport = new WorkWaveLabelsReport();
            Log.Information("Wait the Carrier Label screen with report");
            WaitBase.WaitForCondition(
                () => workWaveLabelsReport.ToolBar.Print.IsVisible() && workWaveLabelsReport.ToolBar.Print.IsEnabled(),
                WaitBase.LongTimeOut);
        }

        public void CloseNextWindow()
        {
            Browser.WebDriver.Close();
            Log.Information("Wait a closing of the new browser window");
            WaitBase.WaitForCondition(() => Browser.WebDriver.WindowHandles.Count.Equals(1), _timeout / 3);
            Browser.WebDriver.SwitchTo().Window(Browser.WebDriver.WindowHandles.First());
        }

        public void SetTimeWindowInputs(string shipmentNumber, string timeWindowStart, string timeWindowEnd)
        {
            Log.Information($"Set Time Window Start and End inputs for Shipment: {shipmentNumber}");
            OpenScreen();
            MainForm.ShipmentNbr.Select(shipmentNumber);
            ShippingSettings.UsrWWStartSec.Select(timeWindowStart);
            ShippingSettings.UsrWWEndSec.Select(timeWindowEnd);
            SaveChanges();
        }

        public void AssertTimeWindowsInputs(string shipmentNumber, string timeWindowStartString, string timeWindowEndString)
        {
            Log.Information($"Validate Time Window Start and End inputs for Shipment: {shipmentNumber}");
            OpenScreen();
            MainForm.ShipmentNbr.Select(shipmentNumber);
            var timeWindowStart = ShippingSettings.UsrWWStartSec.GetValue().ToString();
            var timeWindowEnd = ShippingSettings.UsrWWEndSec.GetValue().ToString();
            var expectedTimeWindowStartList = timeWindowStartString.Split(' ').ToList();
            var expectedTimeWindowEndList = timeWindowEndString.Split(' ').ToList();
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.First());
            timeWindowStart.VerifyContains(expectedTimeWindowStartList.Last());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.First());
            timeWindowEnd.VerifyContains(expectedTimeWindowEndList.Last());
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

        public void ValidateWorkWaveOrderTrackingURL(string shipmentNumber)
        {
            OpenShipmentByNumber(shipmentNumber);
            var workWaveOrderList = GetWorkWaveOrderRows();
            if (!workWaveOrderList.Any())
                throw new Exception("WorkWave Orders are not found");
            if (workWaveOrderList.Count > 1)
                throw new Exception($"Expected behavior: one order is created. Actual: system creates {workWaveOrderList.Count} orders");
            Log.Information($"Validate the WorkWave order: Tracking URL");
            var firstRecord = workWaveOrderList.First();
            var trackingURL = firstRecord.WWTrackingURL.Value;
            if (string.IsNullOrEmpty(trackingURL))
                Log.Error("Tracking URL is empty");
            Log.Information($"Tracking URL: {trackingURL}");
        }

        public void AssertFreightRates(string shipmentNumber, double rate)
        {
            OpenShipmentByNumber(shipmentNumber);
            Log.Information($"Validate the Freight Rates: {rate}. Shipment Number: {shipmentNumber}");
            var freightCost = Convert.ToDouble(ShippingSettings.CuryFreightCost.GetValue().ToString());
            if (!freightCost.Equals(rate))
                Log.Error($"Freight Cost: Actual: {freightCost}. Expected: {rate}");
            var freightPrice = Convert.ToDouble(ShippingSettings.CuryFreightAmt.GetValue().ToString());
            if (!freightPrice.Equals(rate))
                Log.Error($"Freight Price: Actual: {freightPrice}. Expected: {rate}");
        }

        public double GetShippedVolume(string shipmentNumber)
        {
            Log.Information($"Get the Shipped Volume for shipment: {shipmentNumber}");
            OpenShipmentByNumber(shipmentNumber);
            var volume = Convert.ToDouble(MainForm.ShipmentVolume.GetValue());
            Log.Information($"Shipped Volume: {volume}");
            return volume;
        }
    }
}
