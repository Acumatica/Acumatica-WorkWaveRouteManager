using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class CheckingWorkWavePODReport : TestBase
    {
        private string _reportContentAllShipments;
        private string _salesOrderNumber;
        private string _reportContent;
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        private string _expectedNotes = "Test Note 6";
        private int _expectedImageCount = 3;
        private string _inventoryId = "AACOMPUT01";
        private ReportParameter _parameters = new ReportParameter()
        {
            StartDate = "05/27/2021",
            EndDate = "05/27/2021",
            ShipmentNbr = "003844",
            CustomerId = "AACUSTOMER",
            Warehouse = "WHOLESALE",
            InventoryId = "AACOMPUT01",
            DriverNotes = true,
            GPS = true,
            Signature = true,
            Picture = true,
            Packages = true
        };
        private List<Dictionary<string, dynamic>> _inventoryItemList = new List<Dictionary<string, dynamic>>()
        {
            new Dictionary<string, dynamic>()
            {
                {"InventoryID", "AACOMPUT01"},
                {"OrderQty", 3.0}
            },
            new Dictionary<string, dynamic>()
            {
                {"InventoryID", "AAPOWERAID"},
                {"OrderQty", 2.0}
            },
        };
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Checking WorkWave POD Report"))
            {
                using (TestExecution.CreateTestStepGroup("Prepare data: a new shipment with the delivered WorkWave order"))
                {
                    PrepareProcessedWorkWaveOrder();
                    _parameters.ShipmentNbr = _shipmentNumber;
                    _parameters.StartDate = DateTime.Now.ToString("M/d/yyyy");
                    _parameters.EndDate = _parameters.StartDate;

                    //_parameters.ShipmentNbr = "005081";
                    //_parameters.StartDate = DateTime.Now.ToString("M/d/yyyy");
                    //_parameters.EndDate = _parameters.StartDate;
                    //_salesOrderNumber = "SO007506";
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Generate a default report"))
                {
                    _reportContentAllShipments = GenerateWorkWavePodReportFromPDF(new ReportParameter());
                    AssertNonEmptyPodReport(_reportContentAllShipments);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Verify Delivery Statuses"))
                {
                    _reportContentAllShipments = GenerateWorkWavePodReportFromExcel(new ReportParameter());
                    AssertNonEmptyPodReport(_reportContentAllShipments);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Generate a report with setting all parameters"))
                {
                    _parameters.DriverNotes = false;
                    _parameters.GPS = false;
                    _parameters.Signature = true;
                    _parameters.Picture = false;
                    _reportContent = GenerateWorkWavePodReportFromExcel(_parameters);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the report by filters"))
                {
                    string[] ignoredStrings = new[]
                    {
                        "005079 - Alta Ace", $"{_parameters.ShipmentNbr} - Alta Ace",
                        "005079", _parameters.ShipmentNbr,
                        "SO007504", _salesOrderNumber,
                    };
                    AssertExcelPodReport("TestData\\WorkWavePODReportSingle.xlsx", _reportContent, ignoredStrings);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Validate an empty report"))
                {
                    _parameters.InventoryId = "AALEGO500";
                    _parameters.DriverNotes = true;
                    _parameters.GPS = true;
                    _parameters.Signature = true;
                    _parameters.Picture = true;
                    _reportContent = GenerateWorkWavePodReportFromExcel(_parameters);
                    AssertExcelPodReport("TestData\\WorkWavePODReportEmpty.xlsx", _reportContent, null);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Validate the absence of attachments"))
                {
                    _parameters.InventoryId = _inventoryId;
                    _parameters.DriverNotes = false;
                    _parameters.GPS = false;
                    _parameters.Signature = false;
                    _parameters.Picture = false;
                    string[] ignoredStrings = new[]
                    {
                        "005079 - Alta Ace", $"{_parameters.ShipmentNbr} - Alta Ace",
                        "005079", _parameters.ShipmentNbr,
                        "SO007504", _salesOrderNumber,
                    };
                    _reportContent = GenerateWorkWavePodReportFromExcel(_parameters);
                    AssertExcelPodReport("TestData\\WorkWavePODReportSingleWithoutAttachments.xlsx", _reportContent, ignoredStrings);
                }
            }
        }

        private void PrepareProcessedWorkWaveOrder()
        {
            using (TestExecution.CreateTestStepGroup("Precondition"))
            {
                AssertWorkWaveCarrier();
            }
            using (TestExecution.CreateTestStepGroup("Step 1 - Create new sales order and shipment"))
            {
                _salesOrderNumber = CreateSalesOrder(inventoryItemList: _inventoryItemList);
                _shipmentNumber = CreateShipment(_salesOrderNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Create a new WorkWave order"))
            {
                //_shipmentNumber = "003668";
                _requestId = CreateWorkWaveOrder(_shipmentNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Validate the just created WorkWave order"))
            {
                //_shipmentNumber = "003669";
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Pending"},
                        {"WWOrderID", ""},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Partially Routed", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Get the content from Webhook by Request Id"))
            {
                //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                _content = GetWebhookContentByGuid(_requestId);
            }
            using (TestExecution.CreateTestStepGroup("Step 5 - Send the POST request to update the WorkWave order in the Acumatica"))
            {
                UpdateWorkWaveOrder(_content);
            }
            using (TestExecution.CreateTestStepGroup("Step 6 - Get the WorkWave order Ids"))
            {
                var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                _orderId = orderIdList.First();
            }
            using (TestExecution.CreateTestStepGroup("Step 7 - Validate the updated WorkWave order"))
            {
                //_shipmentNumber = "003669";
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "TBS"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Route Planning", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 8 - Validate the WorkWave order"))
            {
                AssertWorkWaveOrder(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 9 - Set the Vehicle by WorkWave Api"))
            {
                _vehicleId = SetVehicleByWorkWaveApi(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 10 - Build and approve routes by WorkWave Api"))
            {
                BuildAndApproveRoutes();
            }
            using (TestExecution.CreateTestStepGroup("Step 11 - Validate the updated WorkWave order"))
            {
                GetUpdatedDeliveryStatus(_shipmentNumber);
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Route Assigned"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Route Assigned", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 12 - Complete PickUp and Delivery orders by Api"))
            {
                var dateString = DateTime.Now.ToString("yyyyMMdd");
                HandlePickUpAndDelivery(_orderId, _vehicleId, dateString);
            }
            using (TestExecution.CreateTestStepGroup("Step 13 - Validate the updated WorkWave order"))
            {
                GetUpdatedDeliveryStatus(_shipmentNumber, _timeout);
                var gpsString = GetGPSByOrderId(_shipmentNumber, _orderId);
                var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Delivered"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", gpsString},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                AssertWorkWaveOrder(_shipmentNumber, "Confirmed", expectedWorkWaveOrderData);
            }
            using (TestExecution.CreateTestStepGroup("Step 14 - Validate downloaded files and notes for the WorkWave order"))
            {
                //_shipmentNumber = "003675";
                //_orderId = "a8c5402b-93b7-46ea-9f8f-1ac68f4b1e57";
                AssertFilesAndNotes(_shipmentNumber, _orderId, _expectedNotes, _expectedImageCount);
            }
            using (TestExecution.CreateTestStepGroup("Step 15 - Validate file prefix"))
            {
                //_shipmentNumber = "003675";
                //_orderId = "a8c5402b-93b7-46ea-9f8f-1ac68f4b1e57";
                AssertFilePrefix(_shipmentNumber, _orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 16 - Validate file comments"))
            {
                //_shipmentNumber = "003824";
                //_orderId = "042b872d-dce5-4939-8079-0e266d02fa05";
                AssertFileComment(_shipmentNumber, _orderId);
            }
        }
    }
}
