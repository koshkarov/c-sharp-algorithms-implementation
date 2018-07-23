using System;

namespace DataStructures
{
    /// <summary>
    /// Creates a new queue (array implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class QueueArray<T>
    {
        private const int CAPACITY = 1000;
        private T[] _arr = new T[CAPACITY];
        private int _head;
        private int _size;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (_size > CAPACITY)
                throw new InvalidOperationException("Queue Overflow!");
            _arr[(_head + ++_size) % CAPACITY] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (_size <= 0)
                throw new InvalidOperationException("The Queueue is empty.");
            _size--;
            return _arr[_head++];
        }
    }
}
