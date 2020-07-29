using Common.TestData;
using Core.Extensions;
using System.Numerics;
using Xunit;

namespace Core.Tests
{
    public class BigIntegerTests
    {
        [Theory]
        [ClassData(typeof(CheckPrimeNumbersTestData))]
        public void IsPrimeNumberTest(BigInteger input, bool output)
        {
            Assert.Equal(input.IsPrimeNumber(true), output);
        }
    }
}
