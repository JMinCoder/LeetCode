using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    class KnapSack01
    {
        public void Test()
        {
            var wts = new int[] { 10, 20, 30 };
            var costs = new int[] { 60, 100, 120 };
            var W = 50;

            Console.WriteLine(this.GetMaxProfit(wts, costs, W));
            Console.WriteLine(this.GetMaxProfit1(wts, costs, W));
            Console.WriteLine(this.GetMaxProfitRec(wts, costs, W, wts.Length));
        }

        public int GetMaxProfit(int[] wts, int[] costs, int W)
        {
            var dp = new int[wts.Length + 1, W + 1];

            for (var w = 1; w <= W; w++)
            {
                for (var i = 0; i < wts.Length; i++)
                {
                    if (wts[i] <= w)
                    {
                        dp[i + 1, w] = Math.Max(
                                    costs[i] + dp[i, w - wts[i]],
                                    dp[i, w]
                                );
                    }
                    else
                    {
                        dp[i + 1, w] = dp[i, w];
                    }
                }
            }

            return dp[wts.Length, W];
        }

        public int GetMaxProfit1(int[] wts, int[] costs, int W)
        {
            var dp = new int[wts.Length + 1, W + 1];

            for (var i = 0; i <= wts.Length; i++)
            {
                for (var w = 0; w <= W; w++)
                {
                    if (i==0 || w == 0)
                    {
                        dp[i, w] = 0;
                    }
                    else if (wts[i-1] <= w)
                    {
                        dp[i, w] = Math.Max(
                                    costs[i-1] + dp[i-1, w - wts[i-1]],
                                    dp[i-1, w]
                                );
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[wts.Length, W];
        }

        public int GetMaxProfitRec(int[] wts, int[] costs, int W, int n)
        {
            if (n == 0 || W == 0) return 0;

            if (wts[n-1] <= W)
            {
                return Math.Max(costs[n - 1] + GetMaxProfitRec(wts, costs, W - wts[n - 1], n - 1),
                                GetMaxProfitRec(wts, costs, W, n - 1));
            }
            else
            {
                return GetMaxProfitRec(wts, costs, W, n - 1);
            }
        }
    }
}
