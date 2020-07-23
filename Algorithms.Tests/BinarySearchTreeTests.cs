﻿using Algorithms.DataStructures.BinarySearchTree.Extensions;
using Algorithms.DataStructures.Trees.Binary;
using Algorithms.DataStructures.Trees.BinarySearch;
using Algorithms.Tests.Base;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Tests
{
    [TestFixture]
    class BinarySearchTreeTests : BaseTest
    {
        private BinarySearchTree<int, string> GetValid()
        {
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <12>

            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));
            return bst;
        }

        private BinaryTreeNode<int, string> CreateBalancedBinarySearchTree(int count, Method method = Method.Recursive)
        {
            var balancedValues = GetBalancedArray(count);

            // create a binary search tree
            var bst = new BinarySearchTree<int, string>();

            // act
            foreach (var item in balancedValues)
            {
                bst.Add(item, Stringify(item), method);
            }

            return bst.Root;
        }

        [Test]
        public void Add_IncrementalKeys_BuildsCorrectTree([Values(Method.Recursive, Method.Iterative)] Method method)
        {
            // arrange 
            var bst = new BinarySearchTree<int, string>();
            var iterations = 100;
            // act
            for (int i = 0; i < iterations; i++)
            {
                bst.Add(i, Stringify(i), method);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = 0; i < iterations; i++)
            {
                Assert.That(tempNode.Key, Is.EqualTo(i));
                tempNode = tempNode.Right;
            }
        }

        [Test]
        public void Add_DecrementalKeys_BuildsCorrectTree([Values(Method.Recursive, Method.Iterative)] Method method)
        {
            // arrange
            var bst = new BinarySearchTree<int, string>();
            var iterations = 100;

            // act
            for (int i = iterations; i > 0; i--)
            {
                bst.Add(i, Stringify(i), method);
            }

            // assert
            var tempNode = bst.Root;
            for (int i = iterations; i > 0; i--)
            {
                Assert.That(tempNode.Key, Is.EqualTo(i));
                tempNode = tempNode.Left;
            }
        }

        [Test]
        public void Add_BalancedKeys_BuildsCorrectTree([Values(Method.Recursive, Method.Iterative)] Method method)
        {
            // arrange
            var rootNode = CreateBalancedBinarySearchTree(100, method);

            // assert
            Assert.IsTrue(rootNode.IsBinarySearchTree());
        }

        [Test]
        public void Add_SameKey_OverwritesValue([Values(true, false)] bool isIterative)
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

            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));

            string expected = "replaced_value";

            // act
            bst.Add(8, expected);

            // assert
            Assert.That(bst.GetValue(8), Is.EqualTo(expected));
        }

        [Test]
        public void Delete_LeaflessNodeLeft_IsCorrect() 
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
            var binarySearchTree = GetValid();

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
        public void Delete_LeaflessNodeRight_IsCorrect()
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
            var binarySearchTree = GetValid();

            // act
            binarySearchTree.Delete(12);

            // assert
            var root = binarySearchTree.Root;
            // verify deleted node and BST integrity
            Assert.Multiple(() => {
                Assert.That(root.Key, Is.EqualTo(6));
                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));
                Assert.That(root.Left.Left.Left.Key, Is.EqualTo(1)); 
                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));
                Assert.That(root.Right.Right.Key, Is.EqualTo(10));
                Assert.That(root.Right.Right.Right, Is.EqualTo(null)); // deleted node
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
            });
        }

        [Test]
        public void Delete_NodeWithOneLeafLeft_IsCorrect() 
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
            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));

            // act
            bst.Delete(2);

            // assert
            var root = bst.Root;

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
        public void Delete_NodeWithOneLeafRight_IsCorrect()
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
            //                              \
            //                              <15>
            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));
            bst.Add(15, Stringify(15));

            // act
            bst.Delete(12);

            // assert
            var root = bst.Root;

            // verify deleted node and BST integrity
            // expected tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /                   /   \
            //<1>                  <9>   <15>
            //
            //
            Assert.Multiple(() => {
                Assert.That(root.Key, Is.EqualTo(6));

                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Left.Left.Key, Is.EqualTo(1));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));

                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));
                Assert.That(root.Right.Right.Key, Is.EqualTo(10));
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
                Assert.That(root.Right.Right.Right.Key, Is.EqualTo(15)); // node replaced with the leaf

            });
        }

        [Test]
        public void Delete_RootNode_IsCorrect()
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
            //                              \
            //                              <15>
            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));
            bst.Add(15, Stringify(15));

            var root1 = bst.Root;

            // act
            bst.Delete(6);

            // assert
            var root = bst.Root;

            // verify deleted node and BST integrity
            // expected tree:
            //             <7>
            //           /     \
            //      <3>         <8>
            //      /  \           \
            //   <2>   <4>         <10>
            //   /                 /   \
            //<1>                <9>   <12>
            //                            \
            //                            <15>
            Assert.Multiple(() => {
                Assert.That(root.Key, Is.EqualTo(7)); // node replaced with a successor

                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Left.Left.Key, Is.EqualTo(1));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));

                Assert.That(root.Right.Key, Is.EqualTo(8));
                Assert.That(root.Right.Left, Is.EqualTo(null)); // past place of the successor that replaced the root
                Assert.That(root.Right.Right.Key, Is.EqualTo(10));
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(9));
                Assert.That(root.Right.Right.Right.Key, Is.EqualTo(12));
                Assert.That(root.Right.Right.Right.Right.Key, Is.EqualTo(15));

            });
        }

        [Test]
        public void Delete_All_IsCorrect()
        {
            // arrange
            // Initial tree:
            //             <6>
            //           /     \
            //      <3>           <8>
            //      /  \         /   \
            //   <2>   <4>     <7>   <10>
            //   /       \          /   \
            //<1>        <5>      <9>   <11>

            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(11, Stringify(11));
            bst.Add(5, Stringify(5));

            // act
            var keys = bst.GetKeys();
            foreach(var key in keys)
            {
                bst.Delete(key);
            }
            
            // assert
            var root = bst.Root;

            Assert.That(root, Is.EqualTo(null));
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
            var binarySearchTree = GetValid();

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
            //   <2>   <4>     <7>   <15>
            //   /                   /   \
            //<1>                  <12>   <20>
            //                       \
            //                       <13>

            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            // root left
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            // root right
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(15, Stringify(15));
            bst.Add(20, Stringify(20));
            bst.Add(12, Stringify(12));
            bst.Add(13, Stringify(13));

            // act
            bst.Delete(8);

            // Expected tree:
            //             <6>
            //           /     \
            //      <3>           <12>
            //      /  \         /   \
            //   <2>   <4>     <7>   <15>
            //   /                   /   \
            //<1>                  <13>   <20>

            // assert
            var root = bst.Root;
            // verify deleted node and BST integrity
            Assert.Multiple(() => {
                Assert.That(root.Key, Is.EqualTo(6));
                Assert.That(root.Left.Key, Is.EqualTo(3));
                Assert.That(root.Left.Left.Key, Is.EqualTo(2));
                Assert.That(root.Left.Right.Key, Is.EqualTo(4));
                Assert.That(root.Right.Key, Is.EqualTo(12));
                Assert.That(root.Right.Left.Key, Is.EqualTo(7));

                Assert.That(root.Right.Right.Key, Is.EqualTo(15));
                Assert.That(root.Right.Right.Right.Key, Is.EqualTo(20));
                Assert.That(root.Right.Right.Left.Key, Is.EqualTo(13));
                Assert.That(root.Right.Right.Left.Left, Is.EqualTo(null));
                Assert.That(root.Right.Right.Left.Right, Is.EqualTo(null));
            });
        }

        [Test]
        public void IsBinarySearchTree_ValidTree_ReturnsTrue()
        {
            // assert
            var rootNode = GetValid().Root;
            Assert.IsTrue(rootNode.IsBinarySearchTree());
        }

        [Test]
        public void IsBinarySearchTree_InvalidTree_ReturnsFalse()
        {
            // create Invlid Binary Search Tree
            var notBinarySearchTree = new BinarySearchTree<int, string>(new BinaryTreeNode<int, string>(3, Stringify(3))
            {
                Left = new BinaryTreeNode<int, string>(2, Stringify(2))
                {
                    Left = new BinaryTreeNode<int, string>(1, Stringify(1))
                },
                Right = new BinaryTreeNode<int, string>(5, Stringify(5))
                {
                    Right = new BinaryTreeNode<int, string>(1, Stringify(1)),
                    Left = new BinaryTreeNode<int, string>(6, Stringify(6))
                }
            });

            // assert
            var rootNode = notBinarySearchTree.Root;
            Assert.IsFalse(rootNode.IsBinarySearchTree());
        }

        [Test]
        public void ContainsKey([Values(true, false)] bool isIterative)
        {
            var bst = new BinarySearchTree<int, string>();
            bst.Add(6, Stringify(6));
            bst.Add(3, Stringify(3));
            bst.Add(2, Stringify(2));
            bst.Add(1, Stringify(1));
            bst.Add(4, Stringify(4));
            bst.Add(8, Stringify(8));
            bst.Add(7, Stringify(7));
            bst.Add(10, Stringify(10));
            bst.Add(9, Stringify(9));
            bst.Add(12, Stringify(12));
            bst.Add(11, Stringify(11));
            bst.Add(5, Stringify(5));

            for (int i = 1; i < 12; i++)
            {
                Assert.That(bst.Contains(i, isIterative), Is.True);
            }
        }

        [Test]
        public void DoesNotContainKey([Values(true, false)] bool isIterative)
        {
            var bst = GetValid();
            Assert.That(GetValid().Contains(11, isIterative), Is.False);
        }

        [Test]
        public void BinaryTreeLevelAdd()
        {
            var iterations = 100;
            var rootNode = CreateBalancedBinarySearchTree(iterations);
            var bst = new BinarySearchTree<int, string>(rootNode);

            var traversed = bst.GetKeys();
            for (int i = 0; i < iterations; i++) Assert.IsTrue(traversed[i] == i);
        }

        [Test]
        public void Add_TreeSize_IsCorrect([Values(Method.Recursive, Method.Iterative)] Method method)
        {
            var iterations = 100;
            // create a binary search tree
            var bst = new BinarySearchTree<int, string>();

            // act
            for (int i = 0; i < iterations; i++)
            {
                bst.Add(i, Stringify(i), method);
            }

            bst.Size.ShouldBe(iterations);
        }

        [Test]
        public void AddDelete_TreeSize_IsCorrect()
        {
            var iterations = 100;
            // create a binary search tree
            var bst = new BinarySearchTree<int, string>();

            // act
            // add 100 objects
            for (int key = 0; key < iterations; key++)
            {
                bst.Add(key, Stringify(key));
            }

            // delete 100 objects
            for (int key = 0; key < iterations; key++)
            {
                bst.Delete(key);
            }

            bst.Size.ShouldBe(0);
        }

    }
}
