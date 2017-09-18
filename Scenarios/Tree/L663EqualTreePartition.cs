using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/equal-tree-partition/description/
     * 
     * Given a binary tree with n nodes, your task is to check if it's possible to partition the tree to two trees which have the equal sum of values after removing exactly one edge on the original tree.

Example 1:
Input:     
    5
   / \
  10 10
    /  \
   2   3

Output: True
Explanation: 
    5
   / 
  10
      
Sum: 15

   10
  /  \
 2    3

Sum: 15
Example 2:
Input:     
    1
   / \
  2  10
    /  \
   2   20

Output: False
Explanation: You can't split the tree into two trees with equal sum after removing exactly one edge on the tree.
Note:
The range of tree node value is in the range of [-100000, 100000].
1 <= n <= 10000
     */
    class L663EqualTreePartition
    {
        public void Test()
        {
            Console.WriteLine(this.CheckEqualTree(Helpers.GetTree(new int?[] { 0 })));
            Console.WriteLine(this.CheckEqualTree(Helpers.GetTree(new int?[] { 5, 10, 10, null, null, 2, 3 })));
        }

        public bool CheckEqualTree(TreeNode root)
        {
            if (root == null) return false;
            var dict = new Dictionary<TreeNode, int>();
            int count = 0;
            int s = TraverseInorder(root, dict, ref count);
            if (s % 2 != 0 || count == 1) return false;

            return CheckEqualTree(root, dict, s / 2);
        }

        public bool CheckEqualTree(TreeNode root, Dictionary<TreeNode, int> dict, int sum)
        {
            if (root != null)
            {
                if (dict[root] == sum) return true;
                return CheckEqualTree(root.left, dict, sum) || CheckEqualTree(root.right, dict, sum);
            }
            return false;
        }
        int TraverseInorder(TreeNode root, Dictionary<TreeNode, int> dict, ref int count)
        {
            var s = 0;
            if (root != null)
            {
                var l = TraverseInorder(root.left, dict, ref count);
                var r = TraverseInorder(root.right, dict, ref count);
                s = root.val + l + r;
                dict.Add(root, s);
                count++;
            }
            return s;
        }
    }
}
