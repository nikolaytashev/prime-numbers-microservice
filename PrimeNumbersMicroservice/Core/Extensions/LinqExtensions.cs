using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> RangeWithStep<T>(T startIndex, T endIndex, Func<T, T> stepFunction) where T : IComparable, IComparable<T>
        {
            for (T i = startIndex; i.CompareTo(endIndex) <= 0; i = stepFunction(i))
            {
                yield return i;
            }
        }
    }
}
