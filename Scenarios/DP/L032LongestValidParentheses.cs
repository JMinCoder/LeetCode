using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
     * For "(()", the longest valid parentheses substring is "()", which has length = 2.
     * Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
     */
    class L032LongestValidParentheses
    {
        public void Test()
        {
            Console.WriteLine(this.LongestValidParentheses("(()"));
            Console.WriteLine(this.LongestValidParentheses(")()())"));
            Console.WriteLine(this.LongestValidParentheses(")()(())"));
        }

        public int LongestValidParentheses(string s)
        {
            var dp = new int[s.Length];
            int max = 0;

            for (var i=1;i<s.Length;i++)
            {
                // Check only ')', as that's where the valid string will be there
                if (s[i] == ')')
                {
                    // () case
                    if (s[i - 1] == '(')
                    {
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else
                    {
                        // ......)) case
                        if (i-dp[i-1] > 0 && s[i-dp[i-1]-1] == '(')
                        {
                            dp[i] = dp[i - 1] + 2;
                        }
                    }
                    max = Math.Max(max, dp[i]);
                }
            }

            return max;
        }
    }
}
