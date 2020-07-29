using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Common.TestData
{
    public class NextPrimeNumberTestData : IEnumerable<object[]>
    {
        private readonly IDictionary<BigInteger, BigInteger> values = new Dictionary<BigInteger, BigInteger>
        {
            { 11, 11 },
            { 12, 13 },
            { 15, 17 },
            { 9977, 10007 },
            { 1000000111, 1000000123 },
            { 1002550007, 1002550009 },
            { 100255000717, 100255000717 },
            { 100255000713, 100255000717 },
            { 100255000718, 100255000757 }
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
