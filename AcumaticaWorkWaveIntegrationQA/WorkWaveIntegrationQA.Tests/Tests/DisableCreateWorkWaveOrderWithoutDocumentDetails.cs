using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class DisableCreateWorkWaveOrderWithoutDocumentDetails : TestBase
    {
        private string _shipmentNumber;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Validate the disable Create WorkWave button for shipment without Document Details"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Create new sales order and shipment"))
                {
                    _shipmentNumber = CreateSalesOrderAndShipment();
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Remove Document Details from shipment"))
                {
                    RemoveShipmentDocumentDetails(_shipmentNumber);
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Check the disabled Create WorkWave order button"))
                {
                    AssertDisabledActionCreateWorkWaveOrder(_shipmentNumber);
                }
            }
        }
    }
}
