using System;

namespace Algorithms.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// The following implementation uses the Fisher-Yates algorithm.
        /// Link: https://stackoverflow.com/a/110570/4697525
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array to be shuffled</param>
        public static void Shuffle<T>(this T[] array)
        {
            var random = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = random.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
