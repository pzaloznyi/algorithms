using System.Collections.Generic;

namespace Algorithms.Lab2
{
    public class Bubble
    {
        public T[] Sort<T>(T[] array, IComparer<T> comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) < 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        private void Swap<T>(ref T first, ref T second)
        {
            var tmpStudent = first;
            first = second;
            second = tmpStudent;
        }
    }
}