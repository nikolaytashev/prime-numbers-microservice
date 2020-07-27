using MediatR;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Application.Queries
{
    public class ValidatePrimeNumberQuery : IRequest<bool>
    {
        public BigInteger value { get; }

        public ValidatePrimeNumberQuery(BigInteger value)
        {
            this.value = value;
        }
    }
}
