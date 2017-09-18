using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class L145PostOrderTraversal
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
            Console.WriteLine(String.Join(", ", this.PostOrderRec(r)));
            Console.WriteLine(String.Join(", ", this.PostOrder(r)));
        }

        public IList<int> PostOrderRec(TreeNode root)
        {
            if (root == null) return null;
            var result = this.PostOrderRec(root.left);
            var right = this.PostOrderRec(root.right);

            if (right != null)
            {
                if (result == null)
                {
                    result = right;
                }
                else
                {
                    for (var i = 0; i < right.Count; i++)
                    {
                        result.Add(right[i]);
                    }
                }
            }
            if (result == null)
            {
                result = new List<int>();
            }

            result.Add(root.val);

            return result;
        }

        public IList<int> PostOrder(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var s = new Stack<KeyValuePair<TreeNode, bool>>();
            s.Push(new KeyValuePair<TreeNode, bool>(root, false));

            while (s.Count > 0)
            {
                var t = s.Pop();
                if (t.Value)
                {
                    result.Add(t.Key.val);
                }
                else
                {
                    s.Push(new KeyValuePair<TreeNode, bool>(t.Key, true));
                    if (t.Key.right != null) s.Push(new KeyValuePair<TreeNode, bool>(t.Key.right, false));
                    if (t.Key.left != null) s.Push(new KeyValuePair<TreeNode, bool>(t.Key.left, false));
                }
            }

            return result;
        }
    }
}
