using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.API.Provider
{
    public class WWProviderLocator
    {
        private WWProviderLocator()
        {
        }

        private static WWProviderLocator _instance;
        private static readonly Dictionary<Type, object> _cache = new Dictionary<Type, object>();
        public static WWProviderLocator Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new WWProviderLocator();
                }
                return _instance;
            }
        }

        public T Get<T>(params object[] args)
        {
            var type = typeof(T);
            if (!_cache.ContainsKey(type))
            {
                _cache[type] = (T)Activator.CreateInstance(type, args);
            }
            
            return (T)_cache[type];
        }

        public WWProviderLocator Reset<T>()
        {
            var type = typeof(T);
            if (_cache.ContainsKey(type))
            {
                _cache.Remove(type);
            }
            return Instance;
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }
}