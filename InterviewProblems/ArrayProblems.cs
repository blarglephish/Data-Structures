using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewProblems
{
    class ArrayProblems
    {
        public static string Substring(string s, int startIndex, int length)
        {
            string retVal = string.Empty;
            char[] charArray = s.ToCharArray();
            for(int i = startIndex; i < startIndex + length; i++)
            {
                retVal += charArray[i];
            }

            return retVal;
        }

        // Given a collection of numbers:
        //    Find a pair of numbers whose sum = a given total
        // EX1: Collection = [1, 2, 3, 9], Sum = 8 (No pair exists, return no)
        // EX2: Collection = [1, 2, 4, 4], Sum = 8 (Indecies 2 (4) and 3 ( 4) equal 8, return Yes)
        // Assume Collections are sorted, integers, positives and negatives
        public static bool HasPairWithSum(int[] collection, int sum)
        {
            HashSet<int> complements = new HashSet<int>(collection.Length);
            foreach (int item in collection)
            {
                if (complements.Contains(item))
                {
                    return true;
                }
                complements.Add(sum - item);
            } 
            return false;
        }

        /*
         * Given a string that contains special characters, reverse the string in a way
         * that special characters are not effected
         * 
         * Ex: str = "a,b$c"
         *  ouput: str = "c,b$a"
         *  
         * Ex: str = "Ab,c,de!$"
         *  output: str = "ed,c,bA!$"
         *  
         *  Sol'n: Have indecies at both ends, and move towards middle. If a pointer is pointing
         *  at a special character, bump it forward. Stop iterating when indecies cross.
         */
        public static String reverseStringSpecialCharacters(string str)
        {
            StringBuilder retVal = new StringBuilder(str);

            int start = 0;
            int end = retVal.Length - 1;
            while (start < end)
            {
                if(!isAlphabetic(retVal[start]))
                {
                    start++;
                }
                else if(!isAlphabetic(retVal[end]))
                {
                    end--;
                }
                else
                {
                    char temp = retVal[start];
                    retVal[start] = retVal[end];
                    retVal[end] = temp;

                    start++;
                    end--;
                }
            }

            return retVal.ToString();
        }

        private static bool isAlphabetic(char v)
        {
            if ( (v >= 'a' && v <= 'z') || (v >= 'A' && v <= 'Z') )
            {
                return true;
            }

            return false;
        }

        public static bool isPalindrome(string str)
        {
            return _isPalindrome(str, 0, str.Length - 1);
        }

        private static bool _isPalindrome(string str, int low, int high)
        {
            while (low < high)
            {
                if (str[low] != str[high])
                {
                    return false;
                }
                low++;
                high--;
            }

            return true;
        }

        /*
         * Ex: set[] = {2, 3, 10, 6, 4, 8, 1}
         * Output: 8
         */
        public static int maxDifferenceBetweenContinuousElements(int[] a)
        {
            int min = a[0];
            int result = 0;
            for (int i = 1; i < a.Length; i++)
            {
                result = Math.Max(result, a[i] - min);
                min = Math.Min(a[i], min);
            }

            return result;
        }

        /*
         * Given a set of numbers, return true if there are 3 numbers that add
         * up to 0
         */
        public static bool ThreeSum(int[] a)
        {
            if (a == null || a.Length < 3)
            {
                throw new ArgumentNullException();
            }

            // Sort the array
            Array.Sort(a);
       
            int target = 0;
            for (int i = 0; i < a.Length - 2; i++)
            {
                int j = i + 1;
                int k = a.Length - 1;
                while (j < k)
                {
                    int sum = a[i] + a[j] + a[k];
                    if (sum == target)
                    {
                        // Success case
                        return true;
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return false;
        }

        public static int[] ThreeSum_Array(int[] a)
        {
            if (a == null || a.Length < 3)
            {
                return new int[] { 0, 0, 0 };
            }

            int target = 0;
            for (int i = 0; i < a.Length -2; i++)
            {
                int j = i + 1;
                int k = a.Length - 1;
                while (j < k)
                {
                    int sum = a[i] + a[j] + a[k];

                    if (sum == target)
                    {
                        return new int[] { i, j, k };
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return new int[] { 0, 0, 0 };
        }

        /*
         * Given an array containing both negative and positive integers. Find the 
         * contiguous sub-array with maximum sum.
         * Ex:
         * Input: { 1, 2, 3}
         * Output: 6 // 1 + 2 + 3
         * 
         * Input: {-1, -2, -3, -4}
         * Output: -1
         */
        public static int Kadanes_contiguousSubArrayWithMaximumSum(int[] arr)
        {
            int localMax = arr[0];
            int globalMax = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                localMax = Math.Max(arr[i], localMax + arr[i]);
                globalMax = Math.Max(globalMax, localMax);
            }
            return globalMax;
        }
    }
}
