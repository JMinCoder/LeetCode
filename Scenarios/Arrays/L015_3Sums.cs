using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note: The solution set must not contain duplicate triplets.

For example, given array S = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
     */
    class L015_3Sums
    {
        public void Test()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 , -1, -1, -1, 2, 2};
            var res = this.ThreeSum(nums);
            Console.WriteLine(
                String.Join(Environment.NewLine,
                res.Select(x => String.Join(", ", x))));                
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            for (var i=0;i<nums.Length;i++)
            {
                while (i > 0 &&  i < nums.Length && nums[i] == nums[i - 1]) i++;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if ( sum == 0 )
                    {
                        var r = new List<int>();
                        r.Add(nums[i]);
                        r.Add(nums[left]);
                        r.Add(nums[right]);

                        result.Add(r);

                        left++;
                        while (left < right && nums[left] == nums[left - 1]) left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
    }
}
