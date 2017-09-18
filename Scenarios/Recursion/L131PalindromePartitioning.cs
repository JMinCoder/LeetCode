using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Recursion
{
    /*
     * https://leetcode.com/problems/palindrome-partitioning
     * 
     * Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

For example, given s = "aab",
Return

[
  ["aa","b"],
  ["a","a","b"]
]
     */
    class L131PalindromePartitioning
    {
        public IList<IList<string>> Partition(string s)
        {
            var ret = new List<IList<string>>();
            var cur = new List<string>();
            Permute(s, ret, cur, 0);
            return ret;
        }

        private void Permute(string s, IList<IList<string>> ret, IList<string> cur, int start)
        {
            if (start == s.Length)
            {
                ret.Add(cur.ToList());
                return;
            }

            for (var i = start; i < s.Length; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    cur.Add(s.Substring(start, i - start + 1));
                    Permute(s, ret, cur, i + 1);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int low, int high)
        {
            while (low <= high)
            {
                if (s[low] != s[high]) return false;
                low++;
                high--;
            }
            return true;
        }
    }
}
