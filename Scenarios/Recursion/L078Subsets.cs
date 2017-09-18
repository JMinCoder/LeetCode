using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/subsets
     * 
     * Given a set of distinct integers, nums, return all possible subsets.

Note: The solution set must not contain duplicate subsets.

For example,
If nums = [1,2,3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]
     */
    class L078Subsets
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();

            Permute(nums, ret, cur, 0);
            return ret;
        }

        private void Permute(int[] nums, IList<IList<int>> ret, IList<int> cur, int start)
        {
            ret.Add(cur.ToList());

            for (var i = start; i < nums.Length; i++)
            {
                cur.Add(nums[i]);
                Permute(nums, ret, cur, i + 1);
                cur.Remove(nums[i]);
            }
        }
    }
}
