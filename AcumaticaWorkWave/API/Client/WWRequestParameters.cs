using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Client
{
    public class WWRequestParameters
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _parameters[key] = value;
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
