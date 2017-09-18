using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/print-binary-tree/description/
     * 
     * Print a binary tree in an m*n 2D string array following these rules:

The row number m should be equal to the height of the given binary tree.
The column number n should always be an odd number.
The root node's value (in string format) should be put in the exactly middle of the first row it can be put. The column and the row where the root node belongs will separate the rest space into two parts (left-bottom part and right-bottom part). You should print the left subtree in the left-bottom part and print the right subtree in the right-bottom part. The left-bottom part and the right-bottom part should have the same size. Even if one subtree is none while the other is not, you don't need to print anything for the none subtree but still need to leave the space as large as that for the other subtree. However, if two subtrees are none, then you don't need to leave space for both of them.
Each unused space should contain an empty string "".
Print the subtrees following the same rules.
Example 1:
Input:
     1
    /
   2
Output:
[["", "1", ""],
 ["2", "", ""]]
Example 2:
Input:
     1
    / \
   2   3
    \
     4
Output:
[["", "", "", "1", "", "", ""],
 ["", "2", "", "", "", "3", ""],
 ["", "", "4", "", "", "", ""]]
Example 3:
Input:
      1
     / \
    2   5
   / 
  3 
 / 
4 
Output:

[["",  "",  "", "",  "", "", "", "1", "",  "",  "",  "",  "", "", ""]
 ["",  "",  "", "2", "", "", "", "",  "",  "",  "",  "5", "", "", ""]
 ["",  "3", "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]
 ["4", "",  "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]]
     */

    class L655PrintBinaryTree
    {
        public void Test()
        {
            var root = Helpers.GetTree(new int?[] { 1, 2, 3, null, 4 });
            Helpers.Print(this.PrintTree(root));
        }

        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int ht = GetHeight(root);
            var res = new List<IList<string>>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            int counter = 0;
            var s = string.Empty;

            while (q.Count != 0 && counter < ht)
            {
                var lst = new List<string>();
                int count = q.Count;
                int pow = (int)Math.Pow(2, ht - counter - 1);

                AddSpace(lst, pow - 1, s);

                for (var i = 0; i < count; i++)
                {
                    root = q.Dequeue();

                    if (i != 0)
                    {
                        int pow1 = (int)Math.Pow(2, ht - counter);
                        AddSpace(lst, pow1 - 1, s);
                    }

                    if (root != null)
                    {
                        lst.Add(root.val.ToString());
                        q.Enqueue(root.left);
                        q.Enqueue(root.right);
                    }
                    else
                    {
                        lst.Add(s);
                        q.Enqueue(null);
                        q.Enqueue(null);
                    }
                }

                AddSpace(lst, pow - 1, s);

                res.Add(lst);
                counter++;
            }

            return res;
        }

        int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(this.GetHeight(root.left), this.GetHeight(root.right));
        }

        void AddSpace(List<string> lst, int count, string s)
        {
            for (var i = 0; i < count; i++)
            {
                lst.Add(s);
            }
        }
    }
}
