using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Core.Extensions
{
    public static class BigIntegerExtensions
    {
        public static BigInteger Sqrt(this BigInteger value)
        {
            if (value == 0) 
                return 0;

            if (value > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(value, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!IsSqrt(value, root))
                {
                    root += value / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("Unsupported operation");
        }

        private static bool IsSqrt(BigInteger value, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (value >= lowerBound && value < upperBound);
        }
    }
}
