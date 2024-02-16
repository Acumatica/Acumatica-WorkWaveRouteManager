using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class WorkWaveShipmentSummaryScreen: TestBase
    {
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("WorkWave Shipment Summary screen"))
            {
                using (TestExecution.CreateTestStepGroup("Precondition"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 1 - Validate the screen with empty filters"))
                {
                    AssertWorkWaveShipmentSummaryEmptyFilters();
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Validate the screen with defined customer filter with the WorkWave integration"))
                {
                    AssertWorkWaveShipmentSummaryCustomerFilter();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Validate the screen with defined customer filter without the WorkWave integration"))
                {
                    AssertWorkWaveShipmentSummaryCustomerFilterWithoutWorkWaveIntegration();
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Validate the screen with defined delivery status filter"))
                {
                    AssertWorkWaveShipmentSummaryDeliveryStatusFilter();
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Validate the screen with defined shipment number filter"))
                {
                    AssertWorkWaveShipmentSummaryShipmentNumberFilter();
                }
            }
        }
    }
}
