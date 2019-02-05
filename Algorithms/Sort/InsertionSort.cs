using System;

namespace Algorithms.Sort
{
    /// <summary>
    /// Insertion sort is a simple sorting algorithm: a comparison sort in which the
    /// sorted array(or list) is built one entry at a time.
    ///
    /// Stable: yes
    /// Cost model: compares
    ///
    /// Worst: O(n^2)
    /// Best: Ω(n)
    /// Average: Θ(n^2)
    ///
    /// Cost model: space
    /// Worst: O(n) total, O(1) auxiliary
    /// </summary>
    public class InsertionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && arr[j].CompareTo(arr[j-1]) < 0; j--)
                {
                    (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                }
            }
        }
    }
}