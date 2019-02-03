using System;

namespace Algorithms.DataStructures
{
    public class Deque<T>
    {
        private DoublyLinkedListNode<T> _sentinel;

        public int Size { get; private set; }

        public Deque()
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
                Prev = _sentinel.Prev,
                Next = _sentinel
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
