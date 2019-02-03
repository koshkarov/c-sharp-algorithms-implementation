using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorithms.DataStructures
{
    public class DequeDoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> _first, _last;
        private int _size;

        public DequeDoublyLinkedList()
        {
            _size = 0;
        }

        // add the item to the front
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            // check if not empty
            if (IsEmpty())
            {
                //if empty, create node and assign first and last to it
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _first.Prev = newNode;
                newNode.Next = _first;
                _first = newNode;
            }

            _size++;
        }

        // add the item to the end
        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            // check if not empty
            if (IsEmpty())
            {
                //if empty, create node and assign first and last to it
                _first = newNode;
                _last = newNode;
            }
            else
            {
                //if not, create node and add to the end
                newNode.Prev = _last;
                _last.Next = newNode;
                _last = newNode;
            }

            _size++;
        }

        // remove and return the item from the front
        public T RemoveFirst()
        {
            ValidateDeque();

            var value = _first.Value;

            if (_first.Next == null)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _first = _first.Next;
                _first.Prev = null;
            }

            _size--;
            return value;
        }

        // remove and return the item from the end
        public T RemoveLast()
        {
            ValidateDeque();

            // get the value from the last node
            var value = _last.Value;

            // if there is only one node reset pointers to null
            if (_first.Next == null)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _last = _last.Prev;
                _last.Next = null;
            }

            _size--;
            return value;
        }


        public bool IsEmpty() => _first == null && _last == null;

        public int Size() => _size;

        private void ValidateDeque()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The Deque is empty.");
            }
        }
    }
}
