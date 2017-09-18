using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * https://leetcode.com/problems/find-all-anagrams-in-a-string
     * 
     * Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
       Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
       The order of output does not matter.
Example 1:

Input:
s: "cbaebabacd" p: "abc"

Output:
[0, 6]

Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".
Example 2:

Input:
s: "abab" p: "ab"

Output:
[0, 1, 2]

Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
     */
    class L438FindAllAnagramsInAString
    {
        public void Test()
        {
            var r = this.FindAnagrams("cbaebabacd", "abc");
            r.Print();

            r = this.FindAnagrams("abab", "ab");
            r.Print();
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            var ret = new List<int>();
            if (s.Length < p.Length) return ret;

            var counts = new int[26];
            var scount = new int[26];
            for (var i = 0; i < p.Length; i++)
            {
                counts[p[i] - 'a']++;
                scount[s[i] - 'a']++;
            }
            if (IsSame(counts, scount)) ret.Add(0);
            for (var i=1;i<s.Length-p.Length+1;i++)
            {
                scount[s[i - 1] - 'a']--;
                scount[s[i + p.Length - 1] - 'a']++;
                if (IsSame(counts, scount)) ret.Add(i);
            }
            return ret;
        }

        private bool IsSame(int []a, int []b)
        {
            if (a.Length != b.Length) return false;
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}
