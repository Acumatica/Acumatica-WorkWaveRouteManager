using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class ProcessShipmentGetDeliveryStatusAction : TestBase
    {
        private string _shipmentNumber;
        private string _shipmentNumberWithoutWorkWaveCarrier;
        private string _requestId;
        private string _orderId;
        private Dictionary<string, dynamic> _content;
        private string _actionNameGetDeliveryStatus = "Get Delivery Status";
        private int _timeout = 60000;
        private string _vehicleId;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Process shipment: Get Delivery Status action"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Create new sales order and shipment with WorkWave carrier"))
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
                using (TestExecution.CreateTestStepGroup("Step 8 - Create new sales order and shipment without WorkWave carrier"))
                {
                    _shipmentNumberWithoutWorkWaveCarrier = CreateSalesOrderAndShipment(shipVia: null);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Validate an absence of the shipment without WorkWave carrier"))
                {
                    AssertAbsenceShipmentWithoutWorkWaveCarrier(_shipmentNumberWithoutWorkWaveCarrier, _actionNameGetDeliveryStatus);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Set the Vehicle by WorkWave Api"))
                {
                    _vehicleId = SetVehicleByWorkWaveApi(_orderId);
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Build and approve routes by WorkWave Api"))
                {
                    BuildAndApproveRoutes();
                }
                using (TestExecution.CreateTestStepGroup("Step 12 - Process shipment with WorkWave carrier to get delivery status: Route Assigned"))
                {
                    ProcessShipment(_shipmentNumber, _actionNameGetDeliveryStatus);
                }
                using (TestExecution.CreateTestStepGroup("Step 13 - Validate the updated WorkWave order"))
                {
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
                using (TestExecution.CreateTestStepGroup("Step 14 - Complete PickUp and Delivery orders by Api"))
                {
                    var dateString = DateTime.Now.ToString("yyyyMMdd");
                    HandlePickUpAndDelivery(_orderId, _vehicleId, dateString);
                }
                using (TestExecution.CreateTestStepGroup("Step 15 - Process shipment with WorkWave carrier to get delivery status: Delivered"))
                {
                    Thread.Sleep(_timeout);
                    ProcessShipment(_shipmentNumber, _actionNameGetDeliveryStatus);
                }
                using (TestExecution.CreateTestStepGroup("Step 16 - Validate the updated WorkWave order"))
                {
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
                using (TestExecution.CreateTestStepGroup("Step 17 - Validate an absence of the shipment with WorkWave carrier and Delivered status"))
                {
                    AssertAbsenceShipmentWithoutWorkWaveCarrier(_shipmentNumber, _actionNameGetDeliveryStatus);
                }
            }
        }
    }
}
