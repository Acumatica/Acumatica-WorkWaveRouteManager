using System;
using System.Collections.Generic;
using System.Linq;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;
using WorkWaveIntegrationQA.Tests.WebhookRestClient;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;
using WorkWaveIntegrationQA.Tests.Helpers;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class StoreUseTrackingDataTests : TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;

        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("AWV-140. Store Use Tracking Data"))
            {
                Precondition();
                TestCase01();
                TestCase02();
            }
        }

        private void Precondition()
        {
            using (TestExecution.CreateTestStepGroup("Precondition"))
            {
                AssertWorkWaveCarrier();
            }
        }

        private void TestCase01()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #1. Step 1 - Create new sales order and shipment. Complete a flow"))
            {
                _shipmentNumber = CreateSalesOrderAndShipment();
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
                //_requestId = "c38db0b8-12f4-4ed2-9d26-1b105fe478a6";
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
        }

        private void TestCase02()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #2. Check the data in the table of DB"))
            {
                //_shipmentNumber = "004435";
                AssertShipmentNumberCarrierLabelHistory(_shipmentNumber);
            }
        }
    }
}
