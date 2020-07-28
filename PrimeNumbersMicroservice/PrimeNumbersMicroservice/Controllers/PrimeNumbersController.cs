using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PrimeNumbersMicroservice.Controllers
{
    /// <summary>
    /// Web API Controller for managing prime numbers
    /// </summary>
    [Route("api/primes")]
    [ApiController]
    public class PrimeNumbersController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructs the PrimeNumbersController
        /// </summary>
        public PrimeNumbersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Checks whether the given number is prime or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if the number is prime, otherwise - false</returns>
        /// <remarks>
        /// Returns 500 if the number is in invalid format
        /// </remarks>
        /// <response code="200">True if the number is prime, otherwise - false</response>
        [HttpGet("{number}/check")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckPrimeNumber([FromRoute] string number)
        {
            if (!BigInteger.TryParse(number, out BigInteger value))
                return BadRequest("Invalid number");

            bool result = await mediator.Send(new CheckPrimeNumberQuery(value));
            return Ok(result);
        }

        /// <summary>
        /// Gets the next prime number after the specified one
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The next prime number</returns>
        /// <remarks>
        /// Returns 500 if the number is in invalid format
        /// </remarks>
        /// <response code="200">Returns the next prime number</response>
        [HttpGet("{number}/next")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNextNumber([FromRoute] string number)
        {
            if (!BigInteger.TryParse(number, out BigInteger value))
                return BadRequest("Invalid number");
            
            BigInteger result = await mediator.Send(new GetNextPrimeNumberQuery(value));
            return Ok(result.ToString());
        }
    }
}
