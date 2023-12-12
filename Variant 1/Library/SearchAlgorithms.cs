using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class SearchAlgorithms
    {
        public const int NOTFOUND = -1;
        public static int LinearSearch<T>(T[] array, in T element) where T : IComparable
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(element) == 0)
                    return i;
            }
            return NOTFOUND;
        }
    }
}
