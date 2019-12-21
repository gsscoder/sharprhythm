using System;
using System.Collections.Generic;

namespace SharpRhythm.Algorithms
{
    /// <summary>
    /// Represents a sorting algorithm.
    /// </summary>
    public interface ISort
    {
        IEnumerable<T> Sort<T>(IEnumerable<T> collection)
            where T : IComparable, 
                      IComparable<T>;
    }
}