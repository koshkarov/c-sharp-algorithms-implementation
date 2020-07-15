using Algorithms.DataStructures.Trees.BinarySearch;
using System;

/// <summary>
/// In computer science, an AVL tree (named after inventors Adelson-Velsky and Landis) is a self-balancing binary search tree.
/// In an AVL tree, the heights of the two child subtrees of any node differ by at most one; 
/// if at any time they differ by more than one, rebalancing is done to restore this property. 
/// </summary>

namespace Algorithms.DataStructures.Trees.AVL
{
    public class AVLTree<TKey, TValue> : BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {

        public new AVLTreeNode<TKey, TValue> Root
        {
            get
            {
                return (AVLTreeNode<TKey, TValue>)base.Root;
            }
            set
            {
                base.Root = value;
            }
        }

        public int Height => Root == null ? 0 : Math.Max(Root.LeftHeight, Root.RightHeight) + 1;

        public override TValue Get(TKey key)
        {
            return base.Get(key);
        }


        public override void Add(TKey key, TValue value, bool isIterative = false)
        {
            // insert as usual
            var newNode = new AVLTreeNode<TKey, TValue>(key, value);
            AddRecursively(Root, newNode);

            // update the heights

        }

        public override void Delete(TKey key)
        {
            // TODO
        }

        public override bool Contains(TKey key, bool isIterative = false)
        {
            return base.Contains(key, isIterative);
        }

        #region private methods

        /// <summary>
        /// Performs right rotation if the imbalance in the left child's left sub-tree.
        /// </summary>
        private AVLTreeNode<TKey, TValue> RotateRight(AVLTreeNode<TKey, TValue> node)
        {
            // rotate
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            // update parents
            Transplant(node, temp);

            return temp;
        }

        /// <summary>
        /// Performs left rotation if the imbalance in the right child's right sub-tree.
        /// </summary>
        private AVLTreeNode<TKey, TValue> RotateLeft(AVLTreeNode<TKey, TValue> node)
        {
            // rotate
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            // update parents
            Transplant(node, temp);

            return temp;
        }

        /// <summary>
        /// Performs right-left rotation if the imbalance in the right child's left sub-tree.
        /// </summary>
        /// <param name="node"></param>
        private AVLTreeNode<TKey, TValue> RotateRightLeft(AVLTreeNode<TKey, TValue> node)
        {
            // perform a right rotate on the parent
            node.Right = RotateRight(node.Right);

            // perform a left rotate on the grand parent
            return RotateLeft(node);
        }

        /// <summary>
        /// Performs left-right rotation if the imbalance in the left child's right sub-tree.
        /// </summary>
        /// <param name="node"></param>
        private AVLTreeNode<TKey, TValue> RotateLeftRight(AVLTreeNode<TKey, TValue> node)
        {
            // perform a left rotate on the parent
            node.Left = RotateLeft(node.Left);

            // perform a right rotate on the grand parent
            return RotateRight(node);
        }

        #endregion
    }
}
