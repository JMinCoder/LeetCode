using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L121StockMaxProfit
    {
        public void Test()
        {
            Console.WriteLine(this.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })); // 5
            Console.WriteLine(this.MaxProfit(new int[] { 7, 6, 4, 3, 1 })); // 0
            Console.WriteLine(this.MaxProfit(new int[] { 3, 4, 3, 3 }));
        }


        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;
            int max = 0;
            int min = prices[0];
            for (var i=1;i<prices.Length;i++)
            {
                min = Math.Min(min, prices[i]);
                max = Math.Max(max, prices[i] - min);
            }
            return max;
        }
    }
}
