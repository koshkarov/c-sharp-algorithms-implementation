using Algorithms.DataStructures;
using System;

namespace Algorithms.Extensions
{
    public static class BinarySearchTreeExtensions
    {
        public static bool IsBinarySerchTree(this BinaryTreeNode<int> node)
        {
            if (node == null) throw new NullReferenceException("BinarySearchTree is empty.");

            return IsBinarySearchTree(node, int.MinValue, int.MaxValue);
        }

        private static bool IsBinarySearchTree(BinaryTreeNode<int> node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Value > max || node.Value < min)
                return false;

            var left = IsBinarySearchTree(node.Left, min, node.Value - 1);
            var right = IsBinarySearchTree(node.Right, node.Value + 1, max);

            return left && right;
        }
    }
}
