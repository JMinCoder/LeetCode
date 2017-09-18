using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Given a sorted array consisting of only integers where every element appears twice except for one element 
     * which appears once. 
     * Find this single element that appears only once.
     * 
     * Example 1:
     * Input: [1,1,2,3,3,4,4,8,8]
     * Output: 2
     * Example 2:
     * Input: [3,3,7,7,10,11,11]
     * Output: 10
     * Note: Your solution should run in O(log n) time and O(1) space.
     */
    class L540SingleElementInSortedArray
    {
        public void Test()
        {
            //Console.WriteLine(this.SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }));
            //Console.WriteLine(this.SingleNonDuplicate(new int[] { 3, 3, 7, 7, 10, 11, 11 }));
            Console.WriteLine(this.SingleNonDuplicate(new int[] { 1, 1, 2 }));
        }
        public int SingleNonDuplicate(int[] nums)
        {
            return bs(nums, 0, nums.Length);
        }

        private int bs(int[] nums, int s, int e)
        {
            if (s < e)
            {
                int mid = s + (e - s) / 2;
                if ((mid-s+1)%2 == 0)
                {
                    //if (mid + 1 == e || mid - 1 == s) return nums[mid];
                    if (nums[mid] == nums[mid - 1])
                        return bs(nums, mid + 1, e);
                    if (nums[mid] == nums[mid + 1])
                        return bs(nums, s, mid);
                    return nums[mid];
                }
                else
                {
                    if (mid+1 == e || mid-1 == s) return nums[mid];
                    if (nums[mid] == nums[mid + 1])
                        return bs(nums, mid + 2, e);
                    if (nums[mid] == nums[mid - 1])
                        return bs(nums, s, mid-1);
                    return nums[mid];
                }
            }
            return -1;
        }
    }
}
