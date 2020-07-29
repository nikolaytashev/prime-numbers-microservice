using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Common.TestData
{
    public class CheckPrimeNumbersTestData : IEnumerable<object[]>
    {
        private readonly IDictionary<BigInteger, bool> values = new Dictionary<BigInteger, bool>
        {
            { 11, true },
            { 13, true },
            { 14, false },
            { 9973, true },
            { 1000000007, true },
            { 1002550007, false },
            { 10025500071, false },
            { 100255000717, true },
            { 100255000713, false },
            { 100255000757, true }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return values.Select(item => new object[] { item.Key, item.Value }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
