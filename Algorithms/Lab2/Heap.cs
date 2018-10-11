using System.Collections.Generic;

namespace Algorithms.Lab2
{
    public class Heap<T>
    {
        public T[] Array { get; }
        private readonly int _heapSize;
        private readonly IComparer<T> _comparer;

        public Heap(T[] array, IComparer<T> comparer)
        {
            Array = array;
            _heapSize = array.Length;
            _comparer = comparer;
        }

        private int left(int i)
        {
            return 2 * i + 1;
        }

        private int right(int i)
        {
            return 2 * i + 2;
        }

        public void Sort()
        {
            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            int i = (Array.Length) / 2;
            while (i >= 0)
            {
                MaxHeapify(i);
                i--;
            }
        }

        private void MaxHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int lagest = i;
            if (l < _heapSize && _comparer.Compare(Array[l], Array[i]) > 0)
                lagest = l;
            if (r < _heapSize && _comparer.Compare(Array[r], Array[lagest]) > 0)
                lagest = r;
            if (lagest != i)
            {
                T temp = Array[i];
                Array[i] = Array[lagest];
                Array[lagest] = temp;

                MaxHeapify(lagest);
            }
        }
    }
}