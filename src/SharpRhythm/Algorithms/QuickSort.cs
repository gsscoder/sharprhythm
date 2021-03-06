using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpRhythm.Algorithms
{
    public class QuickSort : ISort
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection)
            where T : IComparable, 
                      IComparable<T>
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            var list = new List<T>(collection);

            if (list.Count() <= 1) {
                return list;
            }

            var leftList = new List<T> {};
            var rightList = new List<T> {};

            T pivotElement;
            (pivotElement, list) = list.Shift();
            var centerList = new List<T>{ pivotElement };

            while (list.Count() > 0) {
                T currentElement;
                (currentElement, list) = list.Shift();

                var equality = currentElement.CompareTo(pivotElement);
                if (equality == 0) {
                    centerList.Add(currentElement);
                }
                else if (equality < 0) {
                    leftList.Add(currentElement);
                }
                else {
                    rightList.Add(currentElement);
                }
            }
            
            var leftListSorted = Sort(leftList);
            var rightListSorted = Sort(rightList);

            return leftListSorted.Concat(centerList).Concat(rightListSorted);
        }
    }
}