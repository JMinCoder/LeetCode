using Scenarios.Common;
using Scenarios.Lists;
using System;

namespace Scenarios
{
    class L025ReverseNodesInKGroups
    {
        public void Test()
        {
            var h = Helpers.GetList(10);
            for (var i=1;i<10;i++)
            {
                Helpers.Print(ReverseKGroup(Helpers.GetList(10), i));
            }
        }

        
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            int len = Helpers.ListLength(head);
            if (len < k) return head;
            
            ListNode p = head;
            ListNode lastNode = null;
            ListNode newLastNode = null;
            
            while (len >= k)
            {
                ListNode r = null;
                for (var i=0;i<k;i++)
                {
                    ListNode t = p.next;
                    p.next = r;
                    r = p;
                    p = t;
                }
                len -= k;
                if (lastNode == null)
                {
                    lastNode = head;
                    head = r;                    
                }
                else
                {
                    lastNode.next = r;
                    lastNode = newLastNode;
                }
                newLastNode = p;
            }

            if (lastNode != null)
            {
                lastNode.next = p;
            }

            return head;
        }
    }
}
