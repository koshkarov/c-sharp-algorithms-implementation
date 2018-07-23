using System;

namespace DataStructures
{
    public class QueueLinkedList<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                _tail.Next = newNode;
            }

            _tail = newNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The Queueue is empty.");
            }

            T result = _head.Value;
            _head = _head.Next;

            return result;
        }
    }


}
