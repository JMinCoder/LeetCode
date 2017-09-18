using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L525ContinuousSubarraySum
    {
        /*
         * 
         * Given a list of non-negative numbers and a target integer k, write a function to check if the array has a continuous subarray of size 
         * at least 2 that sums up to the multiple of k, that is, sums up to n*k where n is also an integer.
         * 
         * Example 1:
         * Input: [23, 2, 4, 6, 7],  k=6
         * Output: True
         * Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
         * 
         * Example 2:
         * Input: [23, 2, 6, 4, 7],  k=6
         * Output: True
         * Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
         */

        public void Test()
        {
            Console.WriteLine(CheckSubarraySum(new int[] { 23, 2, 4, 6, 7 }, 6));
            Console.WriteLine(CheckSubarraySum(new int[] { 23, 2, 6, 4, 7 }, 6));
            Console.WriteLine(CheckSubarraySum(new int[] { 0}, 0));
            Console.WriteLine(CheckSubarraySum(new int[] { 0, 0 }, 0));
            Console.WriteLine(CheckSubarraySum(new int[] { 0, 3, 0 }, 0));
        }
        public bool CheckSubarraySum(int[] nums, int k)
        {
            if (k == 0)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0 && i < nums.Length-1 && nums[i+1] == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            for (var l=2;l<nums.Length;l++)
            {
                for (int i=0;i<nums.Length-l;i++)
                {
                    int sum = 0;
                    for (int j=i;j<i+l;j++)
                    {
                        sum += nums[j];
                    }
                    if (sum%k == 0)
                    {
                        //Console.WriteLine(sum);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
