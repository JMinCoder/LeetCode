using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * Find the Longest common subsequence of two strings
     * 
     * LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
     * LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.
     */
    class LongestCommonSubsequence
    {
        public void Test()
        {
            var f = "ABCBDAB";
            var s = "BDCABA";
            Console.WriteLine("{0}|{1} = {2}", f, s, this.LCS(f, s));

            f = "ABCDGH"; s = "AEDFHR";
            Console.WriteLine("{0}|{1} = {2}", f, s, this.LCS(f, s));

            f = "AGGTAB"; s = "GXTXAYB";
            Console.WriteLine("{0}|{1} = {2}", f, s, this.LCS(f, s));
        }

        public string LCS(string first, string second)
        {
            int n = first.Length + 1;
            int m = second.Length + 1;
            var dp = new int[n, m];
            int i, j;
            for (i=1;i<n;i++ )
            {
                for (j=1;j<m;j++)
                {
                    if (first[i-1] == second[j-1])
                    {
                        dp[i,j] = dp[i - 1,j - 1] + 1;
                    }
                    else
                    {
                        if (dp[i-1,j] >= dp[i,j-1])
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = dp[i, j-1];
                        }
                    }
                }
            }

            var sb = new StringBuilder();

            i = n - 1;
            j = m - 1;
            while (i>0 && j>0)
            {
                if (first[i-1] == second[j-1])
                {
                    sb.Append(first[i - 1]);
                    i--;
                    j--;
                }
                else
                {
                    if (dp[i - 1, j] >= dp[i, j - 1])
                    {
                        i--;
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
