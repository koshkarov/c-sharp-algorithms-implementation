using System;

namespace DataStructures
{
    /// <summary>
    /// Creates a new stack (array implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class StackArray<T>
    {
        private const int _capacity = 1000;
        private T[] _arr = new T[_capacity];
        private int _top = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (_top >= _capacity)
                throw new InvalidOperationException("Stack Overflow!");

            _arr[++_top] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_top < 0)
                throw new InvalidOperationException("Stack Underflow!");
            return _arr[_top--];
        }
    }
}
