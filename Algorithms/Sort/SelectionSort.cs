using System;

namespace Algorithms.Sort
{
    /// <summary>
    /// Selection sort is a sorting algorithm, specifically an in-place comparison sort.
    /// It has O(n2) time complexity, making it inefficient on large lists,
    /// and generally performs worse than the similar insertion sort.
    /// 
    /// Stable: false
    ///
    /// Cost model: compares
    ///
    /// Worst: О(n^2)
    /// Best: Ω(n^2)
    /// Average: Θ(n^2
    ///
    /// Cost model: space
    /// Worst: O(1) auxiliary
    /// 
    /// </summary>
    public static class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                int min = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }

    }
}