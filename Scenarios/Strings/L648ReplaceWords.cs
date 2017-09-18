using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * https://leetcode.com/problems/replace-words/#/description
     * 
     * In English, we have a concept called root, which can be followed by some other words to form another longer word - let's call this word successor. For example, the root an, followed by other, which can form another word another.

Now, given a dictionary consisting of many roots and a sentence. You need to replace all the successor in the sentence with the root forming it. If a successor has many roots can form it, replace it with the root with the shortest length.

You need to output the sentence after the replacement.

Example 1:
Input: dict = ["cat", "bat", "rat"]
sentence = "the cattle was rattled by the battery"
Output: "the cat was rat by the bat"
Note:
The input will only have lower-case letters.
1 <= dict words number <= 1000
1 <= sentence words number <= 1000
1 <= root length <= 100
1 <= sentence words length <= 1000

     */
    class L648ReplaceWords
    {
        public void Test()
        {
            Console.WriteLine(this.ReplaceWords(new List<string> { "cat", "bat", "rat", "he", "abcd" }, "the cattle was rattled by the battery"));
        }

        public string ReplaceWords(IList<string> dict1, string sentence)
        {
            var dict = dict1.ToList();
            dict.Sort((a, b) =>
            {
                if (a.Length == b.Length)
                    return a.CompareTo(b);
                else
                {
                    return a.Length - b.Length;
                }
            });

            var split = sentence.Split(' ');
            for (var i = 0; i < split.Length; i++)
            {
                for (var j = 0; j < dict.Count; j++)
                {
                    if (split[i].StartsWith(dict[j]))
                    {
                        split[i] = dict[j];
                        break;
                    }
                }
            }

            var sb = new StringBuilder();
            for (var i = 0; i < split.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(" ");
                }

                sb.Append(split[i]);
            }
            return sb.ToString();
        }
    }
}
