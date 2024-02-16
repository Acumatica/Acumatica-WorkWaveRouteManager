using AcumaticaWorkWave.API.Domain;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRestClientBase : RestClient
    {
        private readonly IRestSerializer _serializer;
        private readonly IDeserializer _deserializer;
        private readonly IWWRestOptions _options;

        protected WWRestClientBase(IRestSerializer serializer, IWWRestOptions options)
        {
            _serializer = serializer;
            _deserializer = (IDeserializer)_serializer;
            _options = options;

            UseSerializer(() => serializer);
            Authenticator = new WWAutentificator(_options);

            //AddHandler("application/json", deserializer);
            //AddHandler("text/json", deserializer);
            //AddHandler("text/x-json", deserializer);

            try
            {
                const string schema = "https";
                var builder = new UriBuilder(schema, options.BaseUrl);
                Options.BaseUrl = builder.Uri;

            }
            catch (UriFormatException e)
            {
                throw new UriFormatException("Invalid URL: The format of the URL could not be determined.", e);
            }
        }

        public RestResponse<T> Execute<T>(RestRequest request)
        {
            var response = RestResponse<T>.FromResponse(base.Execute(request));

            if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
            {
                if (response.Content != null)
                {
                    var error = JsonConvert.DeserializeObject<WWApiError>(response.Content);
                    throw new WWAPIException(error);
                }
            }

            if ((int)response.StatusCode >= 500 && (int)response.StatusCode < 600)
            {
                throw new WWHTTPException(response);
            }

            try
            {
                response.Data = _deserializer.Deserialize<T>(response);
            }
            catch
            {
                response.Data = default;
            }

            return response;
        }
    }

    public class WWAPIException : WWRequestExceptionBase
    {
        public WWAPIException(WWApiError error)
        {
            ErrorCode = error.ErrorCode;
            ErrorMessage = error.ErrorMessage;
        }
    }

    public class WWHTTPException : WWRequestExceptionBase
    {
        public WWHTTPException(RestResponse error)
        {
            ErrorCode = (int)error.StatusCode;
            ErrorMessage = error.StatusDescription;
        }
    }
}