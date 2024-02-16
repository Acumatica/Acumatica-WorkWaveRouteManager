using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using Newtonsoft.Json;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider
{
    public class WebhookRequestsDataProvider : WebhookBaseDataProvider
    {
        protected override string GetListUrl => "/requests?sorting=newest";
        protected override string PostUpdateWWOrderUrl => "";
        public WebhookRequestsDataProvider(IWebhookRestOptions options) : base(options) { }

        public WebhookRequestResponse GetAll()
        {
            return Get<WebhookRequest, WebhookRequestResponse>(GetListUrl);
        }

    }

    public class WebhookRequestsDataHelper
    {
        private readonly IWebhookRestOptions _options;

        public WebhookRequestsDataHelper(IWebhookRestOptions options)
        {
            _options = options;
        }
        public WebhookRequestResponse GetAll()
        {
            using (var dataProvider = new WebhookRequestsDataProvider(_options))
            {
                return dataProvider.GetAll();
            }
        }

        public Dictionary<string, dynamic> GetContentByGuid(string requestId = "866e469f-25cf-44f6-903c-e525193823a8")
        {
            using (var dataProvider = new WebhookRequestsDataProvider(_options))
            {
                Log.Information($"Find a content by request id: {requestId}");
                var response = dataProvider.GetAll();
                var contentList = response.Results;
                if (!contentList.Any())
                    Log.Information("List of content from Webhook.site is empty");
                var foundContent = contentList.FirstOrDefault(r => r.Content.Contains(requestId));
                if (foundContent == null)
                    throw new Exception($"Content is not found by request Id: {requestId}");
                var resultDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(foundContent.Content);
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>()
                {
                    {"Content", resultDict},
                    {"Query", foundContent.Query},
                };
                return result;
            }
        }
    }
}
