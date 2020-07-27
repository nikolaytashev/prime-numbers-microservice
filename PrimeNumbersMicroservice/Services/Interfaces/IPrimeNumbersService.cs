using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Services.Interfaces
{
    public interface IPrimeNumbersService
    {
        bool Validate(BigInteger value);
        BigInteger GetNextPrime(BigInteger value);
    }
}
