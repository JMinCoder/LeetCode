using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/maximum-width-of-binary-tree/description/
     * 
     * Given a binary tree, write a function to get the maximum width of the given tree. The width of a tree is the maximum width among all levels. The binary tree has the same structure as a full binary tree, but some nodes are null.

The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.

Example 1:
Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
Example 2:
Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).
Example 3:
Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).
Example 4:
Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).


Note: Answer will in the range of 32-bit signed integer.
    */
    class L662MaximumWidthOfBinaryTree
    {
        public void Test()
        {
            Console.WriteLine(this.WidthOfBinaryTree(Helpers.GetTree(new int?[] { 1, 3, 2, 5, 3, null, 9 })));
            Console.WriteLine(this.WidthOfBinaryTree(Helpers.GetTree(new int?[] { 1, 3, null, 5, 3 })));
            Console.WriteLine(this.WidthOfBinaryTree(Helpers.GetTree(new int?[] { 1, 3, 2, 5 })));
            Console.WriteLine(this.WidthOfBinaryTree(Helpers.GetTree(new int?[] { 1, 3, 2, 5, null, null, 9, 6, null, null, null, null, null, null, 7 })));
        }

        public int WidthOfBinaryTree(TreeNode root)
        {
            var res = 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int count = q.Count;
                int cur = 0;
                int nulls = 0;

                for (var i = 0; i < count; i++)
                {
                    root = q.Dequeue();

                    if (root != null)
                    {
                        cur++;
                        cur += nulls;
                        nulls = 0;
                        q.Enqueue(root.left);
                        q.Enqueue(root.right);
                    }
                    else
                    {
                        if (cur != 0)
                        {
                            nulls++;
                            q.Enqueue(null);
                            q.Enqueue(null);
                        }
                    }
                }
                if (cur == 0) break;
                res = Math.Max(res, cur);
            }

            return res;
        }
    }
}
