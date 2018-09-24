using System;

namespace InterviewProblems
{
    class Program
    {
        public static void PrintHeader(string header)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine(header.ToUpper());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            PrintHeader("Substring");
            string test1 = "Hello World!";
            string sub = ArrayProblems.Substring(test1, 2, 5);
            if (sub != "llo W")
            {
                Console.WriteLine("FAILED TEST");
            }
            Console.ReadLine();

            PrintHeader("HasPairWithSum");
            int[] array1 = { 1, 2, 3, 9 };
            int sum = 8;
            if (ArrayProblems.HasPairWithSum(array1, sum))
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            int[] array2 = { 1, 2, 4, 4 };
            if (!ArrayProblems.HasPairWithSum(array2, sum))
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            int[] array3 = { };
            if (ArrayProblems.HasPairWithSum(array3, sum))
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            int[] array4 = { 0, 5, 12, 7, 9, 14, -4 };
            if (!ArrayProblems.HasPairWithSum(array4, sum))
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            Console.ReadLine();

            // reverseStringWithSpecialCharacters
            string special_input1 = "a,b$c";
            string special_output1 = "c,b$a";
            string special_input2 = "Ab,c,de!$";
            string special_output2 = "ed,c,bA!$";
            if (ArrayProblems.reverseStringSpecialCharacters(special_input1).CompareTo(special_output1) != 0)
            {
                Console.WriteLine("FAILED REVERSE SPECIAL TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED REVERSE SPECIAL TEST 1");
                Console.ReadLine();
            }
            if (ArrayProblems.reverseStringSpecialCharacters(special_input2).CompareTo(special_output2) != 0)
            {
                Console.WriteLine("FAILED REVERSE SPECIAL TEST 2");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED REVERSE SPECIAL TEST 2");
                Console.ReadLine();
            }

            // maxDifference
            int[] maxDiff_input1 = { 2, 3, 10, 6, 4, 8, 1 };
            int maxDiff_output1 = 8;
            if (ArrayProblems.maxDifferenceBetweenContinuousElements(maxDiff_input1) != maxDiff_output1)
            {
                Console.WriteLine("FAILED MAX DIFF TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED MAX DIFF TEST 1");
                Console.ReadLine();
            }

            // 3Sum
            int[] threeSum_input1 = { -1, 0, 1, 2, -1, 4};
            int[] threeSum_input2 = { 4, 30, 2, -1, -3, 8, -6, 100};
            if (ArrayProblems.ThreeSum(threeSum_input1) == false)
            {
                Console.WriteLine("FAILED 3SUM TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED 3SUM TEST 1");
                Console.ReadLine();
            }
            if (ArrayProblems.ThreeSum(threeSum_input2) == false)
            {
                Console.WriteLine("FAILED 3SUM TEST 2");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED 3SUM TEST 2");
                Console.ReadLine();
            }
            if (ArrayProblems.ThreeSum_Array(threeSum_input1) == new int[]{ -1, 0, 1})
            {
                Console.WriteLine("FAILED 3SUM TEST 3");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED 3SUM TEST 3");
                Console.ReadLine();
            }
            if (ArrayProblems.ThreeSum_Array(threeSum_input2) == new int[] { -6, 2, 4})
            {
                Console.WriteLine("FAILED 3SUM TEST 4");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED 3SUM TEST 4");
                Console.ReadLine();
            }

            PrintHeader("FibonacciProblems");
            if (NumberProblems.Fibonacci(0) != 0)
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            if (NumberProblems.Fibonacci(1) != 1)
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            if (NumberProblems.Fibonacci(2) != 1)
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            if (NumberProblems.Fibonacci(8) != 21)
            {
                Console.WriteLine("FAILED TEST");
                Console.ReadLine();
            }
            Console.ReadLine();

            // Kadanes
            int[] Kadanes_Input1 = { 1, 2, 3 };
            int Kadanes_Output1 = 6;
            int[] Kadanes_input2 = { -1, -2, -3, -4 };
            int Kadanes_output2 = -1;
            if (ArrayProblems.Kadanes_contiguousSubArrayWithMaximumSum(Kadanes_Input1) != Kadanes_Output1)
            {
                Console.WriteLine("FAILED KADANES TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED KADANES TEST 1");
                Console.ReadLine();
            }
            if (ArrayProblems.Kadanes_contiguousSubArrayWithMaximumSum(Kadanes_input2) != Kadanes_output2)
            {
                Console.WriteLine("FAILED KADANES TEST 2");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED KADANES TEST 2");
                Console.ReadLine();
            }

            PrintHeader("DP - LongestIncreasingSubsequence (LIS)");
            int[] LISTest1 = { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            if (DynamicProgrammingProblems.LIS(LISTest1) != 6)
            {
                Console.WriteLine("FAILED TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("TEST 1 PASSED");
                Console.ReadLine();
            }
            if (DynamicProgrammingProblems.LIS2(LISTest1) != 6)
            {
                Console.WriteLine("FAILED TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("TEST 1 PASSED");
                Console.ReadLine();
            }

            // Test 2 - LCS
            string lcs_input1 = "ABCDGH";
            string lcs_input2 = "AEDFHR";
            string lcs_input3 = "AGGTAB";
            string lcs_input4 = "GXTXAYB";
            if (DynamicProgrammingProblems.LCS(lcs_input1, lcs_input2) != 3)
            {
                Console.WriteLine("FAILED LCS TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED LCS TEST 1");
                Console.ReadLine();
            }

            if (DynamicProgrammingProblems.LCS(lcs_input3, lcs_input4) != 4)
            {
                Console.WriteLine("FAILED LCS TEST 2");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED LCS TEST 2");
                Console.ReadLine();
            }

            // Test 3 - MED
            string med_input1 = "geek";
            string med_input2 = "gesek";
            string med_input3 = "sunday";
            string med_input4 = "saturday";
            if (DynamicProgrammingProblems.MED(med_input1, med_input2) != 1)
            {
                Console.WriteLine("FAILED MED TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED MED TEST 1");
                Console.ReadLine();
            }

            if (DynamicProgrammingProblems.MED(med_input3, med_input4) != 3)
            {
                Console.WriteLine("FAILED MED TEST 2");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED MED TEST 2");
                Console.ReadLine();
            }

            // Test 4 - Knapsack 0-1
            int[] values = { 60, 100, 120 };
            int[] weights = { 10, 20, 30 };
            int capacity = 50;

            if (DynamicProgrammingProblems.Knapsack_01(values, weights, capacity) != 220)
            {
                Console.WriteLine("FAILED Knapsack TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED Knapsack TEST 1");
                Console.ReadLine();
            }

            // Test 5 - isSubset
            int[] subset_input1 = { 3, 34, 4, 12, 5, 2 };
            int subset_Sum1 = 9;

            if (DynamicProgrammingProblems.SubsetSum(subset_input1, subset_Sum1) == false)
            {
                Console.WriteLine("FAILED Subset Sum TEST 1");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("PASSED Subset Sum TEST 1");
                Console.ReadLine();
            }
        }
    }
}
