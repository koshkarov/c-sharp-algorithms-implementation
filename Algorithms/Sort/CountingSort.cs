namespace Algorithms.Sort
{
    /// <summary>
    /// Counting sort is an algorithm for sorting a collection of objects according
    /// to keys that are small integers; that is, it is an integer sorting algorithm.
    /// It operates by counting the number of objects that have each distinct key
    /// value, and using arithmetic on those counts to determine the positions of
    /// each key value in the output sequence.
    ///
    /// Time Complexity
    /// Best: Ω(n+k)
    /// Average: Θ(n+k)
    /// Worst: O(n+k)
    ///
    /// Space Complexity
    /// Worst: O(k)
    /// </summary>
    public class CountingSort
    {

        public static int[] Sort(int[] unsorted)
        {
            int[] counts = new int[GetMaxValue(unsorted) + 1];
            int[] sorted = new int[unsorted.Length];

            CountElementOccurrences(unsorted, counts);
            CountElementsBelowCurrent(counts);
            SortArray(unsorted, counts, sorted);

            return sorted;
        }

        public static void SortArray(int[] unsorted, int[] counts, int[] sorted)
        {
            for (int i = unsorted.Length - 1; i >= 0; i--)
            {
                sorted[counts[unsorted[i]] - 1] = unsorted[i];
                counts[unsorted[i]]++;
            }
        }

        public static void CountElementsBelowCurrent(int[] c)
        {
            for (int i = 1; i < c.Length; i++)
            {
                c[i] = c[i] + c[i - 1];
            }
        }

        public static void CountElementOccurrences(int[] a, int[] c)
        {
            foreach (var i in a)
            {
                c[i]++;
            }
        }

        public static int GetMaxValue(int[] arr)
        {
            int max = 0;
            foreach (var i in arr)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}