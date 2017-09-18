using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L017LetterCombinationsOfPhone
    {
        public void Test()
        {
            Console.WriteLine(String.Join(",", this.LetterCombinations("23")));
        }

        public IList<string> LetterCombinations(string digits)
        {
            var list = new List<string>();
            if (digits == null || digits.Length == 0) return list;

            var phone = new Dictionary<char, IList<string>>();
            phone.Add('2', new List<string>() { "a", "b", "c" });
            phone.Add('3', new List<string>() { "d", "e", "f" });
            phone.Add('4', new List<string>() { "g", "h", "i" });
            phone.Add('5', new List<string>() { "j", "k", "l" });
            phone.Add('6', new List<string>() { "m", "n", "o" });
            phone.Add('7', new List<string>() { "p", "q", "r", "s" });
            phone.Add('8', new List<string>() { "t", "u", "v" });
            phone.Add('9', new List<string>() { "w", "x", "y", "z" });
                        
            Recurse(digits, list, "", 0, phone);
            return list;    
        }

        private void Recurse(string digits, List<string> list, string str, int loc, Dictionary<char, IList<string>> phone)
        {
            if (loc == digits.Length)
            {
                list.Add(str);
            }
            else
            {
                for (int i=0;i<phone[digits[loc]].Count;i++)
                {
                    this.Recurse(digits, list, str + phone[digits[loc]][i], loc + 1, phone);
                }
            }
        }
    }
}

