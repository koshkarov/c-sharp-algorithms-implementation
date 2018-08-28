using System;

namespace Algorithms.Sort
{
    public class QuickSort
    {
        private static readonly Random Random = new Random();

        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void Sort<T>(T[] arr, int start, int finish) where T : IComparable<T>
        {
            int s = start;
            int f = finish;
            T pivot = arr[start + Random.Next(finish - start)];

            while (s <= f)
            {
                while (arr[s].CompareTo(pivot) < 0)
                    s++;
                while (arr[f].CompareTo(pivot) > 0)
                    f--;
                if (s <= f)
                {
                    (arr[s], arr[f]) = (arr[f], arr[s]);
                    s++;
                    f--;
                }
            }
            if (start < f)
            {
                Sort(arr, start, f);
            }
            if (s < finish)
            {
                Sort(arr, s, finish);
            }
        }

    }
}