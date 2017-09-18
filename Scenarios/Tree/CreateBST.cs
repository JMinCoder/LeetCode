using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class CreateBST
    {
        public void Test()
        {
            int N = 30;
            var root = Helpers.GetTree(N, 4);

            Helpers.BFS(root);

            for (var i = 0; i <= N; i++)
            {
                bool flag = false;
                var successor = Next(root, i, ref flag);
                if (successor != null)
                {
                    if (successor.val != i + 1)
                    {
                        Console.WriteLine("Next of {0} : {1}", i, successor.val);
                    }
                }
                else
                {
                    Console.WriteLine("Next of {0} : NoSuccessor", i);
                }

                flag = false;
                var prev = Previous(root, i, ref flag);
                if (prev != null)
                {
                    if (prev.val != i - 1)
                    {
                        Console.WriteLine("Prev of {0} : {1}", i, prev.val);
                    }
                }
                else
                {
                    Console.WriteLine("Prev of {0} : NoPrevious", i);
                }
            }
        }

        public static TreeNode InsertToBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }
            if (val <= root.val)
            {
                root.left = InsertToBST(root.left, val);
            }
            else
            {
                root.right = InsertToBST(root.right, val);
            }

            return root;
        }

        // Successor
        public static TreeNode Next(TreeNode root, int key, ref bool flag)
        {
            if (root == null) return null;
            var s = Next(root.left, key, ref flag);
            if (flag) return s == null ? root : s;
            if (root.val == key) flag = true;
            return Next(root.right, key, ref flag);
        }

        public static TreeNode Previous(TreeNode root, int key, ref bool flag)
        {
            if (root == null) return null;
            var s = Previous(root.right, key, ref flag);
            if (flag) return s == null ? root : s;
            if (root.val == key) flag = true;
            return Previous(root.left, key, ref flag);
        }
    }
}
