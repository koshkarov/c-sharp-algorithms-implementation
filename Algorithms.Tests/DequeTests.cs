using Algorithms.DataStructures;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    internal class DequeTests
    {
        private const int Size = 50000;

        [Test]
        public void MultipleAddFirstRemoveLast()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequedValue = deque.RemoveLast();
                Assert.AreEqual(i, dequedValue);
            }
        }

        [Test]
        public void MultipleAddFirstRemoveFirst()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddFirst(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequedValue = deque.RemoveFirst();
                Assert.AreEqual(i, dequedValue);
            }
        }

        [Test]
        public void MultipleAddLastRemoveFirst()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddLast(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequedValue = deque.RemoveFirst();
                Assert.AreEqual(i, dequedValue);
            }
        }

        [Test]
        public void MultipleAddLastRemoveLast()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddLast(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequedValue = deque.RemoveLast();
                Assert.AreEqual(i, dequedValue);
            }
        }



        [Test]
        public void QueueUnderflow()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                deque.RemoveFirst();
            }

            try
            {
                deque.RemoveFirst();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Deque is empty.", ex.Message);
            }

        }

        [Test]
        public void EmptyQueueDequeueUnderflow()
        {
            var deque = new Deque<int>();

            try
            {
                deque.RemoveLast();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Deque is empty.", ex.Message);
            }
        }

        [Test]
        public void EmptyDequeSizeIsZero()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(0, deque.Size);
        }

        [Test]
        public void DequeSizeIncreases()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddLast(i);
            }

            Assert.AreEqual(Size, deque.Size);
        }

        [Test]
        public void DequeSizeDecreases()
        {
            var deque = new Deque<int>();

            for (int i = 0; i < Size; i++)
            {
                deque.AddLast(i);
            }

            for (int i = 0; i < Size; i++)
            {
                deque.RemoveFirst();
            }

            Assert.AreEqual(0, deque.Size);
        }
    }
}
