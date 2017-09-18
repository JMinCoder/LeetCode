using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L012IntToRoman
    {
        public void Test()
        {
            Console.WriteLine("Int to Roman");
            int[] nums = { 0, 1, 9, 10, 11, 15, 49, 78, 100, 200, 299, 1234, 3999 };
            foreach (var n in nums)
            {
                if (!this.IntToRoman(n).Equals(this.IntToRoman2(n)))
                {
                    Console.WriteLine("{0} : {1} {2}", n, this.IntToRoman(n), this.IntToRoman2(n));
                }
            }
        }

        public string IntToRoman(int num)
        {
            string[] M = { "", "M", "MM", "MMM" };
            string[] C = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] X = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] I = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        public string IntToRoman2(int num)
        {
            int[] N = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] R = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var sb = new StringBuilder();
            for (int i=0;i<N.Length;i++)
            {
                while (num >= N[i])
                {
                    num -= N[i];
                    sb.Append(R[i]);
                }
            }
            return sb.ToString();
        }
    }
}
