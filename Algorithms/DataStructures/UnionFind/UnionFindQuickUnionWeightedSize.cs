using System;

namespace Algorithms.DataStructures.UnionFind
{
    /// <summary>
    /// The <c>UFQuickUnionWeightedSize</c> class represents a "union–find data type"
    /// (also known as the "disjoint-sets data type").
    /// </summary>
    /// /// <remarks>
    /// It supports the "union" and "find" operations,  along with a "connected" operation
    /// for determining whether two sites  are in the same component
    /// and a "count" operation that returns  the total number of components.s
    /// </remarks>
    public class UnionFindQuickUnionWeightedSize : IUnionFind
    {
        private int[] _arr;
        private int[] _weight;
        private int _count;

        public UnionFindQuickUnionWeightedSize(int size)
        {
            _count = size;
            _arr = new int[size];
            _weight = new int[size];
            for (int i = 0; i < size; i++)
            {
                _arr[i] = i;
                _weight[i] = 0;
            }
        }

        /// <summary>
        /// Merges the component containing site "p" with the 
        /// the component containing site "q".
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (qRoot == pRoot) return;

            if (_weight[pRoot] < _weight[qRoot])
            {
                _arr[pRoot] = qRoot;
                _weight[qRoot] += _weight[pRoot];

            }
            else
            {
                _arr[qRoot] = pRoot;
                _weight[pRoot] += _weight[qRoot];
            }
            _count--;
        }

        /// <summary>
        /// Returns the component identifier
        /// of the component containing "p".
        /// </summary>
        public int Find(int p)
        {
            Validate(p);
            while (p != _arr[p])
            {
                _arr[p] = _arr[_arr[p]]; // Optimization: path compression
                p = _arr[p];
            }
            return p;
        }

        /// <summary>
        /// Returns true if both "p" and "q" are
        /// in the same component, and false otherwise.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// Returns the number of components.
        /// </summary>
        /// <returns></returns>
        public int Count() => _count;

        /// <summary>
        /// Validate that p is a valid index.
        /// </summary>
        /// <param name="p"></param>
        private void Validate(int p)
        {
            int n = _arr.Length;
            if (p < 0 || p >= n)
                throw new ArgumentOutOfRangeException($"Index p equals {p} and is not between 0 and {n-1}");
        }
    }
}
