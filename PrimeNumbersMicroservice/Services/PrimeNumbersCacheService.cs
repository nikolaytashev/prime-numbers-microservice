using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Services
{
    public class PrimeNumbersCacheService : IPrimeNumbersCacheService
    {
        private readonly IMemoryCache cache;

        public PrimeNumbersCacheService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public bool TryGetValue(BigInteger key, out bool value)
        {
            return cache.TryGetValue(key, out value);
        }

        public void SetValue(BigInteger key, bool value)
        {
            cache.Set(key, value, new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove));
        }
    }
}
