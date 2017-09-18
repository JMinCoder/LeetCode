using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class InOrderPredecessor
    {
        public void Test()
        {
            var tree = Helpers.GetTree(new int?[] { 5, 3, 9, 1, 4, 8, 11 });
            
            for (var i = 1; i < 12; i++)
            {
                TreeNode pred = null;
                if (!FindPred(tree, i, ref pred)) pred = null;

                Console.WriteLine("Pred of {0} = {1}", i, pred == null ? "null" : pred.val.ToString());
            }
        }

        bool FindPred(TreeNode root, int key, ref TreeNode pred)
        {
            if (root == null) return false;
            if (root.val == key)
            {
                if (root.left != null)
                {
                    var tmp = root.left;
                    while (tmp.right != null) tmp = tmp.right;
                    pred = tmp;
                }
                return true;
            }
            else if (root.val > key)
            {
                return FindPred(root.left, key, ref pred);
            }
            else
            {
                pred = root;
                return FindPred(root.right, key, ref pred);
            }
        }
    }
}
