using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scenarios
{
    class Capital
    {
        public void Test()
        {
            string[] words = { "USA", "Flag", "FlaG", "I", "", "uSA", "Usa", "FlAg" };

            foreach (var word in words)
            {
                if (this.detectCapitalUse(word) != this.detectCapitalUse2(word))
                {
                    Console.WriteLine("{0} : {1} vs {2}", word, this.detectCapitalUse(word), this.detectCapitalUse2(word));
                }
            }
        }
        public bool detectCapitalUse(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool firstCapital = false;

            if (Char.IsUpper(word, 0))
            {
                if (word.Length == 1) return true;
                firstCapital = true;
            }
            for (int i = 1; i < word.Length; i++)
            {
                if (Char.IsUpper(word, i)) hasUpperCase = true;
                else hasLowerCase = true;
            }
            if (hasUpperCase)
            {
                if (hasLowerCase || !firstCapital) return false;
                return true;
            }

            return true;
        }

        public bool detectCapitalUse2(string word)
        {
            string pat = "^([A-Z]+|[a-z]+|[A-Z][a-z]+)$";
            Match m = Regex.Match(word, pat);

            return m.Success;
        }
    }
}
