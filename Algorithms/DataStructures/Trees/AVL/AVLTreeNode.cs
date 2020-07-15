using Algorithms.DataStructures.Trees.Binary;
using System;

namespace Algorithms.DataStructures.Trees.AVL
{
    public class AVLTreeNode<TKey, TValue> : BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public int LeftHeight { get; private set; } = -1;
        public int RightHeight { get; private set; } = -1;

        public AVLTreeNode(TKey key, TValue value) : base(key, value)
        {
        }

        public new AVLTreeNode<TKey, TValue> Left
        {
            get
            {
                return (AVLTreeNode<TKey, TValue>)base.Left;
            }
            set
            {
                base.Left = value;
            }
        }

        public new AVLTreeNode<TKey, TValue> Right
        {
            get
            {
                return (AVLTreeNode<TKey, TValue>)base.Right;
            }
            set
            {
                base.Right = value;
            }
        }

        public new AVLTreeNode<TKey, TValue> Parent
        {
            get
            {
                return (AVLTreeNode<TKey, TValue>)base.Parent;
            }
            set
            {
                base.Parent = value;
            }
        }
    }

}
