using System;

namespace Algorithms.DataStructures.Queue
{
    /// <summary>
    /// Creates a new queue (resizing array implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    public class QueueArray<T>
    {
        private T[] _arr;
        private int _head, _tail;
        private int _size;

        public QueueArray()
        {
            _arr = new T[1];
        }

        /// <summary>
        /// Insert a new item.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (IsFull())
            {
                Resize(_arr.Length * 2);
            }

            _arr[_tail] = value;
            _tail = ++_tail % _arr.Length;
            _size++;
        }

        /// <summary>
        /// Remove the least recently added item and return it.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The Queue is empty.");
            }

            // Halve size of the array when it is one-quarter full.
            if (Size() == _arr.Length / 4)
            {
                Resize(_arr.Length / 2);
            }

            var returnValue = _arr[_head];

            // Free object for garbage collector (for reference types)
            _arr[_head] = default(T);

            _head = ++_head % _arr.Length;
            _size--;
            return returnValue;
        }

        public bool IsEmpty() => Size() == 0;

        private bool IsFull() => Size() == _arr.Length;

        public int Size() => _size;

        /// <summary>
        /// Resizes the array. 
        /// </summary>
        /// <param name="size">A new size of the array.</param>
        private void Resize(int size)
        {
            T[] resized = new T[size];

            for (int i = 0; i < Size(); i++)
            {
                var tempHead = (_head + i) % _arr.Length;
                resized[i] = _arr[tempHead];
            }

            _arr = resized;

            _head = 0;
            _tail = Size();
        }
    }
}
