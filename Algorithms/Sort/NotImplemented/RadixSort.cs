using System;

namespace Algorithms.Sort
{
    public class RadixSort
    {

        public enum RadixSortType
        {
            Lsd,
            Msd
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="type">Type of the radix sort. </param>
        /// <returns></returns>
        public static T[] Sort<T>(T[] arr, RadixSortType type) where T : IComparable<T>
        {
            // TODO
            throw new NotImplementedException();
        }

    }
}