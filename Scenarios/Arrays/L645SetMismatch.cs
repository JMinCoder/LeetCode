using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/set-mismatch/#/description
     * 
     * The set S originally contains numbers from 1 to n. But unfortunately, due to the data error, one of the numbers in the set got duplicated to another number in the set, which results in repetition of one number and loss of another number.

Given an array nums representing the data status of this set after the error. Your task is to firstly find the number occurs twice and then find the number that is missing. Return them in the form of an array.

Example 1:
Input: nums = [1,2,2,4]
Output: [2,3]
Note:
The given array size will in the range [2, 10000].
The given array's numbers won't have any order.
     */
    class L645SetMismatch
    {
        public void Test()
        {
            Console.WriteLine(this.FindErrorNums(new int[] { 2, 2 })); // 2,1

            Console.WriteLine(this.FindErrorNums(new int[] { 5, 3, 6, 1, 5, 4, 7, 8 })); // 5,2
            Console.WriteLine(this.FindErrorNums(new int[] { 3, 2, 3, 4, 6, 5 })); // 3,1
            Console.WriteLine(this.FindErrorNums(new int[] { 3, 2, 2 })); // 2,1
            Console.WriteLine(this.FindErrorNums(new int[] { 1, 2, 2, 3, 5 })); // 2, 4
            Console.WriteLine(this.FindErrorNums(new int[] { 1, 3, 4, 2, 2 })); // 2, 5
            Console.WriteLine(this.FindErrorNums(new int[] { 1, 2, 3, 4, 4 })); // 4, 5
            Console.WriteLine(this.FindErrorNums(new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 9 })); // 4, 8
        }

        public int[] FindErrorNums(int[] nums)
        {
            if (nums == null || nums.Length < 2) return null;

            var flag = new bool[nums.Length + 1];
            int missing = nums.Length;
            int dup = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (flag[nums[i]])
                {
                    dup = nums[i];
                }
                flag[nums[i]] = true;
            }
            for (var i = 1; i < flag.Length; i++)
            {
                if (!flag[i])
                {
                    missing = i;
                    break;
                }
            }
            return new int[] { dup, missing };
        }
    }
}
