using Algorithms.Sort;
using NUnit.Framework;
using System;
using Algorithms.Sort.Enums;

namespace Algorithms.Tests
{
    [TestFixture]
    class SortTests
    {
        private const int Size = 10000;
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

            InsertionSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }
            
        }

        [Test]
        public void TestMergeSortTopDown()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            MergeSort.Sort(result, MergeSortType.TopDown);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

        [Test]
        public void TestMergeSortBottomUp()
        {
            var result = new int[Size];
            Array.Copy(_unsorted, result, Size);

            MergeSort.Sort(result, MergeSortType.BottomUp);

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

            CountingSort.Sort(result);

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

            BubbleSort.Sort(result);

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

            HeapSort.Sort(result);

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

            QuickSort.Sort(result);

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

            RadixSort.Sort(result, RadixSort.RadixSortType.Lsd);

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

            SelectionSort.Sort(result);

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

            ShellSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i + 1, result[i]);
            }

        }

    }
}
