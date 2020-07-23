using Algorithms.DataStructures.Trees.Binary;
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

        public override TValue GetValue(TKey key)
        {
            return base.GetValue(key);
        }

        public override void Add(TKey key, TValue value, Method method = Method.Recursive)
        {
            var newNode = new AVLTreeNode<TKey, TValue>(key, value);
            var node = (AVLTreeNode<TKey, TValue>)base.Add(newNode, method);
            CheckBalance(node);
        }

        public override void Delete(TKey key)
        {
            AVLTreeNode<TKey, TValue> parent = null;

            // find node
            var node = (AVLTreeNode<TKey, TValue>)GetNodeRecursively(Root, key);

            if (node != null)
            {
                // save its parent to check the balance later
                parent = node.Parent;

                // delete node
                Delete(node);
            }

            // check the balance
            if (parent != null) CheckBalance(node);
        }

        public override bool Contains(TKey key, bool isIterative = false)
        {
            return base.Contains(key, isIterative);
        }

        #region private methods

        /// <summary>
        /// Checks the balance of the node and rebalances if required.
        /// </summary>
        /// <param name="node"></param>
        private void CheckBalance(AVLTreeNode<TKey, TValue> node)
        {
            int rightNodeHeight = Height(node.Right);
            int leftNodeHeight = Height(node.Left);

            if (leftNodeHeight - rightNodeHeight > 1 || leftNodeHeight - rightNodeHeight < -1)
            {
                Rebalance(node);
            }

            if (node.Parent == null) return;

            CheckBalance(node.Parent);
        }

        /// <summary>
        /// Rebalances (rotates) tree nodes.
        /// </summary>
        /// <param name="node"></param>
        private void Rebalance(AVLTreeNode<TKey, TValue> node)
        {
            if (Height(node.Left) - Height(node.Right) > 1)
            {
                if (Height(node.Left.Left) > Height(node.Left.Right))
                {
                    RotateRight(node);
                }
                else
                {
                    RotateLeftRight(node);
                }
            }
            else
            {
                if (Height(node.Right.Right) > Height(node.Right.Left))
                {
                    RotateLeft(node);
                }
                else
                {
                    RotateRightLeft(node);
                }
            }

            if (node.Parent == null)
            {
                Root = node;
            }
        }

        /// <summary>
        /// Performs right rotation if the imbalance in the left child's left sub-tree.
        /// </summary>
        private AVLTreeNode<TKey, TValue> RotateRight(AVLTreeNode<TKey, TValue> node)
        {
            // rotate
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            UpdateParentsOnRotation(node, temp);

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

            UpdateParentsOnRotation(node, temp);

            return temp;
        }

        /// <summary>
        /// Updates parents for rotated nodes.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="temp"></param>
        private void UpdateParentsOnRotation(AVLTreeNode<TKey, TValue> node, AVLTreeNode<TKey, TValue> temp)
        {
            // update parents
            if (node.Parent == null)
            {
                Root = temp;
                temp.Parent = null;
            }
            else
            {
                temp.Parent = node.Parent;
            }

            if (node.Left != null) node.Left.Parent = node;
            if (node.Right != null) node.Right.Parent = node;
            if (temp.Left != null) temp.Left.Parent = temp;
            if (temp.Right != null) temp.Right.Parent = temp;
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
