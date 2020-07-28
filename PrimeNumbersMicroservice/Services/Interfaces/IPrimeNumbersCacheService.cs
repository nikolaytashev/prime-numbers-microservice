using System.Numerics;

namespace Services.Interfaces
{
    public interface IPrimeNumbersCacheService
    {
        bool TryGetValue(BigInteger key, out bool value);
        void SetValue(BigInteger key, bool value);
    }
}
