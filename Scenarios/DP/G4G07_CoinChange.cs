using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
     * 
     * Given a value N, if we want to make change for N cents, and we have infinite supply of each of S = { S1, S2, .. , Sm} valued coins, 
     * how many ways can we make the change? The order of coins doesn’t matter.
     * 
     * For example, for N = 4 and S = {1,2,3}, there are four solutions: 
     * {1,1,1,1},{1,1,2},{2,2},{1,3}. 
     * So output should be 4. 
     * 
     * For N = 10 and S = {2, 5, 3, 6}, there are five solutions: 
     * {2,2,2,2,2}, {2,2,3,3}, {2,2,6}, {2,3,5} and {5,5}. 
     * So the output should be 5.
     */
    class G4G07_CoinChange
    {
        public void Test()
        {
            Console.WriteLine(this.CountCoinChange(new int[] { 1, 2, 3}, 4));
            Console.WriteLine(this.CountCoinChange(new int[] { 2, 5, 3, 6}, 10));
        }

        public int CountCoinChange(int []arr, int n)
        {
            var dp = new int[n + 1];
            Array.Sort(arr);
            
            for (var i=1;i<=n;i++)
            {
                for (var j=0;j<arr.Length; j++)
                {
                    if (arr[j] == i)
                    {
                        dp[i]++;
                    }
                    else if (arr[j] < i)
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            return dp[n];
        }

        private int Recurse(int []arr, int []dp, int n)
        {
            if (dp[n] != -1) return dp[n];
            int res = 0;
            for (var i=0;i<arr.Length;i++)
            {
                if (arr[i] < n)
                {
                    res += this.Recurse(arr, dp, n - arr[i]);
                }
                else if (arr[i] == n)
                {
                    res++;
                }
            }
            dp[n] = res;
            return dp[n];
        }
    }
}
