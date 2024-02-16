using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public class WebhookRestClient : WebhookRestClientBase, IWebhookRestClient
    {
        public WebhookRestClient(IWebhookRestOptions options) : base(new WebhookRestJsonSerializer(), new WebhookRestJsonSerializer(), options) { }

        public bool Delete(IRestRequest request)
        {
            request.Method = Method.DELETE;
            var response = Execute<object>(request);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                return true;
            }
            return false;
        }

        public T Get<T>(IRestRequest request) where T : new()
        {
            request.Method = Method.GET;
            var response = Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                return response.Data;
            }
            return default;
        }

        protected object Get(IRestRequest request)
        {
            request.Method = Method.GET;
            var response = Execute<object>(request);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                return response.Data;
            }
            return default;
        }

        public TE Get<T, TE>(IRestRequest request) where T : new() where TE : new()
        {
            request.Method = Method.GET;
            var response = Execute<TE>(request);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                return response.Data;
            }
            return default;
        }

        public T Post<T>(IRestRequest request, T obj) where T : new()
        {
            return Post<T, T>(request, obj);
        }

        public T Post<T, TE>(IRestRequest request, TE obj) where T : new() where TE : new()
        {
            request.Method = Method.POST;
            request.AddJsonBody(obj);
            var response = Execute<T>(request);
            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            return default;
        }

        public T Put<T>(IRestRequest request, T obj) where T : new()
        {
            request.Method = Method.PUT;
            request.AddJsonBody(obj);

            var response = Execute<T>(request);
            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
            {
                return response.Data;
            }
            throw new Exception(response.StatusDescription);
        }
    }
}
