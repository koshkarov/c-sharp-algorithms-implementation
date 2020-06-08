using System;
using Algorithms.Sort.Enums;

namespace Algorithms.Sort
{
    /// <summary>
    /// Merge sort (top-down) is a general-purpose, comparison-based sorting algorithm.
    ///
    /// Stable: true
    /// 
    /// Time complexity:
    /// Best: Ω(n log(n))
    /// Average: Θ(n log(n))
    /// Worst: O(n log(n))
    ///
    /// Space Complexity:
    /// Worst: O(n)
    /// </summary>
    public static class MergeSort {

        public static void Sort<T>(T[] a, MergeSortType type = MergeSortType.TopDown) where T : IComparable<T>
        {
            var aux = new T[a.Length];
            if (type == MergeSortType.TopDown)
                SortTopDown(a, aux);
            else
                SortBottomUp(a, aux);
        }

        private static void SortTopDown<T>(T[] a, T[] aux) where T : IComparable<T>
        {
            Sort(a, aux, 0, a.Length - 1);
        }

        private static void SortBottomUp<T>(T[] a, T[] aux) where T : IComparable<T>
        {
            var len = a.Length;
            for (int sz = 1; sz < len; sz = sz + sz)
            {
                for (int lo = 0; lo < len - sz; lo += sz + sz)
                {
                    Merge(a, aux, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, len - 1));
                }
            }
        }

        private static void Sort<T>(T[] a, T[] aux, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        private static void Merge<T>(T[] a, T[] aux, int lo, int mid, int hi) where T : IComparable<T>
        {
            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (aux[j].CompareTo(aux[i]) < 0)
                    a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }
    }
}