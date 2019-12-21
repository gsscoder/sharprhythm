using Xunit;
using FluentAssertions;
using SharpRhythm.Algorithms;

namespace SharpRhythm.Tests.Unit
{
    public class LevenshteinFuzzyMatchTests
    {
        [Fact]
        public void Equal_strings_have_distance_zero()
        {
            var sut = new LevenshteinFuzzyMatch();
            
            sut.Compare("levenshtein", "levenshtein")
                .Should().Be(0);
        }

        [Fact]
        public void When_miss_just_one_char_distance_is_one()
        {
            var sut = new LevenshteinFuzzyMatch();
            
            sut.Compare("levenshtein", "levenshtei")
                .Should().Be(1);

            sut.Compare("evenshtein", "levenshtein")
                .Should().Be(1);
        }

        [Fact]
        public void When_difference_is_one_char_case_distance_is_one()
        {
            var sut = new LevenshteinFuzzyMatch();
            
            sut.Compare("Levenshtein", "levenshtein")
                .Should().Be(1);

            sut.Compare("levensHtein", "levenshtein")
                .Should().Be(1);
        }
    }
}