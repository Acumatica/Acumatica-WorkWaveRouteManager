using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class DeletingWorkWaveShipmentInAcumatica : TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Deleting the WorkWave shipment in Acumatica"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Create new sales order and shipment with the TBS status"))
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
                using (TestExecution.CreateTestStepGroup("Step 8 - Delete the WorkWave order. Validate a warning message"))
                {
                    //_shipmentNumber = "003736";
                    DeleteWorkWaveShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Validate the removed shipment"))
                {
                    //_shipmentNumber = "003738";
                    AssertRemovedShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Validate the removed WorkWave order by Api"))
                {
                    //_orderId = "ab62cc45-2249-470b-a5c8-b5a0ee2cb0ef";
                    AssertRemovedWorkWaveOrder(_orderId);
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Create the second sales order and shipment with the Route Assigned status"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }
                using (TestExecution.CreateTestStepGroup("Step 12 - Create the second WorkWave order for current shipment"))
                {
                    //_shipmentNumber = "003668";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 13 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 14 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 15 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 16 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 17 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 18 - Set the Vehicle by WorkWave Api"))
                {
                    _vehicleId = SetVehicleByWorkWaveApi(_orderId);
                }
                using (TestExecution.CreateTestStepGroup("Step 19 - Build and approve routes by WorkWave Api"))
                {
                    BuildAndApproveRoutes();
                }
                using (TestExecution.CreateTestStepGroup("Step 20 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 21 - Validate disabled action to delete the WorkWave shipment"))
                {
                    AssertDisabledActionDeleteShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 22 - Complete PickUp and Delivery orders by Api"))
                {
                    var dateString = DateTime.Now.ToString("yyyyMMdd");
                    HandlePickUpAndDelivery(_orderId, _vehicleId, dateString);
                }
                using (TestExecution.CreateTestStepGroup("Step 23 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 24 - Validate disabled action to delete the WorkWave shipment"))
                {
                    AssertDisabledActionDeleteShipment(_shipmentNumber);
                }
            }
        }
    }
}
