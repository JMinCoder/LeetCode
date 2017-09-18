using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree [1,null,2,3],
   1
    \
     2
    /
   3
return [1,3,2].
     */
    class L094InorderTraversal
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
            Console.WriteLine(String.Join(", ", this.InorderTraversal2(r)));
        }

        public IList<int> InorderTraversalRec(TreeNode root)
        {
            if (root == null) return null;
            var left = InorderTraversalRec(root.left);

            if (left == null)
            {
                left = new List<int>();
            }

            left.Add(root.val);
            var right = InorderTraversalRec(root.right);
            if (right != null)
            {
                for (var i = 0; i < right.Count; i++)
                {
                    left.Add(right[i]);
                }
            }

            return left;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            var stack = new Stack<KeyValuePair<TreeNode, bool>>();

            stack.Push(new KeyValuePair<TreeNode, bool>(root, false));
            while (stack.Count != 0)
            {
                var t = stack.Pop();
                if (t.Value)
                {
                    result.Add(t.Key.val);
                }
                else
                {
                    if (t.Key.right != null) stack.Push(new KeyValuePair<TreeNode, bool>(t.Key.right, false));
                    stack.Push(new KeyValuePair<TreeNode, bool>(t.Key, true));
                    if (t.Key.left != null) stack.Push(new KeyValuePair<TreeNode, bool>(t.Key.left, false));
                }
            }
            return result;
        }

        // This just uses the stack of TreeNode
        public IList<int> InorderTraversal2(TreeNode root)
        {
            var result = new List<int>();
            var s = new Stack<TreeNode>();

            while (root != null || s.Count > 0)
            {
                while (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }
                root = s.Pop();
                result.Add(root.val);
                root = root.right;
            }

            return result;
        }
    }
}
