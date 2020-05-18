using System;

namespace Algorithms.DataStructures.Queue
{
    /// <summary>
    /// Dequeue is an abstract data type that generalizes a queue,
    /// for which elements can be added to or removed from either the front (head) or back (tail).
    /// It is implemented with a circular, doubly-linked list which has a single sentinel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleEndedQueue<T> where T : IComparable<T>
    {
        private DoublyLinkedListNode<T> _sentinel;

        public int Size { get; private set; }

        public DoubleEndedQueue()
        {
            _sentinel = new DoublyLinkedListNode<T>(default(T));
            _sentinel.Prev = _sentinel.Next = _sentinel;
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value)
            {
                Next = _sentinel.Next,
                Prev = _sentinel
            };

            _sentinel.Next.Prev = newNode;
            _sentinel.Next = newNode;
            
            Size++;
        }

        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value)
            {
                Next = _sentinel,
                Prev = _sentinel.Prev
            };

            _sentinel.Prev.Next = newNode;
            _sentinel.Prev = newNode;

            Size++;
        }

        public T RemoveFirst()
        {
            ValidateDeque();

            var value = _sentinel.Next.Value;
            _sentinel.Next = _sentinel.Next.Next;
            _sentinel.Next.Prev = _sentinel;

            Size--;
            return value;
        }

        public T RemoveLast()
        {
            ValidateDeque();

            var value = _sentinel.Prev.Value;

            _sentinel.Prev = _sentinel.Prev.Prev;
            _sentinel.Prev.Next = _sentinel;

            Size--;
            return value;
        }

        public DoublyLinkedListNode<T> Search(T value)
        {
            var node = _sentinel.Next;
            _sentinel.Value = value;

            while (node.Value.CompareTo(value) != 0)
            {
                node = node.Next;
            }

            return node == _sentinel ? null : node;
        }


        public bool IsEmpty() => Size == 0;

        private void ValidateDeque()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The Deque is empty.");
            }
        }
    }
}
