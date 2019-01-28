using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new stack (array implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class StackArray<T>
    {
        private readonly int _capacity;
        private readonly T[] _arr;
        private int _head = 0;

        public StackArray(int capacity)
        {
            _capacity = capacity;
            _arr = new T[capacity];
        }

        /// <summary>
        /// Insert a new item. 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (_head == _capacity)
                throw new InvalidOperationException("Stack Overflow!");

            _arr[_head++] = value;
        }

        /// <summary>
        /// Remove the most recently added item and return it.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The Stack is empty.");

            T value = _arr[--_head];
            return value;
        }

        public bool IsEmpty()
        {
            return _head == 0;
        }

        public int Size()
        {
            return _head;
        }
    }
}
