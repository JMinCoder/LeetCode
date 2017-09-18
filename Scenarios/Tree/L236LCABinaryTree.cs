using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class L236LCABinaryTree
    {
        public void Test()
        {
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n1 = new TreeNode(1) { left = n2, right = n3 };

            var t = this.LowestCommonAncestor(n1, n2, n3);
            Console.WriteLine(t.val);

            var r = Helpers.GetTree(new int?[] { 5, 4, 3, 2, null, 1, null });
            //Console.WriteLine(this.LowestCommonAncestor);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val) return root;
            var left = this.LowestCommonAncestor(root.left, p, q);
            var right = this.LowestCommonAncestor(root.right, p, q);

            if (left == null) return right;
            if (right == null) return left;
            return root;
        }
    }
}
