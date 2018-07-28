using System;
using Algorithms.Algorithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //// ### Binary Search Tree

            //TreeNode root = new TreeNode(5);
            //root.right = new TreeNode(6);
            //root.right.right = new TreeNode(7);

            //root.left = new TreeNode(3);
            //root.left.left = new TreeNode(2);
            //root.left.right = new TreeNode(4);

            //Console.WriteLine(BinaryTreeSolution.FindTarget(root, 9).ToString());

            // ### Queueue

            //var queueue = new Queueue<int>();

            //queueue.Enqueue(1);
            //Console.WriteLine(queueue.ToString());
            //queueue.Enqueue(2);
            //Console.WriteLine(queueue.ToString());
            //queueue.Enqueue(3);
            //Console.WriteLine(queueue.ToString());

            //Console.WriteLine(queueue.Dequeue());
            //Console.WriteLine(queueue.Dequeue());
            //Console.WriteLine(queueue.Dequeue());


            ////### Stack (LinkedList)
            //Console.WriteLine("Starting stack: ");
            //var stackL = new Stack_LinkedList<int>();
            //stackL.Push(5);
            //Console.WriteLine(stackL.ToString());
            //stackL.Push(6);
            //Console.WriteLine(stackL.ToString());

            //Console.WriteLine(stackL.Pop().ToString());
            //Console.WriteLine(stackL.Pop().ToString());

            //### Stack (Array)
            //Console.WriteLine("Starting stack: ");
            //var stackA = new Stack_Array<int>();
            //stackA.Push(5);
            //Console.WriteLine(stackA.ToString());
            //stackA.Push(6);
            //Console.WriteLine(stackA.ToString());
            //Console.WriteLine(stackA.Pop().ToString());
            //Console.WriteLine(stackA.Pop().ToString());
            //stackA.Push(2);
            //stackA.Push(3);
            //Console.WriteLine(stackA.ToString());

            //Console.WriteLine("Hello!");
            //int MAX_SIZE = 1000;
            //var hashTable = new HashTable<string, string>(MAX_SIZE);

            //for (int i = 0; i < MAX_SIZE + 1000; i++)
            //{
            //    hashTable[$"key_{i}"] = $"value_{i}";
            //    //Console.WriteLine($"Added key_{i} = value_{i}");
            //}

            //for (int i = MAX_SIZE + 1000 - 1; i < 0; i--)
            //{
            //    Console.Write($"Received by key_{i} = ");
            //    var result = hashTable[$"key_{i}"];
            //    Console.Write($"{result}");
            //}

            // Is BST?

            // ### Binary Search Tree

            //// Valid BST
            //BinaryTreeNode<int> validBst = new BinaryTreeNode<int>(3);
            //validBst.Right = new BinaryTreeNode<int>(4);
            //validBst.Right.Right = new BinaryTreeNode<int>(6);
            //validBst.Right.Left = new BinaryTreeNode<int>(5);
            //validBst.Left = new BinaryTreeNode<int>(2);
            //validBst.Left.Left = new BinaryTreeNode<int>(1);

            //BinaryTreeNode<int> invalidBst = new BinaryTreeNode<int>(5);
            //invalidBst.Right = new BinaryTreeNode<int>(5);
            //invalidBst.Right.Right = new BinaryTreeNode<int>(1);
            //invalidBst.Right.Left = new BinaryTreeNode<int>(6);
            //invalidBst.Left = new BinaryTreeNode<int>(2);
            //invalidBst.Left.Left = new BinaryTreeNode<int>(1);

            ////Console.WriteLine(BinaryTreeSolution.IsBinarySearchTree(validBst));
            ////Console.WriteLine(BinaryTreeSolution.IsBinarySearchTree(invalidBst));


            BinaryTree bstValid = new BinaryTree();
            bstValid.Root = new BinaryTreeNode<int>(4);
            bstValid.Root.Left = new BinaryTreeNode<int>(2);
            bstValid.Root.Left.Left = new BinaryTreeNode<int>(1);
            bstValid.Root.Left.Right = new BinaryTreeNode<int>(3);
            bstValid.Root.Right = new BinaryTreeNode<int>(6);
            bstValid.Root.Right.Right = new BinaryTreeNode<int>(7);
            bstValid.Root.Right.Left = new BinaryTreeNode<int>(5);

            var list = bstValid.TraverseInOrder();
            foreach (var item in list)
            {
                Console.WriteLine(item + " ");
            }

            Console.WriteLine(bstValid.IsBinarySearchTreeTraversal().ToString());
            Console.WriteLine(bstValid.IsBinarySearchTree().ToString());
        }
    }
}
