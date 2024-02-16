using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Controls.Editors.Selector;
using Controls.Input;
using Core.TestExecution;
using Core.Config;
using Core.Core.Browser;
using Core.Log;
using Core.Login;
using OpenQA.Selenium;
using PX.QA.Tools;
using static System.String;
using Controls.CheckBox;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CheckBox = Controls.CheckBox.CheckBox;
using WorkWaveIntegrationQA.Tests.Extensions;
using WorkWaveIntegrationQA.Tests.WebhookRestClient;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.Helpers;
using Core;
using System.IO;

namespace WorkWaveIntegrationQA.Tests.TestsBase
{
    public abstract class TestBase : Check
    {
        protected static OrderEntry SalesOrderEntry => new OrderEntry();
        protected static ShipmentEntry Shipment => new ShipmentEntry();
        protected static FeaturesMaint Features => new FeaturesMaint();
        protected static WebhookMaint WebhookMaint => new WebhookMaint();
        protected static CarrierPluginMaint CarrierPluginMaint => new CarrierPluginMaint();
        protected static CarrierMaint CarrierMaint => new CarrierMaint();
        protected static WorkWaveShipmentSummary WorkWaveShipmentSummary => new WorkWaveShipmentSummary();
        protected static INSiteMaint INSiteMaint => new INSiteMaint();
        protected static CustomerMaint CustomerMaint => new CustomerMaint();
        protected static BranchMaint BranchMaint => new BranchMaint();
        protected static OrganizationMaint OrganizationMaint => new OrganizationMaint();
        protected static ShipmentGeneric ShipmentGeneric => new ShipmentGeneric();
        protected static InvoiceShipment InvoiceShipment => new InvoiceShipment();
        protected static WorkWavePODReport WorkWavePODReport => new WorkWavePODReport();
        protected static PickPackShipHost PickPackShipHost => new PickPackShipHost();
        protected static WorkWaveLabelsReport WorkWaveLabelsReport => new WorkWaveLabelsReport();
        protected static AdjustmentEntry AdjustmentEntry => new AdjustmentEntry();
        protected static CustomerClassMaint CustomerClassMaint => new CustomerClassMaint();
        protected static CustomerLocationMaint CustomerLocationMaint => new CustomerLocationMaint();

        protected WebhookRequestsDataHelper WebhookRequestsDataHelper;
        protected AcumaticaWebhookDataHelper AcumaticaWebhookDataHelper;
        protected WorkWaveOrderDataHelper WorkWaveOrderDataHelper;
        protected WorkWaveVehicleDataHelper WorkWaveVehicleDataHelper;
        protected WorkWaveRouteDataHelper WorkWaveRouteDataHelper;
        protected WorkWaveExecutionEventDataHelper WorkWaveExecutionEventDataHelper;
        private int _timeout = 5000;

        protected TestBase()
        {
            WebhookRequestsDataHelper = WebhookApiService.WebhookRequestsDataHelper;
            AcumaticaWebhookDataHelper = WebhookApiService.AcumaticaWebhookDataHelper;
            WorkWaveOrderDataHelper = WorkWaveApiService.WorkWaveOrderDataHelper;
            WorkWaveVehicleDataHelper = WorkWaveApiService.WorkWaveVehicleDataHelper;
            WorkWaveRouteDataHelper = WorkWaveApiService.WorkWaveRouteDataHelper;
            WorkWaveExecutionEventDataHelper = WorkWaveApiService.WorkWaveExecutionEventDataHelper;
        }

        public override void BeforeExecute()
        {
            //Only needs to be run once after updating the project version or customization project. Path: \WorkWaveIntegrationQA.Tests\NewWrappers
            //GenerateWrappers();

            Log.Information(
                $"Login by Username: {Config.SITE_DST_LOGIN}, Password: {Config.SITE_DST_PASSWORD} (URL: {Config.SITE_DST_URL})");
            PxLogin.LogIn(Config.SITE_DST_URL, Config.SITE_DST_LOGIN, Config.SITE_DST_PASSWORD);
            CleanUpWorkWaveOrders();
        }

        public override void AfterExecute()
        {
            Log.Information("Stop all browser windows");
            Browser.Stop();
            base.AfterExecute();
        }

        public void CleanUpWorkWaveOrders()
        {
            Log.Information("Cleanup existing orders");
            var orders = WorkWaveOrderDataHelper.GetOrderList();
            foreach (var order in orders)
            {
                WorkWaveOrderDataHelper.RemoveOrder(order.Id);
                Thread.Sleep(_timeout);
            }
        }

        public string CreateSalesOrderAndShipment(string customerID = "AACUSTOMER", string inventoryID = "AACOMPUT01",
            string quantity = "1", string shipVia = "WW")
        {
            Log.Information("Create the Sales order and linked shipment");
            var salesOrderNumber = SalesOrderEntry.CreateNewSalesOrder(customerID, inventoryID, quantity, shipVia);
            var shipmentNumber = SalesOrderEntry.CreateShipmentEntry(salesOrderNumber);
            return shipmentNumber;
        }

        public string CreateSalesOrderAndShipment(List<Dictionary<string, dynamic>> inventoryItemList, string customerID = "AACUSTOMER", string shipVia = "WW")
        {
            Log.Information("Create the Sales order and linked shipment");
            var salesOrderNumber = SalesOrderEntry.CreateNewSalesOrder(inventoryItemList, customerID, shipVia);
            var shipmentNumber = SalesOrderEntry.CreateShipmentEntry(salesOrderNumber);
            return shipmentNumber;
        }

        public string CreateSalesOrder(List<Dictionary<string, dynamic>> inventoryItemList, string customerID = "AACUSTOMER", string shipVia = "WW")
        {
            Log.Information("Create the Sales order");
            var salesOrderNumber = SalesOrderEntry.CreateNewSalesOrder(inventoryItemList, customerID, shipVia);
            return salesOrderNumber;
        }

        public string CreateWorkWaveOrder(string number)
        {
            return Shipment.CreateNewWorkWaveOrder(number);
        }

        public string GetRequestId(string shipmentNumber)
        {
            return Shipment.GetRequestIdFromWorkWaverOrder(shipmentNumber);
        }

        public void AssertShipmentErrorMessage(string shipmentNumber)
        {
            Shipment.AssertErrorMessageWorkWaveOrderCreation(shipmentNumber);
        }

        public void AssertAbsenceOfWorkWaveOrders(string shipmentNumber)
        {
            Shipment.ValidateAbsenceOfWorkWaveOrders(shipmentNumber);
        }

        public void AssertWorkWaveOrder(string number, string shipmentStatus, Dictionary<string, string> expectedData)
        {
            Shipment.ValidateWorkWaveOrderAndShipment(number, shipmentStatus, expectedData);
        }

        public void AssertWorkWaveOrderList(string number, string shipmentStatus,
            List<Dictionary<string, string>> expectedData)
        {
            Shipment.ValidateWorkWaveOrderListAndShipment(number, shipmentStatus, expectedData);
        }

        public List<string> GetWorkWaveOrderIdList(string number)
        {
            return Shipment.GetWorkWaveOrderIdList(number);
        }

        public void GetUpdatedDeliveryStatus(string number, int timeout = 0)
        {
            Shipment.GetUpdatedDeliveryStatus(number, timeout);
        }

        public string GetGPSByOrderId(string shipmentNumber, string orderId)
        {
            return Shipment.GetTheWorkWaveGPSValue(shipmentNumber, orderId);
        }

        public void AssertAbsenceOfFilesAndNotes(string shipmentNumber, string orderId)
        {
            Shipment.ValidateAbsenceOfFilesAndNoteForOrderId(shipmentNumber, orderId);
        }

        public void AssertFilesAndNotes(string shipmentNumber, string orderId, string notes, int imageCount)
        {
            Shipment.ValidateFilesAndNoteForOrderId(shipmentNumber, orderId, notes, imageCount);
        }

        public void AssertFilePrefix(string shipmentNumber, string orderId, int expectedImageCount = 2,
            int expectedSignatureCount = 1)
        {
            Shipment.ValidateFileNamePrefix(shipmentNumber, orderId, expectedImageCount, expectedSignatureCount);
        }

        public void AssertFileComment(string shipmentNumber, string orderId)
        {
            Shipment.ValidateFileComment(shipmentNumber, orderId, WorkWaveExecutionEventDataHelper);
        }

        public Dictionary<string, dynamic> GetWebhookContentByGuid(
            string requestId = "866e469f-25cf-44f6-903c-e525193823a8")
        {
            Thread.Sleep(_timeout * 10);
            return WebhookRequestsDataHelper.GetContentByGuid(requestId);
        }

        public void UpdateWorkWaveOrder(Dictionary<string, object> content)
        {
            var url = GetUrlForAcumaticaWebhook();
            AcumaticaWebhookDataHelper.UpdateWorWaveOrder(url, content);
        }

        public void RemoveWorkWaveOrder(string orderId)
        {
            Log.Information($"Remove the WorkWave order: {orderId}");
            var removed = WorkWaveOrderDataHelper.RemoveOrder(orderId);
        }

        public void AssertRemovedWorkWaveOrder(string orderId)
        {
            Log.Information($"Validate removed order by Api: {orderId}");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            if (order.Id != null)
                throw new Exception($"Removed order is found: {orderId}");
        }

        public void AssertWorkWaveOrder(string orderId)
        {
            Log.Information("Validate parameters of WorkWave order: Unassigned status, " +
                            "one has with Pick-up order type and another one has Drop-off order type");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            order.ForceVehicleId.VerifyEquals(null);
            if (order.Pickup == null)
                throw new Exception($"Pick Up is not defined for order {orderId}");
            if (order.Delivery == null)
                throw new Exception($"Delivery is not defined for order {orderId}");
        }

        public void AssertWorkWaveAddresses(string orderId, AddressDetail expectedPickupAddressDetail, AddressDetail expectedDeliveryAddressDetail)
        {
            Log.Information("Validate addresses of the WorkWave order");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            Log.Information("Validate the pick-up address");
            var actualPickUpAddress = order.Pickup.Location.Address;
            actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.AddressLine1);
            if (!string.IsNullOrEmpty(expectedPickupAddressDetail.AddressLine2))
                actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.AddressLine2);
            actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.City);
            actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.Country);
            actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.State);
            actualPickUpAddress.VerifyContains(expectedPickupAddressDetail.PostalCode);

            Log.Information("Validate the delivery address");
            var actualDeliveryAddress = order.Delivery.Location.Address;
            actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.AddressLine1);
            if (!string.IsNullOrEmpty(expectedDeliveryAddressDetail.AddressLine2))
                actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.AddressLine2);
            actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.City);
            actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.Country);
            actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.State);
            actualDeliveryAddress.VerifyContains(expectedDeliveryAddressDetail.PostalCode);
        }

        public void AssertWorkWaveOrderAddress(string orderId)
        {
            Log.Information("Validate parameters of WorkWave order: Unassigned status, " +
                            "one has with Pick-up order type and another one has Drop-off order type");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            order.ForceVehicleId.VerifyEquals(null);
            if (order.Pickup == null)
                throw new Exception($"Pick Up is not defined for order {orderId}");
            if (order.Delivery == null)
                throw new Exception($"Delivery is not defined for order {orderId}");
        }

        public string SetVehicleByWorkWaveApi(string orderId, string externalId = "Vehicle 1")
        {
            Log.Information($"Set the vehicle for order id: {orderId}");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            var vehicleId = WorkWaveVehicleDataHelper.GetIdByExternalId(externalId);
            WorkWaveOrderDataHelper.SetVehicle(order, vehicleId);
            return vehicleId;
        }

        public void BuildAndApproveRoutes()
        {
            Log.Information("Build routes by DateTime.Now");
            var dateString = DateTime.Now.ToString("yyyyMMdd");
            Dictionary<string, string> dateDictionary = new Dictionary<string, string>()
            {
                {"from", dateString },
                {"to", dateString }
            };
            WorkWaveRouteDataHelper.DefineRoutes(dateDictionary);
            Log.Information($"Approve routes for date string: {dateString}");
            WorkWaveRouteDataHelper.ApproveRoutes(dateString);
        }

        public void HandlePickUpAndDelivery(string orderId, string vehicleId, string dateString, bool uploadAttachments = true)
        {
            Log.Information("Handle the PickUp order");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventPickUp(orderId, vehicleId, dateString));
            if (uploadAttachments)
            {
                Log.Information("Upload note, signature and images for the Delivery Order");
                WorkWaveExecutionEventDataHelper.SetExecutionEvent(
                    WorkWaveExecutionEventDataHelper.SetEventDeliveryFiles(orderId, vehicleId, dateString));
            }
            Log.Information("Handle the Delivery order: timeIn, timeOut, statusUpdate");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventDelivery(orderId, vehicleId, dateString));
        }

        public void HandlePickUpAndDeliveryWithBarcode(string orderId, string vehicleId, string dateString, string barcode)
        {
            Log.Information("Handle the PickUp order");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventPickUp(orderId, vehicleId, dateString));
            Log.Information("Set the Unreadable Barcode");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventDeliveryBarcode(orderId, vehicleId, dateString, barcode));
            Log.Information("Upload note, signature and images for the Delivery Order");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventDeliveryFiles(orderId, vehicleId, dateString));
            Log.Information("Handle the Delivery order: timeIn, timeOut, statusUpdate");
            WorkWaveExecutionEventDataHelper.SetExecutionEvent(WorkWaveExecutionEventDataHelper.SetEventDelivery(orderId, vehicleId, dateString));
        }

        public void EnableWorkWaveFeature()
        {
            Log.Information($"Enable the feature: {Features.Summary.RouteOptimizer.ControlName}");
            Features.ActivateFeature(Features.Summary.RouteOptimizer, true);
        }

        public string GetUrlForAcumaticaWebhook(string webhookName = "WWTest")
        {
            return WebhookMaint.GetUrlByWebhookName(webhookName);
        }

        public void AssertWorkWaveCarrier(string apiKey = "615b4b7b-c597-42bd-95d5-661f4e6408aa", string territory = "API DEMO")
        {
            Log.Information("Validate the WorkWave carrier's creation");
            var carrier = CarrierPluginMaint.GenerateTestCarrier(apiKey, territory);
            CarrierPluginMaint.CreateNewWorkWaveCarrier(carrier);
            TestConnection(carrier.CarrierId);
            Log.Information("Set the Ship Via Code");
            var shipViaCode = CarrierMaint.GenerateShipViaCode();
            var dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            shipViaCode.Description = $"WorkWave_{dateString}";
            CarrierMaint.CreateUpdateShipViaCode(shipViaCode);
            Log.Information("Check quantities of inventory items");
            AddInventoryItemQuantities();
        }

        public void AssertUniqueCombinationWorkWaveTerritory()
        {
            Log.Information("Validate the WorkWave Territory combination");
            var carrier = CarrierPluginMaint.GenerateTestCarrier();
            var newTerritory = new CarrierWorkWaveTerritory()
            {
                Company = "PRODUCTS",
                Branch = "PRODWHOLE",
                Warehouse = "",
                Territory = "API DEMO",
                Active = true
            };
            carrier.CarrierWorkWaveTerritories.Add(newTerritory);
            CarrierPluginMaint.CreateNewWorkWaveCarrier(carrier);
            var existingTerritory = new CarrierWorkWaveTerritory()
            {
                Company = "PRODUCTS",
                Branch = "PRODWHOLE",
                Warehouse = "WHOLESALE",
                Territory = "API DEMO",
                Active = false
            };
            CarrierPluginMaint.CheckErrorMessageDuplicateWorkWaveTerritory(existingTerritory);
            carrier.CarrierWorkWaveTerritories.Remove(newTerritory);
            CarrierPluginMaint.CreateNewWorkWaveCarrier(carrier);
        }

        public void TestConnection(string carrierId = "WW")
        {
            CarrierPluginMaint.TestConnection(carrierId);
        }

        public void AssertShipViaCode()
        {
            Log.Information("Validate the WorkWave ship via code");
            var shipViaCode = CarrierMaint.GenerateShipViaCode();
            var dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            shipViaCode.Id = $"WW{dateString}";
            shipViaCode.Description = $"WorkWave_{dateString}";
            CarrierMaint.CreateUpdateShipViaCode(shipViaCode);
            CarrierMaint.DeleteShipViaCodeById(shipViaCode.Id);
            Log.Information("Validate the update");
            shipViaCode = CarrierMaint.GenerateShipViaCode();
            shipViaCode.Description = $"WorkWave_{dateString}";
            CarrierMaint.CreateUpdateShipViaCode(shipViaCode);
        }

        public void AssertContentForOrderDeletion(Dictionary<string, dynamic> actualContent, string orderId)
        {
            var data = actualContent["Content"]["data"];
            List<dynamic> createdList = data["created"].ToObject<List<dynamic>>();
            if (createdList.Any())
                throw new Exception("Created list is not empty");
            List<dynamic> updatedList = data["updated"].ToObject<List<dynamic>>();
            if (updatedList.Any())
                throw new Exception("Updated list is not empty");
            List<string> deletedList = data["deleted"].ToObject<List<string>>();
            if (!deletedList.Any())
                throw new Exception("Deleted list is empty");
            var foundRecord = deletedList.FirstOrDefault(r => r.Equals(orderId));
            if (foundRecord == null)
                throw new Exception($"Record is not found: {orderId}");
        }

        public void SetBarcodeLimit(string option = "Split")
        {
            CarrierPluginMaint.SetBarcodeLimit(barcodeLimitOption: option);
        }

        public void SetShipmentPackage(string shipmentNumber, int quantity = 11)
        {
            Shipment.SetPackages(shipmentNumber, quantity);
        }

        public void AssertWorkWaveShipmentSummaryEmptyFilters()
        {
            WorkWaveShipmentSummary.AssertEmptyFilters();
        }

        public void AssertWorkWaveShipmentSummaryCustomerFilter(string customer = "AACUSTOMER")
        {
            WorkWaveShipmentSummary.AssertCustomerFilter(customer);
        }

        public void AssertWorkWaveShipmentSummaryCustomerFilterWithoutWorkWaveIntegration(string customer = "ARTCAGES")
        {
            WorkWaveShipmentSummary.AssertCustomerFilterWithoutWorkWaveIntegration(customer);
        }

        public void AssertWorkWaveShipmentSummaryDeliveryStatusFilter()
        {
            foreach (var item in WorkWaveShipmentSummary.ExpectedDeliveryStatusList)
            {
                WorkWaveShipmentSummary.AssertStatusFilter(item);
            }
        }

        public void AssertWorkWaveShipmentSummaryShipmentNumberFilter()
        {
            var shipmentNumber = WorkWaveShipmentSummary.GetShipmentNumberWithWorkWaveOrder();
            WorkWaveShipmentSummary.AssertShipmentNumberFilter(shipmentNumber);
        }

        public void CancelWorkWaveOrder(string shipmentNumber, string orderId)
        {
            Shipment.CancelWorkWaveOrder(shipmentNumber, orderId);
        }

        public void AssertCanceledOrder(string shipmentNumber)
        {
            Shipment.AssertCanceledOrderState(shipmentNumber);
        }

        public void AssertDisabledCancelOrderAction(string shipmentNumber)
        {
            Shipment.CheckDisabledCancelOrderAction(shipmentNumber);
        }

        public void DeleteWorkWaveOrder(string shipmentNumber)
        {
            Shipment.DeleteWorkWaveOrder(shipmentNumber);
        }

        public void AssertDisabledActionDeleteShipment(string shipmentNumber)
        {
            Shipment.CheckDisabledAction(shipmentNumber, Shipment.ToolBar.DeleteShipment);
        }

        public void AssertDisabledActionDeleteWorkWaveOrder(string shipmentNumber)
        {
            Shipment.CheckDisabledAction(shipmentNumber, Shipment.ToolBar.DeleteWWOrder);
        }

        public void AssertDisabledActionCreateWorkWaveOrder(string shipmentNumber)
        {
            Shipment.CheckDisabledAction(shipmentNumber, Shipment.ToolBar.CreateWokWaveOrder);
        }

        public void AssertRemovedShipment(string shipmentNumber)
        {
            if (ShipmentGeneric.SearchShipment(shipmentNumber))
                throw new Exception($"Removed shipment is found: {shipmentNumber}");
        }

        public void DeleteWorkWaveShipment(string shipmentNumber)
        {
            Shipment.DeleteWorkWaveShipment(shipmentNumber);
        }

        public void SetCarrierPodParameters(Dictionary<string, bool> dataDictionary, string carrierId = "WW")
        {
            CarrierPluginMaint.SetPodParameters(dataDictionary, carrierId);
        }

        public List<string> GetBarcodeList(string orderId)
        {
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            var barcodeList = order.Delivery.Barcodes;
            if (!barcodeList.Any())
                throw new Exception($"Barcodes are not found for order: {orderId}");
            return barcodeList;
        }

        public void SetCarrierWorkWaveTerritory(CarrierWorkWaveTerritory dataWorkWaveTerritory, string carrierId = "WW")
        {
            CarrierPluginMaint.SetWorkWaveTerritory(dataWorkWaveTerritory, carrierId);
        }

        public void SetWarehouseAddressDetail(string warehouseId = "WHOLESALE")
        {
            var address = INSiteMaint.GenerateAddressDetail();
            INSiteMaint.SetAddress(warehouseId, address);
        }

        public void SetWarehouseAddressDetailNY(string warehouseId = "WHOLESALE")
        {
            var address = INSiteMaint.GenerateAddressDetailNY();
            INSiteMaint.SetAddress(warehouseId, address);
        }

        public AddressDetail GetWarehouseAddressDetail(string warehouseId = "WHOLESALE")
        {
            return INSiteMaint.GetAddressDetail(warehouseId);
        }

        public void SetCustomerAddressDetail(string customerId = "AACUSTOMER")
        {
            var address = CustomerMaint.GenerateAddressDetail();
            CustomerMaint.SetAddress(customerId, address);
        }

        public void SetCustomerAddressDetailNY(string customerId = "AACUSTOMER")
        {
            var address = CustomerMaint.GenerateAddressDetailNY();
            CustomerMaint.SetAddress(customerId, address);
        }

        public AddressDetail GetCustomerAddressDetail(string customerId = "AACUSTOMER")
        {
            return CustomerMaint.GetAddressDetail(customerId);
        }

        public void SetBranchAddressDetail(string branchId = "PRODWHOLE")
        {
            var address = BranchMaint.GenerateAddressDetail();
            BranchMaint.SetAddress(branchId, address);
        }

        public AddressDetail GetBranchAddressDetail(string branchId = "PRODWHOLE")
        {
            return BranchMaint.GetAddressDetail(branchId);
        }

        public void SetCompanyAddressDetail(string companyId = "PRODUCTS")
        {
            var address = OrganizationMaint.GenerateAddressDetail();
            OrganizationMaint.SetAddress(companyId, address);
        }

        public AddressDetail GetCompanyAddressDetail(string companyId = "PRODUCTS")
        {
            return OrganizationMaint.GetAddressDetail(companyId);
        }

        public void AssertAbsenceShipmentWithoutWorkWaveCarrier(string shipmentNumber, string actionName = "Create WorkWave Order")
        {
            var foundShipment = InvoiceShipment.SearchShipmentByNumber(shipmentNumber, actionName);
            if (foundShipment != null)
                throw new Exception("Shipment is found without WorkWave carrier");
        }

        public void AssertAbsenceShipmentWithoutDocumentDetails(string shipmentNumber, string actionName = "Create WorkWave Order")
        {
            var foundShipment = InvoiceShipment.SearchShipmentByNumber(shipmentNumber, actionName);
            if (foundShipment != null)
                throw new Exception("Shipment is found without document details");
        }

        public void ProcessShipment(string shipmentNumber, string actionName = "Create WorkWave Order", bool waitPanelContent = true, 
            bool waitNewWindow = false)
        {
            InvoiceShipment.ProcessShipment(shipmentNumber, actionName, waitPanelContent, waitNewWindow);
        }

        public void RemoveShipmentDocumentDetails(string shipmentNumber)
        {
            Shipment.RemoveDocumentDetail(shipmentNumber);
        }

        public string GenerateWorkWavePodReportFromPDF(ReportParameter parameters)
        {
            WorkWavePODReport.CreateReport(parameters);
            var contentPath = WorkWavePODReport.GetReportContentPathFromPdf();
            return contentPath;
        }
        public string GenerateWorkWavePodReportFromExcel(ReportParameter parameters)
        {
            WorkWavePODReport.CreateReport(parameters);
            return WorkWavePODReport.GetReportContentPathFromExcel();
        }

        public void AssertReportDeliveryStatus(string content, string workWaveIdSubstring)
        {
            var expectedStatusList = new List<string>() { "Delivered", "Delivered with Issue" };
            WorkWavePODReport.CheckDeliveryStatus(content, expectedStatusList, workWaveIdSubstring);
        }

        public void AssertReportAbsenceAttachments(string content)
        {
            WorkWavePODReport.CheckAbsenceAttachments(content);
        }

        public void AssertPODReportPages(string content, int pageAmount)
        {
            WorkWavePODReport.CheckReportPages(content, pageAmount);
        }

        public void AssertSinglePodReport(string content, ReportParameter parameters)
        {
            WorkWavePODReport.CheckSingleShipment(content, parameters);
        }

        public void AssertExcelPodReport(string expectedPath, string actualPath, string[] ignoredStrings)
        {
            WorkWavePODReport.CompareExcelFiles(expectedPath, actualPath, ignoredStrings);
        }

        public void AssertSinglePodReportShippedQty(string content, List<Dictionary<string, dynamic>> inventoryItemList)
        {
            WorkWavePODReport.CheckShippedQty(content, inventoryItemList);
        }

        public void AssertPodReportAttachmentValues(string content, List<string> valueList)
        {
            WorkWavePODReport.ValidateAttachmentValues(content, valueList);
        }

        public void AssertEmptyPodReport(string content)
        {
            int maxRow = 11;
            var rows = content.Split('\n').ToList();
            rows.Count.VerifyIsLessThanOrEqualTo(maxRow);
        }

        public void AssertNonEmptyPodReport(string content)
        {
            Log.Information("Validate the file existence");
            if (string.IsNullOrEmpty(content))
                Log.Error("PDF report is not found");
        }

        public void PickAndPackScanShipment(string shipmentNumber = "003850")
        {
            PickPackShipHost.ScanShipment(shipmentNumber);
        }

        public void AssertEnabledCreateWorkWaveOrderButtonPickAndPack()
        {
            PickPackShipHost.CheckToolBarButton(PickPackShipHost.ToolBar.CreateWorkWaveOrder);
        }

        public void AssertDisabledConfirmShipmentButtonPickAndPack()
        {
            PickPackShipHost.CheckToolBarButton(PickPackShipHost.ToolBar.ScanConfirmShipment, true, false);
        }

        public void AssertInvisibleCreateWorkWaveOrderButtonPickAndPack()
        {
            PickPackShipHost.CheckToolBarButton(PickPackShipHost.ToolBar.CreateWorkWaveOrder, false, false);
        }

        public void AssertEnabledConfirmShipmentButtonPickAndPack()
        {
            PickPackShipHost.CheckToolBarButton(PickPackShipHost.ToolBar.ScanConfirmShipment, true, true);
        }

        public void PickAndPackCreateWorkWaveOrder()
        {
            PickPackShipHost.CreateNewWorkWaveOrder();
        }

        public void PickAndPackCancelProcess()
        {
            PickPackShipHost.CancelProcess();
        }

        public string CreateSalesOrder(string customerID = "AACUSTOMER", string inventoryID = "AACOMPUT01",
            string quantity = "1", string shipVia = "WW")
        {
            Log.Information("Create the Sales order");
            var salesOrderNumber = SalesOrderEntry.CreateNewSalesOrder(customerID, inventoryID, quantity, shipVia);
            return salesOrderNumber;
        }

        public string QuickProcessSalesOrder(string orderNumber, bool withWorkWaveCarrier)
        {
            return SalesOrderEntry.QuickProcessByOrderNumber(orderNumber, withWorkWaveCarrier);
        }

        public void AssertConfirmedShipment(string shipmentNumber)
        {
            Shipment.ValidateConfirmedShipment(shipmentNumber);
        }

        public string PrintLabelsFromShipment(string shipmentNumber)
        {
            Shipment.PrintLabelsByShipmentId(shipmentNumber);
            var content = WorkWaveLabelsReport.GetReportContentFromExcel();
            Shipment.CloseNextWindow();
            return content;
        }

        public string PrintLabelsFromProcessShipment(string shipmentNumber, string action = "Print Labels")
        {
            ProcessShipment(shipmentNumber, action, false, true);
            var content = WorkWaveLabelsReport.GetReportContentFromExcel();
            InvoiceShipment.CloseNextWindow();
            return content;
        }
        public Dictionary<string, string> PrintLabelsFromSalesOrder(string orderNumber)
        {
            var shipmentNumber = SalesOrderEntry.QuickProcessPrintLabelByOrderNumber(orderNumber);
            var content = WorkWaveLabelsReport.GetReportContentFromExcel();
            return new Dictionary<string, string>()
            {
                {"ShipmentNumber", shipmentNumber},
                {"Content", content},
            };
        }

        public string GenerateWorkWaveLabelReportFromPDF(string shipmentNumber)
        {
            WorkWaveLabelsReport.CreateReport(shipmentNumber);
            var content = WorkWaveLabelsReport.GetReportContentFromPdf();
            return content;
        }
        public string GenerateWorkWaveLabelReportFromExcel(string shipmentNumber)
        {
            WorkWaveLabelsReport.CreateReport(shipmentNumber);
            return WorkWaveLabelsReport.GetReportContentFromExcel();
        }

        public Dictionary<string, dynamic> GetWorkWaveLabelReportData(string shipmentNumber)
        {
            return Shipment.GetDataForWorkWaveLabelReport(shipmentNumber);
        }

        public void AssertWorkWaveLabelReport(string reportContent, Dictionary<string, dynamic> expectedData, string barcodeDelimiter)
        {
            WorkWaveLabelsReport.ValidateReport(reportContent, expectedData, barcodeDelimiter);
        }

        public void AssertWorkWaveLabelReportExcelFiles(string expectedPath, string actualPath, string[] ignoredStrings = null )
        {
            WorkWaveLabelsReport.CompareExcelFiles(expectedPath, actualPath, ignoredStrings);
        }

        public void AssertWorkWaveLabelReportPdfPages(string reportContent)
        {
            WorkWaveLabelsReport.ValidateSubstringAmount(reportContent);
            WorkWaveLabelsReport.ValidateSubstringAmount(reportContent, pattern: @".*SHIP TO:.*\n");
            WorkWaveLabelsReport.ValidateSubstringAmount(reportContent, pattern: @".*SHIP FROM:.*\n");
        }

        public void AssertWorkWaveLabelReportWithoutPackages(string reportContent, Dictionary<string, dynamic> expectedData)
        {
            WorkWaveLabelsReport.ValidatePackagesAbsence(reportContent, expectedData);
        }
        public void AssertWorkWaveLabelReportDropDownList(string shipmentNumber)
        {
            WorkWaveLabelsReport.CheckAbsenceOfShipmentNumber(shipmentNumber);
        }

        public string GetCarrierWorkWaveLabelReportData(string carrierId = "WW")
        {
            return CarrierPluginMaint.GetBarcodeDelimiter(carrierId);
        }

        public string GetShipViaDescription(string id = "WW")
        {
            return CarrierMaint.GetDescription(id);
        }

        public string CreateShipment(string salesOrderNumber)
        {
            var shipmentNumber = SalesOrderEntry.CreateShipmentEntry(salesOrderNumber);
            return shipmentNumber;
        }

        public void AddShipmentPackage(string shipmentNumber, string boxId = "SMALL")
        {
            Shipment.AddPackage(shipmentNumber, boxId);
        }

        public void AddInventoryItemQuantities()
        {
            AdjustmentEntry.AddQuantityInventoryItems(AdjustmentEntry.GenerateInventoryItemQuantityList());
        }

        public string CreateNewCustomerClass(string classId)
        {
            var data = CustomerClassMaint.GenerateCustomerClassDetails(classId);
            CustomerClassMaint.CreateCustomerClass(data);
            return data.ClassId;
        }

        public void AssertCustomerClassDetailsTimeWindowInputs(string classId)
        {
            var data = CustomerClassMaint.GenerateCustomerClassDetails(classId);
            CustomerClassMaint.AssertTimeWindowsInputs(data);
        }

        public void RemoveCustomerClassById(string classId)
        {
            CustomerClassMaint.RemoveCustomerClass(classId);
        }

        public string CreateNewCustomer(string customerId, string classId)
        {
            var customerDetails = CustomerMaint.GenerateCustomerDetails(customerId, classId);
            CustomerMaint.CreateNewCustomer(customerDetails);
            return customerDetails.CustomerId;
        }

        public void AssertCustomerDetailsTimeWindowInputs(string customerId, string classId)
        {
            var customerDetails = CustomerMaint.GenerateCustomerDetails(customerId, classId);
            var customerClassDetails = CustomerClassMaint.GenerateCustomerClassDetails(classId);
            customerDetails.TimeWindowStart = customerClassDetails.TimeWindowStart;
            customerDetails.TimeWindowEnd = customerClassDetails.TimeWindowEnd;
            CustomerMaint.AssertTimeWindowsInputs(customerDetails);
        }

        public void RemoveCustomerById(string customerId)
        {
            CustomerMaint.RemoveCustomer(customerId);
        }

        public void CreateNewCustomerLocation(string customerId)
        {
            var data = CustomerLocationMaint.GenerateCustomerLocationDetails(customerId);
            CustomerLocationMaint.CreateNewCustomerLocation(data);
        }

        public void AssertCustomerLocationDetailsTimeWindowInputs(string customerId)
        {
            var data = CustomerLocationMaint.GenerateCustomerLocationDetails(customerId);
            CustomerLocationMaint.AssertTimeWindowsInputs(data);
        }

        public void SetDefaultLocationCustomer(string customerId)
        {
            var locationDetails = CustomerLocationMaint.GenerateCustomerLocationDetails(customerId);
            CustomerMaint.SetDefaultLocation(locationDetails.CustomerId, locationDetails.LocationId);
        }
        public void AssertCustomerDetailsTimeWindowInputsAfterSetDefaultLocation(string customerId, string classId)
        {
            var customerDetails = CustomerMaint.GenerateCustomerDetails(customerId, classId);
            var locationDetails = CustomerLocationMaint.GenerateCustomerLocationDetails(customerId);
            customerDetails.TimeWindowStart = locationDetails.TimeWindowStart;
            customerDetails.TimeWindowEnd = locationDetails.TimeWindowEnd;
            CustomerMaint.AssertTimeWindowsInputs(customerDetails);
        }
        public void SetDefaultLocationCustomerMain(string customerId)
        {
            var locationDetails = CustomerLocationMaint.GenerateCustomerLocationDetails(customerId);
            locationDetails.LocationId = "MAIN";
            CustomerMaint.SetDefaultLocation(locationDetails.CustomerId, locationDetails.LocationId);
        }

        public void UpdateCustomerClass(string customerId, string classId)
        {
            var customerDetails = CustomerMaint.GenerateCustomerDetails(customerId, classId);
            CustomerMaint.SetCustomerClass(customerDetails.CustomerId, "LOCAL");
            CustomerMaint.SetCustomerClass(customerDetails.CustomerId, customerDetails.CustomerClass);
        }

        public void AssertSalesOrderDetailsTimeWindowInputs(string orderNumber, string timeWindowStart, string timeWindowEnd)
        {
            SalesOrderEntry.AssertTimeWindowsInputs(orderNumber, timeWindowStart, timeWindowEnd);
        }

        public void SetTimeWindowInputsSalesOrder(string orderNumber, string timeWindowStart, string timeWindowEnd)
        {
            SalesOrderEntry.SetTimeWindowInputs(orderNumber, timeWindowStart, timeWindowEnd);
        }

        public void AssertShipmentDetailsTimeWindowInputs(string shipmentNumber, string timeWindowStart, string timeWindowEnd)
        {
            Shipment.AssertTimeWindowsInputs(shipmentNumber, timeWindowStart, timeWindowEnd);
        }

        public void SetTimeWindowInputsShipment(string shipmentNumber, string timeWindowStart, string timeWindowEnd)
        {
            Shipment.SetTimeWindowInputs(shipmentNumber, timeWindowStart, timeWindowEnd);
        }

        public void AssertWorkWaveOrderWithTimeWindows(string orderId, int startSec = 14400, int endSec = 57600)
        {
            Log.Information("Validate parameters of WorkWave order: Time Windows");
            var order = WorkWaveOrderDataHelper.GetOrderById(orderId);
            var timeWindows = order.Pickup.TimeWindows;
            if (!timeWindows.Any())
                throw new Exception("Time Windows is empty");
            var firstRecord = timeWindows.First();
            firstRecord.StartSec.VerifyEquals(startSec);
            firstRecord.EndSec.VerifyEquals(endSec);
        }

        public void AssertWorkWaveOrderTrackingURL(string number)
        {
            Shipment.ValidateWorkWaveOrderTrackingURL(number);
        }

        public void AddNewShipViaCodeForFreightRates(string id, bool removeEntity = false)
        {
            var shipViaCode = CarrierMaint.GenerateShipViaCode(id);
            var dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            shipViaCode.Description = $"{id}_{dateString}";
            CarrierMaint.CreateUpdateShipViaCode(shipViaCode);
            if (removeEntity)
                CarrierMaint.DeleteShipViaCodeById(shipViaCode.Id);
        }

        public void AssertFreightRatesFieldsShipViaCode(string id)
        {
            CarrierMaint.AssertFreightRatesFields(id);
        }

        public void UpdateCalculationMethodAndBaseRateShipViaCode(string id, string calculationMethod, double? baseRate = null)
        {
            CarrierMaint.UpdateCalculationMethod(id, calculationMethod, baseRate);
        }

        public void AssertFreightRatesShipment(string shipmentNumber, double rate)
        {
            Shipment.AssertFreightRates(shipmentNumber, rate);
        }

        public void AddFreightRateShipViaCodes(string id, double weight = 1.00, double volume = 1.00, string zoneId = "CENTRAL",
            double rate = 100.00)
        {
            CarrierMaint.AddFreightRate(id, weight, volume, zoneId, rate);
        }

        public void SetShippingZoneSalesOrder(string orderNumber, string shippingZone = "CENTRAL")
        {
            SalesOrderEntry.SetShippingZone(orderNumber, shippingZone);
        }

        public double GetFreightRateMultiplicationShipViaCode(string id, double volume, string zoneId = "CENTRAL")
        {
            return CarrierMaint.GetFreightRateMultiplication(id, volume, zoneId);
        }

        public double GetShippedVolumeShipment(string shipmentNumber)
        {
            return Shipment.GetShippedVolume(shipmentNumber);
        }

        public void SetFreightCostSalesOrder(string orderNumber, double cost = 200.00)
        {
            SalesOrderEntry.SetFreightCost(orderNumber, cost);
        }

        public void AssertShippingCarrierIntegrationEnableDisableFeature()
        {
            Features.AssertShippingCarrierIntegration();
        }

        public void AssertPlugInTypeDropDownListCarrierPluginMaint(string expectedValue, bool displayed = true)
        {
            CarrierPluginMaint.AssertPlugInTypeDropDownList(expectedValue, displayed);
        }

        public void SetCustomFeature(bool state)
        {
            Features.ActivateFeature(Features.Summary.CustomCarrierIntegration, state);
        }

        public void AssertShipmentNumberCarrierLabelHistory(string shipmentNumber)
        {
            Log.Information($"Validate the Carrier Label History for shipment: {shipmentNumber}");
            var sqlHelper = new SQLHelper();
            var data = sqlHelper.GetCarrierLabelHistory();
            if (!data.Any())
                throw new Exception("The CarrierLabelHistory table is empty");
            var foundRecord = data.FirstOrDefault(r => r.ShipmentNbr.Equals(shipmentNumber));
            if (foundRecord == null)
                throw new Exception($"Record is not found by ShipmentNbr: {shipmentNumber}");
            Log.Information(foundRecord.ToString());
        }

        public void GenerateWrappers()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string wrapperPath = String.Format(projectPath + @"\WorkWaveIntegrationQA.Tests\NewWrappers\");
            string physicalSitePath = @"C:\AcumaticaSites\23.102.0042\23.102.0042.webapp\Site";

            ClassGenerator.ClassGenerator WG = new ClassGenerator.ClassGenerator(physicalSitePath, wrapperPath)
            {
                Username = "admin",
                Namespace = "WorkWaveIntegrationQA.Tests.Wrappers",
            };

            // PL and GI screens are added like this, get the "URL" from the site map screen.
            WG.Screens.Add("GI640096", "~/GenericInquiry/GenericInquiry.aspx?id=563d2ae8-3704-4967-a49e-600ae6a2c097");
            WG.Screens.Add("SO3020PL", "~/GenericInquiry/GenericInquiry.aspx?id=563d2ae8-3704-4967-a49e-600ae6a2c097");
            WG.Screens.Add("SO611061", "~/Frames/ReportLauncher.aspx?ID=SO611061.rpx");
            WG.Screens.Add("SO645000", "~/Frames/ReportLauncher.aspx?ID=SO645000.rpx");

            WG.Run(string.Join(",",
                new[] {
                    "AR201000",
                    "AR303000",
                    "AR303020",

                    "CS100000",
                    "CS101500",
                    "CS102000",
                    "CS207500",
                    "CS207700",

                    "IN204000",
                    "IN303000",

                    "SM304000",

                    "SO301000",
                    "SO302000",
                    "SO302020",
                    "SO503000",
                })
            );
        }
    }
}
