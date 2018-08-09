using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sort
{
    public class MergeSort {

        public static List<int> Sort(List<int> unsorted)
        {
            if (unsorted.Count == 1)
                return unsorted;

            var left = new List<int>();
            var right = new List<int>();

            int middle = unsorted.Count / 2;
            left.AddRange(unsorted.Take(middle));
            right.AddRange(unsorted.Skip(middle).Take((unsorted.Count - middle)));

            return Merge(Sort(left), Sort(right));
        }

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