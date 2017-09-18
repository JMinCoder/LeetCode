using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/first-missing-positive
     * 
     * Given an unsorted integer array, find the first missing positive integer.
     * For example,
     * Given [1,2,0] return 3,
     * and [3,4,-1,1] return 2.
     * 
     * Your algorithm should run in O(n) time and uses constant space.
     */
    class L041FirstMissingPositive
    {
        public void Test()
        {
            Console.WriteLine(this.FirstMissingPositive(new int[] { 1, 2, 0 })); // 3
            Console.WriteLine(this.FirstMissingPositive(new int[] { 3, 4, -1, 1 })); // 2
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 1;
            for (var i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
                
                //var j = i;
                //while (nums[j] != j + 1 && nums[j] >= 0 && nums[j] < nums.Length && nums[nums[j]] != nums[j]+1 && nums[nums[j]] != nums[j])
                //{
                //    var r = nums[j];
                //    nums[j] = nums[r];
                //    nums[r] = r;
                //    j = r;
                //}
            }
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1) return i + 1;
            }
            return nums.Length + 1;
        }

        private void Swap(int []nums, int s, int e)
        {
            var t = nums[s];
            nums[s] = nums[e];
            nums[e] = t;
        }
    }
}
