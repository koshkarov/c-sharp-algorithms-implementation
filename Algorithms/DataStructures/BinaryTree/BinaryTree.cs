using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Algorithms.DataStructures.BinaryTree
{
    /// <summary>
    /// A binary tree is a non linear data structure where each node can have at most 2 child nodes. 
    /// There is no ordering in terms of how the nodes are organised in the binary tree. 
    /// Nodes that do not have any child nodes are called leaf nodes of the binary tree.
    /// 
    /// TODO: Implement and remove binary search tree methods
    /// </summary>
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
            throw new NotImplementedException();
        }



        // TODO: What is this looking for?
        public bool FindTarget(int key)
        {
            return Find(Root, key, new HashSet<int>());
        }

        private bool Find(BinaryTreeNode<int> binaryTreeNode, int key, HashSet<int> set)
        {
            if (binaryTreeNode == null)
                return false;

            if (set.Contains(key - binaryTreeNode.Value))
                return true;

            set.Add(binaryTreeNode.Value);

            return Find(binaryTreeNode.Left, key, set) || Find(binaryTreeNode.Right, key, set);
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
            // TODO3
        }
    }
}

