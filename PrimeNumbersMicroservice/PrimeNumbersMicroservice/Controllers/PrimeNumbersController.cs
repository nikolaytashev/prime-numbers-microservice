using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace PrimeNumbersMicroservice.Controllers
{
    [Route("api/primes")]
    [ApiController]
    public class PrimeNumbersController : ControllerBase
    {
        private readonly IPrimeNumbersService primeNumbersService;
        private readonly IMediator mediator;

        public PrimeNumbersController(IPrimeNumbersService primeNumbersService, IMediator mediator)
        {
            this.primeNumbersService = primeNumbersService;
            this.mediator = mediator;
        }

        /// <summary>
        /// Validates whether the given number is prime or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns if the number is prime or not</returns>
        /// <remarks>
        /// Return 500 if the number is in invalid format
        /// </remarks>
        /// <response code="200">Returns if the number is prime or not</response>
        [HttpGet("{number}/check")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ValidatePrime([FromRoute] string number)
        {
            if (!BigInteger.TryParse(number, out BigInteger value))
                return BadRequest("Invalid number");

            bool result = await mediator.Send(new ValidatePrimeNumberQuery(value));
            return Ok(result);
        }

        /// <summary>
        /// Gets the next prime number after the specified one
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The next prime number</returns>
        /// <remarks>
        /// Return 500 if the number is in invalid format
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
