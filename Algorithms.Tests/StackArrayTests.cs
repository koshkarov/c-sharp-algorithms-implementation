using Algorithms.DataStructures;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    class StackArrayTests
    {
        private static readonly int MAX_SIZE = 1000;

        [Test]
        public void PushElements()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            for (int i = 0; i < MAX_SIZE; i++)
            {
                stack.Push(i);
            }
        }

        [Test]
        public void PopReturnsValue()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            for (int i = 0; i < MAX_SIZE; i++)
            {
                stack.Push(i);
            }

            for (int i = MAX_SIZE - 1; i > 0; i--)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }

        [Test]
        public void PushPop()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            try
            {
                for (int i = 0; i < MAX_SIZE; i++)
                {
                    stack.Push(i);
                }

                for (int i = MAX_SIZE; i > 0; i--)
                {
                    stack.Pop();
                }
            }
            catch (InvalidOperationException e)
            {
                Assert.Fail("Failed to pop all elements.");
            }

        }

        [Test]
        public void StackOverflow()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            InvalidOperationException ex = new InvalidOperationException();

            try
            {
                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    stack.Push(i);
                }
            }
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("Stack Overflow!", ex.Message);
        }

        [Test]
        public void StackIsEmpty()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            InvalidOperationException ex = new InvalidOperationException();

            try
            {
                for (int i = 0; i < MAX_SIZE; i++)
                {
                    stack.Push(i);
                }

                for (int i = 0; i < MAX_SIZE + 1; i++)
                {
                    stack.Pop();
                }
            }
            catch (InvalidOperationException e)
            {
                ex = e;
            }

            Assert.AreEqual("The Stack is empty.", ex.Message);
        }

        [Test]
        public void EmptyStackSizeIsZero()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            Assert.AreEqual(0, stack.Size());
        }

        [Test]
        public void StackSizeIncreases()
        {
            var stack = new StackArray<int>(MAX_SIZE);
            for (int i = 0; i < MAX_SIZE; i++)
            {
                stack.Push(i);
            }
            Assert.AreEqual(MAX_SIZE, stack.Size());
        }

        [Test]
        public void StackSizeDecreases()
        {
            var stack = new StackArray<int>(MAX_SIZE);

            for (int i = 0; i < MAX_SIZE; i++)
            {
                stack.Push(i);
            }

            for (int i = MAX_SIZE; i > 0; i--)
            {
                stack.Pop();
            }
            Assert.AreEqual(0, stack.Size());
        }
    }
}
