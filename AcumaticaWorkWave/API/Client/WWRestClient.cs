using RestSharp;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRestClient : WWRestClientBase, IWWRestClient
    {
        public WWRestClient(IWWRestOptions options) : base(new WWRestJsonSerializer(),  options)
        {
        }

        public RestResponse Get(RestRequest request)
        {
            request.Method = Method.Get;
            return Execute(request);
        }

        public RestResponse Post(RestRequest request)
        {
            request.Method = Method.Post;
            return Execute(request);
        }

        public RestResponse Put(RestRequest request)
        {
            request.Method = Method.Put;
            return Execute(request);
        }

        public RestResponse Delete(RestRequest request)
        {
            request.Method = Method.Delete;
            return Execute(request);
        }

        public T Delete<T>(RestRequest request) where T : class, new()
        {
            request.Method = Method.Delete;
            return Execute<T>(request).Data;
        }

        public T Delete<T, U>(RestRequest request, U obj) where T : class, new()
        {
            request.Method = Method.Delete;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public T Get<T>(RestRequest request) where T : class, new()
        {
            request.Method = Method.Get;
            return Execute<T>(request).Data;
        }

        public T Get<T, U>(RestRequest request, U obj)
            where T : class, new()
            where U : class
        {
            request.Method = Method.Post;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public T Post<T>(RestRequest request, T obj) where T : class, new()
        {
            request.Method = Method.Post;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public T Post<T, U>(RestRequest request, U obj)
            where T : class, new()
            where U : class
        {
            request.Method = Method.Post;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public T Put<T>(RestRequest request, T obj) where T : class, new()
        {
            request.Method = Method.Put;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public T Put<T, U>(RestRequest request, U obj)
            where T : class, new()
            where U : class
        {
            request.Method = Method.Put;
            request.AddBody(obj);
            return Execute<T>(request).Data;
        }

        public RestRequest MakeRequest(string url, WWUrlSegments urlSegments = null, WWRequestParameters parameters = null)
        {
            var request = new RestRequest(url) { RequestFormat = DataFormat.Json };

            if (urlSegments != null)
            {
                foreach (var urlSegment in urlSegments.GetUrlSegments())
                {
                    request.AddUrlSegment(urlSegment.Key, urlSegment.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var parameter in parameters.GetParameters())
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }

            return request;
        }
    }
}