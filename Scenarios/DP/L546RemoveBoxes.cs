using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * https://leetcode.com/problems/remove-boxes/description/
     * 
     * Given several boxes with different colors represented by different positive numbers. 
     * You may experience several rounds to remove boxes until there is no box left. 
     * Each time you can choose some continuous boxes with the same color (composed of k boxes, k >= 1), remove them and get k*k points.
     * 
     * Find the maximum points you can get.
     * 
     * Example 1: 
     * Input: [1, 3, 2, 2, 2, 3, 4, 3, 1]
     * Output: 23
     * 
     * Explanation:
      [1, 3, 2, 2, 2, 3, 4, 3, 1] 
----> [1, 3, 3, 4, 3, 1] (3*3=9 points) 
----> [1, 3, 3, 3, 1] (1*1=1 points) 
----> [1, 1] (3*3=9 points) 
----> [] (2*2=4 points)
     */
    class L546RemoveBoxes
    {
        public void Test()
        {
            Console.WriteLine(this.RemoveBoxes(new int[] { 1, 3, 2, 2, 2, 3, 4, 3, 1 }));
        }

        public int RemoveBoxes(int[] boxes)
        {
            var n = boxes.Length;
            var dp = new int[n,n,n];

            return FindMaxPoints(boxes, 0, n - 1, 0, dp);
        }

        private int FindMaxPoints(int[] boxes, int i, int j, int k, int[,,] dp)
        {
            if (i > j) return 0;
            if (dp[i, j, k] != 0) return dp[i, j, k];

            while ( i+1 <j && boxes[i] == boxes[i+1])
            {
                i++; k++;
            }

            int res = (k + 1) * (k + 1) + FindMaxPoints(boxes, i + 1, j, 0, dp);
            for (var m=i+1;m<=j;m++)
            {
                if (boxes[i] == boxes[m])
                {
                    res = Math.Max(res, FindMaxPoints(boxes, i+1, m - 1, 0, dp) + FindMaxPoints(boxes, m, j, k + 1, dp));
                }
            }
            dp[i, j, k] = res;
            return res;
        }
    }
}
