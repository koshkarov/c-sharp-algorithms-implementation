using System;

namespace Algorithms.DataStructures.Trees.Binary
{
    /// <summary>
    /// Creates a new binary tree node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// 
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public BinaryTreeNode<TKey, TValue> Left { get; set; }
        public BinaryTreeNode<TKey, TValue> Right { get; set; }
        public BinaryTreeNode<TKey, TValue> Parent { get; set; }


        public BinaryTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public BinaryTreeNode(TKey key, TValue value, BinaryTreeNode<TKey, TValue> parent) : this(key, value)
        {
            Parent = parent;
        }

        /// <summary>
        /// Returns whether the node is leaf (has no children nodes)
        /// </summary>
        /// <returns></returns>
        public virtual bool IsLeafNode => Right == null && Left == null;

        /// <summary>
        /// Returns whether the node is internal (has children nodes)
        /// </summary>
        /// <returns></returns>
        public virtual bool IsInternalNode => Right != null || Left != null;

        /// <summary>
        /// Returns whether the node is the left child of its parent
        /// </summary>
        public virtual bool IsLeftChild => Parent != null && Parent.Left == this;

        /// <summary>
        /// Returns whether the node is the right child of its parent
        /// </summary>
        public virtual bool IsRightChild => Parent != null && Parent.Right == this;

        /// <summary>
        /// Returns whether the node has a left child node
        /// </summary>
        public virtual bool HasLeftChild => Left != null;

        /// <summary>
        /// Returns whether the node has a right child node
        /// </summary>
        public virtual bool HasRightChild => Right != null;

    }
}
