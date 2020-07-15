using Algorithms.DataStructures.Trees.AVL;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Tests
{
    [TestFixture]
    class AvlTreeTests
    {
        private string GetValue(int key) => key.ToString();

        [Test]
        public void Height_EmptyTree_ReturnsZero()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            // assert
            avlTree.Height.ShouldBe(0);
        }

        [Test, Ignore("")]
        public void Height_TreeWithOneNode_ReturnsOne()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(1, "1");

            // assert
            avlTree.Height.ShouldBe(1);
        }

    }
}
