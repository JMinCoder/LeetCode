using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L049GroupAnagrams
    {
        public void Test()
        {
            var res = this.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat"  });
            res.Print();
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();
            for (var i=0;i<strs.Length;i++)
            {
                var s = String.Concat(strs[i].OrderBy(c => c));
                if (dict.ContainsKey(s))
                {
                    dict[s].Add(strs[i]);
                }
                else
                {
                    dict.Add(s, new List<string>() { strs[i] });
                }
            }
            var ret = new List<IList<string>>();
            foreach (var key in dict.Keys)
            {
                ret.Add(dict[key]);
            }
            return ret;
        }
    }
}
