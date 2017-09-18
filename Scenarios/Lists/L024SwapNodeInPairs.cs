using Scenarios.Common;
using Scenarios.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
    Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space.You may not modify the values in the list, only nodes itself can be changed.
        */
    class L024SwapNodeInPairs
    {
        public void Test()
        {
            var h = Helpers.GetList(15);
            Helpers.Print(h);            
            var r = SwapPairs(h);
            Helpers.Print(r);
        }
                        
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode result = head.next;
            ListNode prev = null;
            while (head != null && head.next != null)
            {
                ListNode p = head.next;
                head.next = p.next;
                p.next = head;
                if (prev != null)
                {
                    prev.next = p;
                }
                prev = head;
                head = head.next;
            }
            return result;
        }

        
    }
}
