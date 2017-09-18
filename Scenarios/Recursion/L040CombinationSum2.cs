using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/combination-sum-ii
     * 
     * Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

Each number in C may only be used once in the combination.

Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
A solution set is: 
[
  [1, 7],
  [1, 2, 5],
  [2, 6],
  [1, 1, 6]
]
     */
    class L040CombinationSum2
    {
        public void Test()
        {
            //var ret = this.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            var ret = this.CombinationSum2(new int[] { 2,2,2 }, 4);
            ret.Print();
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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
                if (i > start && candidates[i] == candidates[i - 1]) continue;
                cur.Add(candidates[i]);
                Permute(candidates, ret, cur, target - candidates[i], i+1);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
