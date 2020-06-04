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
            Root = isIterative
                ? PutIteratively(key, value)
                : PutRecursively(null, Root, key, value);
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

        public List<TKey> GetKeys()
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

        private BinaryTreeNode<TKey, TValue> PutIteratively(TKey key, TValue value)
        {
            var newNode = new BinaryTreeNode<TKey, TValue>(key, value);
            if (Root == null) return newNode;

            BinaryTreeNode<TKey, TValue> parent = null, curNode = Root;
            while (curNode != null)
            {
                if (key.CompareTo(curNode.Key) > 0)
                {
                    if (curNode.Right == null)
                    {
                        newNode.Parent = parent;
                        curNode.Right = newNode;
                        break;
                    }
                    else {
                        parent = curNode;
                        curNode = curNode.Right;
                    }
                }
                else // newNode.Key.CompareTo(curNode.Key) < 0
                {
                    if (curNode.Left == null)
                    {
                        newNode.Parent = parent;
                        curNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        parent = curNode;
                        curNode = curNode.Left;
                    }
                }
            }

            return Root;
        }

        private BinaryTreeNode<TKey, TValue> PutRecursively(BinaryTreeNode<TKey, TValue> parent, BinaryTreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null) node = new BinaryTreeNode<TKey, TValue>(key, value, parent);
            else if (key.CompareTo(node.Key) < 0) 
                node.Left = PutRecursively(node, node.Left, key, value);
            else if (key.CompareTo(node.Key) > 0) 
                node.Right = PutRecursively(node, node.Right, key, value);
            return node;
        }

        private void Delete(BinaryTreeNode<TKey, TValue> parentNode, BinaryTreeNode<TKey, TValue> currentNode, TKey key)
        {
            if (currentNode == null)
            {
                // couldn't find the node
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
                PutRecursively(currentNode, currentNode.Right, currentNode.Left.Key, currentNode.Left.Value);

                // replace current node with in-order successor (right node)
                Transplant(currentNode, currentNode.Right);
                
            }
            // Deleting a node with one child: remove the node and replace it with its child.
            else if (currentNode.Left != null)
            {
                Transplant(currentNode, currentNode.Left);
            }
            // Deleting a node with one child: remove the node and replace it with its child.
            else if (currentNode.Right != null)
            {
                Transplant(currentNode, currentNode.Right);
            }
            // Deleting a node with no children: simply remove the node from the tree.
            else
            {
                Transplant(currentNode, null);
            }
        }

        private BinaryTreeNode<TKey, TValue> GetSuccessor(BinaryTreeNode<TKey, TValue> node)
        {
            // Case 1: if the right subtree of node is nonempty.
            if (node.Right != null)
            {
                return GetMin(node.Right);
            }

            // Case 2: if the right subtree of node is nonempty.
            var curNode = node;
            var parent = node.Parent;
            while (parent != null && curNode.Equals(parent.Right))
            {
                curNode = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private BinaryTreeNode<TKey, TValue> GetPredecessor(BinaryTreeNode<TKey, TValue> node)
        {
            // Case 1: if the left subtree of node is nonempty.
            if (node.Left != null)
            {
                return GetMax(node.Left);
            }

            // Case 2: if the left subtree of node is nonempty.
            var curNode = node;
            var parent = node.Parent;
            while (parent != null && curNode.Equals(parent.Left))
            {
                curNode = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private BinaryTreeNode<TKey, TValue> GetMin(BinaryTreeNode<TKey, TValue> node)
        {
            var curNode = node;
            while(node.Left != null)
            {
                curNode = curNode.Left;
            }
            return curNode;
        }

        private BinaryTreeNode<TKey, TValue> GetMax(BinaryTreeNode<TKey, TValue> node)
        {
            var curNode = node;
            while (node.Right != null)
            {
                curNode = curNode.Right;
            }
            return curNode;
        }

        private void Transplant(BinaryTreeNode<TKey, TValue> currentNode, BinaryTreeNode<TKey, TValue> newNode)
        {
            // case when currentNode is root node
            if (currentNode.Parent == null) Root = newNode;
            else if (currentNode.Equals(currentNode.Parent.Left)) currentNode.Parent.Left = newNode;
            else currentNode.Parent.Right = newNode;

            // we allow newNode to be null
            if (newNode != null) newNode.Parent = currentNode.Parent;
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