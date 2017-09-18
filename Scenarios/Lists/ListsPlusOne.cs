using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Lists
{
    class ListsPlusOne
    {
        public void Test()
        {
            ListNode [] lists = {
                 null,
                 new ListNode(0),
                 new ListNode(9),
                 new ListNode(1) { next = new ListNode(0) },
                 new ListNode(1) { next = new ListNode(9) },
                 new ListNode(9) { next = new ListNode(9) },
                 new ListNode(2) { next = new ListNode(2) { next = new ListNode(5) }},
                 new ListNode(9) { next = new ListNode(9) { next = new ListNode(9) }},
                 new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) } }},
                 new ListNode(1) { next = new ListNode(2) { next = new ListNode(9) { next = new ListNode(4) } }},
            };

            for (var i = 0; i < lists.Length; i++)
            {
                Console.WriteLine("{0} + 1 = {1}", ConvertToString(lists[i]), ConvertToString(this.PlusOne(lists[i])));
            }
        }

        public ListNode PlusOne(ListNode head)
        {
            if (head == null) return null;

            ListNode dummy = new ListNode(0) { next = head };
            ListNode p = dummy;
            ListNode q = dummy;

            while (p.next != null)
            {
                if (p.val != 9)
                {
                    q = p;
                }

                p = p.next;
            }

            if (p.val != 9)
            {
                p.val++;
                return head;
            }
            else
            {
                p.val = 0;
                var t = q;
                t.val++;
                t = t.next;
                while (t != p)
                {
                    t.val = 0;
                    t = t.next;
                }
                if (q == dummy)
                {
                    return dummy;
                }
            }

            return head;
        }

        public string ConvertToString(ListNode head)
        {
            var sb = new StringBuilder();
            var p = head;
            while (p!=null)
            {
                sb.Append(p.val);
                p = p.next;
            }

            return sb.ToString();
        }
    }
}
