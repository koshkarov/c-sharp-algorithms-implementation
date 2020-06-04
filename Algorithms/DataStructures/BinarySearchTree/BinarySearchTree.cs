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
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BinaryTreeNode<TKey, TValue> Root { get; private set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(BinaryTreeNode<TKey, TValue> root)
        {
            Root = root;
        }

        #region public methods
        public TValue Get(TKey key)
        {
            var node = GetNodeRecursively(Root, key);
            return node == null ? default : node.Value;
        }

        public void Put(TKey key, TValue value, bool isIterative = false)
        {
            var newNode = new BinaryTreeNode<TKey, TValue>(key, value);
            Root = isIterative
                ? PutIteratively(Root, newNode)
                : PutRecursively(Root, newNode);
        }

        public void Delete(TKey key)
        {
            Delete(null, Root, key);
        }

        public bool Contains(TKey key, bool isIterative = false)
        {
            var node = isIterative
                ? GetNodeIteratively(key)
                : GetNodeRecursively(Root, key);

            return node != null;
        }

        public List<TKey> TraverseInOrder()
        {
            List<TKey> list = new List<TKey>();
            InOrderTraversal(Root, list);
            return list;
        }

        public void Clear()
        {
            Root = null;
        }

        #endregion

        #region private methods
        private BinaryTreeNode<TKey, TValue> GetNodeRecursively(BinaryTreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null) return default;
            else if (key.CompareTo(node.Key) > 0) return GetNodeRecursively(node.Right, key);
            else if (key.CompareTo(node.Key) < 0) return GetNodeRecursively(node.Left, key);
            else return node;
        }

        private BinaryTreeNode<TKey, TValue> GetNodeIteratively(TKey key)
        {
            var curNode = Root;

            while(curNode != null)
            {
                if (key.CompareTo(curNode.Key) == 0) return curNode;
                else if (key.CompareTo(curNode.Key) > 0) curNode = curNode.Right;
                else curNode = curNode.Left;
            }

            return curNode;
        }

        private BinaryTreeNode<TKey, TValue> PutIteratively(BinaryTreeNode<TKey, TValue> node, BinaryTreeNode<TKey, TValue> newNode)
        {
            if (node == null) return newNode;

            var curNode = node;
            while (curNode != null)
            {
                if (newNode.Key.CompareTo(curNode.Key) > 0)
                {
                    if (curNode.Right == null)
                    {
                        curNode.Right = newNode;
                        break;
                    } 
                    else curNode = curNode.Right;
                }
                else // newNode.Key.CompareTo(curNode.Key) < 0
                {
                    if (curNode.Left == null)
                    {
                        curNode.Left = newNode;
                        break;
                    }
                    else curNode = curNode.Left;
                }
            }

            return Root;
        }

        private BinaryTreeNode<TKey, TValue> PutRecursively(BinaryTreeNode<TKey, TValue> node, BinaryTreeNode<TKey, TValue> newNode)
        {
            if (node == null) node = newNode;
            else if (newNode.Key.CompareTo(node.Key) < 0) 
                node.Left = PutRecursively(node.Left, newNode);
            else if (newNode.Key.CompareTo(node.Key) > 0) 
                node.Right = PutRecursively(node.Right, newNode);
            return node;
        }

        private void Delete(BinaryTreeNode<TKey, TValue> parentNode, BinaryTreeNode<TKey, TValue> currentNode, TKey key)
        {
            // find the node and store information about a parent
            if (currentNode == null)
            {
                // nothing to delete
                return;
            }
            else if (key.CompareTo(currentNode.Key) > 0)
            {
                Delete(currentNode, currentNode.Right, key);
                return;
            }
            else if (key.CompareTo(currentNode.Key) < 0)
            {
                Delete(currentNode, currentNode.Left, key);
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
                PutRecursively(currentNode.Right, currentNode.Left);

                // replace current node with in-order successor (right node)
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Right);
                
            }
            // Deleting a node with one child: remove the node and replace it with its child.
            else if (currentNode.Left != null)
            {
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Left);
            }
            // Deleting a node with one child: remove the node and replace it with its child.
            else if (currentNode.Right != null)
            {
                ReplaceNodeInParent(parentNode, currentNode, currentNode.Right);
            }
            // Deleting a node with no children: simply remove the node from the tree.
            else
            {
                ReplaceNodeInParent(parentNode, currentNode, null);
            }
        }

        private void ReplaceNodeInParent(BinaryTreeNode<TKey, TValue> parentNode, BinaryTreeNode<TKey, TValue> currentNode, BinaryTreeNode<TKey, TValue> newNode)
        {
            if (parentNode.Left.Equals(currentNode))
                parentNode.Left = newNode;
            else
                parentNode.Right = newNode;
        }

        private static void InOrderTraversal(BinaryTreeNode<TKey, TValue> node, List<TKey> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Key);
            InOrderTraversal(node.Right, list);
        }

        #endregion
    }
}