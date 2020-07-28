using Core.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System.Numerics;

namespace Services
{
    public class PrimeNumbersService : IPrimeNumbersService
    {
        private readonly IPrimeNumbersCacheService cache;

        public PrimeNumbersService(IPrimeNumbersCacheService cache)
        {
            this.cache = cache;
        }

        public BigInteger GetNextPrime(BigInteger value)
        {
            while (true)
            {
                if (CheckPrimeNumber(value))
                    return value;

                value = BigInteger.Add(value, 1);
            }
        }

        public bool CheckPrimeNumber(BigInteger value)
        {
            if (cache.TryGetValue(value, out bool result))
                return result;

            result = value.IsPrimeNumber(true);
            cache.SetValue(value, result);

            return result;
        }
    }
}
