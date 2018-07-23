using NUnit.Framework;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    class StackLinkedListTests
    {
        private StackLinkedList<int> _q;
        private static readonly int MAX_SIZE = 1000;

        [SetUp]
        protected void SetUp()
        {
            _q = new StackLinkedList<int>();
        }

        [Test]
        public void PushElements()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                _q.Push(i);
            }
        }

        [Test]
        public void PushPopElements()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                _q.Push(i);
            }

            for (int i = MAX_SIZE - 1; i < 0; i--)
            {
                Assert.AreEqual(i, _q.Pop());
            }
        }

        [Test]
        public void StackIsEmpty()
        {
            InvalidOperationException ex = new InvalidOperationException();

            try
            {
                for (int i = 0; i < MAX_SIZE; i++)
                {
                    _q.Push(i);
                }

                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    _q.Pop();
                }
            }
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("The Stack is empty.", ex.Message);
        }
    }
}
