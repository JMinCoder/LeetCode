using Scenarios.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * Given an unsorted array, find the max length of subsequence in which the numbers are in incremental order. 
     * 
     * For example: If the input array is {7, 2, 3, 1, 5, 8, 9, 6}, a subsequence with the most numbers in 
     * incremental order is {2, 3, 5, 8, 9} and the expected output is 5.
     */
    class MaximalLengthOfIncrementalSubsequences
    {
        public void Test()
        {
            this.MaximalSubsequenceLength(new int[] { 1, 3, 5, 4, 7 });
            //var data = new int[][]
            //{
            //    new int[]{ 7, 2, 3, 1, 5, 8, 9, 6 },
            //    new int[]{ 10, 22, 9, 33, 21, 50, 41, 60, 80 },
            //    new int[]{ 2, 5, 3, 7, 11, 8, 10, 13, 6 }
            //};

            //for (var i = 0; i < data.Length; i++)
            //{
            //    if (this.MaximalSubsequenceLength(data[i]) != MaximalSubsequenceLengthNLogn(data[i]))
            //    {
            //        Console.WriteLine("Input : {0}. Dp : {1}. NLogN : {2}",
            //            String.Join(",", data[i]),
            //            this.MaximalSubsequenceLength(data[i]),
            //            this.MaximalSubsequenceLengthNLogn(data[i]));
            //    }
            //}
        }

        // http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
        public int MaximalSubsequenceLengthNLogn(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            if (arr.Length == 1) return 1;

            var lists = new int[arr.Length];
            lists[0] = arr[0];
            int length = 1; // Length points to next free slot. 

            for (var i=1;i<arr.Length;i++)
            {
                if (arr[i] < lists[0])
                {
                    // This is smallest number till now
                    lists[0] = arr[i];
                }
                else if (arr[i] > lists[length-1])
                {
                    // This is the greatest element till now
                    lists[length++] = arr[i];
                }
                else
                {
                    // Find the ceil index and replace that with current element
                    lists[BinarySearch.CeilIndex(lists, -1, length - 1, arr[i])] = arr[i];
                }
            }

            return length;
        }

        public int MaximalSubsequenceLength(int []arr)
        {
            var dp = new int[arr.Length];
            dp[0] = 1;
            int max = 1;

            for (var i=1;i<arr.Length;i++)
            {
                dp[i] = 1;
                for (var j=0;j<i;j++)
                {
                    if (arr[j] < arr[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}
