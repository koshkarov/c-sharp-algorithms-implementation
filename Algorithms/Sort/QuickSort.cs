using System;

namespace Algorithms.Sort
{
    /// <summary>
    /// Quicksort (sometimes called partition-exchange sort) is an O(N log N) efficient sorting algorithm,
    /// serving as a systematic method for placing the elements of an array in order.
    ///
    /// Stable: false
    /// 
    /// Time complexity:
    /// Best: Ω(n log(n))
    /// Average: Θ(n log(n))
    /// Worst: O(n^2)
    ///
    /// Space Complexity:
    /// Worst: O(log(n))
    /// </summary>
    public static class QuickSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo < hi)
            {
                int j = Partition(arr, lo, hi);

                Sort(arr, lo, j - 1);
                Sort(arr, j + 1, hi);
            }
        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            int i = lo;
            int j = hi+1;

            T pivot = arr[lo];

            while (true)
            {
                while (arr[++i].CompareTo(pivot) < 0)
                    if (i == hi)
                        break;
                while (pivot.CompareTo(arr[--j]) < 0)
                    if (j == lo)
                        break;

                if (i >= j)
                    break;

                (arr[i], arr[j]) = (arr[j], arr[i]);
            }

            (arr[lo], arr[j]) = (arr[j], arr[lo]);
            return j;
        }
    }
}