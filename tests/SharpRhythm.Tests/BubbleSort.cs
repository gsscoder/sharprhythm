using System.Collections.Generic;
using Xunit;
using SharpRhythm.Algorithms.Sort;

namespace SharpRhythm.Tests
{
    public class BubbleSortTests
    {
        [Fact]
        public void Should_sort_positive_numbers()
        {
            var sorted = BubbleSort.Sort(Integers.Unsorted);

            Assert.Equal(Integers.Sorted, sorted);
        }

        [Fact]
        public void Should_sort_negative_numbers()
        {
            var sorted = BubbleSort.Sort(Integers.NegativeUnsorted);

            Assert.Equal(Integers.NegativeSorted, sorted);
        }

        [Fact]
        public void Should_sort_strings()
        {
            var sorted = BubbleSort.Sort(Strings.Unsorted);

            Assert.Equal(Strings.Sorted, sorted);
        }
    }
}
