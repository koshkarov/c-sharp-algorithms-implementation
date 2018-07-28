using System;

namespace Algorithms.Algorithms
{
    /// <summary>
    /// Creates a new stack (array implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class StackArray<T>
    {
        private readonly int _size;
        private readonly T[] _arr;
        private int _top = -1;

        public StackArray(int size)
        {
            _size = size;
            _arr = new T[size];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            _top = _top + 1;
            if (_top >= _size)
                throw new InvalidOperationException("Stack Overflow!");
            _arr[_top] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_top < 0)
                throw new InvalidOperationException("The Stack is empty.");
            return _arr[_top--];
        }
    }
}
