using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
     */
    class L173BSTIteraor
    {
        public void Test()
        {
            var r = new L109SortedListToBST().SortedListToBST(Helpers.GetList(10));

            var itr = new BSTIterator(r);
            while (itr.HasNext())
            {
                Console.WriteLine(itr.Next());
            }
        }

        public class BSTIterator
        {
            Stack<TreeNode> s = new Stack<TreeNode>();

            public BSTIterator(TreeNode root)
            {
                this.InsertNodes(root);
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return s.Count > 0;
            }

            /** @return the next smallest number */
            public int Next()
            {
                var r = s.Pop();
                this.InsertNodes(r.right);
                return r.val;
            }

            // Insert the root and go down the left tree till there is no left
            private void InsertNodes(TreeNode root)
            {
                while (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }
            }
        }
    }
}
