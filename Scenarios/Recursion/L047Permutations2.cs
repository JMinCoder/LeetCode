using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/permutations-ii
     * Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[
  [1,1,2],
  [1,2,1],
  [2,1,1]
]
    */
    class L047Permutations2
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            var visited = new bool[nums.Length];
            Array.Sort(nums);
            Permute(nums, ret, cur, visited);
            return ret;
        }

        private void Permute(int[] nums, IList<IList<int>> ret, IList<int> cur, bool[] visited)
        {
            if (cur.Count == nums.Length)
            {
                ret.Add(cur.ToList());
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1])) continue;

                visited[i] = true;
                cur.Add(nums[i]);
                Permute(nums, ret, cur, visited);
                cur.RemoveAt(cur.Count - 1);
                visited[i] = false;

            }
        }
    }
}
