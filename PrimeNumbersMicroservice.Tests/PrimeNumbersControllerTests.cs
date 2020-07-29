using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PrimeNumbersMicroservice.Controllers;
using System.Numerics;
using System.Threading.Tasks;
using Xunit;

namespace PrimeNumbersMicroservice.Tests
{
    public class PrimeNumbersControllerTests
    {
        private readonly PrimeNumbersController primeNumbersController;

        public PrimeNumbersControllerTests()
        {
            var mediator = new Mock<IMediator>();
            this.primeNumbersController = new PrimeNumbersController(mediator.Object);
        }

        [Fact]
        public async Task CheckPrimeNumberSuccessful()
        {
            BigInteger value = It.IsAny<BigInteger>();
            var result = await primeNumbersController.CheckPrimeNumber(value.ToString());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CheckPrimeNumberWrongInputData()
        {
            var result = await primeNumbersController.CheckPrimeNumber("wrong");
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetNextPrimeNumberSuccessful()
        {
            BigInteger value = It.IsAny<BigInteger>();
            var result = await primeNumbersController.GetNextNumber(value.ToString());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetNextPrimeNumberWrongInputData()
        {
            var result = await primeNumbersController.GetNextNumber("wrong");
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
