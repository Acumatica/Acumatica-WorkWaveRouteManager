using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class ProcessShipmentWorkWaveShipmentWithoutDocumentItems : TestBase
    {
        private string _shipmentNumber;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Process Shipment: Validate the absence of the WorkWave shipments without document details"))
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
                using (TestExecution.CreateTestStepGroup("Step 3 - Check the absence of the WorkWave shipments without document details"))
                {
                    AssertAbsenceShipmentWithoutDocumentDetails(_shipmentNumber);
                }
            }
        }
    }
}
