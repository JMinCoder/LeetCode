using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * A sub-array has one number of some continuous numbers. 
     * Given an integer array with positive numbers and negative numbers, get the maximum sum of all sub-arrays. 
     * Time complexity should be O(n).
     * 
     * For example, in the array {1, -2, 3, 10, -4, 7, 2, -5}, its sub-array {3, 10, -4, 7, 2} has the maximum sum 18.
     */
    class MaximumSumOfAllSubArrays
    {
        public void Test()
        {
            Console.WriteLine(this.MaxSubarraySum(new int[] { 1, -2, 3, 10, -4, 7, 2, -5 }));
        }

        public int MaxSubarraySum(int []arr)
        {
            int sum = 0;
            int max = Int32.MinValue;
            for (var i=0;i<arr.Length;i++)
            {
                sum += arr[i];
                if (sum < 0) sum = 0;
                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
