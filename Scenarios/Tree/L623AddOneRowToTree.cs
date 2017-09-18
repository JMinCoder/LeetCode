using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/add-one-row-to-tree
     * 
     * Given the root of a binary tree, then value v and depth d, you need to add a row of nodes with value v at the given depth d. The root node is at depth 1.

The adding rule is: given a positive integer depth d, for each NOT null tree nodes N in depth d-1, create two tree nodes with value v as N's left subtree root and right subtree root. And N's original left subtree should be the left subtree of the new left subtree root, its original right subtree should be the right subtree of the new right subtree root. If depth d is 1 that means there is no depth d-1 at all, then create a tree node with value v as the new root of the whole original tree, and the original tree is the new root's left subtree.

Example 1:
Input: 
A binary tree as following:
       4
     /   \
    2     6
   / \   / 
  3   1 5   

v = 1

d = 2

Output: 
       4
      / \
     1   1
    /     \
   2       6
  / \     / 
 3   1   5   

Example 2:
Input: 
A binary tree as following:
      4
     /   
    2    
   / \   
  3   1    

v = 1

d = 3

Output: 
      4
     /   
    2
   / \    
  1   1
 /     \  
3       1
     */
    class L623AddOneRowToTree
    {
        public void Test()
        {
            var t = Helpers.GetTree(new int?[] { 4, 2, 6, 3, 1, 5 });
            t = this.AddOneRow(t, 1, 2);
            Helpers.BFS(t);
            Console.WriteLine("--------------");
            t = Helpers.GetTree(new int?[] { 4, 2, null, 3, 1 });
            t = this.AddOneRow(t, 1, 3);
            Helpers.BFS(t);
            Console.WriteLine("--------------");
            var t1 = Helpers.GetTree(new int?[] { 4, 2, 6, 3, 1, 5 });
            t1 = this.AddOneRow(t1, 1, 2);
            Helpers.BFS(t1);
            Console.WriteLine("--------------");
            var t2 = Helpers.GetTree(new int?[] { 1, 2, 3, 4 });
            t2 = this.AddOneRow(t2, 5, 4);
            Helpers.BFS(t2);
        }

        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (root == null) return root;
            if (d == 1)
            {
                var t = new TreeNode(v);
                t.left = root;
                return t;
            }
            root.left = AddOneRow(root.left, v, d - 1, true);
            root.right = AddOneRow(root.right, v, d - 1, false);
            return root;
        }

        public TreeNode AddOneRow(TreeNode root, int v, int d, bool left)
        {
            if (d == 1)
            {
                var t = new TreeNode(v);
                if (left)
                    t.left = root;
                else
                    t.right = root;
                return t;
            }
            if (root == null) return root;
            root.left = AddOneRow(root.left, v, d - 1, true);
            root.right = AddOneRow(root.right, v, d - 1, false);
            return root;
        }
    }
}
