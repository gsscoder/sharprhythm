using Microsoft.FSharp.Collections;
using FsCheck;
using FsCheck.Xunit;
using SharpRhythm.Algorithms;
using SharpRhythm.Tests.Fakes;

namespace SharpRhythm.Tests.Unit
{
    public class QuickSortTests : SortTest
    {
        private static readonly ISort _sut = new QuickSort();

        [Property(Arbitrary = new[] { typeof(ArbitraryIntegers) })]
        public void Should_sort_numbers(FSharpList<int> list)
        {
            Execute(list, _sut);
        }

        [Property(Arbitrary = new[] { typeof(ArbitraryStrings) })]
        public void Should_sort_strings(FSharpList<string> list)
        {
            Execute(list, _sut);
        }
    }
}