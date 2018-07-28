using System;
using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class QueueLinkedListTests
    {
        private QueueLinkedList<int> _q;
        private static readonly int MAX_SIZE = 1000;

        [SetUp]
        protected void SetUp()
        {
            _q = new QueueLinkedList<int>();
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
        public void QueueuUnderflow()
        {
            InvalidOperationException ex = new InvalidOperationException();

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
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("The Queueue is empty.", ex.Message);
        }
    }
}
