using Xunit;
using FluentAssertions;
using SharpRhythm.Algorithms.Sort;

namespace SharpRhythm.Tests
{
    public class BubbleSortTests
    {
        [Fact]
        public void Should_sort_positive_numbers()
        {
            var sorted = BubbleSort.Sort(Integers.Unsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Integers.Unsorted.Length)
                .And.Contain(Integers.Sorted);
        }

        [Fact]
        public void Should_sort_negative_numbers()
        {
            var sorted = BubbleSort.Sort(Integers.NegativeUnsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Integers.NegativeUnsorted.Length)
                .And.Contain(Integers.NegativeSorted);
        }

        [Fact]
        public void Should_sort_strings()
        {
            var sorted = BubbleSort.Sort(Strings.Unsorted);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(Strings.Unsorted.Length)
                .And.Contain(Strings.Sorted);
        }
    }
}