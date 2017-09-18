using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Bits
{
    /*
     * Given an array of integers, every element appears three times except for one, which appears exactly once. Find that single one.
     * Note:
     * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
     */
    class L137SingleNumber2
    {
        public void Test()
        {
            Console.WriteLine(this.SingleNumber(new int[] { 3, 3, 2, 3}));
        }
        public int SingleNumber(int[] nums)
        {
            int ones = 0, twos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ones = (ones ^ nums[i]) & ~twos;
                twos = (twos ^ nums[i]) & ~ones;
            }
            return ones;
        }
    }
}
