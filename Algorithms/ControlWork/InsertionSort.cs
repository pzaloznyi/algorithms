namespace Algorithms.ControlWork
{
    public class Insertion
    {
        public static int[] Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i;
                while (j > 0 && current < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = current;
            }

            return array;
        }
    }
}