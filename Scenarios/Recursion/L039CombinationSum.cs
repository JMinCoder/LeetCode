using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/combination-sum
     * 
     * Given a set of candidate numbers (C) (without duplicates) and a target number (T), find all unique combinations in C 
     * where the candidate numbers sums to T.

The same repeated number may be chosen from C unlimited number of times.

Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
For example, given candidate set [2, 3, 6, 7] and target 7, 
A solution set is: 
[
  [7],
  [2, 2, 3]
]
     */
    class L039CombinationSum
    {
        public void Test()
        {
            var ret = this.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            ret.Print();
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();
            var cur = new List<int>();
            Array.Sort(candidates);

            Permute(candidates, ret, cur, target, 0);
            return ret;
        }

        private void Permute(int[] candidates, IList<IList<int>> ret, IList<int> cur, int target, int start)
        {
            if (target == 0)
            {
                ret.Add(cur.ToList());
                return;
            }

            for (var i = start; i < candidates.Length && candidates[i] <= target; i++)
            {
                cur.Add(candidates[i]);
                Permute(candidates, ret, cur, target - candidates[i], i);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
