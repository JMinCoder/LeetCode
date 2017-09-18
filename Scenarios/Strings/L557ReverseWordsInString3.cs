using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Note: In the string, each word is separated by single space and there will not be any extra space in the string.
     */
    class L557ReverseWordsInString3
    {
        public void Test()
        {
            var s = "Let's take LeetCode contest";
            //var s = "I love u";
            Console.WriteLine(s);
            Console.WriteLine(this.ReverseWords(s));
        }

        public string ReverseWords(string s)
        {
            var sb = new StringBuilder(s.Length);

            int prev = 0;
            for (var i=0;i<s.Length;i++)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    sb.Append(this.Reverse(s, prev, i));
                    sb.Append(s[i]);
                    prev = i + 1;
                }
            }

            if (prev < s.Length)
            {
                sb.Append(this.Reverse(s, prev, s.Length));
            }

            return sb.ToString();
            //return this.Reverse(sb.ToString(), 0, s.Length);
        }

        private string Reverse(string s, int start, int end)
        {
            var sb = new StringBuilder(s.Substring(start, end-start));

            start = 0;
            end = sb.Length - 1;
            while (start < end)
            {
                var t = sb[start];
                sb[start] = sb[end];
                sb[end] = t;

                start++;
                end--;
            }

            return sb.ToString();
        }
    }
}
