using Core.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Services
{
    public class PrimeNumbersService : IPrimeNumbersService
    {
        private const int NegativeSignNumber = -1;
        
        public bool Validate(BigInteger value)
        {
            if (value.Sign == NegativeSignNumber || value.IsZero || value.IsOne)
                return false;

            if (value == 2 || value == 3 || value == 5)
                return true;

            BigInteger.DivRem(value, 2, out BigInteger remainder);
            if (remainder == 0)
                return false;

            BigInteger.DivRem(value, 3, out remainder);
            if (remainder == 0)
                return false;

            BigInteger.DivRem(value, 5, out remainder);
            if (remainder == 0)
                return false;

            BigInteger boundary = value.Sqrt();
            bool hasDividerWithRemainder = LinqExtensions.RangeWithStep(6, boundary, (index) => BigInteger.Add(index, 6))
                .AsParallel().Any(item =>
                {
                    BigInteger.DivRem(value, item + 1, out BigInteger remainder);
                    if (remainder == 0)
                        return true;

                    BigInteger.DivRem(value, item + 5, out remainder);
                    if (remainder == 0)
                        return true;

                    return false;
                });

            return !hasDividerWithRemainder;
        }

        public BigInteger GetNextPrime(BigInteger value)
        {
            if (value.IsEven)
                value = BigInteger.Subtract(value, 1);

            while (true)
            {
                value = BigInteger.Add(value, 2);
                if (Validate(value))
                    return value;
            }
        }
    }
}
