using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new stack (linked list implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class StackLinkedList<T>
    {
        private LinkedListNode<T> _head;
        private readonly int _capacity;
        private int _size;

        public StackLinkedList(int capacity)
        {
            this._capacity = capacity;
        }

        /// <summary>
        /// Insert a new item. 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (_size == _capacity)
                throw new InvalidOperationException("Stack Overflow!");

            var oldHead = _head;
            _head = new LinkedListNode<T>(value)
            {
                Next = oldHead
            };
            _size++;
        }

        /// <summary>
        /// Remove the most recently added item and return it.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The Stack is empty.");
            }

            T result = _head.Value;
            _head = _head.Next;
            _size--;
            return result;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public int Size()
        {
            return _size;
        }
    }
}
