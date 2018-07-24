using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Creates a new tree node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the linked list</typeparam>
    /// 
    public class BinaryTreeNode<T>
    {
        public T Value;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;

        public BinaryTreeNode(T value) { Value = value; }

    }

    public class BinaryTreeSolution
    {
        public static bool FindTarget(BinaryTreeNode<int> root, int k)
        {
            return Find(root, k, new HashSet<int>());
        }

        private static bool Find(BinaryTreeNode<int> binaryTreeNode, int k, HashSet<int> set)
        {
            if (binaryTreeNode == null)
                return false; 

            if (set.Contains(k - binaryTreeNode.Value))
                return true;

            set.Add(binaryTreeNode.Value);

            return Find(binaryTreeNode.Left, k, set) || Find(binaryTreeNode.Right, k, set);
        }
    }

}
