using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Domain.Entities;
using Core.Log;
using Newtonsoft.Json;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider
{
    public class AcumaticaWebhookDataProvider : WebhookBaseDataProvider
    {
        protected override string GetListUrl => "";
        protected override string PostUpdateWWOrderUrl => "/cf920cca-53f4-40ff-adce-0fca4c3c27d4";
        public AcumaticaWebhookDataProvider(IWebhookRestOptions options) : base(options) { }

        public object Create(string url, Dictionary<string, object> content)
        {
            WebhookRequestParameters query = new WebhookRequestParameters();
            var json = JsonConvert.SerializeObject(content["Query"]);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            query.Add(dictionary);
            return Post<object>(content["Content"], query, url);
        }
    }

    public class AcumaticaWebhookDataHelper
    {
        private readonly IWebhookRestOptions _options;

        public AcumaticaWebhookDataHelper(IWebhookRestOptions options)
        {
            _options = options;
        }
        public object UpdateWorWaveOrder(string url, Dictionary<string, object> content)
        {
            using (var dataProvider = new AcumaticaWebhookDataProvider(_options))
            {
                Log.Information($"Update the WorkWave order in the Acumatica by url: {url}");
                return dataProvider.Create(url, content);
            }
        }

    }
}
