using System;
using System.Drawing;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new queue (linked list implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    public class QueueLinkedList<T>
    {
        private LinkedListNode<T> _first, _last;
        private int _size;

        /// <summary>
        /// Insert a new item at the end of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            var oldLast = _last;
            _last = new LinkedListNode<T>(value);

            if (IsEmpty())
            {
                _first = _last;
            }
            else
            {
                oldLast.Next = _last;
            }

            _size++;
        }

        /// <summary>
        /// Remove the least recently added item from the linked list and and return its value.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The Queue is empty.");
            }

            T value = _first.Value;
            _first = _first.Next;

            if (IsEmpty())
            {
                _last = null;
            }

            _size--;

            return value;
        }

        public bool IsEmpty() => _first == null;

        public int Size() => _size;
    }


}
