using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * 
     * https://leetcode.com/problems/strange-printer/description/
     * 
     * There is a strange printer with the following two special requirements:

The printer can only print a sequence of the same character each time.
At each turn, the printer can print new characters starting from and ending at any places, and will cover the original existing characters.
Given a string consists of lower English letters only, your job is to count the minimum number of turns the printer needed in order to print it.

Example 1:
Input: "aaabbb"
Output: 2
Explanation: Print "aaa" first and then print "bbb".
Example 2:
Input: "aba"
Output: 2
Explanation: Print "aaa" first and then print "b" from the second place of the string, which will cover the existing character 'a'.
Hint: Length of the given string will not exceed 100.

    */

    class L664StrangePrinter
    {
        public void Test()
        {
            Console.WriteLine(this.StrangePrinter("aaabbb")); // 2
            Console.WriteLine(this.StrangePrinter("aba")); //2
            Console.WriteLine(this.StrangePrinter("abaaac")); // 3
            Console.WriteLine(this.StrangePrinter("aabcbaa")); // 3
            Console.WriteLine(this.StrangePrinter("tbgtgb")); // 4
        }

        public int StrangePrinter(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var n = s.Length;
            var dp = new int[n, n];

            return FindPrints(s, 0, n - 1, dp);
        }

        private int FindPrints(string s, int i, int j, int[,] dp)
        {
            if (i > j) return 0;
            if (dp[i, j] != 0) return dp[i, j];

            while (i + 1 < j && s[i] == s[i + 1])
            {
                i++;
            }

            int res = 1 + FindPrints(s, i + 1, j, dp);
            for (var m = i + 1; m <= j; m++)
            {
                if (s[i] == s[m])
                {
                    res = Math.Min(res, FindPrints(s, i + 1, m - 1, dp) + FindPrints(s, m, j, dp));
                }
            }
            dp[i, j] = res;
            return res;
        }
    }
}
