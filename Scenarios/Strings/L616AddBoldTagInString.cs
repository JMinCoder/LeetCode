using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * https://leetcode.com/problems/add-bold-tag-in-string
     * 
     * Given a string s and a list of strings dict, you need to add a closed pair of bold tag <b> and </b> to wrap the substrings in s that exist in dict. If two such substrings overlap, you need to wrap them together by only one pair of closed bold tag. Also, if two substrings wrapped by bold tags are consecutive, you need to combine them.
     * Example 1: Input: 
     * s = "abcxyz123"
     * dict = ["abc","123"]
     * Output:
     * "<b>abc</b>xyz<b>123</b>"
     * 
     * Example 2:
     * Input: 
     * s = "aaabbcc"
     * dict = ["aaa","aab","bc"]
     * Output:
     * "<b>aaabbc</b>c"
     * Note:
     * The given dict won't contain duplicates, and its length won't exceed 100.
     * All the strings in input have length in range [1, 1000].
     */
    class L616AddBoldTagInString
    {
        public void Test()
        {
            Console.WriteLine(this.AddBoldTag("abcxyz123", new string[] { "abc", "123" }));  // <b>abc</b>xyz<b>123</b>
            Console.WriteLine(this.AddBoldTag("aaabbcc", new string[] { "aaa", "aab", "bc" })); // <b>aaabbc</b>c
            Console.WriteLine(this.AddBoldTag("aaabbcc", new string[] { "aaa", "aab", "bc", "aaabbcc" }));
            Console.WriteLine(this.AddBoldTag("abcdef", new string[] { "ab", "bc", "cd", "de", "ef", "fg", "gh" })); //"<b>abcdef</b>"
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool IsWord = false;
        }

        TrieNode GetTrie(string[] dict)
        {
            var root = new TrieNode();

            foreach (var word in dict)
            {
                var current = root;
                foreach (var c in word)
                {
                    if (!current.children.ContainsKey(c))
                        current.children.Add(c, new TrieNode());

                    current = current.children[c];
                }
                current.IsWord = true;
            }

            return root;
        }

        public string AddBoldTag(string s, string[] dict)
        {
            var root = this.GetTrie(dict);

            var flag = new bool[s.Length];
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                var current = root;
                int j = i;
                while (j < len && current.children.ContainsKey(s[j]))
                {
                    current = current.children[s[j]];
                    j++;
                }

                if (current.IsWord)
                {
                    for (int k = i; k < j; k++)
                    {
                        flag[k] = true;
                    }
                }
            }

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (!flag[i])
                {
                    sb.Append(s[i]);
                    continue;
                }
                var j = i;
                while (j < s.Length && flag[j]) j++;
                sb.Append(string.Format("<b>{0}</b>", s.Substring(i, j - i)));
                i = j - 1;
            }

            return sb.ToString();

            //var result = s.ToCharArray().Select(x => x + "").ToList();
            //bool p = false;
            //for (int i = len - 1; i >= 0; i--)
            //{
            //    if (dp[i] && !p)
            //    {
            //        result.Insert(i + 1, "</b>");
            //    }

            //    if (dp[i] && (i == 0 || !dp[i - 1]))
            //    {
            //        result.Insert(i, "<b>");
            //    }
            //    p = dp[i];
            //}

            //return string.Join("", result);
        }

        // This works
        public string AddBoldTag3(string s, string[] dict)
        {
            int n = s.Length;
            int[] mark = new int[n + 1];
            foreach (var word in dict)
            {
                int i = -1;
                while ((i = s.IndexOf(word, i + 1)) >= 0)
                {
                    mark[i]++;
                    mark[i + word.Length]--;
                }
            }
            StringBuilder sb = new StringBuilder();
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                int cur = sum + mark[i];
                if (cur > 0 && sum == 0) sb.Append("<b>");
                if (cur == 0 && sum > 0) sb.Append("</b>");
                if (i == n) break;
                sb.Append(s[i]);
                sum = cur;
            }
            return sb.ToString();
        }

        // TLE
        public string AddBoldTag2(string s, string[] dict)
        {
            var flag = new bool[s.Length];

            for (int i = 0, end = 0; i < s.Length; i++)
            {
                foreach (var word in dict)
                {
                    if (s.IndexOf(word, i) == i)
                    {
                        end = Math.Max(end, i + word.Length);
                    }
                }
                flag[i] = end > i;
            }

            var sb = new StringBuilder();
            for (var i=0;i<s.Length;i++)
            {
                if (!flag[i])
                {
                    sb.Append(s[i]);
                    continue;
                }
                var j = i;
                while (j < s.Length && flag[j]) j++;
                sb.Append(string.Format("<b>{0}</b>", s.Substring(i, j - i)));
                i = j-1;
            }

            return sb.ToString();
        }

        // TLE
        public string AddBoldTag1(string s, string[] dict)
        {
            var flag = new bool[s.Length];

            foreach (var word in dict)
            {
                var len = word.Length;
                for (var i = 0; i <= s.Length - len; i++)
                {
                    if (s.IndexOf(word, i) == i)
                    {
                        for (var j = i; j < i + len; j++) flag[j] = true;
                    }
                }
            }

            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (!flag[i])
                {
                    sb.Append(s[i]);
                    continue;
                }
                var j = i;
                while (j < s.Length && flag[j]) j++;
                sb.Append(string.Format("<b>{0}</b>", s.Substring(i, j - i)));
                i = j - 1;
            }

            return sb.ToString();
        }
    }
}
