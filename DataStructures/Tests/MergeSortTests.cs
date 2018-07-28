using System.Collections.Generic;
using Algorithms.Algorithms.Sort;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class MergeSortTests
    {
        private List<int> list; 

        [SetUp]
        protected void SetUp()
        {
            list = new List<int>();
            for (int i = 9; i > 0; i--)
                list.Add(i);
        }

        [Test]
        public void MergeSort()
        {
            var expected = new List<int>();
            for (int i = 1; i < 10; i++)
                expected.Add(i);

            var sorted = Sort.MergeSort(list);
            Assert.AreEqual(expected, sorted);
        }
    }
}
