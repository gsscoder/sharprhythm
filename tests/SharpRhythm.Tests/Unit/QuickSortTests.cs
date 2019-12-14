using Microsoft.FSharp.Collections;
using FsCheck;
using FsCheck.Xunit;
using SharpRhythm.Algorithms.Sort;
using SharpRhythm.Tests.Fakes;

namespace SharpRhythm.Tests.Unit
{
    public class QuickSortTests : SortTest
    {
        [Property(Arbitrary = new[] { typeof(ArbitraryIntegers) })]
        public void Should_sort_numbers(FSharpList<int> list)
        {
            Execute(list, QuickSort.Sort);
        }

        [Property(Arbitrary = new[] { typeof(ArbitraryStrings) })]
        public void Should_sort_strings(FSharpList<string> list)
        {
            Execute(list, QuickSort.Sort);
        }
    }
}