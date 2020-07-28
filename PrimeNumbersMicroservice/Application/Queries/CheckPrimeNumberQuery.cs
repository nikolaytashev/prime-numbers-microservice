using MediatR;
using System.Numerics;

namespace Application.Queries
{
    public class CheckPrimeNumberQuery : IRequest<bool>
    {
        public BigInteger Value { get; }

        public CheckPrimeNumberQuery(BigInteger value)
        {
            this.Value = value;
        }
    }
}
