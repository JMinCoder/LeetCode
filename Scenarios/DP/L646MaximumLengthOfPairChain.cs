using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * https://leetcode.com/problems/maximum-length-of-pair-chain
     * 
     * You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.

Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c. Chain of pairs can be formed in this fashion.

Given a set of pairs, find the length longest chain which can be formed. You needn't use up all the given pairs. You can select pairs in any order.

Example 1:
Input: [[1,2], [2,3], [3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4]
Note:
The number of given pairs will be in the range [1, 1000].
     */
    class L646MaximumLengthOfPairChain
    {
        public void Test()
        {
            Console.WriteLine(this.FindLongestChain(new int[,] { { 3, 4 }, { 2, 3 }, { 1, 2 } })); // 2
            Console.WriteLine(this.FindLongestChain(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 } })); // 2
        }

        public int FindLongestChain(int[,] pairs)
        {
            int n = pairs.GetLength(0);
            int i = 0, j = 0, max = 0;
            var list = new List<KeyValuePair<int, int>>();
            for (i = 0; i < n; i++)
            {
                list.Add(new KeyValuePair<int, int>(pairs[i, 0], pairs[i, 1]));
            }

            list.Sort((a, b) => a.Value - b.Value);

            var lis = new int[n];

            for (i = 0; i < n; i++)
                lis[i] = 1;

            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (list[i].Key > list[j].Value && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];

            return max;
        }
    }
}
