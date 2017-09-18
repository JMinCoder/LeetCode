using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Given a roman numeral, convert it to an integer.
     * Input is guaranteed to be within the range from 1 to 3999.
     */
    class L013RomanToInteger
    {
        public void Test()
        {
            var intToRoman = new L012IntToRoman();

            for (var i = 1; i < 3999; i++)
            {
                if (i != this.RomanToInt(intToRoman.IntToRoman2(i)))
                {
                    Console.WriteLine("{0} : {1} : {2}", i, intToRoman.IntToRoman2(i), this.RomanToInt(intToRoman.IntToRoman2(i)));
                }
            }

            //Console.WriteLine(this.RomanToInt("MMMCD"));
        }

        public int RomanToInt(string s)
        {
            int[] N = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] R = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            int num = 0;

            for (int i = 0; i < N.Length; i++)
            {
                while (s.Length >= R[i].Length && s.Substring(0, R[i].Length).Equals(R[i]))
                {
                    num += N[i];
                    s = s.Substring(R[i].Length);
                }
            }
            return num;
        }
    }
}
