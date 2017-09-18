using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
     * 
     * Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.

Example 1:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 9

Output: True
Example 2:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 28

Output: False
*/

    class L653TwoSumBST
    {
        public void Test()
        {
            Console.WriteLine(this.FindTarget(Helpers.GetTree(new int?[] { 5, 3, 6, 2, 4, 7 }), 9));
            Console.WriteLine(this.FindTarget(Helpers.GetTree(new int?[] { 5, 3, 6, 2, 4, 7 }), 90));
            Console.WriteLine(this.FindTarget(Helpers.GetTree(new int?[] { 2, 0, 3, -4, 1 }), -1));
        }

        public bool FindTarget(TreeNode root, int k)
        {
            return FindInTree(root, root, k);
        }

        bool FindInTree(TreeNode root, TreeNode curNode, int k)
        {
            if (curNode == null) return false;

            if (FindVal(root, curNode, k - curNode.val)) return true;

            return FindInTree(root, curNode.left, k) || FindInTree(root, curNode.right, k);
        }

        bool FindVal(TreeNode root, TreeNode curNode, int k)
        {
            if (root == null) return false;
            if (root.val == k && root != curNode) return true;
            return FindVal(root.left, curNode, k) || FindVal(root.right, curNode, k);
        }
    }
}
