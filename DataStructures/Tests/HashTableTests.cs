using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class HashTableTests
    {
        private HashTable<string, string> _hashTable;
        private static readonly int MAX_SIZE = 1000;

        [SetUp]
        protected void SetUp()
        {
            _hashTable = new HashTable<string, string>(MAX_SIZE);
        }

        [Test]
        public void AddKeyValuePair()
        {
            for (int i = 0; i < MAX_SIZE + 1000; i++)
            {
                _hashTable[$"key_{i}"] = $"value_{i}";
            }
        }

        [Test]
        public void ReadAddedKeyValuePair()
        {
            for (int i = 0; i < MAX_SIZE + 1000; i++)
            {
                _hashTable[$"key_{i}"] = $"value_{i}";
            }

            for (int i = 0; i < MAX_SIZE + 1000; i++)
            {
                Assert.AreEqual($"value_{i}", _hashTable[$"key_{i}"]);
            }
        }
    }
}
