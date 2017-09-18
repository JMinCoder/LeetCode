using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Say you have an array for which the ith element is the price of a given stock on day i.
     * Design an algorithm to find the maximum profit. You may complete at most two transactions.
     * 
     * Note:
     * You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
     */
    class L123BestTimeToBuyAndSellStocks3
    {
        public void Test()
        {
            Console.WriteLine(this.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })); // 7
            Console.WriteLine(this.MaxProfit(new int[] { 7, 6, 4, 3, 1 })); // 0
            Console.WriteLine(this.MaxProfit(new int[] { 3, 4, 3, 4, 5 })); // 3
            Console.WriteLine(this.MaxProfit(new int[] { 3, 5, 7, 10 })); // 7
            Console.WriteLine(this.MaxProfit(new int[] { 3, 5, 2, 10 })); // 10
            Console.WriteLine(this.MaxProfit(new int[] { 3, 5, 10 })); // 7
        }

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;
            // f[k, ii] represents the max profit up until prices[ii] (Note: NOT ending with prices[ii]) using at most k transactions. 
            // f[k, ii] = max(f[k, ii-1], prices[ii] - prices[jj] + f[k-1, jj]) { jj in range of [0, ii-1] }
            //          = max(f[k, ii-1], prices[ii] + max(f[k-1, jj] - prices[jj]))
            // f[0, ii] = 0; 0 times transation makes 0 profit
            // f[k, 0] = 0; if there is only one price data point you can't make any money no matter how many times you can trade

            int K = 2; // number of max transation allowed
            int maxProf = 0;
            var f = new int[K + 1, prices.Length];

            for (int kk = 1; kk <= K; kk++)
            {
                int tmpMax = f[kk - 1, 0] - prices[0];
                for (int ii = 1; ii < prices.Length; ii++)
                {
                    f[kk, ii] = Math.Max(f[kk, ii - 1], prices[ii] + tmpMax);
                    tmpMax = Math.Max(tmpMax, f[kk - 1, ii] - prices[ii]);
                    maxProf = Math.Max(f[kk, ii], maxProf);
                }
            }
            return maxProf;
        }
    }
}
