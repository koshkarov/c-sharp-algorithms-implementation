using Algorithms.DataStructures;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    internal class DequeLinkedListTests
    {
        private const int Size = 50000;

        [Test]
        public void MultipleAddFirstRemoveLast()
        {
            var queue = new DequeDoublyLinkedList<int>();

            for (int i = 0; i < Size; i++)
            {
                queue.AddFirst(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequeued = queue.RemoveLast();
                Console.WriteLine(dequeued);
                Assert.AreEqual(i, dequeued);
            }
        }

        [Test]
        public void MultipleAddFirstRemoveFirst()
        {
            var queue = new DequeDoublyLinkedList<int>();

            for (int i = 0; i < Size; i++)
            {
                queue.AddFirst(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequeued = queue.RemoveFirst();
                Console.WriteLine(dequeued);
                Assert.AreEqual(i, dequeued);
            }
        }

        [Test]
        public void MultipleAddLastRemoveFirst()
        {
            var queue = new DequeDoublyLinkedList<int>();

            for (int i = 0; i < Size; i++)
            {
                queue.AddLast(i);
            }

            for (int i = 0; i < Size; i++)
            {
                var dequeued = queue.RemoveFirst();
                Assert.AreEqual(i, dequeued);
            }
        }

        [Test]
        public void MultipleAddLastRemoveLast()
        {
            var queue = new DequeDoublyLinkedList<int>();
            const int size = 50;

            for (int i = 0; i < Size; i++)
            {
                queue.AddLast(i);
            }

            for (int i = Size - 1; i >= 0; i--)
            {
                var dequeued = queue.RemoveLast();
                Assert.AreEqual(i, dequeued);
            }
        }



        //[Test]
        //public void QueueUnderflow()
        //{
        //    var queue = new DequeLinkedList<int>();
        //    var size = 1000;

        //    for (int i = 0; i < size; i++)
        //    {
        //        queue.Enqueue(i);
        //    }

        //    for (int i = 0; i < size; i++)
        //    {
        //        queue.Dequeue();
        //    }

        //    try
        //    {
        //        queue.Dequeue();
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        Assert.AreEqual("The Queue is empty.", ex.Message);
        //    }

        //}

        //[Test]
        //public void EmptyQueueDequeueUnderflow()
        //{
        //    var queue = new DequeLinkedList<int>();

        //    try
        //    {
        //        queue.Dequeue();
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        Assert.AreEqual("The Queue is empty.", ex.Message);
        //    }
        //}

        //[Test]
        //public void EmptyQueueSizeIsZero()
        //{
        //    var queue = new DequeLinkedList<int>();
        //    Assert.AreEqual(0, queue.Size());
        //}

        //[Test]
        //public void QueueSizeIncreases()
        //{
        //    var queue = new DequeLinkedList<int>();
        //    var size = 100;

        //    for (int i = 0; i < size; i++)
        //    {
        //        queue.Enqueue(i);
        //    }

        //    Assert.AreEqual(size, queue.Size());
        //}

        //[Test]
        //public void StackSizeDecreases()
        //{
        //    var queue = new DequeLinkedList<int>();
        //    var size = 100;

        //    for (int i = 0; i < size; i++)
        //    {
        //        queue.Enqueue(i);
        //    }

        //    for (int i = 0; i < size; i++)
        //    {
        //        queue.Dequeue();
        //    }

        //    Assert.AreEqual(0, queue.Size());
        //}
    }
}
