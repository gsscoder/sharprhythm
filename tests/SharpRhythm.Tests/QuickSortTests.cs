using Xunit;
using FluentAssertions;
using SharpRhythm.Algorithms.Sort;

namespace SharpRhythm.Tests
{
    public class QuickSortTests
    {
        [Fact]
        public void Should_sort_positive_numbers()
        {
            var sorted = QuickSort.Sort(Integers.Unsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Integers.Unsorted.Length)
                .And.Contain(Integers.Sorted);
        }

        [Fact]
        public void Should_sort_negative_numbers()
        {
            var sorted = QuickSort.Sort(Integers.NegativeUnsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Integers.NegativeUnsorted.Length)
                .And.Contain(Integers.NegativeSorted);
        }

        [Fact]
        public void Should_sort_strings()
        {
            var sorted = QuickSort.Sort(Strings.Unsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Strings.Unsorted.Length)
                .And.Contain(Strings.Sorted);
        }
    }
}