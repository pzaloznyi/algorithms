using System;

namespace Algorithms.Lab3
{
    public class Interpolation
    {
        public int Search<T>(T[] students, Func<T, int> field, int mark)
        {
            int low = 0;
            int mid = -1;
            int high = students.Length - 1;
            int index = -1;

            while (low <= high)
            {
                var div1 = (field(students[high]) - field(students[low]));
                var div2 = (mark - field(students[low]));
                if (div1 == 0 || div2 == 0)
                {
                    mid = low;
                }
                else
                {
                    mid = (int)(low + (double)(high - low) / div1 * div2);                    
                }

                var fieldMid = field(students[mid]);
                if (fieldMid == mark)
                {
                    index = mid;
                    break;
                }

                if (fieldMid < mark)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return index;
        }
    }
}