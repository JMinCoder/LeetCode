using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits 
     * existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.
     * Example 1:
     *   Input: 12
     *   Output: 21
     * 
     * Example 2:
     *   Input: 21
     *   Output: -1
     */
    class L556NextGreaterElement3
    {
        public void Test()
        {
            //for (var i = 1; i < Int32.MaxValue; i++)
            //{
            //    if (this.NextGreaterElement(i) != this.NextGreaterElement2(i))
            //    {
            //        Console.WriteLine("{0} : {1} # {2}", i, this.NextGreaterElement(i), this.NextGreaterElement2(i));
            //    }
            //}
            //var n = 12443322;
            //var n = 1200000;
            //var n = 1999999;
            var n = 120;
            Console.WriteLine("{0} : {1}", n, this.NextGreaterElement(n));
        }

        public int NextGreaterElement(int n)
        {
            if (n == Int32.MaxValue)
            {
                return -1;
            }

            char[] a = ("" + n).ToCharArray();
            int i = a.Length - 2;
            while (i >= 0 && a[i + 1] <= a[i])
            {
                i--;
            }
            if (i < 0)
                return -1;
            int j = a.Length - 1;
            while (j >= 0 && a[j] <= a[i])
            {
                j--;
            }
            swap(a, i, j);
            reverse(a, i + 1);
            try
            {
                return Int32.Parse(new String(a));
            }
            catch (OverflowException)
            {

            }
            return -1;
        }


        public int NextGreaterElement2(int n)
        {
            if (n <= 0) return -1;
            if (n == Int32.MaxValue) return -1;

            var nums = n.ToString().ToCharArray();
            var i = nums.Length - 1;
            while (i >= 1 && nums[i] <= nums[i-1])
            {
                i--;
            }
            if (i == 0) return -1;
            this.swap(nums, i-1, i);
            var j = i;
            while ( j < nums.Length-1 && nums[j] <= nums[j+1])
            {
                this.swap(nums, j, j + 1);
            }
            this.reverse(nums, i + 1);
            return Int32.Parse(new String(nums));
        }

        private void reverse(char[] a, int start)
        {
            int i = start, j = a.Length - 1;
            while (i < j)
            {
                swap(a, i, j);
                i++;
                j--;
            }
        }
        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
