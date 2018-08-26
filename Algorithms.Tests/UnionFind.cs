using System;
using System.IO;
using Algorithms.DataStructures;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class UnionFindTests
    {
        private UnionFindQuickFind _unionFindQuickFind;
        private const int MAX_SIZE = 10;
        private int[,] _data;

        [SetUp]
        protected void SetUp()
        {
            _unionFindQuickFind = new UnionFindQuickFind(MAX_SIZE);
            _data = new[,]
            {
                {4, 3},
                {3, 8},
                {6, 5},
                {9, 4},
                {2, 1},
                {8, 9},
                {5, 0},
                {7, 2},
                {6, 1},
                {1, 0},
                {6, 7}
            };
        }

        /// <summary>
        /// If the sites are in different components, merge the two components
        /// and print the pair to standard output.
        /// </summary>
        [Test]
        public void PrintNotConnectedComponentsTest()
        {
            string result = "";

            // Print only not connected unions
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                int p = _data[i, 0];
                int q = _data[i, 1];

                if (!_unionFindQuickFind.Connected(p, q))
                {
                    _unionFindQuickFind.Union(p, q);
                    result += $"{p} {q}";
                }
            }

            string expected = "4 3" +
                              "3 8" +
                              "6 5" +
                              "9 4" +
                              "2 1" +
                              "5 0" +
                              "7 2" +
                              "6 1";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountComponentsTest()
        {
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                int p = _data[i, 0];
                int q = _data[i, 1];

                _unionFindQuickFind.Union(p, q);
            }

            Assert.AreEqual(2, _unionFindQuickFind.Count());
        }
    }
}
