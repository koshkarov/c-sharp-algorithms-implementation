using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Creates a new stack (linked list implementation) of arbitrary type <typeparamref name="T"/>.
    ///  - Every operation takes constant time in the worst case.
    ///  - Uses extra time and space to deal with the links.
    /// </summary>
    /// <typeparam name="T">The element type of the stack.</typeparam>
    /// 
    public class StackLinkedList<T>
    {
        private LinkedListNode<T> _head;
        private int _size;

        /// <summary>
        /// Insert a new item. 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
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

        public bool IsEmpty() => _head == null;

        public int Size() => _size;
    }
}
