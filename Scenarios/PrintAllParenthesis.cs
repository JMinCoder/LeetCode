using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class PrintAllParenthesis
    {
        public void Test()
        {
            PrintAll(3);
        }

        public void PrintAll(int n)
        {
            Recurse(string.Empty, n, n);
        }

        private void Recurse(string s, int open, int close)
        {
            if (open == 0 && close == 0)
            {
                Console.WriteLine(s);
                return;
            }
            if (open == close)
            {
                Recurse(s + "(", open - 1, close);
            }
            else
            {
                Recurse(s + ")", open, close - 1);
                if (open > 0)
                {
                    Recurse(s + "(", open-1, close);
                }
            }
        }
    }
}
