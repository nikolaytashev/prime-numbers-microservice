﻿using MediatR;
using System.Numerics;

namespace Application.Queries
{
    public class GetNextPrimeNumberQuery : IRequest<BigInteger>
    {
        public BigInteger Value { get; }

        public GetNextPrimeNumberQuery(BigInteger value)
        {
            this.Value = value;
        }
    }
}
