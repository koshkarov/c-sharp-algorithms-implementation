using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new stack (resizing array implementation) of arbitrary type <typeparamref name="T"/>.
    ///  - Every operation takes constant amortized time.
    ///  - Less wasted space.
    /// </summary>
    /// <typeparam name="T">The element type of the stack.</typeparam>
    /// 
    public class StackArray<T>
    {
        private T[] _arr;
        private int _head;

        public StackArray()
        {
            _arr = new T[1];
        }

        /// <summary>
        /// Insert a new item. 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            // if array is full resize it twice the size
            if (_head == _arr.Length)
            {
                Resize(_arr.Length * 2);
            }

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

            // Free object for garbage collector (for reference types)
            _arr[_head] = default(T);

            // Halve size of the array when it is one-quarter full.
            if (_head > 0 && _head == _arr.Length / 4)
            {
                Resize(_arr.Length / 2);
            }

            return value;
        }

        public bool IsEmpty() => _head == 0;

        public int Size() => _head;

        /// <summary>
        /// Resize array.
        /// </summary>
        /// <param name="size">A new size of the array.</param>
        private void Resize(int size)
        {
            T[] resize = new T[size];

            for (int i = 0; i < _head; i++)
            {
                resize[i] = _arr[i];
            }

            _arr = resize;
        }
    }
}
