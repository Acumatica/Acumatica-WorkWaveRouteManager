using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveIntegrationQA.Tests.WorkWaveRestClient.Client
{
    public class WorkWaveUrlSegments
    {
        private const string territoryId_string = "territoryId";
        private const string orderId_string = "orderId";
        private const string date_string = "date";
        private readonly Dictionary<string, string> _urlSegments = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _urlSegments.Add(key, value);
        }

        public void AddTerritoryId(string value)
        {
            _urlSegments.Add(territoryId_string, value);
        }

        public void AddOrderId(string value)
        {
            _urlSegments.Add(orderId_string, value);
        }

        public void AddDate(string value)
        {
            _urlSegments.Add(date_string, value);
        }

        public void Delete(string key)
        {
            if (_urlSegments.ContainsKey(key))
            {
                _urlSegments.Remove(key);
            }
        }

        public Dictionary<string, string> GetUrlSegments()
        {
            return _urlSegments;
        }
    }
}
