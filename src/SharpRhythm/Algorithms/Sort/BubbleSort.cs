using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpRhythm.Algorithms
{
    public static class BubbleSort
    {
        public static IEnumerable<T> Sort<T>(IEnumerable<T> collection)
            where T : IComparable, 
                      IComparable<T>
        {
            bool swapped;
            var array = collection.ToArray();

            for (var i = 1; i < array.Length; i++) {
                swapped = false;
                for (var j = 0; j < array.Length - i; j++) {
                    var next = array[j + 1];
                    var actual = array[j];
                    if (next.CompareTo(actual) < 0) {
                        array[j] = next;
                        array[j + 1] = actual;
                        swapped = true;
                    }
                }
                if (!swapped) {
                    return array;
                }
            }
            return array;
        }
    }
}