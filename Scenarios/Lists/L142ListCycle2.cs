using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Lists
{
    class L142ListCycle2
    {
        public void Test()
        {
            for (var i=1;i<11;i++)
            {
                var list = this.GetCycleList(11, i);
                Console.WriteLine("{0} : {1}", i, this.HasCycle(list));
            }
        }

        public int HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return -1;
            ListNode slow = head; ListNode fast = head;
            int count = 0;
            while (fast.next != null && fast.next.next != null)
            {
                //Console.WriteLine(slow.val);
                slow = slow.next;
                count++;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return count;
                }
            }
            return -1;
        }

        private ListNode GetCycleList(int numElements, int firstCycledElem)
        {
            var list = Helpers.GetList(numElements);
            var p = list; var q = list;
            while (p.next != null)
            {
                if (p.val == firstCycledElem) q = p;

                p = p.next;
            }
            p.next = q;
            return list;
        }
    }
}
