using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class L098ValidBinaryTree
    {
        /*
         * Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
Example 1:
    2
   / \
  1   3
Binary tree [2,1,3], return true.
Example 2:
    1
   / \
  2   3
         */
        
        public void Test()
        {
            //var r = new TreeNode(10)
            //{
            //    left = new TreeNode(5),
            //    right = new TreeNode(15)
            //    {
            //        left = new TreeNode(6),
            //        right = new TreeNode(20)
            //    }
            //};
            //[3,1,5,0,2,4,6,null,null,null,3]
            var r = new TreeNode(3)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                    }
                },
                right = new TreeNode(5)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(6)
                }
            };
            Console.WriteLine(this.IsValidBST(r));
        }
        public bool IsValidBST(TreeNode root)
        {
            TreeNode prev = null;
            return InOrder(root, ref prev);
        }

        private bool InOrder(TreeNode root, ref TreeNode prev)
        { 
            if (root == null) return true;

            if (!InOrder(root.left, ref prev)) return false;

            if (prev != null && prev.val >= root.val) return false;
            prev = root;
            return InOrder(root.right, ref prev);
        }

        private bool IsBST(TreeNode root, int min, int max)
        {
            if (root == null) return true;
            if (root.val < min || root.val >= max) return false;
            return IsBST(root.left, min, root.val) && IsBST(root.right, root.val, max);
        }
    }
}
