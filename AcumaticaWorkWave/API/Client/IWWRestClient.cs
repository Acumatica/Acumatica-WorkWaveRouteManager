using RestSharp;

namespace AcumaticaWorkWave.API.Client
{
    public interface IWWRestClient
    {
        RestResponse Get(RestRequest request);

        T Get<T>(RestRequest request) where T : class, new();

        T Get<T, TU>(RestRequest request, TU obj) where T : class, new() where TU : class;

        RestResponse Post(RestRequest request);

        T Post<T>(RestRequest request, T obj) where T : class, new();

        T Post<T, TU>(RestRequest request, TU obj) where T : class, new() where TU : class;

        RestResponse Put(RestRequest request);

        T Put<T>(RestRequest request, T obj) where T : class, new();

        T Put<T, TU>(RestRequest request, TU obj) where T : class, new() where TU : class;

        RestResponse Delete(RestRequest request);

        T Delete<T>(RestRequest request) where T : class, new();

        T Delete<T, TU>(RestRequest request, TU obj) where T : class, new();

        RestRequest MakeRequest(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null);
        
    }
}