using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, you need to find the length of Longest Consecutive Path in Binary Tree.

Especially, this path can be either increasing or decreasing. For example, [1,2,3,4] and [4,3,2,1] are both considered valid, 
but the path [1,2,4,3] is not valid. On the other hand, the path can be in the child-Parent-child order, where not necessarily be parent-child order.

Example 1:
Input:
        1
       / \
      2   3
Output: 2
Explanation: The longest consecutive path is [1, 2] or [2, 1].
Example 2:
Input:
        2
       / \
      1   3
Output: 3
Explanation: The longest consecutive path is [1, 2, 3] or [3, 2, 1].
     */
    class L549BinaryTreeLongestConsecutiveSequence2
    {
        public void Test()
        {
            var tree = Helpers.GetTree(new int?[] { 2, 1, 3 });
            Console.WriteLine(this.LongestConsecutive(tree));
        }

        public int LongestConsecutive(TreeNode root)
        {
            int less = 0;
            int great = 0;
            int max = 0;
            this.PostOrder(root, ref less, ref great, ref max);
            return max;
        }

        private void PostOrder(TreeNode root, ref int less, ref int great, ref int max)
        {
            if (root == null) return;
            int ll = 0, lg = 0;
            int rl = 0, rg = 0;
            this.PostOrder(root.left, ref ll, ref lg, ref max);
            this.PostOrder(root.right, ref rl, ref rg, ref max);

            less = 1; great = 1;

            if (root.left != null) 
            {
                if (root.val - root.left.val == 1)
                {
                    less = ll + 1;
                }
                else if (root.val - root.left.val == -1)
                {
                    great = lg + 1;
                }
            }
            if (root.right != null)
            {
                if (root.val - root.right.val == 1)
                {
                    less = Math.Max(less, rl + 1);
                }
                else if (root.val - root.right.val == -1)
                {
                    great = Math.Max(great, rg + 1);
                }
            }

            max = Math.Max(max, less + great - 1);
        }
    }
}
