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
    public class CheckingPickPackShip : TestBase
    {
        private string _shipmentNumber;
        private string _shipmentNumberWithoutWorkWaveCarrier;
        private string _requestId;
        private string _orderId;
        private Dictionary<string, dynamic> _content;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Checking Pick, Pack, Ship"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Prepare data: two shipments with the WW carrier and without the WW carrier"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                    _shipmentNumberWithoutWorkWaveCarrier = CreateSalesOrderAndShipment(shipVia: null);
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Scan a shipment without the WorkWave carrier"))
                {
                    PickAndPackScanShipment(_shipmentNumberWithoutWorkWaveCarrier);
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Check toolbar buttons"))
                {
                    AssertInvisibleCreateWorkWaveOrderButtonPickAndPack();
                    AssertEnabledConfirmShipmentButtonPickAndPack();
                    PickAndPackCancelProcess();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Scan a shipment with the WorkWave carrier (without the WW order)"))
                {
                    PickAndPackScanShipment(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Check toolbar buttons"))
                {
                    AssertEnabledCreateWorkWaveOrderButtonPickAndPack();
                    AssertDisabledConfirmShipmentButtonPickAndPack();
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Create a new WorkWave order"))
                {
                    PickAndPackCreateWorkWaveOrder();
                    PickAndPackCancelProcess();
                }
                using (TestExecution.CreateTestStepGroup("Step 6 - Validate the just created WorkWave order"))
                {
                    //_shipmentNumber = "003669";
                    _requestId = GetRequestId(_shipmentNumber);
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
                using (TestExecution.CreateTestStepGroup("Step 7 - Get the content from Webhook by Request Id"))
                {
                    //_requestId = "866e469f-25cf-44f6-903c-e525193823a8";
                    _content = GetWebhookContentByGuid(_requestId);
                }
                using (TestExecution.CreateTestStepGroup("Step 8 - Send the POST request to update the WorkWave order in the Acumatica"))
                {
                    UpdateWorkWaveOrder(_content);
                }
                using (TestExecution.CreateTestStepGroup("Step 9 - Get the WorkWave order Ids"))
                {
                    var orderIdList = GetWorkWaveOrderIdList(_shipmentNumber);
                    _orderId = orderIdList.First();
                }
                using (TestExecution.CreateTestStepGroup("Step 10 - Validate the updated WorkWave order"))
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
            }
        }
    }
}
