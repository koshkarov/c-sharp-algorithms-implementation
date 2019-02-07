using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Extensions
{
    static class RandomExtensions
    {
        /// <summary>
        /// The following implementation uses the Fisher-Yates algorithm.
        /// It runs in O(n) time and shuffles in place, so is better performing than the 'sort by random' technique.
        /// Link: https://stackoverflow.com/a/110570/4697525
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rng"></param>
        /// <param name="array"></param>
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
