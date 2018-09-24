using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class MaxHeap
    {
        private int[] Items;
        private int Length;

        public MaxHeap(int size)
        {
            this.Items = new int[size];
            this.Length = 0;
        }

        public MaxHeap(int[] A)
        {
            int[] items = new int[A.Length];
            for (int i =0; i < A.Length; i++)
            {
                items[i] = A[i];
            }
            BuildMaxHeap(ref items, items.Length);

            this.Items = items;
            this.Length = items.Length;
        }

        public int GetMaxHeapSize()
        {
            return Items.Length;
        }

        public int GetLength()
        {
            return Length;
        }

        public int[] GetItems()
        {
            return Items;
        }

        public void Insert(int value)
        {
            Items[Length++] = int.MinValue;
            _IncreaseKey(ref Items, Length-1, value);
        }

        public int ExtractMax()
        {
            if (Length <= 0)
            {
                // Underflow case ... throw error?
                throw new Exception("Heap underflow!");
            }
            int max = Items[0];
            Items[0] = Items[--Length];
            _MaxHeapify(ref Items, 0, Length);

            return max;
        }

        public string GetArrayAsString()
        {
            string retVal = "[ ";
            foreach (int k in Items)
            {
                retVal += k + " ";
            }
            return retVal += "]";
        }

        public bool IsHeap()
        {
            return IsHeap(Items, Length);
        }

        #region Public Static Methods
        public static void BuildMaxHeap(ref int[] A, int heapSize)
        {
            for (int i = ((heapSize - 1) / 2); i >= 0; i--)
            {
                _MaxHeapify(ref A, i, heapSize);
            }
        }

        public static string GetArrayAsString(int[] A)
        {
            string retVal = "[ ";
            foreach (int k in A)
            {
                retVal += k + " ";
            }
            return retVal += "]";
        }

        public static int[] HeapSort(int[] A)
        {
            int[] retVal = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                retVal[i] = A[i];
            }

            int heapSize = A.Length;
            MaxHeap.BuildMaxHeap(ref retVal, heapSize);
            for (int i = heapSize - 1; i > 0; i--)
            {
                _Swap<int>(ref retVal[0], ref retVal[i]);
                heapSize--;
                _MaxHeapify(ref retVal, 0, heapSize);
            }

            return retVal;
        }

        public static bool IsHeap(int[] A, int heapSize)
        {
            for (int i = heapSize-1; i > 0; i--)
            {
                if (A[_Parent(i)] < A[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsHeap(int[] A)
        {
            return IsHeap(A, A.Length);
        }
        #endregion

        #region Private:
        private static int _Parent(int i) { return (i - 1) / 2; }
        private static int _Left(int i) { return (2 * i) + 1; }
        private static int _Right(int i) { return (2 * i) + 2; }

        private static void _Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        private static void _MaxHeapify(ref int[] A, int i, int heapSize)
        {
            int l = _Left(i);
            int r = _Right(i);
            int largest = i;

            if (l < heapSize && A[l] > A[largest])
            {
                largest = l;
            }
            if (r < heapSize && A[r] > A[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                _Swap<int>(ref A[i], ref A[largest]);
                _MaxHeapify(ref A, largest, heapSize);
            }
        }

        private static void _IncreaseKey(ref int[] A, int i, int key)
        {
            if (key < A[i])
            {
                throw new Exception("new key is smaller than current key!");
            }
            A[i] = key;
            while (i > 0 && A[_Parent(i)] < A[i])
            {
                _Swap<int>(ref A[i], ref A[_Parent(i)]);
                i = _Parent(i);
            }
        }
        #endregion
    }
}
