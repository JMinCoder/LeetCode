using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    class L656CoinPath
    {
        public void Test()
        {
            Helpers.Print(this.CheapestJump(new int[] { 1, 2, 4, -1, 2 }, 2));
        }

        public IList<int> CheapestJump(int[] A, int B)
        {
            var res = new List<int>();
            //if (A.empty() || A.back() == -1) return ans;

            // working backward
            var n = A.Length;
            var dp = new int[n];
            var pos = new int[n];

            for (var i = 0; i < n; i++)
            {
                dp[i] = Int32.MaxValue;
                pos[i] = -1;
            }

            //dp[n - 1] = A[n - 1];
            dp[0] = A[0];

            for (var i = 1; i < n; i++)
            {
                if (A[i] == -1) continue;
                for (var j = i - 1; j >= 0 && j > i - B; j--)
                {
                    if (A[i] + dp[j] < dp[i])
                    {
                        dp[i] = A[i] + dp[j];
                        pos[i] = j;
                    }
                }
            }

            //for (int i = n - 2; i >= 0; i--)
            //{
            //    if (A[i] == -1) continue;
            //    for (int j = i + 1; j <= Math.Min(i + B, n - 1); j++)
            //    {
            //        if (dp[j] == Int32.MaxValue) continue;
            //        if (A[i] + dp[j] < dp[i])
            //        {
            //            dp[i] = A[i] + dp[j];
            //            pos[i] = j;
            //        }
            //    }
            //}
            // cannot jump to An
            if (dp[0] == Int32.MaxValue) return res;
            int k = 0;
            while (k != -1)
            {
                res.Add(k + 1);
                k = pos[k];
            }
            return res;
        }
    }
}
