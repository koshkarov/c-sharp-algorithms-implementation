using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    /// <summary>
    /// Insertion sort is a simple sorting algorithm: a comparison sort in which the
    /// sorted array(or list) is built one entry at a time. It is much less
    /// efficient on large lists than more advanced algorithms such as quicksort,
    /// heapsort, or merge sort.
    /// </summary>
    public class InsertionSort
    {
        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            // Consider the first element of the array is sorted already
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    j--;
                }
            }
            return arr;
        }
    }
}