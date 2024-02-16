using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class WorkWaveTerritoryDuplicates : TestBase
    {
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Validate the WorkWave Territory Duplicates"))
            {
                using (TestExecution.CreateTestStepGroup("Step 1 - Setup the WorkWave carrier"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Check the unique combination of Company, Branch and Warehouse"))
                {
                    AssertUniqueCombinationWorkWaveTerritory();
                }
            }
        }
    }
}
