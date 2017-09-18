using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.
     * You may assume the integer do not contain any leading zero, except the number 0 itself.
     * The digits are stored such that the most significant digit is at the head of the list.
     */
    class L066PlusOne
    {
        public void Test()
        {
            int[][] ns = {
                    new int[] { },
                    new int[] {0},
                    new int[] { 9 },
                    new int[] {1, 0 },
                    new int[] {3, 2, 1 },
                    new int[] {1, 3, 2},
                    new int[] {1, 1 , 5 },
                    new int[] { 9, 9, 9 },
                    new int[] {1, 2, 3, 4},
            };

            for (var i=0;i<ns.Length;i++)
            {
                Console.WriteLine("{0,5} + 1 = {1,5}",
                    String.Join("", ns[i]),
                    String.Join("", this.PlusOne(ns[i])));
            }
        }

        public int[] PlusOne(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }
            if (digits.Length > 0 && digits[0] == 0)
            {
                int[] ret = new int[digits.Length + 1];
                ret[0] = 1;
                return ret;
            }
            return digits;
        }
    }
}
