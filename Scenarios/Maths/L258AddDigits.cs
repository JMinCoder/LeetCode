using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
     * For example:
     * Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
     * Follow up:
     * Could you do it without any loop/recursion in O(1) runtime?
     */
    class L258AddDigits
    {
        public void Test()
        {
            //int[] nums = { 0, 1, 9, 11, 38, 55, 100, 887 };
            //for (var i = 0; i < nums.Length; i++)
            //{
            //    Console.WriteLine("{0} : {1} : {2}", nums[i], this.AddDigits(nums[i]), this.AddDigits2(nums[i]));
            //}
            for (var j = 0; j<100;j++)
            {
                if (this.AddDigits(j) != AddDigits2(j))
                {
                    Console.WriteLine("{0}=> {1}, {2}", j, this.AddDigits(j), AddDigits2(j));
                }
            }
        }

        public int AddDigits(int num)
        {
            int ret = 0;
            while (num > 0)
            {
                ret += num % 10;
                num /= 10;
            }
            if (ret > 9) return AddDigits(ret);
            return ret;
        }

        public int AddDigits2(int num)
        {
            return num % 9 == 0 ? num == 0 ? 0 : 9 : num % 9;
        }
    }
}
