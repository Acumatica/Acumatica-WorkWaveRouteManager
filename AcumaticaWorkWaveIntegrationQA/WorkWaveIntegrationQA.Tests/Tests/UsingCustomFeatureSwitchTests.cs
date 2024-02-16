using System;
using System.Collections.Generic;
using System.Linq;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;
using WorkWaveIntegrationQA.Tests.WebhookRestClient;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class UsingCustomFeatureSwitchTests : TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        private string _shipViaCodesId = Guid.NewGuid().ToString().Substring(0, 8);
        private string _plugInTypeWorkWave = "AcumaticaWorkWave.Plugin.WorkWaveCarrier";

        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("AWV-139. Using a Custom Feature Switch"))
            {
                Precondition();
                TestCase01();
                TestCase02();
                TestCase03();
                TestCase04();
                TestCase05();
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
            using (TestExecution.CreateTestStepGroup("TestCase #1. Step 1 - Validate the features for Shipping Carrier Integration"))
            {
                AssertShippingCarrierIntegrationEnableDisableFeature();
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Carriers. Validate the Plug-In Type drop-down"))
            {
                AssertPlugInTypeDropDownListCarrierPluginMaint(_plugInTypeWorkWave);
            }
        }

        private void TestCase02()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #2. Step 1 - Disable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(false);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Carriers. Validate the Plug-In Type drop-down"))
            {
                AssertPlugInTypeDropDownListCarrierPluginMaint(_plugInTypeWorkWave, displayed: false);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Enable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(true);
            }
        }

        private void TestCase03()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #3. Step 1 - Disable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(false);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Create new sales order and shipment"))
            {
                _shipmentNumber = CreateSalesOrderAndShipment();
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Create a new WorkWave order"))
            {
                //_shipmentNumber = "003668";
                _requestId = CreateWorkWaveOrder(_shipmentNumber);
            }
            using (TestExecution.CreateTestStepGroup("Step 4 - Validate the just created WorkWave order"))
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
            using (TestExecution.CreateTestStepGroup("Step 5 - Get the content from Webhook by Request Id"))
            {
                //_requestId = "c38db0b8-12f4-4ed2-9d26-1b105fe478a6";
                _content = GetWebhookContentByGuid(_requestId);
            }
            using (TestExecution.CreateTestStepGroup("Step 6 - Send the POST request to update the WorkWave order in the Acumatica"))
            {
                UpdateWorkWaveOrder(_content);
            }
            using (TestExecution.CreateTestStepGroup("Step 7 - Get the WorkWave order Ids"))
            {
                var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                _orderId = orderIdList.First();
            }
            using (TestExecution.CreateTestStepGroup("Step 8 - Validate the updated WorkWave order"))
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
            using (TestExecution.CreateTestStepGroup("Step 9 - Validate the WorkWave order"))
            {
                AssertWorkWaveOrder(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 10 - Set the Vehicle by WorkWave Api"))
            {
                _vehicleId = SetVehicleByWorkWaveApi(_orderId);
            }
            using (TestExecution.CreateTestStepGroup("Step 11 - Build and approve routes by WorkWave Api"))
            {
                BuildAndApproveRoutes();
            }
            using (TestExecution.CreateTestStepGroup("Step 12 - Validate the updated WorkWave order"))
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
            using (TestExecution.CreateTestStepGroup("Step 13 - Complete PickUp and Delivery orders by Api"))
            {
                var dateString = DateTime.Now.ToString("yyyyMMdd");
                HandlePickUpAndDelivery(_orderId, _vehicleId, dateString);
            }
            using (TestExecution.CreateTestStepGroup("Step 14 - Validate the updated WorkWave order"))
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
            using (TestExecution.CreateTestStepGroup("Step 15 - Enable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(true);
            }
        }

        private void TestCase04()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #4. Step 1 - Disable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(false);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Ship Via Codes. Add a new entity. Remove this entity"))
            {
                AddNewShipViaCodeForFreightRates(_shipViaCodesId, true);
            }
            using (TestExecution.CreateTestStepGroup("Step 3 - Enable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(true);
            }
        }

        private void TestCase05()
        {
            using (TestExecution.CreateTestStepGroup("TestCase #5. Step 1 - Enable the Custom feature for Shipping Carrier Integration"))
            {
                SetCustomFeature(true);
            }
            using (TestExecution.CreateTestStepGroup("Step 2 - Carrier. Create or update an entity"))
            {
                AssertWorkWaveCarrier();
            }
        }
    }
}
