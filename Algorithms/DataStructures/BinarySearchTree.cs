﻿using System;
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
        public BinaryTreeNode<int> Root { get; private set; }

        public BinarySearchTree()
        {
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

        public void Insert(int key, bool isIterative = false)
        {
            Root = isIterative 
                ? InsertIteratively(Root, key)
                : InsertRecursively(Root, key);
        }

        private BinaryTreeNode<int> InsertIteratively(BinaryTreeNode<int> root, int v)
        {
            throw new NotImplementedException();
        }

        private BinaryTreeNode<int> InsertRecursively(BinaryTreeNode<int> node, int v)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<int>(v);
            }
            else if (v < node.Value)
            {
                node.Left = InsertRecursively(node.Left, v);
            }
            else
            {
                node.Right = InsertRecursively(node.Right, v);
            }

            return node;
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

