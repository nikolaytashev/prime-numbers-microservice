using System.Numerics;

namespace Services.Interfaces
{
    public interface IPrimeNumbersService
    {
        BigInteger GetNextPrime(BigInteger value);
        bool CheckPrimeNumber(BigInteger value);
    }
}
