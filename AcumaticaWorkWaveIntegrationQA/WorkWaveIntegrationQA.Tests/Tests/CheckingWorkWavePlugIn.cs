using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.TestExecution;
using PX.QA.Tools;
using WorkWaveIntegrationQA.Tests.Extensions;
using WorkWaveIntegrationQA.Tests.TestsBase;

namespace WorkWaveIntegrationQA.Tests.Tests
{
    public class CheckingWorkWavePlugIn : TestBase
    {
        private string _acumaticaWebhookUrl;
        public override void Execute()
        {
            using (TestExecution.CreateTestCaseGroup("Checking WorkWave plug-in"))
            {
                //Default setup is completed by Customization Plugin
                using (TestExecution.CreateTestStepGroup("Step 1 - Enable the feature: WorkWave Route Optimization"))
                {
                    EnableWorkWaveFeature();
                }
                using (TestExecution.CreateTestStepGroup("Step 2 - Get the Url for Webhook: WWTest"))
                {
                    _acumaticaWebhookUrl = GetUrlForAcumaticaWebhook();
                }
                using (TestExecution.CreateTestStepGroup("Step 3 - Setup the WorkWave carrier"))
                {
                    AssertWorkWaveCarrier();
                }
                using (TestExecution.CreateTestStepGroup("Step 4 - Set required addresses: company, customer, warehouse, branch"))
                {
                    SetCompanyAddressDetail();
                    SetCustomerAddressDetail();
                    SetWarehouseAddressDetail();
                    SetBranchAddressDetail();
                }
                using (TestExecution.CreateTestStepGroup("Step 5 - Set inventory item quantities"))
                {
                    AddInventoryItemQuantities();
                }
            }
        }
    }
}
