using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core.Browser;
using Core.Log;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class DisabledStoringOfAttachmentsForCarrier: TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Disabled storing of attachments for carrier"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Disable storing of attachments"))
                {
                    var podParametersDictionary = new Dictionary<string, bool>()
                    {
                        {"STORE POD SIGNATURE", false},
                        {"STORE POD PICTURES", false},
                        {"STORE POD GPS", false},
                        {"STORE POD DRIVER NOTES", false}
                    };
                    SetCarrierPodParameters(podParametersDictionary);
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
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
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
                    ////_shipmentNumber = "003701";
                    ////_orderId = "6947b75e-33bb-4dc9-810a-8dd97f833cd2";
                    ////_requestId = "88c9ebd2-f173-4978-b25b-437a44959ed2";
                    GetUpdatedDeliveryStatus(_shipmentNumber, _timeout);
                    var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Delivered"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", ""},
                        {"WWErrorMessage", ""},
                    };
                    AssertWorkWaveOrder(_shipmentNumber, "Confirmed", expectedWorkWaveOrderData);
                }
                using (TestExecution.CreateTestStepGroup("Step 15 - Validate the absence of downloaded files and notes for the WorkWave order"))
                {
                    //_shipmentNumber = "003675";
                    //_orderId = "a8c5402b-93b7-46ea-9f8f-1ac68f4b1e57";
                    AssertAbsenceOfFilesAndNotes(_shipmentNumber, _orderId);
                }
            }
        }

        public override void AfterExecute()
        {
            using (TestExecution.CreateTestStepGroup("Restore previous parameters"))
            {
                var podParametersDictionary = new Dictionary<string, bool>()
                {
                    {"STORE POD SIGNATURE", true},
                    {"STORE POD PICTURES", true},
                    {"STORE POD GPS", true},
                    {"STORE POD DRIVER NOTES", true}
                };
                SetCarrierPodParameters(podParametersDictionary);
            }
            Log.Information("Stop all browser windows");
            Browser.Stop();
            base.AfterExecute();
        }
    }
}
