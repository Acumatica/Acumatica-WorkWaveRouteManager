using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.Entity;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class QuickProcessOnSalesOrders : TestBase
    {
        private string _salesOrderId;
        private string _salesOrderIdWithoutWorkWaveCarrier;
        private string _shipmentNumber;
        private string _shipmentNumberWithoutWorkWaveCarrier;
        private string _requestId;
        private string _orderId;
        private Dictionary<string, dynamic> _content;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Quick Process on Sales Orders"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Prepare data: two sales orders with/without the WW carrier"))
                {
                    _salesOrderId = CreateSalesOrder();
                    _salesOrderIdWithoutWorkWaveCarrier = CreateSalesOrder(shipVia: null);
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Quick process a sales order with the WW carrier to create a shipment"))
                {
                    //_salesOrderId = "SO006253";
                    _shipmentNumber = QuickProcessSalesOrder(_salesOrderId, true);
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
                using (TestExecution.CreateTestStepGroup("Step 8 - Quick process a sales order without the WW carrier to create a shipment"))
                {
                    _shipmentNumberWithoutWorkWaveCarrier = QuickProcessSalesOrder(_salesOrderIdWithoutWorkWaveCarrier, false);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Validate a confirmed shipment"))
                {
                    AssertConfirmedShipment(_shipmentNumberWithoutWorkWaveCarrier);
                }
            }
        }
    }
}
