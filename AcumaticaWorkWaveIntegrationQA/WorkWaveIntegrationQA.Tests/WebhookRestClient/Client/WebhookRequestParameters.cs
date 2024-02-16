using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WebhookRestClient.Client
{
    public class WebhookRequestParameters
    {
        private const string reqID_string = "reqID";
        private const string nonce_string = "nonce";
        private const string signature_string = "signature";
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _parameters[key] = value;
        }

        public void Add(Dictionary<string, string> queryDictionary)
        {
            foreach (var pair in queryDictionary)
            {
                Add(pair.Key, pair.Value);
            }
        }

        public void Delete(string key)
        {
            if (_parameters.ContainsKey(key))
            {
                _parameters.Remove(key);
            }
        }

        public Dictionary<string, string> GetParameters()
        {
            return _parameters;
        }
    }
}
