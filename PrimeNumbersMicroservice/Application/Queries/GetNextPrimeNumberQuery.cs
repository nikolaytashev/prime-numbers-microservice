using MediatR;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Application.Queries
{
    public class GetNextPrimeNumberQuery : IRequest<BigInteger>
    {
        public BigInteger value { get; }

        public GetNextPrimeNumberQuery(BigInteger value)
        {
            this.value = value;
        }
    }
}
