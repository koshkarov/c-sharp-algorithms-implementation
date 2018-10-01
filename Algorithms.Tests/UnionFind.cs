using NUnit.Framework;
using System.Collections.Generic;
using Algorithms.DataStructures.UnionFind;

namespace Algorithms.Tests
{
    [TestFixture]
    class UnionFindTests
    {
        private IUnionFind _unionFind;
        private const int Size = 10;
        private readonly int[,] _unions = { {4, 3}, {3, 8}, {6, 5}, {9, 4}, {2, 1}, {8, 9}, {5, 0}, {7, 2}, {6, 1}, {1, 0}, {6, 7} };
        private const string ExpectedString = "4 3 : 3 8 : 6 5 : 9 4 : 2 1 : 5 0 : 7 2 : 6 1";
        private const int ExpectedCount = 2;

        [SetUp]
        protected void SetUp()
        {
            
        }

        [Test]
        public void QuickFindTests()
        {
            _unionFind = new UnionFindQuickFind(Size);
            Assert.AreEqual(ExpectedString, GetNotConnectedUnions());
            Assert.AreEqual(ExpectedCount, _unionFind.Count());
        }

        [Test]
        public void QuickUnionTests()
        {
            _unionFind = new UnionFindQuickUnion(Size);
            Assert.AreEqual(ExpectedString, GetNotConnectedUnions());
            Assert.AreEqual(ExpectedCount, _unionFind.Count());
        }

        [Test]
        public void QuickUnionWeightedTests()
        {
            _unionFind = new UnionFindQuickUnionWeightedSize(Size);
            Assert.AreEqual(ExpectedString, GetNotConnectedUnions());
            Assert.AreEqual(ExpectedCount, _unionFind.Count());
        }

        private string GetNotConnectedUnions()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < _unions.GetLength(0); i++)
            {
                int p = _unions[i, 0];
                int q = _unions[i, 1];

                if (!_unionFind.Connected(p, q))
                {
                    _unionFind.Union(p, q);
                    result.Add($"{p} {q}");
                }
            }

            return string.Join(" : ", result);
        }
    }
}
