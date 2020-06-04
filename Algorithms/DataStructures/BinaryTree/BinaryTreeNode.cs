using System;

namespace Algorithms.DataStructures.BinaryTree
{
    /// <summary>
    /// Creates a new tree node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// 
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public BinaryTreeNode<TKey, TValue> Left { get; set; }
        public BinaryTreeNode<TKey, TValue> Right { get; set; }
        private BinaryTreeNode<TKey, TValue> _parent { get; set; }


        public BinaryTreeNode(TKey key, TValue value) {
            Key = key;
            Value = value; 
        }

        public BinaryTreeNode(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parent) : this(key, value)
        {
            _parent = parent;
        }

    }
}
