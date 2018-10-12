namespace Algorithms.ControlWork
{
    public class Binary
    {
        public static int Search(int[] a, int x)
        {
            if (a.Length == 0 || x < a[0] || x > a[a.Length - 1])
                return -1;

            int first = 0;
            int last = a.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (x <= a[mid])
                    last = mid;
                else
                    first = mid + 1;
            }

            if (a[last] == x)
                return last;
            return -1;
        }
    }
}