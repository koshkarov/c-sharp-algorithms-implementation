using System;

namespace Algorithms.Sort
{
    /// <summary>
    /// Insertion sort is a simple sorting algorithm: a comparison sort in which the
    /// sorted array(or list) is built one entry at a time.
    ///
    /// Stable: yes
    /// 
    /// Time complexity:
    /// Best: Ω(n)
    /// Average: Θ(n^2)
    /// Worst: O(n^2)
    ///
    /// Space Complexity:
    /// Worst: O(1)
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