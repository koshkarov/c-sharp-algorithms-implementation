using Algorithms.Sort;
using NUnit.Framework;
using System;
using Algorithms.Sort.Enums;
using Algorithms.Extensions;

namespace Algorithms.Tests
{
    [TestFixture]
    class SortTests
    {
        private const int _size = 10000;
        private static int[] _unsorted;
        private static int[] _sorted;

        [SetUp]
        protected void SetUp()
        {
            _unsorted = new int[_size];
            _sorted = new int[_size];

            // populate both arrays
            for (int i = 0; i < _unsorted.Length; i++)
            {
                _sorted[i] = i;
                _unsorted[i] = i;
            }

            // shuffle the unsorted
            _unsorted.Shuffle();
        }


        [Test]
        public void TestInsertionSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            InsertionSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }
            
        }

        [Test]
        public void TestMergeSortTopDown()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            MergeSort.Sort(result, MergeSortType.TopDown);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestMergeSortBottomUp()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            MergeSort.Sort(result, MergeSortType.BottomUp);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestCountingSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            CountingSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestBubbleSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            BubbleSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestHeapSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            HeapSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestQuickSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            QuickSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestRadixSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            RadixSort.Sort(result, RadixSort.RadixSortType.Lsd);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestSelectionSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            SelectionSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

        [Test]
        public void TestShellSort()
        {
            var result = new int[_size];
            Array.Copy(_unsorted, result, _size);

            ShellSort.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(_sorted[i], result[i]);
            }

        }

    }
}
