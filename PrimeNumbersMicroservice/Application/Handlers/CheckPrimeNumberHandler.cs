using Application.Queries;
using MediatR;
using Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CheckPrimeNumberHandler : IRequestHandler<CheckPrimeNumberQuery, bool>
    {
        private readonly IPrimeNumbersService primeNumbersService;

        public CheckPrimeNumberHandler(IPrimeNumbersService primeNumbersService)
        {
            this.primeNumbersService = primeNumbersService;
        }

        public Task<bool> Handle(CheckPrimeNumberQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(primeNumbersService.CheckPrimeNumber(request.Value));
        }
    }
}
