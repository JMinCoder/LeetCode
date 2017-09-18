using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * Write a program to find the n-th ugly number.
     * Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
     * For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
     * Note that 1 is typically treated as an ugly number, and n does not exceed 1690.
     */
    class L264UglyNumberII
    {
        public int NthUglyNumber(int n)
        {
            var dp = new int[n];
            dp[0] = 1;
            int f2 = 0; int f3 = 0; int f5 = 0;

            for (var i = 1; i < n; i++)
            {
                int x2 = dp[f2] * 2;
                int x3 = dp[f3] * 3;
                int x5 = dp[f5] * 5;

                var min = Math.Min(x2, Math.Min(x3, x5));
                if (x2 == min) f2++;
                if (x3 == min) f3++;
                if (x5 == min) f5++;
                dp[i] = min;
            }

            return dp[n - 1];
        }
    }
}
