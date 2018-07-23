using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Creates a new tree node of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the linked list</typeparam>
    /// 
    public class BinaryTree<T>
    {
        public T Value;
        public BinaryTree<T> Left;
        public BinaryTree<T> Right;

        public BinaryTree(T value) { Value = value; }

    }

    public class BinaryTreeSolution
    {
        public static bool FindTarget(BinaryTree<int> root, int k)
        {
            return Find(root, k, new HashSet<int>());
        }

        private static bool Find(BinaryTree<int> binaryTree, int k, HashSet<int> set)
        {
            if (binaryTree == null)
                return false; 

            if (set.Contains(k - binaryTree.Value))
                return true;

            set.Add(binaryTree.Value);

            return Find(binaryTree.Left, k, set) || Find(binaryTree.Right, k, set);
        }
    }

}
