using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class L530Minimum_AbsoluteDiffInBST
    {
        /*
         * Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.
         * 
         * Input:

   1
    \
     3
    /
   2

Output:
1

Explanation:
The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).
         */

        public void Test()
        {
            var t = new TreeNode(1)
            {
                right = new TreeNode(30)
                { 
                    left = new TreeNode(28)
                }              
            };

            Console.WriteLine("Min diff : {0}", this.GetMinimumDifference(t));
        }
        public int GetMinimumDifference(TreeNode root)
        {
            int min = Int32.MaxValue;
            int left = -1;
            InOrder(root, ref left, ref min);
            return min;
        }

        private void InOrder(TreeNode root, ref int left, ref int min)
        {
            if (root != null)
            {
                InOrder(root.left, ref left, ref min);

                if (left != -1)
                {
                    min = Math.Min(min, Math.Abs(left - root.val));
                }
                left = root.val;
                InOrder(root.right, ref left, ref min);
            }
        }
    }
}
