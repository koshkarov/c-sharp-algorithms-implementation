using Algorithms.DataStructures.BinaryTree;
using System;

namespace Algorithms.DataStructures.AVLTree
{
    public class AVLTreeNode<TKey, TValue> : BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public int LeftHeight { get; private set; }
        public int RightHeight { get; private set; }

        public AVLTreeNode(TKey key, TValue value) : base(key, value)
        {

        }
    }
}
