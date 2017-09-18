using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    class L233NumberOfDigitOne
    {
        private void Print(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public void Test()
        {
            Print(this.CountDigitOne(13));
        }

        public int CountDigitOne(int n)
        {
            int countr = 0;
            for (long i = 1; i <= n; i *= 10)
            {
                long divider = i * 10;
                countr += (int)((n / divider) * i + Math.Min(Math.Max(n % divider - i + 1, 0), i));
            }
            return countr;
        }
    }
}
