using Common.TestData;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using Xunit;

namespace PrimeNumbersMicroservice.Tests
{
    public class PrimeNumbersControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string CheckPrimeNumberEndpoint = "/api/primes/{0}/check";
        private const string NextPrimeNumberEndpoint = "/api/primes/{0}/next";

        private HttpClient client { get; }

        public PrimeNumbersControllerTests(WebApplicationFactory<Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Theory]
        [ClassData(typeof(CheckPrimeNumbersTestData))]
        public async Task CheckPrimeNumberSuccessful(BigInteger input, bool output)
        {
            var response = await client.GetAsync(string.Format(CheckPrimeNumberEndpoint, input));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            Assert.Equal(output, result);
        }

        [Fact]
        public async Task CheckPrimeNumberNegativeInputData()
        {
            var response = await client.GetAsync(string.Format(CheckPrimeNumberEndpoint, -1));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CheckPrimeNumberWrongInputData()
        {
            var response = await client.GetAsync(string.Format(CheckPrimeNumberEndpoint, "wrong"));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(NextPrimeNumberTestData))]
        public async Task GetNextPrimeNumberSuccessful(BigInteger input, BigInteger output)
        {
            var response = await client.GetAsync(string.Format(NextPrimeNumberEndpoint, input));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = BigInteger.Parse(await response.Content.ReadAsStringAsync());
            Assert.Equal(output, result);
        }

        [Fact]
        public async Task GetNextPrimeNumberNegativeInputData()
        {
            var response = await client.GetAsync(string.Format(NextPrimeNumberEndpoint, -1));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetNextPrimeNumberWrongInputData()
        {
            var response = await client.GetAsync(string.Format(NextPrimeNumberEndpoint, "wrong"));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
