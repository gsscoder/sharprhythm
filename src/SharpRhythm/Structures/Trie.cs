using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpRhythm.Structures
{
    public class TrieNode
    {
        private readonly char _character;
        private readonly Hashtable _children = new Hashtable();

        public TrieNode(char character, bool completeWord = false)
        {
            _character = character;
            CompleteWord = completeWord;
        }

        internal bool CompleteWord
        {
            get;
            set;
        }

        public TrieNode GetChild(char character)
        {
            return (TrieNode)_children[character];
        }

        public TrieNode AddChild(char character, bool completeWord = false)
        {
            if (!_children.ContainsKey(character)) {
                _children[character] = new TrieNode(character, completeWord);
            }
            var childNode = (TrieNode)_children[character];
            childNode.CompleteWord = childNode.CompleteWord || completeWord;
            return childNode;
        }

        public TrieNode RemoveChild(char character)
        {
            var childNode = GetChild(character);
            if (childNode == null &&
                !childNode.CompleteWord && !childNode.HasChildren(character)) {
                _children.Remove(character);
            }
            return this;
        }

        public bool HasChild(char character)
        {
            return _children.ContainsKey(character);
        }

        public bool HasChildren(char character)
        {
            return _children.Keys.Count != 0; 
        }

        public IEnumerable<string> SuggestChildren()
        {
            foreach (var key in _children.Keys) {
                yield return key.ToString();
            }
        }

        public override string ToString()
        {
            var children = string.Join(string.Empty, SuggestChildren().ToArray());
            children = children.Length > 0 ? $":{children}" : string.Empty;
            var completeString = CompleteWord ? "*" : string.Empty;

            return $"{_character}{completeString}{children}";
        }
    }

    public class Trie
    {
#if DEBUG
        public const char HeadCharacter = '*';
#else
        private const char HeadCharacter = '*';
#endif
        public Trie()
        {
            Head = new TrieNode(HeadCharacter);
        }

#if DEBUG
        public TrieNode Head
#else
        internal TrieNode Head
#endif
        {
            get;
            private set;
        }

        public Trie AddWord(string word)
        {
            var characters = word.ToArray();
            var currentNode = Head;

            for (var charIndex = 0; charIndex < characters.Length; charIndex++) {
                var complete = charIndex == characters.Length - 1;
                currentNode = currentNode.AddChild(characters[charIndex], complete);
            }

            return this;
        }

        public Trie DeleteWord(string word) {
            void DepthFirstDelete(TrieNode currentNode, int charIndex = 0) {
                if (charIndex >= word.Length) {
                    return;
                }
                var character = word[charIndex];
                var nextNode = currentNode.GetChild(character);
                if (nextNode == null) {
                    return;
                }
                DepthFirstDelete(nextNode, charIndex + 1);
                if (charIndex == (word.Length - 1)) {
                    nextNode.CompleteWord = false;
                }

                currentNode.RemoveChild(character);
            };

            DepthFirstDelete(Head);

            return this;
        }

        public IEnumerable<string> SuggestNextCharacters(string word) {
            var lastCharacter = GetLastCharacterNode(word);
            if (lastCharacter == null) {
                return null;
            }

            return lastCharacter.SuggestChildren();
        }

        public bool DoesWordExist(string word)
        {
            var lastCharacter = GetLastCharacterNode(word);

            return lastCharacter != null && lastCharacter.CompleteWord;
        }

        public TrieNode GetLastCharacterNode(string word) {
            var characters = word.ToArray();
            var currentNode = Head;

            for (var charIndex = 0; charIndex < characters.Length; charIndex += 1) {
                if (!currentNode.HasChild(characters[charIndex])) {
                    return null;
                }
                currentNode = currentNode.GetChild(characters[charIndex]);
            }

            return currentNode;
        }
    }
}