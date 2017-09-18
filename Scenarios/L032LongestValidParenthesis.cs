using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L032LongestValidParenthesis
    {
        /*
         * Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
         */

        public void Test()
        {
            string[] ss =
            {
                "(()",
                ")()())",
                ")((()())()",
                ")((()())))))",
            };

            for (var i = 0; i < ss.Length; i++)
            {
                Console.WriteLine("{0} : {1}", ss[i], this.LongestValidParentheses(ss[i]));
            }
        }

        public int LongestValidParentheses(string s)
        {
            int left = 0;
            int right = 0;
            int max = 0;
            for (var i=0;i<s.Length;i++)
            {
                if (s[i] == '(') left++;
                else
                {
                    if (right < left)
                    {
                        right++;
                        max = Math.Max(max, 2 * right);                        
                    }
                    else
                    {
                        right = 0;
                        left = 0;
                    }
                }
            }

            return max;
        }
    }
}
