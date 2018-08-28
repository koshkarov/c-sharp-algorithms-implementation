using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// The <c>UnionFindQuickFind</c> class represents a "union–find data type"
    /// (also known as the "disjoint-sets data type").
    /// </summary>
    /// /// <remarks>
    /// It supports the "union" and "find" operations,  along with a "connected" operation
    /// for determining whether two sites  are in the same component
    /// and a "count" operation that returns  the total number of components.s
    /// </remarks>
    public class UFQuickFind : IUnionFind
    {
        private int[] _arr;
        private int _count;

        public UFQuickFind(int size)
        {
            _count = size;
            _arr = new int[size];
            for (int i = 0; i < size; i++)
                _arr[i] = i;
        }

        /// <summary>
        /// Adds a connection between the two sites "p" and "q".
        /// If "p" and "q" are in different components,
        /// then it replaces these two components with a
        /// new component that is the union of the two.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            if (Connected(p, q)) return;

            for (int i = 0; i < _arr.Length; i++)
                if (_arr[i] == pId) _arr[i] = qId;
            _count--;
        }

        /// <summary>
        /// Returns the component identifier
        /// of the component containing "p".
        /// </summary>
        public int Find(int p)
        {
            Validate(p);
            return _arr[p];
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
            Validate(p);
            Validate(q);
            return _arr[p] == _arr[q];
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
