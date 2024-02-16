using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client;
using WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Domain.Entities;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.DataProvider
{
    public abstract class WorkWaveBaseDataProvider : Client.WorkWaveRestClient
    {
        protected abstract string GetListUrl { get; }
        protected abstract string SingleOrderUrl { get; }
        protected abstract string PostUpdateWWOrderUrl { get; }
        protected WorkWaveBaseDataProvider(IWorkWaveRestOptions options) : base(options) { }

        protected virtual TE Get<T, TE>(string url) where T : new() where TE : new()
        {
            var request = MakeRequest(url);
            TE result = Get<T, TE>(request);
            return result;
        }
        protected virtual TE Get<T, TE>(string url, WorkWaveUrlSegments urlSegments, WorkWaveRequestParameters parameters = null) where T : new() where TE : IWorkWaveEntitiesResponse<T>, new()
        {
            var request = MakeRequest(url, urlSegments?.GetUrlSegments(), parameters?.GetParameters());
            TE result = Get<T, TE>(request);
            if (result == null) return default(TE);
            return result;
        }

        protected virtual TE Get<T, TE>(WorkWaveRequestParameters parameters) where T : new() where TE : IWorkWaveEntitiesResponse<T>, new()
        {
            return Get<T, TE>(SingleOrderUrl, null, parameters);
        }

        protected T Post<T>(T obj) where T : new()
        {
            var request = MakeRequest(PostUpdateWWOrderUrl);
            return Post<T>(request, obj);
        }

        protected T Post<T>(T obj, WorkWaveUrlSegments urlSegments, WorkWaveRequestParameters parameters) where T : new()
        {
            var request = MakeRequest(PostUpdateWWOrderUrl, urlSegments?.GetUrlSegments(), parameters?.GetParameters());
            return Post<T>(request, obj);
        }

        protected T Post<T>(string url, T obj, WorkWaveUrlSegments urlSegments, WorkWaveRequestParameters parameters) where T : new()
        {
            var request = MakeRequest(url, urlSegments?.GetUrlSegments(), parameters?.GetParameters());
            return Post<T>(request, obj);
        }

        protected bool Delete(WorkWaveUrlSegments urlSegments)
        {
            var request = MakeRequest(PostUpdateWWOrderUrl, urlSegments.GetUrlSegments());
            return Delete(request);
        }
    }
}
