using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewProblems
{
    public class DynamicProgrammingProblems
    {
        /*
         * LIS = Longest Increasing Subsequence
         * 
         * Longest Increasing Subsequence (LIS) = the largest
         * count of any sequence of numbers in an array. Numbers
         * do not have to be consecutive, just in sequence.
         * Ex: The sequence [10 22 9 33 21 50 41 60 80] has
         * LIS = 6 (The sequence is [10 22 33 50 60 80]
         * 
         * Sol'n: A greedy algorithm doesn't work here. Instead, lets break
         * the problem into sub-problems, and solve for those. Lets declare 
         * L(i) = the LIS for an array of length i. We recognize that if
         * a[i] > a[i-j], for every j where 0 <= j < i then L(i) = L(i-j) + 1. 
         * This allows us to iterate over the array and calculate L[i-j] for each
         * i. We can use a dynamic programmng solution to generate the sub-problems,
         * and use memorization to store the results.
         */
        public static int LIS(int[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException();
            }
            if (a.Length == 0)
            {
                return 0;
            }

            // Create the memorization array = dp, and initialize all entries to 1
            int[] dp = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[i] > a[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            int retVal = 0;
            for (int i = 0; i < a.Length; i++)
            {
                retVal = Math.Max(retVal, dp[i]);
            }

            return retVal;
        }

        public static int LIS2(int[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException();
            }
            if (a.Length < 1)
            {
                return 0;
            }

            int[] dp = new int[a.Length];
            dp[0] = 1;
            int retVal = 0;
            for (int i = 1; i < a.Length; i++)
            {
                int maxValue = 0;
                for (int j = 0; j < i; j++)
                {
                    if (a[i] > a[j])
                    {
                        maxValue = Math.Max(maxValue, dp[j]);
                    }
                }
                dp[i] = maxValue + 1;
                retVal = Math.Max(retVal, dp[i]);
            }

            return retVal;
        }

        /*
         * LCS = Longest Common Subsequence
         * 
         * The longest continuous sequence (LCS) is the longest
         * subsequence in common between two strings.
         * 
         * Ex: LCS for input "ABCDGH" and "AEDFHR" is "ADH" of length 3
         * EX: LCS for input "AGGTAB" and "GXTXAYB" is "GTAB" of length 4
         * 
         * Sol'n: If we declare L[i, j] = LCS for strings of length i and j, then
         * L[i, j] = L[i-1, j-1] +1. if str1[i] == str[j]. When str1[i] != str2[j], then
         * L[i, j] = Max(L[i-1, j], L[i, j-1]).
         * Recognizing this relation,
         * we can represent the solution as a series of sub problems that just need
         * to be solved. Using a dynamic programming solution and memorization, we
         * can solve and store sub-problems and use a bottom-up approach to solving
         * the larger problem.
         */
        public static int LCS(string str1, string str2)
        {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
            {
                throw new ArgumentNullException();
            }

            return lcs_helper2(str1, str2, str1.Length, str2.Length);
        }

        // Naive recursive solution - solves subprroblems multiple times
        private static int lcs_helper(string str1, string str2, int m, int n)
        {
            if (m == 0 || n == 0)
            {
                return 0;
            }
            if (str1[m - 1] == str2[n - 1])
            {
                return 1 + lcs_helper(str1, str2, m - 1, n - 1);
            }
            else
            {
                return Math.Max(
                    lcs_helper(str1, str2, m - 1, n),
                    lcs_helper(str1, str2, m, n - 1)
                );
            }
        }

        // Dynamic programming solution with memoization
        private static int lcs_helper2(string str1, string str2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            // Build up dp, bottom up
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            // The length of the LCS is now stored at dp[m, n]
            // To get the actual string, we can use dp values: we start dp[m,j]
            // and check if the characters are equal. If they are, we add it to a string,
            // and subtract 1 from each. We keep doing this until we arrive at 0. If they do
            // not match, then we move to the box with max value.

            return dp[m, n];
        }

        /*
         * Given 2 strings, and the following operations that can be performed on str1,
         * find the minimum number of operatiobns required to convert str1 to str2
         * Operations:
         *  - Replace
         *  - Remove / Delete
         *  - Insert
         * 
         * Ex: "geek" and "gesek" : 1
         * Ex: "sunday" and "saturday" : 3
         */
        public static int MED(string str1, string str2)
        {
            if (str1.Length == 0 || str2.Length == 0)
            {
                throw new ArgumentNullException();
            }

            return med_helper2(str1, str2, str1.Length, str2.Length);
        }

        /*
         * Sol'n: Assume that dp[i, j] = minEditDistance (MED) of strings of length i and j.
         * If str1[i-1] == str2[j-1], then dp[i-1, j-1] == dp[i-2, j-2]. If they are different,
         * then we need to consider how the above three operations, calculate each, and then
         * store the min of the three at dp[i-1, j-1]
         */
        private static int med_helper(string str1, string str2, int m, int n)
        {
            if (m == 0)
            {
                return n;
            }
            if (n == 0)
            {
                return m;
            }
            if (str1[m - 1] == str2[n - 1])
            {
                return med_helper(str1, str2, m - 1, n - 1);
            }

            int insert = med_helper(str1, str2, m, n - 1);
            int remove = med_helper(str1, str2, m - 1, n);
            int replace = med_helper(str1, str2, m - 1, n - 1);

            int min = Math.Min(insert, remove);
            min = Math.Min(min, replace);

            return 1 + min;
        }

        private static int med_helper2(string str1, string str2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        int insert = dp[i, j - 1];
                        int remove = dp[i - 1, j];
                        int replace = dp[i - 1, j - 1];

                        int min = Math.Min(insert, remove);
                        min = Math.Min(min, replace);
                        dp[i, j] = min + 1;
                    }
                }
            }

            return dp[m, n];
        }

        /*
         * Classic knapsack problem. The 0-1 variant means that you either take
         * the object, or don't take it at all.
         * 
         * Ex: 
         *  - value[] = {60, 100, 120}
         *  - weights[] = {10, 20, 30}
         *  - capacity = 50
         * Output: 220
         * 
         * Sol'n: The problem can be broken down into a series of sub-problems:
         * For each item K, there are two possibilities: either the kth item is in the
         * optimal set, or it is not. Therefore, the maximum value that can be obtained
         * by n items = MAX(not taking the nth item, taking the nth item)
         * In code, this is:
         *   MAX(max_val(val-Kth item, weights-Kth item, capacity),
         *       max_val(val-Kth item, weights-Kth item, capacity
         */
        public static int Knapsack_01(int[] values, int[] weights, int capacity)
        {
            if (values == null || weights == null)
            {
                throw new ArgumentNullException();
            }

            return knapsack_helper2(capacity, weights, values, values.Length);
        }

        private static int knapsack_helper(int W, int[] weights, int[] values, int n)
        {
            if (W == 0 || n == 0)
            {
                return 0;
            }

            // If the weight of the nth item is greater than our capacity, 
            // then this item cannot be included in the optimal solution
            if (weights[n - 1] > W)
            {
                return knapsack_helper(W, weights, values, n - 1);
            }

            // Otherwise, we return the maximum of 
            else
            {
                return Math.Max(
                    values[n - 1] + knapsack_helper(W - weights[n - 1], values, weights, n - 1),
                    knapsack_helper(W, values, weights, n - 1)
                    );
            }
        }

        private static int knapsack_helper2(int W, int[] wt, int[] val, int n)
        {
            int[,] K = new int[n + 1, W + 1];
            
            for(int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (wt[i-1] <= w)
                    {
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            return K[n, W];
        }

        /*
         * Given a set of non-negative integers and a value Sum, determine if there
         * is a subset of the given set with sum equal to given Sum
         * 
         * Ex: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
         * Output: True // There is a subset (4, 5) with sum 9
         * 
         * Sol'n: 
         * Declare a fuction isSum(int[] set, int Sum, int n), where n is the length
         * of numbers in the set. 
         * For every number in the set, there are two cases: either the 
         * number is included in the optimal/correct subset, or it is not.
         * Starting from the end, we can include the last element in the set, in which
         * case can recur with isSum(int[] set, Sum - set[n-1], n-1). If we do not
         * include it, then we have isSum(int[] set, Sum, n-1). Base case is if
         */
        public static Boolean SubsetSum(int[] a, int S)
        {
            return subset_helper2(a, S, a.Length);
        }

        private static bool subset_helper(int[] set, int Sum, int n)
        {
            // Base Case 1: Sum is 0, meaning we have our solution set
            if (Sum == 0)
            {
                return true;
            }
            // Base Case 2: We are at last index, but Sum is not 0, cannot be optimal set
            if (n == 0)
            {
                return false;
            }

            // If the last element is greater than Sum, ignore it
            if (set[n-1] > Sum)
            {
                return subset_helper(set, Sum, n - 1);
            }

            // Else, check if sum can be obtained by any of the following:
            // - Including the last element
            // - excluding the last element

            return subset_helper(set, Sum, n - 1) || subset_helper(set, Sum - set[n - 1], n - 1);
        }

        private static bool subset_helper2(int[] set, int Sum, int n)
        {
            // The value of the subset[i][j] will be true if there is
            // a subset of set[0..j-1] with sum equal to i
            bool[,] dp = new bool[Sum + 1, n + 1];

            // If Sum is 0, then answer is true
            for (int i = 0; i <= n; i++)
            {
                dp[0, i] = true;
            }

            // if sum is not 0 and set is empty, then answer is false
            for (int i = 1; i <= Sum; i++)
            {
                dp[i, 0] = false;
            }

            // Fill in the rest of the subset table, bottom up style
            for(int i = 1; i <= Sum; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    dp[i, j] = dp[i, j - 1];
                    if (i >= set[j-1])
                    {
                        dp[i, j] = dp[i, j] || dp[i - set[j - 1], j - 1];
                    }
                }
            }

            return dp[Sum, n];
        }
    }
}
