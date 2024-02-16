using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public interface IWorkWaveRestClient
    {
        T Post<T>(IRestRequest request, T obj) where T : new();
        T Put<T>(IRestRequest request, T obj) where T : new();
        bool Delete(IRestRequest request);
        T Get<T>(IRestRequest request) where T : new();
        TE Get<T, TE>(IRestRequest request) where T : new() where TE : new();
        RestRequest MakeRequest(string url, Dictionary<string, string> urlSegments = null, Dictionary<string, string> parameters = null);
    }
}
