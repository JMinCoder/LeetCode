using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is 
     * changed to the original key plus sum of all keys greater than the original key in BST.

Example:

Input: The root of a Binary Search Tree like this:
              5
            /   \
           2     13

Output: The root of a Greater Tree like this:
             18
            /   \
          20     13
     */
    class L538ConvertBSTtoGreaterTree
    {
        public void Test()
        {
            var t = new TreeNode(5)
            {
                left = new TreeNode(2),
                right = new TreeNode(13)
            };
            Helpers.BFS(t);
            Console.WriteLine("===========");
            t = this.ConvertBST(t);
            Console.WriteLine("===========");
            Helpers.BFS(t);
        }

        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            return this.RevInorder(root, ref sum);
        }

        private TreeNode RevInorder(TreeNode root, ref int sum)
        {
            if (root != null)
            {
                this.RevInorder(root.right, ref sum);
                Console.WriteLine(root.val);
                root.val += sum;
                sum = root.val;
                this.RevInorder(root.left, ref sum);
            }

            return root;
        }
    }
}
