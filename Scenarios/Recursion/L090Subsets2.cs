using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/subsets-ii
     * 
     * Given a collection of integers that might contain duplicates, nums, return all possible subsets.

Note: The solution set must not contain duplicate subsets.

For example,
If nums = [1,2,2], a solution is:

[
  [2],
  [1],
  [1,2,2],
  [2,2],
  [1,2],
  []
]
     */
    class L090Subsets2
    {
        public void Test()
        {
            //var ret = this.SubsetsWithDup(new int[] { 1, 2, 2 });
            //var ret = this.SubsetsWithDup(new int[] { 2, 2, 2, 2 });
            var ret = this.SubsetsWithDup(new int[] { 2, 2, 2, 1, 2 });
            ret.Print();
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            Array.Sort(nums);
            Permute(nums, ret, cur, 0);
            return ret;
        }

        private void Permute(int[] nums, IList<IList<int>> ret, IList<int> cur, int start)
        {
            ret.Add(cur.ToList());

            for (var i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                cur.Add(nums[i]);                
                Permute(nums, ret, cur, i + 1);
                cur.RemoveAt(cur.Count-1);                
            }
        }
    }
}
