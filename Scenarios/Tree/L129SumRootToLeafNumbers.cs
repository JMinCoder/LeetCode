using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/sum-root-to-leaf-number
     * 
     * Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

An example is the root-to-leaf path 1->2->3 which represents the number 123.

Find the total sum of all root-to-leaf numbers.

For example,

    1
   / \
  2   3
The root-to-leaf path 1->2 represents the number 12.
The root-to-leaf path 1->3 represents the number 13.

Return the sum = 12 + 13 = 25.
     */
    class L129SumRootToLeafNumbers
    {
        public void Test()
        {
            var t = Helpers.GetTree(new int?[] { 1,2,3});
            Console.WriteLine(this.SumNumbersRec(t));
        }

        public int SumNumbersRec(TreeNode root)
        {
            return Helper(root, 0);
        }

        private int Helper(TreeNode root, int sum)
        {
            if (root == null) return 0;
            int cur = sum * 10 + root.val;
            if (root.left == null && root.right == null) return cur;
            return Helper(root.left, cur) + Helper(root.right, cur);
        }

        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;
            var q = new Queue<KeyValuePair<TreeNode, int>>();
            q.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            int sum = 0;
            while (q.Count != 0)
            {
                var count = q.Count;
                for (var i = 0; i < count; i++)
                {
                    var x = q.Dequeue();
                    root = x.Key;
                    int cur = x.Value * 10 + root.val;

                    Console.Write("{0} ", root.val);

                    if (root.left != null)
                    {
                        q.Enqueue(new KeyValuePair<TreeNode, int>(root.left, cur));
                    }

                    if (root.right != null)
                    {
                        q.Enqueue(new KeyValuePair<TreeNode, int>(root.right, cur));
                    }

                    if (root.left == null && root.right == null)
                    {
                        sum = sum + cur;
                    }
                }
                Console.WriteLine();                
            }

            return sum;
        }
    }
}
