using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures.UnionFind
{
    /// <summary>
    /// This class estimates the value of the percolation threshold via Monte Carlo simulation.
    ///
    /// Problem: if sites are independently set to be open with probability p (and therefore blocked with probability 1 − p),
    /// what is the probability that the system percolates?
    /// When p equals 0, the system does not percolate; when p equals 1, the system percolates.
    ///
    /// When n is sufficiently large, there is a threshold value <![CDATA[p*]]> such that when <![CDATA[p < p*]]> a random n-by-n grid almost never percolates,
    /// and when p > p*, a random n-by-n grid almost always percolates.
    ///
    /// No mathematical solution for determining the percolation threshold p* has yet been derived.
    /// This class estimates p*.
    /// </summary>
    public class PercolationStats
    {
        private readonly Random _random = new Random();

        private int GetRandom => _random.Next(1, _size + 1);

        private readonly int _size;
        private readonly List<double> _trialsResults = new List<double>();
        private double _z = 0.1960; // 95% confidence interval value

        /// <summary>
        /// Perform trials independent experiments on an n-by-n matrix.
        /// </summary>
        /// <param name="matrixSize">The size of matrix to use in simulation</param>
        /// <param name="trials">Number of trials to perform in simulation.</param>
        public PercolationStats(int matrixSize, int trials)
        {
            
            if (matrixSize <= 0 || trials <= 0)
                throw new IndexOutOfRangeException();

            _size = matrixSize;

            int trial = 0;
            while (trial < trials)
            {
                bool percolates = false;
                Percolation percolation = new Percolation(matrixSize);

                int openSites = 0;
                while (!percolates)
                {
                    int randomRow = GetRandom;
                    int randomCol = GetRandom;

                    if (percolation.IsOpen(randomRow, randomCol)) continue;
                    percolation.Open(randomRow, randomCol);
                    openSites++;

                    if (percolation.Percolates())
                    {
                        percolates = true;
                        _trialsResults.Add((double)openSites / (double)(_size * _size));
                        break;
                    }
                }
                trial++;
            }
            
            Console.WriteLine($"mean                    = {Mean()}");
            Console.WriteLine($"stddev                  = {StdDev()}");
            Console.WriteLine($"95% confidence interval = [{ConfidenceLo()}, {ConfidenceHi()}]");
        }

        /// <summary>
        /// Sample mean of percolation threshold.
        /// </summary>
        /// <returns></returns>
        public double Mean()
        {
            return _trialsResults.Sum() / _trialsResults.Count;
        }

        /// <summary>
        /// Sample standard deviation of percolation threshold.
        /// </summary>
        /// <returns></returns>
        public double StdDev()
        {
            int count = _trialsResults.Count;
            double mean = Mean();
            double stdDev = 0;

            if (count > 1)
            {
                double variance = _trialsResults.Sum(d => Math.Pow(d - mean, 2)) / (_trialsResults.Count - 1);
                stdDev = Math.Sqrt(variance);
            }

            return stdDev;
        }

        /// <summary>
        /// Returns low endpoint of 95% confidence interval
        /// </summary>
        /// <returns></returns>
        public double ConfidenceLo()
        {
            return Mean() -_z * (StdDev() / Math.Sqrt(_trialsResults.Count));
        }

        /// <summary>
        /// Return high endpoint of 95% confidence interval
        /// </summary>
        /// <returns></returns>
        public double ConfidenceHi()
        {
            return Mean() + _z * (StdDev() / Math.Sqrt(_trialsResults.Count));
        }
    }
}
