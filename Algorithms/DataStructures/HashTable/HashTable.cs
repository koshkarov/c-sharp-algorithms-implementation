using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// HashTable implementation. If collision happents the LinkedList data structures is used to store the elements. 
    /// </summary>
    /// <typeparam name="TK">Key</typeparam>
    /// <typeparam name="TV">Value</typeparam>
    public class HashTable<TK, TV>
    {
        private readonly int _size;
        private readonly DoublyLinkedListNode<KeyValuePair<TK, TV>>[] _items;

        public HashTable(int size)
        { 
            _size = size;
            _items = new DoublyLinkedListNode<KeyValuePair<TK, TV>>[size];
        }

        /// <summary>
        /// Gets and sets elements to the HashMap.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TV this[TK key]
        {
            get
            {
                var currentNode = _items[GetHashValue(key)];

                // iterate through linked list to find the key
                while (currentNode != null)
                {
                    var keyValuePair = currentNode.Value;

                    // for the sake of simplicity we compare using Equal(). 
                    // TODO: do some research how to properly compare
                    if (keyValuePair.Key.Equals(key))
                    {
                        return keyValuePair.Value;
                    }
                    currentNode = currentNode.Next;
                }

                // there was no ll nodes at all or we couldn't fine the key
                return default;
            }
            set
            {
                var position = GetHashValue(key);
                var node = _items[position];

                var newNode = new DoublyLinkedListNode<KeyValuePair<TK, TV>>(
                    new KeyValuePair<TK, TV>(key, value));

                if (node == null)
                {
                    _items[position] = newNode;
                }
                else
                {
                    while (node.Next != null)
                    {
                        node = node.Next;
                    }
                    node.Next = newNode;
                    newNode.Prev = node;
                }
            }
        }

        /// <summary>
        /// Removes the first occurrence of the specified value 
        /// from the LinkedList of arbitrary type <typeparamref name="TK"/>.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TK key)
        {
            var linkedList = _items[GetHashValue(key)];
            if (linkedList != null)
            {
                var node = Find(key);
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;
            }
        }

        /// <summary>
        /// Determines whether a value is in the LinkedList 
        /// of arbitrary type <typeparamref name="TK"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(TK key)
        {
            return Find(key) != null;
        }

        /// <summary>
        /// Finds the first node that contains the specified value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private DoublyLinkedListNode<KeyValuePair<TK, TV>> Find(TK key)
        {
            var position = GetHashValue(key);
            var node = _items[position];

            while (node != null)
            {
                var keyValuePair = node.Value;
                if (keyValuePair.Key.Equals(key))
                {
                    return node;
                }
                node = node.Next;
            }

            return default(DoublyLinkedListNode<KeyValuePair<TK, TV>>);
        }

        /// <summary>
        /// Finds the position of the element in the hash table. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetHashValue(TK key)
        {
            int value = key.GetHashCode() % _size;
            return Math.Abs(value);
        }
    }
}
