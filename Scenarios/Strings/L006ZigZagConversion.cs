using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
     * (you may want to display this pattern in a fixed font for better legibility)
     * P   A   H   N
     * A P L S I I G
     * Y   I   R
     * And then read line by line: "PAHNAPLSIIGYIR"
     * Write the code that will take a string and make this conversion given a number of rows:
     * 
     * convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".
     */
    class L006ZigZagConversion
    {
        public void Test()
        {
            var inputs = new List<KeyValuePair<string, KeyValuePair<int, string>>>();
            inputs.Add(new KeyValuePair<string, KeyValuePair<int, string>>(
                "PAYPALISHIRING", new KeyValuePair<int, string>(3, "PAHNAPLSIIGYIR")));

            Console.WriteLine(this.Convert3("PAYPALISHIRING", 4));
            //for (var i=0;i<inputs.Count;i++)
            //{
            //    if (!this.Convert(inputs[i].Key, inputs[i].Value.Key).Equals(inputs[i].Value.Value))
            //    {
            //        Console.WriteLine("Convert({0}, {1}) is {2} != {3}", 
            //            inputs[i].Key, 
            //            inputs[i].Value.Key,
            //            this.Convert(inputs[i].Key, inputs[i].Value.Key),
            //            inputs[i].Value.Value);
            //    }
            //}
        }

        public string Convert(string s, int numRows)
        {
            var sbs = new List<StringBuilder>(numRows);
            int i = 0;
            for (i = 0;i<numRows; i++)
            {
                sbs.Add(new StringBuilder());
            }

            i = 0;
            while (i<s.Length)
            {
                for (var j=0;j<numRows && i < s.Length; j++,i++)
                {
                    sbs[j].Append(s[i]);
                }
                for (var j=numRows-2; j>0 && i < s.Length; j--,i++)
                {
                    sbs[j].Append(s[i]);
                }
            }

            for (i = 1; i < numRows; i++)
            {
                sbs[0].Append(sbs[i].ToString());
            }

           

            return sbs[0].ToString();
        }

        public string Convert2(string s, int numRows)
        {
            //actually to find the pattern of indexes
            //special conditions numRows:1
            if (numRows == 1) return s;
            int offset = 2 * numRows - 2;
            var result = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                // first and last row increase a model
                // zigzag pattern is an upside down N pattern
                for (int j = 0; j * offset + i < s.Length; j++)
                {
                    result.Append(s[j * offset + i]);
                    if (i != 0 && i != numRows - 1 && (j + 1) * offset - i < s.Length)
                        result.Append(s[(j + 1) * offset - i]);
                }
            }
            return result.ToString();
        }

        public string Convert3(string s, int numRows)
        {
            var result = new StringBuilder();
            if (numRows == 1) return s;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0, k = i; k < s.Length; j++)
                {
                    Console.Write("{0,2} ", k);
                    result.Append(s[k]);
                    k += ((i == 0 || (j % 2 == 0)) && (i != numRows - 1)) ? 2 * (numRows - i - 1) : 2 * i;
                }
                Console.WriteLine("");
            }
            return result.ToString();
        }
    }
}
