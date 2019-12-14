using Xunit;
using FluentAssertions;
using SharpRhythm.Structures;

namespace SharpRhythm.Tests.Unit
{
    public class TrieTests
    {
        [Fact]
        public void Should_create()
        {
            var trie = new Trie();

            trie.Head.ToString().Should().Be(Trie.HeadCharacter.ToString());
        }

        [Fact]
        public void Should_add_words()
        {
            var trie = new Trie();

            trie.AddWord("cat");
            trie.Head.ToString().Should().Be("*:c");
            trie.Head.GetChild('c').ToString().Should().Be("c:a");

            trie.AddWord("car");
            trie.Head.ToString().Should().Be("*:c");
            trie.Head.GetChild('c').ToString().Should().Be("c:a");
            trie.Head.GetChild('c').GetChild('a').ToString().Should().Be("a:tr");
            trie.Head.GetChild('c').GetChild('a').GetChild('t').ToString().Should().Be("t*");
        }

        [Fact]
        public void Should_delete_word()
        {
            var trie = new Trie();
            
            trie.AddWord("carpet");
            trie.AddWord("car");
            trie.AddWord("cat");
            trie.AddWord("cart");
            trie.DoesWordExist("carpet").Should().BeTrue();
            trie.DoesWordExist("car").Should().BeTrue();
            trie.DoesWordExist("cart").Should().BeTrue();
            trie.DoesWordExist("cat").Should().BeTrue();

            trie.DeleteWord("carpool");
            trie.DoesWordExist("carpet").Should().BeTrue();
            trie.DoesWordExist("car").Should().BeTrue();
            trie.DoesWordExist("cart").Should().BeTrue();
            trie.DoesWordExist("cat").Should().BeTrue();

            trie.DeleteWord("carpet");
            trie.DoesWordExist("carpet").Should().BeFalse();
            trie.DoesWordExist("car").Should().BeTrue();
            trie.DoesWordExist("cart").Should().BeTrue();
            trie.DoesWordExist("cat").Should().BeTrue();

            trie.DeleteWord("cat");
            trie.DoesWordExist("car").Should().BeTrue();
            trie.DoesWordExist("cart").Should().BeTrue();
            trie.DoesWordExist("cat").Should().BeFalse();

            trie.DeleteWord("car");
            trie.DoesWordExist("car").Should().BeFalse();
            trie.DoesWordExist("cart").Should().BeTrue();

            trie.DeleteWord("cart");
            trie.DoesWordExist("car").Should().BeFalse();
            trie.DoesWordExist("cart").Should().BeFalse();
        }
    }
}