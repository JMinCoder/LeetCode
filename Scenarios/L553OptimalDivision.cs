using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Given a list of positive integers, the adjacent integers will perform the float division. For example, [2,3,4] -> 2 / 3 / 4.
     * However, you can add any number of parenthesis at any position to change the priority of operations.
     *  
     * You should find out how to add parenthesis to get the ******maximum result*******, 
     * and return the corresponding expression in string format. 
     * 
     * Your expression should NOT contain redundant parenthesis.
     * 
     * Example:
     * Input: [1000,100,10,2]
     * Output: "1000/(100/10/2)"
     * Explanation:
     * 1000/(100/10/2) = 1000/((100/10)/2) = 200
     * However, the bold parenthesis in "1000/((100/10)/2)" are redundant, 
     * since they don't influence the operation priority. So you should return "1000/(100/10/2)". 
     * 
     * Other cases:
     * 1000/(100/10)/2 = 50
     * 1000/(100/(10/2)) = 50
     * 1000/100/10/2 = 0.5
     * 1000/100/(10/2) = 2
     * 
     * Note:
     * The length of the input array is [1, 10].
     * Elements in the given array will be in range [2, 1000].
     * There is only one optimal division for each test case.
     */
    class L553OptimalDivision
    {
        public void Test()
        {
            var arr = new int[] { 1000, 100, 10, 2 };
            Console.WriteLine(this.OptimalDivision(arr));
        }

        // I thought it's similar to Matrix-chain multiplication in CLRS, so I also use DP, which takes O(n^3) and is hard to construct final expression. Very bad idea to use DP.
        public string OptimalDivision(int[] nums)
        {
            if (nums == null || nums.Length == 0) return string.Empty;
            var sb = new StringBuilder(nums[0].ToString());

            if (nums.Length == 1) return sb.ToString();
            if (nums.Length == 2)
            {
                sb.Append("/");
                sb.Append(nums[1].ToString());
            }
            else
            {
                sb.Append("/(");
                sb.Append(nums[1].ToString());
                for (var i = 2; i < nums.Length; i++)
                {
                    sb.Append("/");
                    sb.Append(nums[i].ToString());
                }
                sb.Append(")");
            }
            return sb.ToString();
        }
    }
}
