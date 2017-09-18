using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/permutations
     * Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
     */
    class L046Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            var visited = new bool[nums.Length];
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
                if (!visited[i])
                {
                    visited[i] = true;
                    cur.Add(nums[i]);
                    Permute(nums, ret, cur, visited);
                    cur.Remove(nums[i]);
                    visited[i] = false;
                }
            }
        }
    }
}
