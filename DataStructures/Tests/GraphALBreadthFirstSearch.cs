using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using Algorithms.Algorithms.Graph;
using Algorithms.Algorithms.Graph.Alternatives;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class GraphALBreadthFirstSearch
    {
        private GraphAdjacencyList<int?> _graph;
        private Dictionary<int, BfsVertexInfo<int>> _bfsInfo;

        [SetUp]
        protected void SetUp()
        {
            _graph = new GraphAdjacencyList<int?>(GraphType.Directed);

            _graph.AddEdges(0, new List<int?>() { 1 });
            _graph.AddEdges(1, new List<int?>() { 0, 4, 5 });
            _graph.AddEdges(2, new List<int?>() { 3, 4, 5 });
            _graph.AddEdges(3, new List<int?>() { 2, 6 });
            _graph.AddEdges(4, new List<int?>() { 1, 2 });
            _graph.AddEdges(5, new List<int?>() { 1, 2, 6 });
            _graph.AddEdges(6, new List<int?>() { 3, 5 });
            _graph.AddEdges(7, new List<int?>());
        }

        [Test]
        public void ValidateBfsInfo()
        {
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

            var _bfsInfo = _graph.BFS(3);

            foreach (KeyValuePair<int?, BfsVertexInfo<int?>> pair in _bfsInfo)
            {
                
                Assert.AreEqual(_bfsInfo[pair.Key].Distance, compareData[(int)pair.Key].Distance);
                Assert.AreEqual(_bfsInfo[pair.Key].Predecessor, compareData[(int)pair.Key].Predecessor);
            }
        }
    }
}
