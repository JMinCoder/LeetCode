using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * https://leetcode.com/problems/valid-anagram
     * 
     * Given two strings s and t, write a function to determine if t is an anagram of s.

For example,
s = "anagram", t = "nagaram", return true.
s = "rat", t = "car", return false.

Note:
You may assume the string contains only lowercase alphabets.
     */
    class L242ValidAnagram
    {
        public void Test()
        {
            Console.WriteLine(this.IsAnagram("anagram", "nagaram"));
            Console.WriteLine(this.IsAnagram("cat", "rat"));
        }
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var a1 = new int[26]; var a2 = new int[26];

            for (var i=0;i<s.Length;i++)
            {
                a1[s[i] - 'a']++;
                a2[t[i] - 'a']++;
            }

            for (var i=0;i<26;i++)
            {
                if (a1[i] != a2[i]) return false;
            }

            return true;
        }
    }
}
