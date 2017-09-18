using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * Given two strings representing two complex numbers.

You need to return a string representing their multiplication. Note i2 = -1 according to the definition.

Example 1:
Input: "1+1i", "1+1i"
Output: "0+2i"
Explanation: (1 + i) * (1 + i) = 1 + i2 + 2 * i = 2i, and you need convert it to the form of 0+2i.
Example 2:
Input: "1+-1i", "1+-1i"
Output: "0+-2i"
Explanation: (1 - i) * (1 - i) = 1 + i2 - 2 * i = -2i, and you need convert it to the form of 0+-2i.
*/

    class L537ComplexNumberMultiplication
    {
        public void Test()
        {
            //Console.WriteLine(this.ComplexNumberMultiply("1+1i", "1+1i"));
            //Console.WriteLine(this.ComplexNumberMultiply("1 + -1i", "1 + -1i"));
            Console.WriteLine(this.ComplexNumberMultiply("78+-76i", "-86+72i")); //"-1236+12152i"
        }

        public string ComplexNumberMultiply(string a, string b)
        {
            var p1 = this.GetNumber(a);
            var p2 = this.GetNumber(b);

            Console.WriteLine("{2} => {0} + {1}i", p1.Key, p1.Value, a);
            Console.WriteLine("{2} => {0} + {1}i", p2.Key, p2.Value, b);

            var sb = new StringBuilder();

            sb.Append((p1.Key * p2.Key) - (p1.Value * p2.Value));
            sb.Append("+");
            sb.Append((p1.Key * p2.Value) + (p1.Value * p2.Key));
            sb.Append("i");
            return sb.ToString();
        }

        private KeyValuePair<int, int> GetNumber(string str)
        {
            int x = 0;
            int y = 0;
            int i = 0;
            bool isNeg = false;
            str = str.TrimStart();
            if (str[i] == '-') { isNeg = true; i++; }
            while (i!=str.Length)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    x = x * 10 + str[i] - '0';
                }
                else
                {
                    break;
                }
                i++;
            }
            if (isNeg) { x = -x; isNeg = false; }

            while (i != str.Length && str[i] == ' ') i++;
            if (str[i] == '+') i++;
            while (i != str.Length && str[i] == ' ') i++;
            if (str[i] == '-') { i++; isNeg = true; }
            while (i != str.Length && str[i] == ' ') i++;
            while (i != str.Length)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    y = y * 10 + str[i] - '0';
                }
                else
                {
                    break;
                }
                i++;
            }
            if (isNeg) { y = -y; isNeg = false; }

            return new KeyValuePair<int, int>(x, y);
        }
    }
}
