using Scenarios.Common;
using Scenarios.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
     */
    class L109SortedListToBST
    {
        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                Helpers.BFS(this.SortedListToBST(Helpers.GetList(i)));
                Console.WriteLine("---------------");
            }
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            return Insert(head, null);
        }

        private TreeNode Insert(ListNode head, ListNode tail)
        {
            if (head == tail) return null;
            var slow = head;
            var fast = head;

            while (fast != tail && fast.next != tail)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            var r = new TreeNode(slow.val);
            r.left = this.Insert(head, slow);
            r.right = this.Insert(slow.next, tail);

            return r;
        }
    }
}
