using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class RandomizedIntArray
    {
        private int[] Items;

        public RandomizedIntArray(int size = 0, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            this.Items = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                Items[i] = rand.Next(minValue, maxValue);
            }
        }

        public RandomizedIntArray(int size)
        {
            this.Items = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                Items[i] = rand.Next();
            }
        }

        public void ToAbsValues()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = Math.Abs(Items[i]);
            }
        }

        public int GetSize()
        {
            return Items.Length;
        }

        public string GetArrayAsString()
        {
            string retVal = "{ ";
            foreach (int item in Items)
            {
                retVal += item + " ";
            }

            return retVal += "}";
        }

        public int GetMaxValue()
        {
            int retVal = Items[0];
            for (int i = 1; i < Items.Length; i++)
            {
                if (Items[i] > retVal)
                {
                    retVal = Items[i];
                }
            }

            return retVal;
        }

        public int GetMinValue()
        {
            int retVal = Items[0];
            for (int i = 1; i < Items.Length; i++)
            {
                if (Items[i] < retVal)
                {
                    retVal = Items[i];
                }
            }

            return retVal;
        }

        public bool IsOrdered()
        {
            for (int i = 1; i < Items.Length; i++)
            {
                if (Items[i - 1] > Items[i])
                {
                    return false;
                }
            }

            return true;
        }

        public int[] GetArrayItems()
        {
            return Items;
        }

        /**
         * SORTING ALGORITHMS
         * 
         * */

        /**
         * Insertion Sort
         * O(n^2) average run time
         **/
        public void InsertionSort()
        {
            for (int i = 1; i < Items.Length; i++)
            {
                int key = Items[i];
                int j = i - 1;
                while (j >= 0 && Items[j] > key)
                {
                    Items[j + 1] = Items[j];
                    j--;
                }

                Items[j + 1] = key;
            }
        }

        public void MergeSort()
        {
            _MergeSort(Items, 0, Items.Length - 1);
        }

        private void _MergeSort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2; // This gets rounded down if the sum is odd
                _MergeSort(A, p, q);
                _MergeSort(A, (q + 1), r);

                _Merge(A, p, q, r);
            }
        }

        private void _Merge(int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] L = new int[n1+1];
            int[] R = new int[n2+1];

            for (int it =0; it < n1; it++)
            {
                L[it] = A[p + it];
            }
            for (int it = 0; it < n2; it++)
            {
                R[it] = A[q + 1 + it];
            }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;

            int i = 0;
            int j = 0;
            for (int k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i++];
                }
                else
                {
                    A[k] = R[j++];
                }
            }
        }

        public void BubbleSort()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                for (int j = Items.Length-1; j > i; j--)
                {
                    if (Items[j] < Items[j - 1])
                    {
                        int temp = Items[j];
                        Items[j] = Items[j - 1];
                        Items[j-1] = temp;
                    }
                }
            }
        }

        public void QuickSort()
        {
            _Quicksort(Items, 0, Items.Length - 1);
        }

        private void _Quicksort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = _Partition(A, p, r);
                _Quicksort(A, p, q - 1);
                _Quicksort(A, q + 1, r);
            }
        }

        private int _Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = -1;

            for (int j = 0; j < r; j++)
            {
                if (A[j] <= x)
                {
                    _Swap<int>(ref A[++i], ref A[j]);
                }
            }
            _Swap<int>(ref A[i+1], ref A[r]);

            return i + 1;
        }

        private static void _Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        /*
         * Given an array of ints representing building heights, return back
         * the amount of water (sq. ft) that would be trapped between them. Assume
         * a distance of 1 between buildings.
         * Ex: Input = { 2, 0, 2 }, or |_|
         *     Output = 2, since that is the sq. ft. of water that would be trapped between these
         *     
         * Sol'n:
         * We will only 'trap' water if it is a local minima (ie, it is the lowest point between two
         * maxima.) The amount of water that is trappped for a current index value is the height
         * of the lower maxima - the height of the index. So long as we keep values of these 
         * left and right maxima, we should be able to work both ends of the array, recording the
         * total rainfall trapped, and stop when we cross index values. We need to make sure that our
         * local maxima values are correct, and only updte the rainfall total when the current index
         * value is less than each of the maxima.
         */
        private static int GetTrappedRainFall(int[] heights)
        {
            // Initialize the return value
            int retVal = 0;

            // indecies of the array to work from both ends
            int low = 0;
            int high = heights.Length - 1;

            // heights of the maxima, initialized to 0. These will be reset
            int LMax = 0;
            int RMax = 0;

            while (low < high)
            {
                if (heights[low] < heights[high])
                {
                    if (heights[low] > LMax)
                    {
                        LMax = heights[low];
                    }
                    else
                    {
                        retVal += LMax - heights[low];
                    }
                    low++;
                }
                else
                {
                    if (heights[high] > RMax)
                    {
                        RMax = heights[high];
                    }
                    else
                    {
                        retVal += RMax - heights[high];
                    }
                    high--;
                }
            }
            return retVal;
        }
    }
}
