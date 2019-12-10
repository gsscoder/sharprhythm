using System.Collections.Generic;
using System.Linq;

namespace SharpRhythm
{
    static class EnumerableExtensions
    {
        public static (T, List<T>) Shift<T>(this IEnumerable<T> array)
        {
            return (array.First(), new List<T>(array.Skip(1)));
        }
    }
}