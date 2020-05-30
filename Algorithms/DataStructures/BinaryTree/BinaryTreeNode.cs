using System.Collections.Generic;

namespace Algorithms.DataStructures.BinaryTree
{
    /// <summary>
    /// Creates a new tree node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the linked list</typeparam>
    /// 
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value) { Value = value; }

    }
}
