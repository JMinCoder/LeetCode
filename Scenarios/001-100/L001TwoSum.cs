using System;
using System.Collections.Generic;

namespace Scenarios
{
    public class L001TwoSums {

        public void Test()
        {
            var r = this.TwoSum(new int[] {2, 7, 11, 15}, 9);
            Console.WriteLine("Result : {0}", String.Join(", ", r)); // 0,1
        }
        public int[] TwoSum(int[] nums, int target) {
            var d = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (d.ContainsKey(nums[i]))
                {
                    d[nums[i]]++;
                }
                else
                {
                    d.Add(nums[i], 1);
                }
            }
            for (var i = 0; i < nums.Length; i++)
            {
                int j = target - nums[i];
                if (d.ContainsKey(j))
                {
                    if (nums[i] != j || d[nums[i]] > 1)
                    {
                        for (var k = 0; k < nums.Length; k++)
                        {
                            if (nums[k] == j && k != i)
                            {
                                return new int[] { i, k };
                            }
                        }
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
}