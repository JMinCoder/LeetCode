using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    class L087ScrambleString
    {
        public void Test()
        {
            Console.WriteLine(this.IsScramble1("a", "a")); // True
            Console.WriteLine(this.IsScramble1("great", "rgtae")); // True
            Console.WriteLine(this.IsScramble1("abcd", "bdac"));

            Console.WriteLine(this.IsScramble1(
            "bcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcdebcde",
            "cebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebdcebd"));
        }

        public bool IsScramble1(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            var dic = new Dictionary<string, bool>();
            return S1Helper(s1, s2, dic);
        }

        private bool S1Helper(string s1, string s2, Dictionary<string, bool> dic)
        { 
            var a1 = new int[26];
            var a2 = new int[26];

            if (s1.Length == 0) return true;
            if (s1.Length == 1 && s1.Equals(s2))
            {
                return true;
            }

            if (dic.ContainsKey(s1 + s2)) return dic[s1 + s2];

            bool res = false;
            for (var i = 1; i < s1.Length && !res; i++)
            {
                res = res || (this.S1Helper(s1.Substring(0, i), s2.Substring(0, i), dic) &&
                    this.S1Helper(s1.Substring(i), s2.Substring(i), dic));

                res = res || (this.S1Helper(s1.Substring(0, i), s2.Substring(s1.Length - i), dic) &&
                    this.S1Helper(s1.Substring(i), s2.Substring(0, s1.Length - i), dic));
            }

            dic[s1 + s2] = res;
            return res;
        }

        public bool IsScramble(string s1, string s2)
        {
            var a1 = new int[26];
            var a2 = new int[26];

            if (s1.Length != s2.Length) return false;

            if (s1.Equals(s2)) return true;

            for (var i = 0; i < s1.Length; i++)
            {
                a1[s1[i] - 'a']++;
                a2[s2[i] - 'a']++;
            }

            for (var i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }

            for (var i=1;i<s1.Length;i++)
            {
                if (this.IsScramble(s1.Substring(0, i), s2.Substring(0, i)) &&
                    this.IsScramble(s1.Substring(i), s2.Substring(i)))
                    return true;

                if (this.IsScramble(s1.Substring(0, i), s2.Substring(s1.Length - i)) &&
                    this.IsScramble(s1.Substring(i), s2.Substring(0, s1.Length - i)))
                    return true;
            }
            return false;
        }
    }
}
