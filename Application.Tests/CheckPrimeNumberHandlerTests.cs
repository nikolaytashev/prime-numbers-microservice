using Application.Handlers;
using Application.Queries;
using Common.TestData;
using Moq;
using Services.Interfaces;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests
{
    public class CheckPrimeNumberHandlerTests
    {
        private readonly CheckPrimeNumberHandler checkPrimeNumberHandler;

        public CheckPrimeNumberHandlerTests()
        {
            var mockService = new Mock<IPrimeNumbersService>();
            foreach(var model in new CheckPrimeNumbersTestData())
            {
                mockService.Setup(s => s.CheckPrimeNumber((BigInteger)model[0])).Returns((bool)model[1]).Verifiable();
            }
            
            this.checkPrimeNumberHandler = new CheckPrimeNumberHandler(mockService.Object);
        }

        [Theory]
        [ClassData(typeof(CheckPrimeNumbersTestData))]
        public async Task HandleCheckPrimeNumberSuccessful(BigInteger input, bool output)
        {
            var result = await checkPrimeNumberHandler.Handle(new CheckPrimeNumberQuery(input), CancellationToken.None);
            Assert.Equal(result, output);
        }
    }
}
