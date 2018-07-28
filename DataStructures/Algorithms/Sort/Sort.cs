using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Algorithms.Sort
{
    public static class Sort
    {
        /// <summary>
        /// 
        /// Complexity: O(nlog(n))
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        public static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count == 1)
                return unsorted;

            var left = new List<int>();
            var right = new List<int>();

            int middle = unsorted.Count / 2;
            left.AddRange(unsorted.Take(middle));
            right.AddRange(unsorted.Skip(middle).Take((unsorted.Count - middle)));

            return Merge(MergeSort(left), MergeSort(right));
        }

        /// <summary>
        /// 
        /// Complexity: O(n + m)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static List<int> Merge(List<int> a, List<int> b)
        {
            int i = 0;
            int j = 0;

            int n = a.Count;
            int m = b.Count;
            List<int> result = new List<int>();

            while (i < n || j < m)
            {
                if ( j == m || (i < n  && a[i] <= b[j]))
                {
                    result.Add(a[i]);
                    i++;
                }
                else
                {
                    result.Add(b[j]);
                    j++;
                }
            }

            return result;
        }
    }
}
