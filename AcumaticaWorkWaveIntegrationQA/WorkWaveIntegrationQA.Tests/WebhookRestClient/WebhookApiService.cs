using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient
{
    public static class WebhookApiService
    {
        static WebhookApiService()
        {
            var _options = GetRestOptionsWebhook();
            WebhookRequestsDataHelper = new WebhookRequestsDataHelper(_options);
            AcumaticaWebhookDataHelper = new AcumaticaWebhookDataHelper(GetRestOptionsAcumaticaWebhook());
        }

        #region DataProviders

        public static WebhookRequestsDataHelper WebhookRequestsDataHelper;
        public static AcumaticaWebhookDataHelper AcumaticaWebhookDataHelper;

        #endregion

        private static IWebhookRestOptions GetRestOptionsWebhook()
        {
            return new WebhookRestOptions();
        }

        private static IWebhookRestOptions GetRestOptionsAcumaticaWebhook()
        {
            return new WebhookRestOptions( "http://localhost/AcumaticaWorkWave/Webhooks/Company/", "");
        }
    }
}
