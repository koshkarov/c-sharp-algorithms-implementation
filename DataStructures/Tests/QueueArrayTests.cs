using System;
using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class QueueArrayTests
    {
        private QueueArray<int> _q;
        private static readonly int MAX_SIZE = 1000;

        [SetUp]
        protected void SetUp()
        {
            _q = new QueueArray<int>();
        }

        [Test]
        public void EnqueueElements()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                _q.Enqueue(i);
            }
        }

        [Test]
        public void EnqueueDequeueElements()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                _q.Enqueue(i);
            }

            for (int i = MAX_SIZE - 1; i < 0; i--)
            {
                Assert.AreEqual(i, _q.Dequeue());
            }
        }

        [Test]
        public void QueueOverflow()
        {
            InvalidOperationException ex = new InvalidOperationException();

            try
            {
                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    _q.Enqueue(i);
                }
            }
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("Queue Overflow!", ex.Message);
        }

        [Test]
        public void QueueuUnderflow()
        {
            try
            {
                for (int i = 0; i < MAX_SIZE; i++)
                {
                    _q.Enqueue(i);
                }

                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    _q.Dequeue();
                }
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The Queueue is empty.", ex.Message);
            }
            
        }
    }
}
