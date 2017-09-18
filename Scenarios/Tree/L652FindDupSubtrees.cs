using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * https://leetcode.com/problems/find-duplicate-subtrees/description/
     * 
     * Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.

Two trees are duplicate if they have the same structure with same node values.

Example 1: 
        1
       / \
      2   3
     /   / \
    4   2   4
       /
      4
The following are two duplicate subtrees:
      2
     /
    4
and
    4
Therefore, you need to return above trees' root in the form of a list.

     */

    class L652FindDupSubtrees
    {
        public void Test()
        {
            //var root = Helpers.GetTree(new int?[] { 1, 2, 3, 4, null, 2, 4, null, null, null, null, 4 });
            //var root = new TreeNode(0);
            //var cur = root;
            //for (var i = 0; i < 100000; i++)
            //{
            //    cur.right = new TreeNode(0);
            //    cur = cur.right;
            //}
            ////IterativePostOrder(root);

            ////var root = Helpers.GetTree(new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //var res = FindDuplicateSubtrees(root);
            ////IterativePostOrder(root);

            //foreach (var t in res)
            //{
            //    Console.WriteLine(t.val);
            //}

            //Console.WriteLine(PredictPartyVictory("RD"));
            //Console.WriteLine(PredictPartyVictory("RDD"));
            //for (var i = 1; i < 1000; i++)
            //{
            //    Console.WriteLine("{0} : {1}", i, MinSteps(i));
            //}
        }

        public IList<TreeNode> FindDuplicateSubtrees2(TreeNode root)
        {
            var hash = new HashSet<string>();
            var dict = new Dictionary<string, TreeNode>();

            var res = new List<TreeNode>();
            Traverse(root, hash, dict);

            foreach (var val in dict)
            {
                res.Add(val.Value);
            }
            return res;
        }

        public string Traverse(TreeNode root, HashSet<string> hash, Dictionary<string, TreeNode> dict)
        {
            if (root == null) return "N";

            var l = Traverse(root.left, hash, dict);
            var r = Traverse(root.right, hash, dict);

            var s = l + "#" + root.val + "#" + r;
            if (hash.Contains(s))
            {
                if (!dict.ContainsKey(s)) dict.Add(s, root);
            }
            else
            {
                hash.Add(s);
            }
            return s;
        }

        public IList<TreeNode> FindDuplicateSubtrees1(TreeNode root)
        {
            var hash = new HashSet<string>();
            var dict = new Dictionary<string, TreeNode>();

            var res = new List<TreeNode>();
            Traverse(root, hash, dict);

            foreach (var val in dict)
            {
                res.Add(val.Value);
            }
            return res;
        }

        public string Traverse1(TreeNode root, HashSet<string> hash, Dictionary<string, TreeNode> dict)
        {
            if (root == null) return "N";

            var l = Traverse(root.left, hash, dict);
            var r = Traverse(root.right, hash, dict);

            var s = l + "#" + root.val + "#" + r;
            if (hash.Contains(s))
            {
                if (!dict.ContainsKey(s)) dict.Add(s, root);
            }
            else
            {
                hash.Add(s);
            }
            return s;
        }
    }
}
