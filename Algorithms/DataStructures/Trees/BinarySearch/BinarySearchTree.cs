using Algorithms.DataStructures.Trees.Binary;
using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Trees.BinarySearch
{
    /// <summary>
    /// Definition. A binary search tree (BST) is a binary tree where each node has a Comparable key (and an associated value) 
    /// and satisfies the restriction:
    ///  - that the key in any node is larger than the keys in all nodes in that node's left subtree 
    ///  - and smaller than the keys in all nodes in that node's right subtree.
    /// 
    /// In Binary Search Tree, all the nodes to the left of a node have values less the value of the node, 
    /// and all the nodes to the right of a node have values greater than the value of the node.
    /// 
    /// Algorithm:      Average     Worst case
    /// Space           O(n)        O(n)
    /// Search          O(log n)    O(n)
    /// Insert          O(log n)    O(n)
    /// Delete          O(log n)    O(n)
    /// 
    /// </summary>
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BinaryTreeNode<TKey, TValue> Root { get; protected set; }
        public int Size { get; protected set; } = 0;

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(BinaryTreeNode<TKey, TValue> root)
        {
            Root = root;
        }

        #region public methods

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual TValue GetValue(TKey key)
        {
            var node = GetNodeRecursively(Root, key);
            return node == null ? default : node.Value;
        }

        /// <summary>
        /// Inserts the specified key-value pair into the symbol table, 
        /// overwriting the old value with the new value if the symbol table already contains the specified key.s
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="isIterative"></param>
        public virtual void Add(TKey key, TValue value, Method method = Method.Recursive)
        {
            var newNode = new BinaryTreeNode<TKey, TValue>(key, value);
            Add(newNode, method);
        }

        /// <summary>
        /// Removes the specified key and its associated value from this symbol table
        /// (if the key is in this symbol table).
        /// </summary>
        /// <param name="key"></param>
        public virtual void Delete(TKey key)
        {
            var node = GetNodeRecursively(Root, key);
            if (node != null) Delete(node);
        }

        /// <summary>
        /// Does this symbol table contain the given key?
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isIterative"></param>
        /// <returns></returns>
        public virtual bool Contains(TKey key, bool isIterative = false)
        {
            var node = isIterative
                ? GetNodeIteratively(key)
                : GetNodeRecursively(Root, key);

            return node != null;
        }

        /// <summary>
        /// Returns the list of keys traversed in order.
        /// </summary>
        /// <returns></returns>
        public virtual IList<TKey> GetKeys()
        {
            var list = new List<TKey>();
            InOrderTraversal(Root, list);
            return list;
        }

        /// <summary>
        /// Clears the tree.
        /// </summary>
        public virtual void Clear()
        {
            Root = null;
        }

        #endregion

        #region protected methods

        protected BinaryTreeNode<TKey, TValue> GetSuccessor(BinaryTreeNode<TKey, TValue> node)
        {
            // Case 1: if the right subtree of node is nonempty.
            if (node.HasRightChild)
            {
                return GetMin(node.Right);
            }

            // Case 2: if the right subtree of node is nonempty.
            var curNode = node;
            var parent = node.Parent;
            while (parent != null && curNode.IsRightChild)
            {
                curNode = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        protected BinaryTreeNode<TKey, TValue> GetPredecessor(BinaryTreeNode<TKey, TValue> node)
        {
            // Case 1: if the left subtree of node is nonempty.
            if (node.HasLeftChild)
            {
                return GetMax(node.Left);
            }

            // Case 2: if the left subtree of node is nonempty.
            var curNode = node;
            var parent = node.Parent;
            while (parent != null && curNode.IsLeftChild)
            {
                curNode = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        protected BinaryTreeNode<TKey, TValue> GetMin(BinaryTreeNode<TKey, TValue> node)
        {
            var curNode = node;
            while (curNode.Left != null)
            {
                curNode = curNode.Left;
            }
            return curNode;
        }

        protected BinaryTreeNode<TKey, TValue> GetMax(BinaryTreeNode<TKey, TValue> node)
        {
            var curNode = node;

            while (curNode.HasRightChild)
            {
                curNode = curNode.Right;
            }

            return curNode;
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter node.
        /// </summary>
        protected virtual int GetHeight(BinaryTreeNode<TKey, TValue> startNode)
        {
            if (startNode == null)
                return 0;
            else
                return 1 + Math.Max(GetHeight(startNode.Left), GetHeight(startNode.Right));
        }

        protected void Transplant(BinaryTreeNode<TKey, TValue> currentNode, BinaryTreeNode<TKey, TValue> newNode)
        {
            // case when currentNode is root node
            if (currentNode.Parent == null)
            {
                Root = newNode;
            }

            // identify which node is current node in relation to its parent and replace it
            else if (currentNode.IsLeftChild)
            {
                currentNode.Parent.Left = newNode;
            }
            else
            {
                currentNode.Parent.Right = newNode;
            }

            // update the parent info on inserted node
            if (newNode != null)
            {
                newNode.Parent = currentNode.Parent;
            }
        }

        protected static void InOrderTraversal(BinaryTreeNode<TKey, TValue> node, List<TKey> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Key);
            InOrderTraversal(node.Right, list);
        }

        protected BinaryTreeNode<TKey, TValue> GetNodeRecursively(BinaryTreeNode<TKey, TValue> startNode, TKey key)
        {
            if (startNode == null) return default;
            else if (key.CompareTo(startNode.Key) > 0) return GetNodeRecursively(startNode.Right, key);
            else if (key.CompareTo(startNode.Key) < 0) return GetNodeRecursively(startNode.Left, key);
            else return startNode;
        }

        protected BinaryTreeNode<TKey, TValue> GetNodeIteratively(TKey key)
        {
            var curNode = Root;

            while (curNode != null)
            {
                if (key.CompareTo(curNode.Key) == 0) return curNode;
                else if (key.CompareTo(curNode.Key) > 0) curNode = curNode.Right;
                else curNode = curNode.Left;
            }

            return curNode;
        }

        protected virtual void Add(BinaryTreeNode<TKey, TValue> node, Method method)
        {
            if (method == Method.Iterative)
            {
                AddIteratively(node);
            }
            else
            {
                if (Root == null) {
                    Root = node;
                    Size++;
                }
                else
                {
                    AddRecursively(Root, node);
                }
            }
        }

        protected void AddIteratively(BinaryTreeNode<TKey, TValue> newNode)
        {
            if (Root == null) {
                Root = newNode;
                Size++;
                return;
            };

            var curNode = Root;
            while (curNode != null)
            {
                // case when new node key precedes parent key
                if (newNode.Key.CompareTo(curNode.Key) < 0)
                {
                    if (curNode.Left == null)
                    {
                        curNode.Left = newNode;
                        newNode.Parent = curNode;
                        Size++;
                        break;
                    }
                    else
                    {
                        curNode = curNode.Left;
                    }
                }
                // case when new node key follows parent key
                else if (newNode.Key.CompareTo(curNode.Key) > 0)
                {
                    if (curNode.Right == null)
                    {
                        
                        curNode.Right = newNode;
                        newNode.Parent = curNode;
                        Size++;
                        break;
                    }
                    else
                    {
                        curNode = curNode.Right;
                    }
                }
                else
                {
                    // case when key matches. so we just update the value
                    curNode.Value = newNode.Value;
                }
            }
        }

        protected void AddRecursively(BinaryTreeNode<TKey, TValue> parent, BinaryTreeNode<TKey, TValue> newNode)
        {
            // case when new node key precedes parent key
            if (newNode.Key.CompareTo(parent.Key) < 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Size++;
                } 
                else
                {
                    AddRecursively(parent.Left, newNode);
                }
            }
            // case when new node key follows parent key
            else if (newNode.Key.CompareTo(parent.Key) > 0)
            {
                if (parent.Right == null)
                {
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Size++;
                } 
                else
                {
                    AddRecursively(parent.Right, newNode);
                }
            }
            else
            {
                // case when key matches. so we just update the value
                parent.Value = newNode.Value;
            }
        }

        /// <summary>
        /// Deletes node from a tree.
        /// </summary>
        /// <param name="delNode"></param>
        protected void Delete(BinaryTreeNode<TKey, TValue> delNode)
        {
            // this covers both cases when the delete node is leafless and there is only one leaf
            if (delNode.Left == null)
            {
                Transplant(delNode, delNode.Right);
            }
            // this case covers when there is only right leaf in delete node
            else if (delNode.Right == null)
            {
                Transplant(delNode, delNode.Left);
            }
            // this case covers when delete node has both children
            else
            {
                // get a successor - it is always be a minimum node of the right sub-tree
                // (we know already that the right sub-tree exists)
                var successor = GetSuccessor(delNode);

                if (successor.Parent.Equals(delNode) == false)
                {
                    // replace successor with the right child
                    Transplant(successor, successor.Right);
                    // rewire successor's node with the delete node's right child
                    successor.Right = delNode.Right;
                    // and update replaces right child's parrent with successor's node
                    successor.Right.Parent = successor;
                }

                Transplant(delNode, successor);
                successor.Left = delNode.Left;
                successor.Left.Parent = successor;
            }
            Size--;
        }

        #endregion
    }
}