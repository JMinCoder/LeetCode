using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * We define the Perfect Number is a positive integer that is equal to the sum of all its positive divisors except itself.

Now, given an integer n, write a function that returns true when it is a perfect number and false when it is not.

        Input: 28
Output: True
Explanation: 28 = 1 + 2 + 4 + 7 + 14
Note: The input number n will not exceed 100,000,000. (1e8)
     */
    class L507PerfectNumber
    {
        public void Test()
        {
            for (var i = 1; i < 100000000; i++)
            {
                if (this.CheckPerfectNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public bool CheckPerfectNumber(int num)
        {
            if (num == 1) return false;
            int sum = 1;
            for (var i=2;i<=Math.Sqrt(num);i++)
            {
                if (num%i == 0)
                {
                    sum += i;
                    sum += (num / i);
                }
            }

            return sum == num;
        }
    }
}
