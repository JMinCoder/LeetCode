using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/split-array-into-consecutive-subsequences/description/
     * 
     * 
Example 1:
Input: [1,2,3,3,4,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3
3, 4, 5
Example 2:
Input: [1,2,3,3,4,4,5,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3, 4, 5
3, 4, 5
Example 3:
Input: [1,2,3,4,4,5]
Output: False
Note:
The length of the input is in range of [1, 10000]
    */
    class L659SplitArrayIntoConsecutiveSubsequences
    {
        public void Test()
        {
            Console.WriteLine(this.IsPossible(new int[] { 3, 3, 3, 4, 4, 4, 5, 5, 5 }));
            Console.WriteLine(this.IsPossible(new int[] { 1, 2, 3, 4, 4, 5 }));
            Console.WriteLine(this.IsPossible(new int[] { 1, 2, 3, 3, 4, 5 }));
            Console.WriteLine(this.IsPossible(new int[] { 1, 2, 3, 3, 4, 4, 5, 5 }));
            Console.WriteLine(this.IsPossible(new int[] { 1, 2, 3 }));
        }

        public bool IsPossible(int[] nums)
        {
            if (nums.Length < 3) return false;

            var list = new List<List<int>>();

            list.Add(new List<int> { nums[0] });

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    list[list.Count - 1].Add(nums[i]);
                }
                else if (nums[i] == nums[i - 1])
                {
                    if (list.Count == 1)
                    {
                        list.Add(new List<int> { nums[i] });
                    }
                    else
                    {
                        bool flag = false;
                        for (var j = list.Count - 2; j >= 0; j--)
                        {
                            if (list[j][list[j].Count - 1] == nums[i] - 1)
                            {
                                list[j].Add(nums[i]);
                                flag = true;
                                break;
                            }

                        }
                        if (!flag)
                        {
                            list.Add(new List<int> { nums[i] });
                        }
                    }
                }
                else
                {
                    list.Add(new List<int> { nums[i] });
                }
            }

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Count < 3) return false;
            }

            return true;
        }
    }
}
