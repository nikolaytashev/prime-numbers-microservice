using Application.Queries;
using MediatR;
using Services.Interfaces;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class ValidatePrimeNumberHandler : IRequestHandler<ValidatePrimeNumberQuery, bool>
    {
        private readonly IPrimeNumbersService primeNumbersService;

        public ValidatePrimeNumberHandler(IPrimeNumbersService primeNumbersService)
        {
            this.primeNumbersService = primeNumbersService;
        }

        public Task<bool> Handle(ValidatePrimeNumberQuery request, CancellationToken cancellationToken)
        {
            return primeNumbersService.ValidateAsync(request.value);
        }
    }
}
