using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.WebhookRestClient.Client;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.DataProvider
{
    public abstract class WebhookBaseDataProvider : Client.WebhookRestClient
    {
        protected abstract string GetListUrl { get; }
        protected abstract string PostUpdateWWOrderUrl { get; }
        protected WebhookBaseDataProvider(IWebhookRestOptions options) : base(options) { }

        protected virtual TE Get<T, TE>(string url) where T : new() where TE : new()
        {
            var request = MakeRequest(url);
            TE result = Get<T, TE>(request);
            return result;
        }

        protected T Post<T>(T obj) where T : new()
        {
            var request = MakeRequest(PostUpdateWWOrderUrl);
            return Post<T>(request, obj);
        }

        protected T Post<T>(T obj, WebhookRequestParameters parameters, string url) where T : new()
        {
            var request = MakeRequest(url, parameters: parameters?.GetParameters());
            return Post<T>(request, obj);
        }
    }
}
