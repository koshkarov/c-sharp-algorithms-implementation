using Algorithms.DataStructures.BinarySearchTree;
using Algorithms.DataStructures.BinaryTree;
using Algorithms.Extensions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class BinarySearchTreeTests
    {
        BinarySearchTree bstValid;

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
        }

        private BinaryTreeNode<int> GetValidBinarySearchTree()
        {
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>

            return new BinaryTreeNode<int>(6)
            {
                Left = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(2)
                    {
                        Left = new BinaryTreeNode<int>(1)
                    },
                    Right = new BinaryTreeNode<int>(4)
                },
                Right = new BinaryTreeNode<int>(8)
                {
                    Left = new BinaryTreeNode<int>(7),
                    Right = new BinaryTreeNode<int>(10)
                    {
                        Left = new BinaryTreeNode<int>(9),
                        Right = new BinaryTreeNode<int>(12)
                    }
                }
            };
        }

        private BinaryTreeNode<int> CreateBalancedBinarySearchTree(int elementsCount, bool isIterative = false)
        {
            // create an array for values
            var balancedValues = new int[elementsCount];

            // populate it
            for (int i = 0; i < elementsCount; i++) 
                balancedValues[i] = i;

            // shuffle values in-place
            balancedValues.Shuffle();

            // create a binary search tree
            var bst = new BinarySearchTree();

            // act
            foreach (var item in balancedValues)
            {
                bst.Insert(item, isIterative);
            }

            return bst.Root;
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
            var iterations = 100;

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
            var rootNode = CreateBalancedBinarySearchTree(100, isIterative);

            // assert
            Assert.IsTrue(rootNode.IsBinarySearchTree());
        }

        [Test]
        public void Delete_LeaflessNode_IsCorrect() 
        {
            // arrange
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>
            var binarySearchTree = new BinarySearchTree(GetValidBinarySearchTree());

            // act
            binarySearchTree.Delete(1);

            // assert
            var root = binarySearchTree.Root;
            // verify deleted node and BST integrity
            Assert.Multiple(() => {
                Assert.That(root.Value, Is.EqualTo(6));
                Assert.That(root.Left.Value, Is.EqualTo(3));
                Assert.That(root.Left.Left.Value, Is.EqualTo(2));
                Assert.That(root.Left.Right.Value, Is.EqualTo(4));
                Assert.That(root.Left.Left.Left, Is.EqualTo(null)); // deleted node
                Assert.That(root.Right.Value, Is.EqualTo(8));
                Assert.That(root.Right.Left.Value, Is.EqualTo(7));
                Assert.That(root.Right.Right.Value, Is.EqualTo(10));
                Assert.That(root.Right.Right.Right.Value, Is.EqualTo(12));
                Assert.That(root.Right.Right.Left.Value, Is.EqualTo(9));
            });
        }

        [Test]
        public void Delete_NodeWithOneLeaf_IsCorrect() 
        {
            // arrange
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>
            var binarySearchTree = new BinarySearchTree(GetValidBinarySearchTree());

            // act
            binarySearchTree.Delete(2);

            // assert
            var root = binarySearchTree.Root;

            // verify deleted node and BST integrity
            // expected tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <1>   <4>     <7>   <10>
            //                      /   \
            //                    <9>   <12>
            Assert.Multiple(() => {
                Assert.That(root.Value, Is.EqualTo(6));

                Assert.That(root.Left.Value, Is.EqualTo(3));
                Assert.That(root.Left.Left.Value, Is.EqualTo(1)); // node replaced with the leaf
                Assert.That(root.Left.Right.Value, Is.EqualTo(4));

                Assert.That(root.Right.Value, Is.EqualTo(8));
                Assert.That(root.Right.Left.Value, Is.EqualTo(7));
                Assert.That(root.Right.Right.Value, Is.EqualTo(10));

                Assert.That(root.Right.Right.Right.Value, Is.EqualTo(12));
                Assert.That(root.Right.Right.Left.Value, Is.EqualTo(9));
            });
        }

        [Test]
        public void Delete_NodeWithTwoLeafsCase1_IsCorrect() 
        {
            // arrange
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>
            var binarySearchTree = new BinarySearchTree(GetValidBinarySearchTree());

            // act
            binarySearchTree.Delete(10);

            // assert
            var root = binarySearchTree.Root;

            // verify deleted node and BST integrity
            // expected tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <12>
            //   /                   /
            //<1>                  <9>
            Assert.Multiple(() => {
                Assert.That(root.Value, Is.EqualTo(6));

                Assert.That(root.Left.Value, Is.EqualTo(3));
                Assert.That(root.Left.Left.Value, Is.EqualTo(2));
                Assert.That(root.Left.Right.Value, Is.EqualTo(4));

                Assert.That(root.Right.Value, Is.EqualTo(8));
                Assert.That(root.Right.Left.Value, Is.EqualTo(7));
                Assert.That(root.Right.Right.Value, Is.EqualTo(12));

                Assert.That(root.Right.Right.Left.Value, Is.EqualTo(9));
                Assert.That(root.Right.Right.Right, Is.EqualTo(null));
                
            });
        }

        [Test]
        public void Delete_NodeWithTwoLeafsCase2_IsCorrect()
        {
            // arrange
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>
            var binarySearchTree = new BinarySearchTree(GetValidBinarySearchTree());

            // act
            binarySearchTree.Delete(8);

            // assert
            var root = binarySearchTree.Root;

            // verify deleted node and BST integrity

            // expected tree:
            //             <6>
            //           /     \
            //      <3>           <10>
            //      /  \         /   \
            //   <2>   <4>     <9>   <12>
            //   /            /
            //<1>         <7>

            Assert.Multiple(() => {
                Assert.That(root.Value, Is.EqualTo(6));

                Assert.That(root.Left.Value, Is.EqualTo(3));
                Assert.That(root.Left.Left.Value, Is.EqualTo(2));
                Assert.That(root.Left.Right.Value, Is.EqualTo(4));

                Assert.That(root.Right.Value, Is.EqualTo(10));
                Assert.That(root.Right.Left.Value, Is.EqualTo(9));
                Assert.That(root.Right.Right.Value, Is.EqualTo(12));

                Assert.That(root.Right.Left.Left.Value, Is.EqualTo(7));
                Assert.That(root.Right.Left.Right, Is.EqualTo(null));
            });
        }

        [Test]
        public void IsBinarySearchTree_ValidTree_ReturnsTrue()
        {
            // assert
            var rootNode = bstValid.Root;
            Assert.IsTrue(rootNode.IsBinarySearchTree());
        }

        [Test]
        public void IsBinarySearchTree_InvalidTree_ReturnsFalse()
        {
            // create Invlid Binary Search Tree
            var notBinarySearchTree = new BinarySearchTree(new BinaryTreeNode<int>(3)
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

            // assert
            var rootNode = notBinarySearchTree.Root;
            Assert.IsFalse(rootNode.IsBinarySearchTree());
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
        public void DoesNotContainKey([Values(true, false)] bool isIterative)
        {
            Assert.AreEqual(false, bstValid.Contains(8, isIterative));
        }

        [Test]
        public void BinaryTreeLevelInsert()
        {
            var iterations = 100;
            var rootNode = CreateBalancedBinarySearchTree(iterations);
            var bst = new BinarySearchTree(rootNode);

            var traversed = bst.TraverseInOrder();
            for (int i = 0; i < iterations; i++) Assert.IsTrue(traversed[i] == i);
        }

    }
}
