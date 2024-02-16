using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Core.Browser;
using Core.Log;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class CheckingBarcodeLimitationParameter: TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _orderId;
        private string _vehicleId;
        private Dictionary<string, dynamic> _content;
        private int _timeout = 60000;
        private string _expectedNotes = "Test Note 6";
        private int _expectedImageCount = 3;

        private string _quantity1 = "11";
        private string _quantity2 = "10";
        private List<string> _orderList;
        private string _preventOption = "Prevent";
        private string _allowOption = "Allow";
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Checking Barcode Limitation parameter: Split"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Barcode Limit: Split"))
                {
                    SetBarcodeLimit();
                }
                using (TestExecution.CreateTestStepGroup($"Step 2 - Create new sales order and shipment with quantity: {_quantity1}"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment(quantity: _quantity1);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Define shipment packages"))
                {
                    SetShipmentPackage(_shipmentNumber, Convert.ToInt32(_quantity1));
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003688";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Validate WorkWave orders"))
                {
                    //_shipmentNumber = "003688";
                    //_requestId = "f09d4dd7-27e9-4357-ba34-54a066549f4d";
                    var expectedWorkWaveOrderDataList = new List<Dictionary<string, string>>()
                    {
                        new Dictionary<string, string>()
                        {
                            {"WWDeliveryStatus", "Pending"},
                            {"WWOrderID", ""},
                            {"WWRequestID", _requestId},
                            {"WWGPS", ""},
                            {"WWErrorCode", ""},
                            {"WWErrorMessage", ""},
                        },
                        new Dictionary<string, string>()
                        {
                            {"WWDeliveryStatus", "Pending"},
                            {"WWOrderID", ""},
                            {"WWRequestID", _requestId},
                            {"WWGPS", ""},
                            {"WWErrorCode", ""},
                            {"WWErrorMessage", ""},
                        }
                    };
                    AssertWorkWaveOrderList(_shipmentNumber, "Partially Routed", expectedWorkWaveOrderDataList);
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Send the POST request to update the WorkWave orders in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Get the WorkWave order Ids"))
                {
                    _orderList = GetWorkWaveOrderIdList(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Validate the updated WorkWave orders"))
                {
                    //_shipmentNumber = "003669";
                    var expectedWorkWaveOrderDataList = new List<Dictionary<string, string>>()
                    {
                        new Dictionary<string, string>()
                        {
                            {"WWDeliveryStatus", "TBS"},
                            {"WWOrderID", _orderList.First()},
                            {"WWRequestID", _requestId},
                            {"WWGPS", ""},
                            {"WWErrorCode", ""},
                            {"WWErrorMessage", ""},
                        },
                        new Dictionary<string, string>()
                        {
                            {"WWDeliveryStatus", "TBS"},
                            {"WWOrderID", _orderList.Last()},
                            {"WWRequestID", _requestId},
                            {"WWGPS", ""},
                            {"WWErrorCode", ""},
                            {"WWErrorMessage", ""},
                        }
                    };
                    AssertWorkWaveOrderList(_shipmentNumber, "Route Planning", expectedWorkWaveOrderDataList);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Validate the WorkWave orders by Api"))
                {
                    //_orderList = new List<string>() { "b77f66fe-b734-45ef-9c79-14c63ca14a57", "70e1c9d2-90a1-49fc-9a0a-3df72a0792d5" };
                    foreach (var item in _orderList)
                    {
                        AssertWorkWaveOrder(item);
                    }
                }

            }

            using (TestExecution.CreateTestCaseGroup("Checking Barcode Limitation parameter: Prevent"))
            {
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Barcode Limit: Prevent"))
                {
                    SetBarcodeLimit(_preventOption);
                }
                using (TestExecution.CreateTestStepGroup($"Step 2 - Create new sales order and shipment with quantity: {_quantity1}"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment(quantity: _quantity1);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Define shipment packages"))
                {
                    SetShipmentPackage(_shipmentNumber, Convert.ToInt32(_quantity1));
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Check the error message after WorkWave order creation"))
                {
                    //_shipmentNumber = "003691";
                    AssertShipmentErrorMessage(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup($"Step 5 - Reduce an amount of packages to {_quantity2}"))
                {
                    //_shipmentNumber = "003691";
                    SetShipmentPackage(_shipmentNumber, Convert.ToInt32(_quantity2));
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003691";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 8 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 11 - Validate the updated WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 12 - Validate the WorkWave order"))
                {
                    AssertWorkWaveOrder(_orderId);
                }

            }

            using (TestExecution.CreateTestCaseGroup("Checking Barcode Limitation parameter: Allow"))
            {
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Barcode Limit: Allow"))
                {
                    SetBarcodeLimit(_allowOption);
                }
                using (TestExecution.CreateTestStepGroup($"Step 2 - Create new sales order and shipment with quantity: {_quantity1}"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment(quantity: _quantity1);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Define shipment packages"))
                {
                    SetShipmentPackage(_shipmentNumber, Convert.ToInt32(_quantity1));
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003691";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Validate the just created WorkWave order"))
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
                using (TestExecution.CreateTestStepGroup("Step 6 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 7 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Validate the updated WorkWave order with error code"))
                {
                    //_shipmentNumber = "003669";
                    var expectedWorkWaveOrderData = new Dictionary<string, string>()
                    {
                        {"WWDeliveryStatus", "Error"},
                        {"WWOrderID", _orderId},
                        {"WWRequestID", _requestId},
                        {"WWGPS", ""},
                        {"WWErrorCode", "102"},
                        {"WWErrorMessage", "orders[0].delivery.barcodes cannot define more than 10 barcodes"},
                    };
                    AssertWorkWaveOrder(_shipmentNumber, "Route Error", expectedWorkWaveOrderData);
                }
            }

        }
        public override void AfterExecute()
        {
            using (TestExecution.CreateTestStepGroup("Step 1 - Set the Barcode Limit: Split"))
            {
                SetBarcodeLimit();
            }
            Log.Information("Stop all browser windows");
            Browser.Stop();
            base.AfterExecute();
        }
    }
}
