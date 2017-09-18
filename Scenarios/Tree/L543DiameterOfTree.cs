using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Example:
Given a binary tree 
          1
         / \
        2   3
       / \     
      4   5    
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

Note: The length of path between two nodes is represented by the number of edges between them.
     */
    class L543DiameterOfTree
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int max = 0;
            Dfs(root, ref max);
            return max;
        }

        private int Dfs(TreeNode root, ref int max)
        {
            if (root == null) return 0;
            int l = Dfs(root.left, ref max);
            int r = Dfs(root.right, ref max);
            max = Math.Max(max, l + r);
            return Math.Max(l, r) + 1;
        }
    }
}
