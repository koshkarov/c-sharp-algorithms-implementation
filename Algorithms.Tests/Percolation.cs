using Algorithms.DataStructures.UnionFind;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    class PercolationTests
    {
        private Percolation percolation3;
        private Percolation percolation6;
        private PercolationStats perStats;

        [SetUp]
        protected void SetUp()
        {
            percolation3 = new Percolation(3);
            percolation6 = new Percolation(6);
            
        }

        [Test]
        public void VerifyPercolationWith3By3Matrix()
        {
            percolation3.Open(1, 2);
            Assert.AreEqual(false, percolation3.Percolates());
            percolation3.Open(2, 2);
            Assert.AreEqual(false, percolation3.Percolates());
            percolation3.Open(3, 1);
            Assert.AreEqual(false, percolation3.Percolates());
            percolation3.Open(2, 1);
            Assert.AreEqual(true, percolation3.Percolates());
        }

        [Test]
        public void VerifyPercolationWith6By6Matrix()
        {
            percolation6.Open(1, 1);
            Assert.AreEqual(false, percolation6.Percolates());
            percolation6.Open(2, 1);
            Assert.AreEqual(false, percolation6.Percolates());
            percolation6.Open(3, 1);
            Assert.AreEqual(false, percolation6.Percolates());
            percolation6.Open(4, 1);
            Assert.AreEqual(false, percolation6.Percolates());
            percolation6.Open(5, 1);
            Assert.AreEqual(false, percolation6.Percolates());
            percolation6.Open(6, 1);
            Assert.AreEqual(true, percolation6.Percolates());
        }

        [Test]
        public void VerifyMonteCarloSimulation()
        {
            perStats = new PercolationStats(200, 100);
        }
    }
}
