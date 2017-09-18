using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Lists
{
    public class LinklistReverse
    {
        public void Test()
        {
            var h = Helpers.GetList(5);
            Helpers.Print(h);
            h = this.Reverse(h);
            Helpers.Print(h);
            h = this.RecReverse(h);
            Helpers.Print(h);
        }

        public ListNode Reverse(ListNode h)
        {
            ListNode r = null;
            
            while (h != null)
            {
                ListNode t = h;
                h = h.next;
                t.next = r;
                r = t;
            }
            return r;
        }

        public ListNode RecReverse(ListNode h)
        {
            if (h == null || h.next == null)
            {
                return h;
            }

            ListNode t = h.next;
            ListNode r = this.RecReverse(h.next);
            t.next = h;
            h.next = null;

            return r;
        }
    }
}
