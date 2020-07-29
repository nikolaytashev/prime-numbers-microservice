using Common.TestData;
using Moq;
using Services.Interfaces;
using System.Numerics;
using Xunit;

namespace Services.Tests
{
    public class PrimeNumbersServiceTests
    {
        private readonly PrimeNumbersService primeNumbersService;

        public PrimeNumbersServiceTests()
        {
            var mockedPrimeNumbersCacheService = new Mock<IPrimeNumbersCacheService>();
            mockedPrimeNumbersCacheService.Setup(s => s.TryGetValue(It.IsAny<BigInteger>(), out It.Ref<bool>.IsAny)).Returns(false);
            this.primeNumbersService = new PrimeNumbersService(mockedPrimeNumbersCacheService.Object);
        }

        [Theory]
        [ClassData(typeof(CheckPrimeNumbersTestData))]
        public void CheckPrimeNumbersTest(BigInteger input, bool output)
        {
            var result = primeNumbersService.CheckPrimeNumber(input);
            Assert.True(result == output);
        }

        [Theory]
        [ClassData(typeof(NextPrimeNumberTestData))]
        public void NextPrimeNumbersTest(BigInteger input, BigInteger output)
        {
            var result = primeNumbersService.GetNextPrime(input);
            Assert.Equal(result, output);
        }
    }
}
