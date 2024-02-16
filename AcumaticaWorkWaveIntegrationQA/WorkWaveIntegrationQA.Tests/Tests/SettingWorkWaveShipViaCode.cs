using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class SettingWorkWaveShipViaCode : TestBase
    {
        private string _acumaticaWebhookUrl;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Setting WorkWave Ship Via code"))
            {
                //Default setup is completed by Customization Plugin
                using (TestExecution.CreateTestStepGroup("Step 1 - Set the Ship Via Code for WorkWave carrier"))
                {
                    AssertShipViaCode();
                }
            }
        }
    }
}
