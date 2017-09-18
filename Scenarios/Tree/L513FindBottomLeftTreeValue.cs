using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, find the leftmost value in the last row of the tree.
     */
    class L513FindBottomLeftTreeValue
    {
        public void Test()
        {
            var r = new TreeNode(3)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(2)
                },
                right = new TreeNode(5)
            };

            var t = new TreeNode(10)
            {
                left = new TreeNode(20)
                {
                    left = new TreeNode(15)
                },
                right = new TreeNode(30)
            };

            Console.WriteLine(this.FindBottomLeftValue(r));
            Console.WriteLine(this.FindBottomLeftValue2(r));
            
            Console.WriteLine(this.FindBottomLeftValue(t));
            Console.WriteLine(this.FindBottomLeftValue2(t));
        }

        public int FindBottomLeftValue(TreeNode root)
        {
            if (root == null) return -1;

            int val = -1;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                root = q.Dequeue();
                if (root == null)
                {
                    if (q.Count == 0) break;
                    q.Enqueue(null);
                    root = q.Dequeue();
                    val = root.val;
                }

                if (root.left != null) q.Enqueue(root.left);
                if (root.right != null) q.Enqueue(root.right);
            }

            return val;
        }

        public int FindBottomLeftValue2(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            int result = -1;

            if (root == null)
            {
                throw new ArgumentNullException("Null root passed");
            }

            q.Enqueue(root);
            while (q.Count > 0)
            {
                int count = q.Count;
                for (var i = 0; i < count; i++)
                {
                    root = q.Dequeue();
                    result = root.val;
                    if (root.right != null) q.Enqueue(root.right);
                    if (root.left != null) q.Enqueue(root.left);
                }
            }

            return result;
        }
    }
}
