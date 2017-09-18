using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Multiple transactions allowed in one day, but first need to sell, before buy again.
     */
    class L122StockMaxProfit2
    {
        public void Test()
        {
            Console.WriteLine(this.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })); // 7
            Console.WriteLine(this.MaxProfit(new int[] { 7, 6, 4, 3, 1 })); // 0
            Console.WriteLine(this.MaxProfit(new int[] { 3, 4, 3, 4, 5 })); // 3
        }


        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;
            int total = 0;
            int profit = 0;
            int buy = prices[0];
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] < buy)
                {
                    buy = prices[i];
                }
                else if (prices[i] > buy)
                {
                    profit = prices[i] - buy;
                    total += profit;
                    buy = prices[i];
                }
            }
            return total;
        }
    }
}
