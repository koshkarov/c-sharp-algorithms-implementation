using NUnit.Framework;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    class BinarySearchTreeTests
    {
        BinaryTree bstValid;
        BinaryTree bstInvalid;

        [SetUp]
        protected void SetUp()
        {
            // Valid Binary Search Tree
            bstValid = new BinaryTree();
            bstValid.Root = new BinaryTreeNode<int>(4);
            bstValid.Root.Left = new BinaryTreeNode<int>(2);
            bstValid.Root.Left.Left = new BinaryTreeNode<int>(1);
            bstValid.Root.Left.Right = new BinaryTreeNode<int>(3);
            bstValid.Root.Right = new BinaryTreeNode<int>(6);
            bstValid.Root.Right.Right = new BinaryTreeNode<int>(7);
            bstValid.Root.Right.Left = new BinaryTreeNode<int>(5);

            // Invlid Binary Search Tree
            bstInvalid = new BinaryTree();
            bstInvalid.Root = new BinaryTreeNode<int>(3);
            bstInvalid.Root.Left = new BinaryTreeNode<int>(2);
            bstInvalid.Root.Left.Left = new BinaryTreeNode<int>(1);
            bstInvalid.Root.Right = new BinaryTreeNode<int>(5);
            bstInvalid.Root.Right.Right = new BinaryTreeNode<int>(1);
            bstInvalid.Root.Right.Left = new BinaryTreeNode<int>(6);
        }


        [Test]
        public void IsBinarySearchTreeTraversalValid()
        {
            Assert.AreEqual(true, bstValid.IsBinarySearchTreeTraversal());
        }

        [Test]
        public void IsBinarySearchTreeTraversalInvalid()
        {
            Assert.AreEqual(false, bstInvalid.IsBinarySearchTreeTraversal());
        }

        [Test]
        public void IsBinarySearchTreeValid()
        {
            Assert.AreEqual(true, bstValid.IsBinarySearchTree());
        }

        [Test]
        public void IsBinarySearchTreeInvalid()
        {
            Assert.AreEqual(false, bstInvalid.IsBinarySearchTree());
        }

        [Test]
        public void ContainsKey()
        {
            for (int i = 1; i < 8; i++)
            {
                Assert.AreEqual(true, bstValid.Contains(i));
            }
        }

        [Test]
        public void DoesNotContainKey()
        {
            Assert.AreEqual(false, bstValid.Contains(8));

        }

    }
}
