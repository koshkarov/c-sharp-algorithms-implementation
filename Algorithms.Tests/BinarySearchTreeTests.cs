using Algorithms.DataStructures;
using Algorithms.Extensions;
using Algorithms.Tests.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.ComponentModel.DataAnnotations;

namespace Algorithms.Tests
{
    [TestFixture]
    class BinarySearchTreeTests
    {
        BinarySearchTree bstValid;
        BinarySearchTree bstInvalid;

        [SetUp]
        protected void SetUp()
        {
            // Valid Binary Search Tree
            bstValid = new BinarySearchTree(new BinaryTreeNode<int>(4)
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
            });

            // Invlid Binary Search Tree
            bstInvalid = new BinarySearchTree(new BinaryTreeNode<int>(3)
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
            });
        }

        [Test]
        public void Insert_IncrementalKeys_BuildsCorrectTree([Values(true, false)]bool isIterative)
        {
            // arrange 
            var bst = new BinarySearchTree();
            var iterations = 100;
            // act
            for (int i = 0; i < iterations; i++)
            {
                bst.Insert(i, isIterative);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = 0; i < iterations; i++)
            {
                Assert.IsTrue(tempNode.Value == i);
                tempNode = tempNode.Right;
            }
        }

        [Test]
        public void Insert_DecrementalKeys_BuildsCorrectTree([Values(true, false)] bool isIterative)
        {
            // arrange
            var bst = new BinarySearchTree();
            var iterations = 5;

            // act
            for (int i = iterations; i > 0; i--)
            {
                bst.Insert(i, isIterative);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = iterations; i > 0; i--)
            {
                Assert.IsTrue(tempNode.Value == i);
                tempNode = tempNode.Left;
            }
        }

        [Test]
        public void Insert_BalancedKeys_BuildsCorrectTree([Values(true, false)] bool isIterative)
        {
            // arrange
            var balancedValues = new int[100];

            for (int i = 0; i < 100; i++) 
                balancedValues[i] = i;

            balancedValues.Shuffle();

            var bst = new BinarySearchTree();

            // act
            foreach (var item in balancedValues)
            {
                bst.Insert(item, isIterative);
            }

            // assert
            var rootNode = bst.Root;
            Assert.IsTrue(rootNode.IsBinarySerchTree());
        }

        [Test]
        public void IsBinarySearchTree_ValidTree_ReturnsTrue()
        {
            // assert
            var rootNode = bstValid.Root;
            Assert.IsTrue(rootNode.IsBinarySerchTree());
        }

        [Test]
        public void IsBinarySearchTree_InvalidTree_ReturnsFalse()
        {
            // assert
            var rootNode = bstInvalid.Root;
            Assert.IsFalse(rootNode.IsBinarySerchTree());
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
        public void ContainsKey([Values(true, false)] bool isIterative)
        {
            for (int i = 1; i < 8; i++)
            {
                Assert.AreEqual(true, bstValid.Contains(i, isIterative));
            }
        }

        [Test]
        public void DoesNotContainKey()
        {
            Assert.AreEqual(false, bstValid.Contains(8));

        }

        [Test]
        public void BinaryTreeLevelInsert()
        {
            var bst = new BinarySearchTree();
            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(3);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(7);

            var traversed = bst.TraverseInOrder();

            Assert.AreEqual(false, bstValid.Contains(8));

        }

    }
}
