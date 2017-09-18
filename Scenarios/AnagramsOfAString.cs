using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class AnagramsOfAString
    {
        public void Test()
        {
            var res = this.Anagrams("abc");
            res.Print();
        }

        public IList<string> Anagrams(string str)
        {
            var ret = new List<string>();
            var sb = new StringBuilder();
            var used = new bool[str.Length];
            Permute(str, ret, sb, used);
            return ret;
        }

        private void Permute(string str, IList<string> ret, StringBuilder sb, bool[]used)
        {
            if (sb.Length == str.Length)
            {
                ret.Add(sb.ToString());
                return;
            }

            for (var i = 0; i < str.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    sb.Append(str[i]);
                    Permute(str, ret, sb, used);
                    sb.Remove(sb.Length - 1, 1);
                    used[i] = false;
                }
            }
        }
    }
}
