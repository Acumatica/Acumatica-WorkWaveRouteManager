using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class AbsenceOfShipmentPackages: TestBase
    {
        private string _shipmentNumber;
        private string _requestId;
        private string _quantity1 = "0";

        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Absence of shipment packages"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Create new sales order and shipment"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }

                using (TestExecution.CreateTestStepGroup("Step 2 - Remove shipment packages"))
                {
                    SetShipmentPackage(_shipmentNumber, Convert.ToInt32(_quantity1));
                }

                using (TestExecution.CreateTestStepGroup("Step 3 - Create a new WorkWave order"))
                {
                    //_shipmentNumber = "003688";
                    _requestId = CreateWorkWaveOrder(_shipmentNumber);
                }

                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the WorkWave order"))
                {
                    //_shipmentNumber = "003688";
                    //_requestId = "f09d4dd7-27e9-4357-ba34-54a066549f4d";
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
            }
        }
    }
}
