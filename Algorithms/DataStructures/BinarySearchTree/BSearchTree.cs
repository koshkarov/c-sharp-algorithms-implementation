using Algorithms.DataStructures.BinaryTree;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
    public class BSearchTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BinaryTreeNode<TKey, TValue> Root { get; private set; }

        public BSearchTree()
        {
        }

        public BSearchTree(BinaryTreeNode<TKey, TValue> root)
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
                : PutRecursively(Root, new BinaryTreeNode<TKey, TValue>(key, value));
        }

        public void Delete(TKey key)
        {
            var node = GetNodeRecursively(Root, key);
            if (node == null) throw new InvalidOperationException($"Couldn't find node with key {key}");
            Delete(node);
        }

        public bool Contains(TKey key, bool isIterative = false)
        {
            var node = isIterative
                ? GetNodeIteratively(key)
                : GetNodeRecursively(Root, key);

            return node != null;
        }

        public IList<TKey> GetKeys()
        {
            var list = new List<TKey>();
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

        private BinaryTreeNode<TKey, TValue> PutRecursively(BinaryTreeNode<TKey, TValue> node, BinaryTreeNode<TKey, TValue> newNode)
        {
            if (node == null) node = newNode;
            else if (newNode.Key.CompareTo(node.Key) < 0)
            {
                newNode.Parent = node;
                node.Left = PutRecursively(node.Left, newNode);
            }
            else if (newNode.Key.CompareTo(node.Key) > 0)
            {
                newNode.Parent = node;
                node.Right = PutRecursively(node.Right, newNode);
            }
                
            return node;
        }

        /// <summary>
        /// Deletes node from a tree.
        /// </summary>
        /// <param name="delNode"></param>
        private void Delete(BinaryTreeNode<TKey, TValue> delNode)
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
                    // rewire successor's node with the delte node right child
                    successor.Right = delNode.Right;
                    // and update replaces right child's parrent with successor's node
                    successor.Right.Parent = successor;
                }

                Transplant(delNode, successor);
                successor.Left = delNode.Left;
                successor.Left.Parent = successor;

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
            while(curNode.Left != null)
            {
                curNode = curNode.Left;
            }
            return curNode;
        }

        private BinaryTreeNode<TKey, TValue> GetMax(BinaryTreeNode<TKey, TValue> node)
        {
            var curNode = node;
            while (curNode.Right != null)
            {
                curNode = curNode.Right;
            }
            return curNode;
        }

        private void Transplant(BinaryTreeNode<TKey, TValue> currentNode, BinaryTreeNode<TKey, TValue> newNode)
        {
            // case when currentNode is root node
            if (currentNode.Parent == null)
            {
                Root = newNode;
            }
            // identify which node is current node in relation to its parent and replace it
            else if (currentNode.Equals(currentNode.Parent.Left))
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