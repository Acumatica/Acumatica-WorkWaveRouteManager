using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Log;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public class WebhookRestClientBase : RestClient, IDisposable
    {
        protected ISerializer _serializer;
        private readonly IWebhookRestOptions _options;

        protected WebhookRestClientBase(IDeserializer deserializer, ISerializer serializer, IWebhookRestOptions options)
        {
            _serializer = serializer;
            _options = options;

            foreach (var contextType in new List<string>() { "application/json" })
                AddHandler(contextType, () => deserializer);

            try
            {
                BaseUrl = new Uri($"{options.baseUrl}{options.token}");
            }
            catch (UriFormatException e)
            {
                throw new UriFormatException("Invalid URL: The format of the URL could not be determined.", e);
            }

        }

        public RestRequest MakeRequest(string url, Dictionary<string, string> urlSegments = null, Dictionary<string, string> parameters = null)
        {
            var request = new RestRequest(url) { JsonSerializer = _serializer, RequestFormat = DataFormat.Json };

            if (!string.IsNullOrEmpty(_options.apiKey))
                request.AddHeader("Api-Key", _options.apiKey);

            request.AddHeader("Accept", "application/json");

            if (urlSegments != null)
            {
                foreach (var urlSegment in urlSegments)
                {
                    request.AddUrlSegment(urlSegment.Key, urlSegment.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value, false);
                }
            }

            return request;
        }
        public void LogRequest(IRestRequest request, IRestResponse response)
        {
            RestClient client = new RestClient(_options.baseUrl);
            var requestToLog = new
            {
                resource = request.Resource,
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                method = request.Method.ToString(),
                uri = client.BuildUri(request),
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = JsonConvert.DeserializeObject(response.Content),
                headers = response.Headers,
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };

            Log.Information($"Request is completed:\nRequest Data: {JsonConvert.SerializeObject(requestToLog)}\n" +
                            $"Response Data: {JsonConvert.SerializeObject(responseToLog)}\n");
        }

        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            Log.Information("Send the http request to Webhook.site API");
            var response = base.Execute<T>(request);
            LogRequest(request, response);
            if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
            {
                throw GetResponseError<T>(response);
            }
            if ((int)response.StatusCode >= 500 && (int)response.StatusCode < 600)
            {
                throw new Exception($"{response.ErrorMessage}", response.ErrorException);
            }

            return response;
        }

        private static Exception GetResponseError<T>(IRestResponse<T> response)
        {
            Log.Information("Client error from API");
            var error = JsonConvert.DeserializeObject<WebhookResponseContent>(response.Content);
            if (error != null)
                return new Exception($"{string.Join(",", error.Errors.Select(e => e.Message))}({error.Status})");
            return new Exception("Error messages are not found. Review the Status Code");
        }

        public void Dispose()
        {
        }

    }
}
