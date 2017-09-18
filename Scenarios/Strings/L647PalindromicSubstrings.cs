using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * https://leetcode.com/problems/palindromic-substrings/#/description
     * 
     * Given a string, your task is to count how many palindromic substrings in this string.

The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

Example 1:
Input: "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".
Example 2:
Input: "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
Note:
The input string length won't exceed 1000.
     */
    class L647PalindromicSubstrings
    {
        public void Test()
        {
            Console.WriteLine(this.CountSubstrings("abc"));
            Console.WriteLine(this.CountSubstrings("aaa"));
        }

        public int CountSubstrings(string s)
        {
            int count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                // even length
                count += CountSubstrings(s, i, i + 1);
                // odd length
                count += CountSubstrings(s, i, i);
            }
            return count;
        }

        public int CountSubstrings(string s, int i, int j)
        {
            int count = 0;
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                count++;
                i--; j++;
            }
            return count;
        }
    }
}
