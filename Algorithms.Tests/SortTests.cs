using Algorithms.Sort;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    class SortTests
    {
        private const int Size = 100;
        private static int[] _unsorted;

        [SetUp]
        protected void SetUp()
        {
            Random rnd = new Random();

            _unsorted = new int[Size];
            for (int i = 0; i < _unsorted.Length; i++)
                _unsorted[i] = Size - i;
        }


        [Test]
        public void TestInsertionSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = InsertionSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }
            
        }

        [Test]
        public void TestMergeSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = MergeSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestCountingSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = CountingSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestBubbleSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = BubbleSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestHeapSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = HeapSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestQuickSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = QuickSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestRadixSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = RadixSort.Sort(result, RadixSort.RadixSortType.Lsd);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestSelectionSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = SelectionSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestShellSort()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            result = ShellSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

    }
}
