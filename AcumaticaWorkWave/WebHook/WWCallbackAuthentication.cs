using AcumaticaWorkWave.BLC;
using PX.Data;
using PX.Objects.CS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AcumaticaWorkWave.WebHook
{
    public interface IWWCallbackAuthenticator
    {
        string SignatureKey { get; set; }
        List<KeyValuePair<string, string>> Plugins { get; set; }

        bool Authenticate(Uri requestUri);
        string CreateToken(string message, string secret);
    }

    public interface IWWCallbackAuthenticatorConfig
    {
        void Configure(IWWCallbackAuthenticator provider);
    }

    public class WWCallbackAuthenticatorConfig : IWWCallbackAuthenticatorConfig
    {
        public void Configure(IWWCallbackAuthenticator provider)
        {
            provider.SignatureKey = "signature";
            provider.Plugins = GetWWPluginSettings();
        }

        private List<KeyValuePair<string, string>> GetWWPluginSettings()
        {
            WWCarrierPluginMaintExt graph = PXGraph.CreateInstance<CarrierPluginMaint>()
                                                .GetExtension<WWCarrierPluginMaintExt>();

            return graph.GetWWSignaturePasswordAndCallbackUrl();
        }
    }

    public class WWCallbackAuthenticator : IWWCallbackAuthenticator
    {
        public WWCallbackAuthenticator(IWWCallbackAuthenticatorConfig configuration)
        {
            configuration.Configure(this);
        }

        public string SignatureKey { get; set; }
        public List<KeyValuePair<string, string>> Plugins { get; set; }

        public bool Authenticate(Uri requestUri)
        {
            var signatureFromUrl = GetParameterFromUrl(requestUri, SignatureKey);

            foreach (var plugin in Plugins)
            {
                var urlWithoutSignature = RemoveParameterFromUrl(requestUri, SignatureKey);
                var modifiedUrl = ReplaceUrlPath(urlWithoutSignature, plugin.Key);
                var hash = CreateToken(modifiedUrl, plugin.Value);
                if (hash == signatureFromUrl) return true;
            }

            return false;
        }

        public string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        private string GetParameterFromUrl(Uri uri, string key)
        {
            var parameters = DecodeQueryParameters(uri);
            return parameters.ContainsKey(key) ? parameters[key] : null;
        }

        private static string RemoveParameterFromUrl(Uri uri, string key)
        {
            var uriBuilder = new UriBuilder(uri);
            var decodedQuery = DecodeQueryParameters(uri);
            if (decodedQuery.Any())
            {
                decodedQuery.Remove(key);
                string newQuery = GetQueryFromParameters(decodedQuery);
                uriBuilder.Query = newQuery;
            }

            return uriBuilder.Uri.ToString();
        }
        
        private static string ReplaceUrlPath(string uriCleared, string callbackUri)
        {
            var uriBuilder = new UriBuilder(uriCleared);
            var callbackBuilder = new UriBuilder(callbackUri);
            uriBuilder.Scheme = callbackBuilder.Scheme;
            uriBuilder.Host = callbackBuilder.Host;
            uriBuilder.Path = callbackBuilder.Path;
            uriBuilder.Port = callbackBuilder.Port;

            return uriBuilder.Uri.ToString();
        }

        private static Dictionary<string, string> DecodeQueryParameters(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("Uri is null");

            if (uri.Query.Length == 0)
                return new Dictionary<string, string>();
            var query = uri.ToString().Split('?').LastOrDefault();

            return query?.TrimStart('?')
                            .Split(new[] { '&', ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(parameter => parameter.Split(new[] { '=' }, count: 2, StringSplitOptions.RemoveEmptyEntries))
                            .GroupBy(parts => parts[0],
                                     parts => parts.Length > 2 ? string.Join("=", parts, 1, parts.Length - 1) : (parts.Length > 1 ? parts[1] : ""))
                            .ToDictionary(grouping => grouping.Key,
                                          grouping => string.Join(",", grouping));
        }

        private static string GetQueryFromParameters(Dictionary<string, string> queryParameters)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach (var item in queryParameters)
            {
                queryString.Add(item.Key, item.Value);
            }

            return string.Join("&", queryString.AllKeys.Select(key => $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(queryString[key])}"));

        }

        
    }
}