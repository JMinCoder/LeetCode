using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L238ProductOfArrayExceptSelf
    {
        public void Test()
        {
            int[][] hs = {
                /*
                    new int[] { },
                    new int[] {5 }, */
                    new int[] {4, 5 },
                    new int[] {1,2,3,4 },
                    new int[] {8,2,3,4 }
            };
            
            foreach (var h in hs)
            {
                Console.WriteLine(String.Join(", ", this.ProductExceptSelf3(h)));
                if (!Enumerable.SequenceEqual(this.ProductExceptSelf1(h), this.ProductExceptSelf1(h)))
                {
                    Console.WriteLine("Diff: " + String.Join(", ", this.ProductExceptSelf1(h)));
                    Console.WriteLine("Diff: " + String.Join(", ", this.ProductExceptSelf2(h)));
                    Console.WriteLine("Diff: " + String.Join(", ", this.ProductExceptSelf3(h)));
                }
            }
        }

        public int[] ProductExceptSelf1(int[] nums)
        {
            var prod = 1;
            for (var i=0;i<nums.Length;i++)
            {
                prod *= nums[i];
            }
            var output = new int[nums.Length];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = prod / nums[i];
            }
            return output;
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            if (nums.Length == 0) return nums;
            int n = nums.Length;
            int []left = new int[n];
            int []right = new int[n];
            left[0] = 1; right[n - 1] = 1;
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
                right[n - 1 - i] = right[n - i] * nums[n - i];
            }
            var output = new int[nums.Length];
            for (int i = 0; i < n; i++)
            {
                output[i] = left[i] * right[i];
            }
            return output;
        }

        public int[] ProductExceptSelf3(int[] nums)
        {
            if (nums.Length == 0) return nums;
            int n = nums.Length;
            var output = new int[nums.Length];
            for (int i = 1; i < n; i++)
            {
                output[i] = 1;
            }
            int left = 1;
            int right = 1;
            
            for (int i = 0; i < n; i++)
            {
                output[i] *= left;
                output[n-i-1] *= right;

                left = left * nums[i];
                right = right * nums[n- i - 1];
            }
            return nums;
        }
    }
}

