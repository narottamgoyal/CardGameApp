using System;
using System.Collections.Generic;

namespace CardGameApp
{
    /// <summary>
    /// Util methods
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Shuffle via Fisher Yates Algo
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void ShuffleByFisherYatesAlgo<T>(List<T> items)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var randNumber = new Random().Next(0, i);
                var temp = items[i];
                items[i] = items[randNumber];
                items[randNumber] = temp;
            }
        }
    }
}
