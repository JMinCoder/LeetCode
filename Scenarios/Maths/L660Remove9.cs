using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * https://leetcode.com/problems/remove-9/description/
     * 
     * Start from integer 1, remove any integer that contains 9 such as 9, 19, 29...

So now, you will have a new integer sequence: 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, ...

Given a positive integer n, you need to return the n-th integer after removing. Note that 1 will be the first integer.

Example 1:
Input: 9
Output: 10
Hint: n will not exceed 9 x 10^8.


     */
    class L660Remove9
    {
        public void Test()
        {
            Console.WriteLine(this.NewInteger(8));
            Console.WriteLine(this.NewInteger(9));
            Console.WriteLine(this.NewInteger(10));
            Console.WriteLine(this.NewInteger(18));
            Console.WriteLine(this.NewInteger(19));
            Console.WriteLine(this.NewInteger(89));
            for (var i = 9; i < 100; i++)
            {
                Console.WriteLine("{0} : {1} ", i, this.NewInteger(i));
            }
        }

        public int NewInteger(int n)
        {
            int remainder = 0;
            var finish = false;
            var res = new List<int>();

            while (!finish)
            {
                if (n == 0)
                {
                    finish = true;
                }
                else
                {
                    remainder = n % 9;
                    n = n / 9;
                    res.Add(remainder);
                }
                remainder = 0;
            }
            int r = 0;
            for (int i = res.Count - 1; i >= 0; i--)
            {
                r = r * 10 + res[i];
            }
            return r;
        }
    }
}
