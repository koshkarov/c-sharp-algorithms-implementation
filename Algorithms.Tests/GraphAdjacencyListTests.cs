using Algorithms.DataStructures.Graph;
using Algorithms.DataStructures.Graph.AdjacencyList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms.Tests
{
    [TestFixture]
    class GraphAdjacencyListTests
    {
        private GraphAdjacencyList<char> _graphUndirectedChars;

        [SetUp]
        protected void SetUp()
        {
            _graphUndirectedChars = new GraphAdjacencyList<char>(GraphType.Undirected);
            _graphUndirectedChars.AddEdge('a', 'b');
            _graphUndirectedChars.AddEdge('a', 'd');
            _graphUndirectedChars.AddEdge('a', 'c');
            _graphUndirectedChars.AddEdge('b', 'c');
            _graphUndirectedChars.AddEdge('b', 'd');

        }

        [Test]
        public void VerifyBreadthFirstSearch()
        {

            var graphDirectedInts = new GraphAdjacencyList<int?>(GraphType.Directed);

            graphDirectedInts.AddEdges(0, new HashSet<int?>() { 1 });
            graphDirectedInts.AddEdges(1, new HashSet<int?>() { 0, 4, 5 });
            graphDirectedInts.AddEdges(2, new HashSet<int?>() { 3, 4, 5 });
            graphDirectedInts.AddEdges(3, new HashSet<int?>() { 2, 6 });
            graphDirectedInts.AddEdges(4, new HashSet<int?>() { 1, 2 });
            graphDirectedInts.AddEdges(5, new HashSet<int?>() { 1, 2, 6 });
            graphDirectedInts.AddEdges(6, new HashSet<int?>() { 3, 5 });
            graphDirectedInts.AddEdges(7, new HashSet<int?>());

            BfsVertexInfo<int?>[] compareData = new[]
            {
                new BfsVertexInfo<int?>() {Distance = 4, Predecessor = 1},
                new BfsVertexInfo<int?>() {Distance = 3, Predecessor = 4},
                new BfsVertexInfo<int?>() {Distance = 1, Predecessor = 3},
                new BfsVertexInfo<int?>() {Distance = 0, Predecessor = null},
                new BfsVertexInfo<int?>() {Distance = 2, Predecessor = 2},
                new BfsVertexInfo<int?>() {Distance = 2, Predecessor = 2},
                new BfsVertexInfo<int?>() {Distance = 1, Predecessor = 3},
                new BfsVertexInfo<int?>() {Distance = null, Predecessor = null}
            };

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 3)");

            var path = new List<int?>();

            var _bfsInfo = graphDirectedInts.BreadthFirstSearch(3, v => path.Add(v));

            Console.WriteLine(string.Join(", ", path));

            foreach (KeyValuePair<int?, BfsVertexInfo<int?>> pair in _bfsInfo)
            {
                Assert.AreEqual(_bfsInfo[pair.Key].Distance, compareData[(int)pair.Key].Distance);
                Assert.AreEqual(_bfsInfo[pair.Key].Predecessor, compareData[(int)pair.Key].Predecessor);
            }
        }

        [Test]
        public void VerifyDepthFirstSearch()
        {
           
        }

        [Test]
        public void PrintAllRoutes()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save current out
                TextWriter currentOut = Console.Out;

                // Set a new out
                Console.SetOut(sw);

                _graphUndirectedChars.PrintAllPaths('c', 'd');

                string expected = "c a b d " + "\r\n" + "c a d " + "\r\n" + "c b a d " + "\r\n" + "c b d " + "\r\n";
                Assert.AreEqual(expected, sw.ToString());
                sw.Close();
                Console.SetOut(currentOut);
            }
            
        }
    }
}
