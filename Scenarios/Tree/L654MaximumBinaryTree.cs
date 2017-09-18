using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/maximum-binary-tree/description/
     * 
     * Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].
    */
    class L654MaximumBinaryTree
    {
        public void Test()
        {
            Helpers.BFS(this.ConstructMaximumBinaryTree(new int[] { 3, 2, 1, 6, 0, 5 }));
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTree(nums, 0, nums.Length);
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums, int l, int h)
        {
            if (l < h)
            {
                int max = l;
                for (var i = l + 1; i < h; i++)
                {
                    if (nums[i] > nums[max]) max = i;
                }
                var root = new TreeNode(nums[max]);
                root.left = this.ConstructMaximumBinaryTree(nums, l, max);
                root.right = this.ConstructMaximumBinaryTree(nums, max + 1, h);
                return root;
            }
            return null;
        }
    }
}
