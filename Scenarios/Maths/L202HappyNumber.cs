using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * Write an algorithm to determine if a number is "happy".
     * A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the 
     * squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. 
     * Those numbers for which this process ends in 1 are happy numbers.
     * Example: 19 is a happy number
     * 1^2 + 9^2 = 82
     * 8^2 + 2^2 = 68
     * 6^2 + 8^2 = 100
     * 1^2 + 0^2 + 0^2 = 1
     */
    class L202HappyNumber
    {
        public void Test()
        {
            Console.WriteLine(this.IsHappy(19));
            //for (var j = 0; j < 20; j++)
            //{
            //    Console.WriteLine("{0} : {1}", j, this.IsHappy(j));
            //}
        }

        public bool IsHappy(int n)
        {
            var hash = new HashSet<int>();

            hash.Add(n);
            while (true)
            {
                n = this.Happy(n);
                
                if (n ==1)
                {
                    return true;
                }
                if (hash.Contains(n)) return false;
                hash.Add(n);
            } 
        }

        private int Happy(int num)
        {
            int ret = 0;
            while (num > 0)
            {
                ret += (num % 10) * (num % 10);
                num /= 10;
            }
            return ret;
        }
    }
}
