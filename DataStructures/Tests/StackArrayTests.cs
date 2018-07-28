using System;
using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class StackArrayTests
    {
        private StackArray<int> _q;
        private static readonly int MAX_SIZE = 1000;

        [SetUp]
        protected void SetUp()
        {
            _q = new StackArray<int>(MAX_SIZE);
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
        public void StackOverflow()
        {
            InvalidOperationException ex = new InvalidOperationException();

            try
            {
                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    _q.Push(i);
                }
            }
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("Stack Overflow!", ex.Message);
        }

        [Test]
        public void StackUnderflow()
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
