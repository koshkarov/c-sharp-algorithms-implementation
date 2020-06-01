using Algorithms.DataStructures.BinaryTree;
using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.BinarySearchTree
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
        private const string NOT_FOUND_DELETE_VALUE_MESSAGE = "Couldn't find the value to delete";

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
            var newNode = new BinaryTreeNode<int>(key);
            Root = isIterative 
                ? InsertIteratively(Root, newNode)
                : InsertRecursively(Root, newNode);
        }

        private BinaryTreeNode<int> InsertIteratively(BinaryTreeNode<int> node, BinaryTreeNode<int> newNode)
        {
            if (node == null) return newNode;

            var curNode = node;
            while (curNode != null)
            {
                if (newNode.Value > curNode.Value)
                {
                    if (curNode.Right == null)
                    {
                        curNode.Right = newNode;
                        break;
                    } 
                    else
                    {
                        curNode = curNode.Right;
                    }
                }
                else // key < curNode.Value
                {
                    if (curNode.Left == null)
                    {
                        curNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        curNode = curNode.Left;
                    }
                }
            }

            return Root;
        }

        private BinaryTreeNode<int> InsertRecursively(BinaryTreeNode<int> node, BinaryTreeNode<int> newNode)
        {
            if (node == null)
                node = newNode;
            else if (newNode.Value < node.Value)
                node.Left = InsertRecursively(node.Left, newNode);
            else // newNode.Value > currentNode.Value
                node.Right = InsertRecursively(node.Right, newNode);

            return node;
        }

        public void Delete(int deleteValue)
        {
            Delete(null, Root, deleteValue);
        }

        private void Delete(BinaryTreeNode<int> parentNode, BinaryTreeNode<int> currentNode, int value)
        {
            // find the node and store information about a parent
            if (currentNode == null) 
                throw new InvalidOperationException(NOT_FOUND_DELETE_VALUE_MESSAGE);
            else if (value > currentNode.Value)
            {
                Delete(currentNode, currentNode.Right, value);
                return;
            }
                
            else if (value < currentNode.Value)
            {
                Delete(currentNode, currentNode.Left, value);
                return;
            }
                

            // Check a special case when deleting a root node
            // TODO


            // There are three possible cases to consider:
            // - Deleting a node with no children: simply remove the node from the tree.
            // - Deleting a node with one child: remove the node and replace it with its child.
            // - Deleting a node with two children: 

            if (currentNode.Left != null && currentNode.Right != null)
            {
                // insert left node to the in-order successor
                InsertRecursively(currentNode.Right, currentNode.Left);

                // replace current node with in-order successor (right node)
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Right);
                
            }
            // node with only left child
            else if (currentNode.Left != null)
            {
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Left);
            }
            // node with only right child
            else if (currentNode.Right != null)
            {
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Right);
            }
            else // leafless node
            {
                ReplaceNodeInParent(parentNode, currentNode, null);
            }
        }

        private void ReplaceNodeInParent(BinaryTreeNode<int> parentNode, BinaryTreeNode<int> currentNode, BinaryTreeNode<int> newNode)
        {
            if (parentNode.Left.Equals(currentNode))
            {
                parentNode.Left = newNode;
            }
            else
            {
                parentNode.Right = newNode;
            }
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
    }
}

