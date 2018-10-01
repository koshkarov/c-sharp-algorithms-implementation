using System;

namespace Algorithms.DataStructures.UnionFind
{
    /// <summary>
    /// Percolation. Given a composite systems comprised of randomly distributed insulating and metallic materials:
    /// what fraction of the materials need to be metallic so that the composite system is an electrical conductor?
    /// 
    /// The model. We model a percolation system using an n-by-n grid of sites. Each site is either open or blocked.
    /// A full site is an open site that can be connected to an open site in the top row via a chain of neighboring (left, right, up, down) open sites.
    /// We say the system percolates if there is a full site in the bottom row.
    /// In other words, a system percolates if we fill all open sites connected to the top row and that process fills some open site on the bottom row.
    /// (For the insulating/metallic materials example, the open sites correspond to metallic materials,
    /// so that a system that percolates has a metallic path from top to bottom, with full sites conducting.)
    /// </summary>
    public class Percolation
    {
        private int[,] _grid;
        private readonly int _gridSize;
        private UnionFindQuickUnionWeightedSize _unionFind;

        private readonly int _vUpper;
        private readonly int _vLower;
        private int _openSites;

        private enum SiteState
        {
            Open = 1
        };

        public Percolation(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException($"Matrix can't be a size of {n}");

            _gridSize = n;
            _grid = new int[n,n]; // by default all sites are marked as 0 (blocked)

            // Create sites (+ 2 virtual sites
            var x = n * n + 2;
            _unionFind = new UnionFindQuickUnionWeightedSize(n * n + 2);
            _vUpper = n * n;
            _vLower = n * n + 1;
        }

        /// <summary>
        /// Open a site with the specified matrix indices. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Open(int row, int col)
        {
            // Validate indices
            Validate(row, col);

            // Verify if is not open already
            if (IsOpen(row , col)) return;

            // Open site 
            _grid[row - 1, col - 1] = (int)SiteState.Open;
            _openSites++;

            // Connect to virtual sites if eligible (first or last row in grid)
            if (row == 1)
                _unionFind.Union(_vUpper, GetOneDimensionIndex(row, col));
            else if (row == _gridSize)
                _unionFind.Union(_vLower, GetOneDimensionIndex(row, col));

            // Find open neighbours and link them to the opened site
            if (col != 1 && IsOpen(row, col - 1))
            {
                _unionFind.Union(GetOneDimensionIndex(row, col), GetOneDimensionIndex(row, col - 1));
            }
            // upper
            if (row != 1 && IsOpen(row - 1, col))
            {
                _unionFind.Union(GetOneDimensionIndex(row, col), GetOneDimensionIndex(row - 1, col));
            }
            // right
            if (col != _gridSize && IsOpen(row, col + 1))
            {
                _unionFind.Union(GetOneDimensionIndex(row, col), GetOneDimensionIndex(row, col + 1));
            }
            // lower
            if (row != _gridSize && IsOpen(row + 1, col))
            {
                _unionFind.Union(GetOneDimensionIndex(row, col), GetOneDimensionIndex(row + 1, col));
            }
        }

        /// <summary>
        /// Returns a boolean value if the site is open.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsOpen(int row, int col)
        {
            Validate(row, col);
            return _grid[row - 1, col - 1] == (int)SiteState.Open;
        }

        /// <summary>
        /// Returns a boolean value if the site is full.
        /// A full site is an open site that can be connected to an open site in the top row
        /// via a chain of neighboring (left, right, up, down) open sites.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsFull(int row, int col)
        {
            Validate(row, col);
            return _unionFind.Connected(_vUpper, GetOneDimensionIndex(row, col));
        }

        /// <summary>
        /// Returns a number of open sites.
        /// </summary>
        /// <returns></returns>
        public int NumberOfOpenSites() => _openSites;

        /// <summary>
        /// Returns boolean value if the n-by-n grid of sites percolates.
        /// </summary>
        /// <returns></returns>
        public bool Percolates() => _unionFind.Connected(_vUpper, _vLower);

        /// <summary>
        /// Performs validation of the matrix indices.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void Validate(int row, int col)
        {
            if (row < 1 || row > _gridSize || col < 1 || col > _gridSize)
                throw new IndexOutOfRangeException($"Row {row} or column {col} index is out of range.");
        }

        /// <summary>
        /// Converts the matrix indices to a one-dimensional array index. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private int GetOneDimensionIndex(int row, int col)
        {
            return (row - 1)  * _gridSize + (col - 1);
        }
    }
}
