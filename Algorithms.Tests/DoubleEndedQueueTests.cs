using Algorithms.DataStructures;
using NUnit.Framework;
using System;
using System.Timers;

namespace Algorithms.Tests
{
    [TestFixture]
    internal class DoubleEndedQueueTests
    {
        private const int Size = 10000;

        [Test]
        public void MultipleAddFirstRemoveLast()
        {
            var deque = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequeuedValue = deque.RemoveLast();
                Assert.AreEqual(i, dequeuedValue);
            }
        }

        [Test]
        public void MultipleAddFirstRemoveFirst()
        {
            var deque = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddFirst(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequeuedValue = deque.RemoveFirst();
                Assert.AreEqual(i, dequeuedValue);
            }
        }

        [Test]
        public void MultipleAddLastRemoveFirst()
        {
            var deque = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddLast(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequeuedValue = deque.RemoveFirst();
                Assert.AreEqual(i, dequeuedValue);
            }
        }

        [Test]
        public void MultipleAddLastRemoveLast()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.AddLast(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequeuedValue = doubleEndedQueue.RemoveLast();
                Assert.AreEqual(i, dequeuedValue);
            }
        }



        [Test]
        public void QueueUnderflow()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.RemoveFirst();
            }

            try
            {
                doubleEndedQueue.RemoveFirst();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Deque is empty.", ex.Message);
            }

        }

        [Test]
        public void EmptyQueueDequeueUnderflow()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            try
            {
                doubleEndedQueue.RemoveLast();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Deque is empty.", ex.Message);
            }
        }

        [Test]
        public void EmptyDequeSizeIsZero()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();
            Assert.AreEqual(0, doubleEndedQueue.Size);
        }

        [Test]
        public void DequeSizeIncreases()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.AddLast(i);
            }

            Assert.AreEqual(Size, doubleEndedQueue.Size);
        }

        [Test]
        public void DequeSizeDecreases()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.AddLast(i);
            }

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.RemoveFirst();
            }

            Assert.AreEqual(0, doubleEndedQueue.Size);
        }

        [Test]
        public void DequeueSearch()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < Size; i++)
            {
                doubleEndedQueue.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var result = doubleEndedQueue.Search(i);
                Assert.AreEqual(i, result.Value);
            }

        }
    }
}
