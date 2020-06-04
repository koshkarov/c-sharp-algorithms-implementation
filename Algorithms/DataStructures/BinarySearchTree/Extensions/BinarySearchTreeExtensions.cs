using Algorithms.DataStructures.BinaryTree;
using System;

namespace Algorithms.DataStructures.BinarySearchTree.Extensions
{
    public static class BinarySearchTreeExtensions
    {
        /// <summary>
        /// Determines whether a binary tree is a binary searh tree.
        /// </summary>
        /// <param name="node">The root node of the tree.</param>
        /// <returns></returns>
        public static bool IsBinarySearchTree<TValue>(this BinaryTreeNode<int, TValue> node)
        {
            if (node == null) throw new InvalidOperationException("BinarySearchTree is empty.");
            return IsBinarySearchTree(node, int.MinValue, int.MaxValue);
        }

        private static bool IsBinarySearchTree<TValue>(BinaryTreeNode<int, TValue> node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Key > max || node.Key < min)
                return false;

            var left = IsBinarySearchTree(node.Left, min, node.Key - 1);
            var right = IsBinarySearchTree(node.Right, node.Key + 1, max);

            return left && right;
        }
    }
}
