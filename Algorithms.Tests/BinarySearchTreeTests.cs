using Algorithms.DataStructures;
using NUnit.Framework;

namespace Algorithms.Tests
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
            bstValid = new BinaryTree
            {
                Root = new BinaryTreeNode<int>(4)
                {
                    Left = new BinaryTreeNode<int>(2)
                    {
                        Left = new BinaryTreeNode<int>(1),
                        Right = new BinaryTreeNode<int>(3)
                    },
                    Right = new BinaryTreeNode<int>(6)
                    {
                        Right = new BinaryTreeNode<int>(7),
                        Left = new BinaryTreeNode<int>(5)
                    }
                }
            };

            // Invlid Binary Search Tree
            bstInvalid = new BinaryTree
            {
                Root = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(2)
                    {
                        Left = new BinaryTreeNode<int>(1)
                    },
                    Right = new BinaryTreeNode<int>(5)
                    {
                        Right = new BinaryTreeNode<int>(1),
                        Left = new BinaryTreeNode<int>(6)
                    }
                }
            };
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
