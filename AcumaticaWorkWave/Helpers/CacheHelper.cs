using System;
using System.Runtime.Caching;

namespace AcumaticaWorkWave.Helpers
{
    public class CacheHelper<TItem>
    {
        private const double lifeTimeSeconds = 20.0;

        public TItem GetOrCreate(string key, Func<TItem> createItem)
        {
            ObjectCache cache = MemoryCache.Default;
            TItem cacheEntry;
            var item = cache.Get(key);
            if (item == null)
            {
                cacheEntry = createItem();

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(lifeTimeSeconds);

                cache.Set(key, cacheEntry, policy);
            }
            else
            {
                cacheEntry = (TItem)item;
            }
            return cacheEntry;
        }
    }
}