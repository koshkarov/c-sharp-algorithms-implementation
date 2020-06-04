using Algorithms.DataStructures.BinarySearchTree;
using Algorithms.DataStructures.BinarySearchTree.Extensions;
using Algorithms.DataStructures.BinaryTree;
using Algorithms.Extensions;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class BinarySearchTreeTests
    {
        const string _value = "value";
        BinarySearchTree<int, string> bstValid;

        [SetUp]
        protected void SetUp()
        {
            // Valid Binary Search Tree
            bstValid = new BinarySearchTree<int, string>(new BinaryTreeNode<int, string>(4, _value)
            {
                Left = new BinaryTreeNode<int, string>(2, _value)
                {
                    Left = new BinaryTreeNode<int, string>(1, _value),
                    Right = new BinaryTreeNode<int, string>(3, _value)
                },
                Right = new BinaryTreeNode<int, string>(6, _value)
                {
                    Right = new BinaryTreeNode<int, string>(7, _value),
                    Left = new BinaryTreeNode<int, string>(5, _value)
                }
            });
        }

        private BinaryTreeNode<int, string> GetValidBinarySearchTree()
        {
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>

            return new BinaryTreeNode<int, string>(6, _value)
            {
                Left = new BinaryTreeNode<int, string>(3, _value)
                {
                    Left = new BinaryTreeNode<int, string>(2, _value)
                    {
                        Left = new BinaryTreeNode<int, string>(1, _value)
                    },
                    Right = new BinaryTreeNode<int, string>(4, _value)
                },
                Right = new BinaryTreeNode<int, string>(8, _value)
                {
                    Left = new BinaryTreeNode<int, string>(7, _value),
                    Right = new BinaryTreeNode<int, string>(10, _value)
                    {
                        Left = new BinaryTreeNode<int, string>(9, _value),
                        Right = new BinaryTreeNode<int, string>(12, _value)
                    }
                }
            };
        }

        private BinaryTreeNode<int, string> CreateBalancedBinarySearchTree(int elementsCount, bool isIterative = false)
        {
            // create an array for values
            var balancedValues = new int[elementsCount];

            // populate it
            for (int i = 0; i < elementsCount; i++) 
                balancedValues[i] = i;

            // shuffle values in-place
            balancedValues.Shuffle();

            // create a binary search tree
            var bst = new BinarySearchTree<int, string>();

            // act
            foreach (var item in balancedValues)
            {
                bst.Put(item, _value, isIterative);
            }

            return bst.Root;
        }

        [Test]
        public void Insert_IncrementalKeys_BuildsCorrectTree([Values(true, false)]bool isIterative)
        {
            // arrange 
            var bst = new BinarySearchTree<int, string>();
            var iterations = 100;
            // act
            for (int i = 0; i < iterations; i++)
            {
                bst.Put(i, _value, isIterative);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = 0; i < iterations; i++)
            {
                Assert.IsTrue(tempNode.Key == i);
                tempNode = tempNode.Right;
            }
        }

        [Test]
        public void Insert_DecrementalKeys_BuildsCorrectTree([Values(true, false)] bool isIterative)
        {
            // arrange
            var bst = new BinarySearchTree<int, string>();
            var iterations = 100;

            // act
            for (int i = iterations; i > 0; i--)
            {
                bst.Put(i, _value, isIterative);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = iterations; i > 0; i--)
            {
                Assert.IsTrue(tempNode.Key == i);
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
            var binarySearchTree = new BinarySearchTree<int, string>(GetValidBinarySearchTree());

            // act
            binarySearchTree.Delete(1);

            // assert
            var root = binarySearchTree.Root;
            // verify deleted node and BST integrity
            Assert.Multiple(() => {
                Assert.That(root.Key, Is.EqualTo(6));
                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));
                Assert.That(root.Left.Left.Left, Is.EqualTo(null)); // deleted node
                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));
                Assert.That(root.Right.Right.Key, Is.EqualTo(10));
                Assert.That(root.Right.Right.Right.Key, Is.EqualTo(12));
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
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
            var binarySearchTree = new BinarySearchTree<int, string>(GetValidBinarySearchTree());

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
                Assert.That(root.Key, Is.EqualTo(6));

                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(1)); // node replaced with the leaf
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));

                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));
                Assert.That(root.Right.Right.Key, Is.EqualTo(10));

                Assert.That(root.Right.Right.Right.Key, Is.EqualTo(12));
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
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
            var binarySearchTree = new BinarySearchTree<int, string>(GetValidBinarySearchTree());

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
                Assert.That(root.Key, Is.EqualTo(6));

                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));

                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));
                Assert.That(root.Right.Right.Key, Is.EqualTo(12));

                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
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
            var binarySearchTree = new BinarySearchTree<int, string>(GetValidBinarySearchTree());

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
                Assert.That(root.Key, Is.EqualTo(6));

                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));

                Assert.That(root.Right.Key, Is.EqualTo(10));
                Assert.That(root.Right.Left.Key, Is.EqualTo(9));
                Assert.That(root.Right.Right.Key, Is.EqualTo(12));

                Assert.That(root.Right.Left.Left.Key, Is.EqualTo(7));
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
            var notBinarySearchTree = new BinarySearchTree<int, string>(new BinaryTreeNode<int, string>(3, _value)
            {
                Left = new BinaryTreeNode<int, string>(2, _value)
                {
                    Left = new BinaryTreeNode<int, string>(1, _value)
                },
                Right = new BinaryTreeNode<int, string>(5, _value)
                {
                    Right = new BinaryTreeNode<int, string>(1, _value),
                    Left = new BinaryTreeNode<int, string>(6, _value)
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
                Assert.That(bstValid.Contains(i, isIterative), Is.True);
            }
        }

        [Test]
        public void DoesNotContainKey([Values(true, false)] bool isIterative)
        {
            var bst = GetValidBinarySearchTree();
            Assert.That(bstValid.Contains(8, isIterative), Is.False);
        }

        [Test]
        public void BinaryTreeLevelInsert()
        {
            var iterations = 100;
            var rootNode = CreateBalancedBinarySearchTree(iterations);
            var bst = new BinarySearchTree<int, string>(rootNode);

            var traversed = bst.GetKeys();
            for (int i = 0; i < iterations; i++) Assert.IsTrue(traversed[i] == i);
        }

    }
}
