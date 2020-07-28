using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Core.Extensions
{
    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Checks whether the given number is prime
        /// </summary>
        /// <param name="useParallel">true to enables parallelization of the operation, otherwise - false</param>
        /// <returns>true if number is prime, otherwise - false</returns>
        public static bool IsPrimeNumber(this BigInteger value, bool useParallel = false)
        {
            if (value.Sign == Constants.NegativeSignNumber || value.IsZero || value.IsOne)
                return false;

            if (Constants.MinimumValueDividers.Any(item => value == item))
                return true;

            if (Constants.MinimumValueDividers.Any(item => BigInteger.Remainder(value, item) == 0))
                return false;

            BigInteger boundary = value.Sqrt();

            IEnumerable<BigInteger> enumerable = LinqExtensions.RangeWithStep(Constants.ValidationStepSize, boundary, (index) => BigInteger.Add(index, Constants.ValidationStepSize));
            if (useParallel)
                enumerable = enumerable.AsParallel();

            bool hasDividerWithNoRemainder = enumerable.Any(index =>
            {
                if (BigInteger.Remainder(value, index + 1) == 0 || BigInteger.Remainder(value, index + 5) == 0)
                    return true;

                return false;
            });

            return !hasDividerWithNoRemainder;
        }

        /// <summary>
        /// Square root of the given number
        /// </summary>
        /// <returns>Returns the square root of the given number</returns>
        public static BigInteger Sqrt(this BigInteger value)
        {
            return (BigInteger)Math.Exp(BigInteger.Log(value) / 2);
        }
    }
}
