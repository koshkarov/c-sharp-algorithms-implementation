using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Binary search trees (BST), sometimes called ordered or sorted binary trees. 
    /// 
    /// In Binary Search Tree, all the nodes to the left of a node have values less the value of the node, 
    /// and all the nodes to the right of a node have values greater than the value of the node.
    /// 
    /// TODO: provide complexity
    /// 
    /// </summary>
    public class BinarySearchTree
    {
        public BinaryTreeNode<int> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(BinaryTreeNode<int> root)
        {
            Root = root;
        }

        public void Clear()
        {
            Root = null;
        }

        public bool Contains(int key, bool isIterative = false)
        {
            var result = isIterative 
                ? SearchIteratively(Root, key) 
                : SearchRecursively(Root, key);

            return result != null;
        }

        private BinaryTreeNode<int> SearchRecursively(BinaryTreeNode<int> node, int key)
        {
            if (node == null || node.Value == key)
                return node;
            if (key > node.Value)
                return SearchRecursively(node.Right, key);
            if (key < node.Value)
                return SearchRecursively(node.Left, key);

            return node;
        }

        private BinaryTreeNode<int> SearchIteratively(BinaryTreeNode<int> node, int key)
        {
            var curNode = node;
            while(curNode != null)
            {
                if (key == curNode.Value)
                {
                    return curNode;
                }

                if (key > curNode.Value) {
                    curNode = curNode.Right;
                }
                else // key < curNode.Value
                {
                    curNode = curNode.Left;
                }
            }

            return curNode;
        }

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

        private void Insert(BinaryTreeNode<int> currentNode, BinaryTreeNode<int> insertNode)
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

