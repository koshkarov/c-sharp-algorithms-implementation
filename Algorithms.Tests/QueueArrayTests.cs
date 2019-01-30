using Algorithms.DataStructures;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    class QueueArrayTests
    {
        [Test]
        public void MultipleEnqueueDequeueReturnValues()
        {
            var queue = new QueueArray<int>();
            var size = 50;

            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < size; i++)
            {
                var dequeued = queue.Dequeue();
                Assert.AreEqual(i, dequeued);
            }
        }

        [Test]
        public void QueueUnderflow()
        {
            var queue = new QueueArray<int>();
            var size = 1000;

            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < size; i++)
            {
                queue.Dequeue();
            }

            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Queue is empty.", ex.Message);
            }
            
        }

        [Test]
        public void EmptyQueueDequeueUnderflow()
        {
            var queue = new QueueArray<int>();

            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Queue is empty.", ex.Message);
            }
        }

        [Test]
        public void EmptyQueueSizeIsZero()
        {
            var queue = new QueueArray<int>();
            Assert.AreEqual(0, queue.Size());
        }

        [Test]
        public void QueueSizeIncreases()
        {
            var queue = new QueueArray<int>();
            var size = 100;

            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(size, queue.Size());
        }

        [Test]
        public void StackSizeDecreases()
        {
            var queue = new QueueArray<int>();
            var size = 100;

            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < size; i++)
            {
                queue.Dequeue();
            }

            Assert.AreEqual(0, queue.Size());
        }
    }
}
