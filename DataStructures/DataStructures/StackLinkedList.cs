using System;

namespace DataStructures
{
    /// <summary>
    /// Creates a new stack (linked list implementation) of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    /// 
    public class StackLinkedList<T>
    {
        private LinkedListNode<T> _head;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T result = _head.Value;
            _head = _head.Next;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
        }
    }
}
