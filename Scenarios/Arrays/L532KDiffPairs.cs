using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    class L532KDiffPairs
    {
        /*
         * Given an array of integers and an integer k, you need to find the number of unique k-diff pairs in the array. Here a k-diff pair is defined as an integer pair (i, j), where i and j are both numbers in the array and their absolute difference is k.

Example 1:
Input: [3, 1, 4, 1, 5], k = 2
Output: 2
Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
Although we have two 1s in the input, we should only return the number of unique pairs.
Example 2:
Input:[1, 2, 3, 4, 5], k = 1
Output: 4
Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and (4, 5).
Example 3:
Input: [1, 3, 1, 5, 4], k = 0
Output: 1
Explanation: There is one 0-diff pair in the array, (1, 1).
         */

        public void Test()
        {
            Console.WriteLine(this.FindPairs2(new int[] { 3, 1, 4, 1, 5 }, 2));
            Console.WriteLine(this.FindPairs2(new int[] { 1, 2, 3, 4, 5 }, 1));
            Console.WriteLine(this.FindPairs2(new int[] { 1, 3, 1, 5, 4 }, 0));
            Console.WriteLine(this.FindPairs2(new int[] { 1, 1,1,1,1 }, 0));
        }

        public int FindPairs(int[] nums, int k)
        {
            var hash = new HashSet<string>();
            for (var i = 0; i < nums.Length; ++i)
            {
                for (var j = i + 1; j < nums.Length; ++j)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k)
                    {
                        var s = (nums[i] <= nums[j]) ?
                                    String.Format("{0}:{1}", nums[i], nums[j]) :
                                    String.Format("{0}:{1}", nums[j], nums[i]);

                        if (!hash.Contains(s))
                        {
                            hash.Add(s);
                        }
                    }
                }
            }
            return hash.Count;
        }

        public int FindPairs2(int[] nums, int k)
        {
            if (nums == null | nums.Length <= 1 || k < 0) return 0;
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            int count = 0;
            foreach (var num in dict.Keys)
            {
                if (k==0)
                {
                    if (dict[num] >= 2)
                        count++;
                }
                else
                {
                    if (dict.ContainsKey(num + k))
                        count++;
                }
            }
            return count;
        }
    }
}
