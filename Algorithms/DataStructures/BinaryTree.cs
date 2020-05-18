using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class BinaryTree
    {
        public BinaryTreeNode<int> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(BinaryTreeNode<int> root)
        {
            Root = root;
        }

        public void Clear()
        {
            Root = null;
        }

        public bool Contains(int key)
        {
            return Search(Root, key) != null;
        }

        public BinaryTreeNode<int> Search(BinaryTreeNode<int> node, int key)
        {
            if (node == null || node.Value == key)
                return node;
            if (key > node.Value)
                return Search(node.Right, key);
            if (key < node.Value)
                return Search(node.Left, key);

            return node;
        }

        /// <summary>
        /// Insert the key into the binary tree at first position available in level order.
        /// The idea is to do iterative level order traversal of the given tree using queue. If we find a node whose left child is empty, we make new key as left child of the node. 
        /// Else if we find a node whose right child is empty, we make new key as right child. We keep traversing the tree until we find a node whose either left or right is empty.
        /// </summary>
        /// <param name="key">A value to insert.s</param>
        public void Insert(int key)
        {
            var insertNode = new BinaryTreeNode<int>(key);

            // case if binary tree is empty
            if (Root == null)
            {
                Root = insertNode;
                return;
            } 
            else
            {
                Insert(Root, insertNode);
            }
        }

        public void Insert(BinaryTreeNode<int> currentNode, BinaryTreeNode<int> insertNode)
        {
            var queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(currentNode);

            while(queue.Count != 0)
            {
                var tempNode = queue.Dequeue();

                if (tempNode.Left == null)
                {
                    tempNode.Left = insertNode;
                    break;
                }
                else
                {
                    queue.Enqueue(tempNode.Left);
                }

                if (tempNode.Right == null)
                {
                    tempNode.Right = insertNode;
                    break;
                }
                else
                {
                    queue.Enqueue(tempNode.Right);
                }
            }
        }

        public void Delete()
        {
            
        }

        public List<int> TraverseInOrder()
        {
            List<int> list = new List<int>();
            InOrderTraversal(Root, list);
            return list;
        }

        private static void InOrderTraversal(BinaryTreeNode<int> node, List<int> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Value);
            InOrderTraversal(node.Right, list);
        }

        private static void PreOrderTraversal(BinaryTreeNode<int> node, List<int> list)
        {
            if (node == null) return;
            list.Add(node.Value);
            PreOrderTraversal(node.Left, list);
            PreOrderTraversal(node.Right, list);
        }

        private static void PostOrderTraversal(BinaryTreeNode<int> node, List<int> list)
        {
            if (node == null) return;
            PostOrderTraversal(node.Left, list);
            PostOrderTraversal(node.Right, list);
            list.Add(node.Value);
        }

        public bool IsBinarySearchTreeTraversal()
        {
            return IsBstTraversal(Root);
        }

        public bool IsBinarySearchTree()
        {
            return IsBst(Root, int.MinValue, int.MaxValue);
        }

        private static bool IsBst(BinaryTreeNode<int> node, int min, int max)
        {
            if (node == null)
                return true;
            if (node.Value < min || node.Value > max)
                return false;

            // node.Value+1 and node.Value-1 are done to allow only distinct elements in BST.
            return IsBst(node.Left, min, node.Value - 1) &&
                   IsBst(node.Right, node.Value + 1, max);
        }

        private static bool IsBstTraversal(BinaryTreeNode<int> node)
        {
            var list = new List<int>();
            InOrderTraversal(node, list);
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] > list[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

