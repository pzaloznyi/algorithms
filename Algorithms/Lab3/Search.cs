using System;

namespace Algorithms.Lab3
{
    public class Interpolation
    {
        public static int Search<T>(T[] array, Func<T, int> field, int key)
        {
            int mid;
            int low = 0;
            int high = array.Length - 1;

            while (field(array[low]) < key && field(array[high]) > key)
            {
                mid = low + (key - field(array[low])) * (high - low) / (field(array[high]) - field(array[low]));

                if (field(array[mid]) < key)
                    low = mid + 1;
                else if (field(array[mid]) > key)
                    high = mid - 1;
                else
                    return mid;
            }

            if (field(array[low]) == key)
                return low;
            if (field(array[high]) == key)
                return high;
            return -1;
        }
    }
}