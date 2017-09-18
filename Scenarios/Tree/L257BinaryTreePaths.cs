using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, return all root-to-leaf paths.

For example, given the following binary tree:

   1
 /   \
2     3
 \
  5
All root-to-leaf paths are:

["1->2->5", "1->3"]
     */
    class L257BinaryTreePaths
    {
        public void Test()
        {
            var root = Helpers.GetTree(5, 2);
            Helpers.BFS(root);
            Console.WriteLine(String.Join("; ", this.BinaryTreePaths(root)));
        }
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();
            if (root == null) return list;
            Inorder(root, ref list, root.val.ToString());
            return list;
        }

        private void Inorder(TreeNode root, ref List<string> list, string str)
        {
            if (root == null) return;

            if (root.left == null && root.right == null)
            {
                list.Add(str);
                return;
            }
            
            if (root.left != null)
            {
                Inorder(root.left, ref list, str + "->" + root.left.val);
            }

            if (root.right != null)
            {
                Inorder(root.right, ref list, str + "->" + root.right.val);
            }
        }
    }
}
