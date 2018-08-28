using System;
using System.Linq;

namespace Algorithms.Sort
{
    /// <summary>
    /// Merge sort is an O(n log n) comparison-based sorting algorithm. Most
    /// implementations produce a stable sort, which means that the implementation
    /// preserves the input order of equal elements in the sorted output.
    ///
    /// Time complexity:
    /// Best: Ω(n log(n))
    /// Average: Θ(n log(n))
    /// Worst: O(n log(n))
    ///
    /// Space Complexity:
    /// Worst: O(n)
    /// </summary>
    public class MergeSort {

        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            int arrLength = arr.Length;

            if (arrLength == 1)
                return arr;

            int middle = arrLength / 2;

            T[] left = arr.Take(middle).ToArray();
            T[] right = arr.Skip(middle).ToArray();

            return Merge(Sort(left), Sort(right));
        }

        private static T[] Merge<T>(T[] a, T[] b) where T : IComparable<T>
        {
            int i = 0;
            int j = 0;

            int aLength = a.Length;
            int bLength = b.Length;

            T[] resultArr = new T[aLength + bLength];

            while (i < aLength || j < bLength)
            {
                if ( j == bLength || (i < aLength  && a[i].CompareTo(b[j]) <= 0))
                {
                    resultArr[i + j] = a[i];
                    i++;
                }
                else
                {
                    resultArr[i + j] = b[j];
                    j++;
                }
            }

            return resultArr;
        }
    }
}