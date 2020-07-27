using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPrimeNumbersService
    {
        Task<bool> ValidateAsync(BigInteger value);
        Task<BigInteger> GetNextPrimeAsync(BigInteger value);
    }
}
