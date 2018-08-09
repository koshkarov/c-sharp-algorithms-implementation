﻿namespace Algorithms.DataStructures
{
    class LinkedList<T>
    {
        private LinkedListNode<T> _head;

        /// <summary>
        /// Determines whether a value is in the LinkedList of arbitrary type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Find(value) == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The first LinkedListNode<T> that contains the specified value, if found; otherwise, null.</T></returns>
        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> node = _head;

            if (node != null)
            {
                do
                {
                    if (node.Value.Equals(value))
                    {
                        return node;
                    }
                    node = node.Next;
                } while (node != null);
            }

            return null;
        }

    }

    /// <summary>
    /// Creates a new linked list node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the linked list</typeparam>
    public class LinkedListNode<T>
    {
        public T Value;
        public LinkedListNode<T> Next;

        public LinkedListNode(T value) { Value = value; }

    }
}
