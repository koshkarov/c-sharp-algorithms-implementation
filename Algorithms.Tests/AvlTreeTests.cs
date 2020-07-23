using Algorithms.DataStructures.Trees.AVL;
using Algorithms.Tests.Base;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Tests
{
    [TestFixture]
    class AvlTreeTests : BaseTest
    {

        [Test]
        public void Size_TreeWithMultipleNodes_ReturnsCorrrectResult([Values(0, 1, 25)] int count)
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            int[] balanced = GetBalancedArray(count);
            foreach (int i in balanced)
            {
                avlTree.Add(i, Stringify(i));
            }
            // assert
            avlTree.Size.ShouldBe(count);
        }

        [Test]
        public void Add_RightRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(3, Stringify(3));
            avlTree.Add(2, Stringify(2));
            avlTree.Add(1, Stringify(1));
            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent, Is.EqualTo(avlTree.Root));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent, Is.EqualTo(avlTree.Root));
            });
        }

        [Test]
        public void Add_LeftRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(1, Stringify(1));
            avlTree.Add(2, Stringify(2));
            avlTree.Add(3, Stringify(3));

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys & parents
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent, Is.EqualTo(avlTree.Root));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent, Is.EqualTo(avlTree.Root));
            });
        }

        [Test]
        public void Add_LeftRightRotation_ReturnsCorrrectTree()
        {
            // 4 3 2 1 0 <- to test
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(3, Stringify(3));
            avlTree.Add(1, Stringify(1));
            avlTree.Add(2, Stringify(2));

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent, Is.EqualTo(avlTree.Root));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent, Is.EqualTo(avlTree.Root));
            });
        }

        [Test]
        public void Add_RightLeftRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(1, Stringify(1));
            avlTree.Add(3, Stringify(3));
            avlTree.Add(2, Stringify(2));

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys & parents
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent, Is.EqualTo(avlTree.Root));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent, Is.EqualTo(avlTree.Root));
            });
        }

        [Test]
        public void Add_MultiRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(43, Stringify(43));
            avlTree.Add(18, Stringify(18));
            avlTree.Add(22, Stringify(22));

            // rotates left
            //           <43>
            //          /     
            //      <18>         
            //          \        
            //           <22> 

            // left-right rotation

            //            <22>
            //          /     \
            //      <18>       <43>

            avlTree.Add(9, Stringify(9));
            avlTree.Add(21, Stringify(21));
            avlTree.Add(6, Stringify(6));

            //             <22>
            //           /     \
            //      <18>         <43>
            //      /  \ 
            //   <9>  <21>
            //   /
            //<6>

            // right rotation with grandparent 22
            //             <18>
            //           /     \
            //       <9>         <22>
            //      /            /   \
            //   <6>          <21>   <43>

            var root = avlTree.Root;
            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(6));

                // keys & parents
                Assert.That(root.Key, Is.EqualTo(18));
                Assert.That(root.Parent, Is.EqualTo(null));

                // left sub-tree
                Assert.That(root.Left.Key, Is.EqualTo(9));
                Assert.That(root.Left.Parent.Key, Is.EqualTo(18));

                Assert.That(root.Left.Left.Key, Is.EqualTo(6));
                Assert.That(root.Left.Left.Parent.Key, Is.EqualTo(9));
                Assert.That(root.Left.Left.Left, Is.EqualTo(null));
                Assert.That(root.Left.Left.Right, Is.EqualTo(null));

                Assert.That(root.Left.Right, Is.EqualTo(null));

                // right sub-tree
                Assert.That(root.Right.Key, Is.EqualTo(22));
                Assert.That(root.Right.Parent.Key, Is.EqualTo(18));

                Assert.That(root.Right.Left.Key, Is.EqualTo(21));
                Assert.That(root.Right.Left.Parent.Key, Is.EqualTo(22));

                Assert.That(root.Right.Right.Key, Is.EqualTo(43));
                Assert.That(root.Right.Right.Parent.Key, Is.EqualTo(22));

            });
        }

        [Test]
        public void Delete_RightRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(3, Stringify(3));
            avlTree.Add(4, Stringify(4));
            avlTree.Add(2, Stringify(2));
            avlTree.Add(1, Stringify(1));

            // delete 4 which will create imbalance and trigger right rotation
            avlTree.Delete(4);

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent.Key, Is.EqualTo(2));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent.Key, Is.EqualTo(2));
            });
        }


        [Test]
        public void Delete_LeftRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(2, Stringify(2));
            avlTree.Add(1, Stringify(1));
            avlTree.Add(3, Stringify(3));
            avlTree.Add(4, Stringify(1));

            // delete 4 which will create imbalance and trigger right rotation
            avlTree.Delete(1);

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys & parents
                Assert.That(avlTree.Root.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Left.Parent.Key, Is.EqualTo(3));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(4));
                Assert.That(avlTree.Root.Right.Parent.Key, Is.EqualTo(3));
            });
        }

        [Test]
        public void Delete_LeftRightRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(3, Stringify(3));
            avlTree.Add(4, Stringify(4));
            avlTree.Add(1, Stringify(1));
            avlTree.Add(2, Stringify(2));

            // delete 4 which will create imbalance and trigger left-right rotation
            avlTree.Delete(4);

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent.Key, Is.EqualTo(2));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent.Key, Is.EqualTo(2));
            });
        }

        [Test]
        public void Delete_RightLeftRotation_ReturnsCorrrectTree()
        {
            // arrange 
            var avlTree = new AVLTree<int, string>();

            avlTree.Add(1, Stringify(1));
            avlTree.Add(0, Stringify(0));
            avlTree.Add(3, Stringify(3));
            avlTree.Add(2, Stringify(2));

            // delete 0 which will create imbalance and trigger right-left rotation
            avlTree.Delete(0);

            // assert
            Assert.Multiple(() =>
            {
                // size
                Assert.That(avlTree.Size, Is.EqualTo(3));

                // keys & parents
                Assert.That(avlTree.Root.Key, Is.EqualTo(2));
                Assert.That(avlTree.Root.Parent, Is.EqualTo(null));

                Assert.That(avlTree.Root.Left.Key, Is.EqualTo(1));
                Assert.That(avlTree.Root.Left.Parent, Is.EqualTo(avlTree.Root));

                Assert.That(avlTree.Root.Right.Key, Is.EqualTo(3));
                Assert.That(avlTree.Root.Right.Parent, Is.EqualTo(avlTree.Root));
            });
        }
    }
}
