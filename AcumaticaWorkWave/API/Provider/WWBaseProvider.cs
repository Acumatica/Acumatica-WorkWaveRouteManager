using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.Resources;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AcumaticaWorkWave.API.Provider
{
    public abstract class WWBaseProvider
    {
        private readonly IWWRestClient _client;
        protected const string LB = "{";
        protected const string RB = "}";

        protected WWBaseProvider(IWWRestOptions options)
        {
            _client = new WWRestClient(options);
        }

        protected virtual T Get<T>(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Get<T>(request);
        }

        protected virtual T Get<T, U>(U obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
            where U : class
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Get<T, U>(request, obj);
        }

        protected virtual T Put<T>(T obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Put(request, obj);
        }

        protected virtual T Put<T, U>(U obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
            where U : class
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Put<T, U>(request, obj);
        }

        protected virtual T Post<T>(T obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Post(request, obj);
        }

        protected virtual T Post<T, U>(U obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
            where U : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Post<T, U>(request, obj);
        }

        protected virtual T Delete<T>(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Delete<T>(request);
        }

        protected virtual T Delete<T, U>(U obj, string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
            where T : class, new()
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Delete<T, U>(request, obj);
        }

        protected virtual RestResponse Get(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Get(request);
        }

        protected virtual RestResponse Put(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Put(request);
        }

        protected virtual RestResponse Delete(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
        {
            var request = _client.MakeRequest(url, urlSegments, parameters);
            return _client.Delete(request);
        }

        

        public T Deserialize<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }
    }
}