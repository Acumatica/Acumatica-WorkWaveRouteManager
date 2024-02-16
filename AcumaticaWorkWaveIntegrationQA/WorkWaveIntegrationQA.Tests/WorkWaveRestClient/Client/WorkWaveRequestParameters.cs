using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveRequestParameters
    {
        private const string ids_string = "ids";
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _parameters[key] = value;
        }
        public void AddIds(string value)
        {
            _parameters[ids_string] = value;
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
