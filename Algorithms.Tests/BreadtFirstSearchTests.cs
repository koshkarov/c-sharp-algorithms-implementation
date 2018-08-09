using Algorithms.Graph;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class BreadtFirstSearchTests
    {
        private int[][] _graph;
        private BfsVertexInfo<int?>[] _bfsInfo;

        [SetUp]
        protected void SetUp()
        {
            _graph = new int[][]
            {
                new int[] {1},
                new int[] {0, 4, 5},
                new int[] {3, 4, 5},
                new int[] {2, 6},
                new int[] {1, 2},
                new int[] {1, 2, 6},
                new int[] {3, 5},
                new int[] {}
            };
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

            _bfsInfo = BFS.DoBfs(_graph, 3);

            for (int i = 0; i < _bfsInfo.Length; i++)
            {
                Assert.AreEqual(_bfsInfo[i].Distance, compareData[i].Distance);
                Assert.AreEqual(_bfsInfo[i].Predecessor, compareData[i].Predecessor);
            }
        }
    }
}
