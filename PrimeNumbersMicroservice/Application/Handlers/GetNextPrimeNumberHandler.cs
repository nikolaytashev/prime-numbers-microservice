using Application.Queries;
using MediatR;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetNextPrimeNumberHandler : IRequestHandler<GetNextPrimeNumberQuery, BigInteger>
    {
        private readonly IPrimeNumbersService primeNumbersService;

        public GetNextPrimeNumberHandler(IPrimeNumbersService primeNumbersService)
        {
            this.primeNumbersService = primeNumbersService;
        }

        public Task<BigInteger> Handle(GetNextPrimeNumberQuery request, CancellationToken cancellationToken)
        {
            return primeNumbersService.GetNextPrimeAsync(request.value);
        }
    }
}
