using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Design
{
    class LRUCache
    {
        public static void Test()
        {
            var cache = new LRUCache(2);
            cache.set(2, 1);
            Console.WriteLine(cache.get(2));
            cache.set(3, 2);
            Console.WriteLine(cache.get(2));
            Console.WriteLine(cache.get(3));
            cache.set(4, 6);
            Console.WriteLine(cache.get(2));
            Console.WriteLine(cache.get(4));
        }
        private class LinkedNode
        {
            public int Key;
            public int Value;
            public LinkedNode(int key, int value, LinkedNode next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
                this.Prev = null;
                if (next != null) next.Prev = this;
            }

            public LinkedNode Next;
            public LinkedNode Prev;
        }

        private Dictionary<int, LinkedNode> dict; 
        LinkedNode head = null;
        LinkedNode last = null;

        int capacity;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.dict = new Dictionary<int, LinkedNode>();
        }

        public int get(int key)
        {
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                if (node != head)
                {
                    if (node == last)
                    {
                        last = node.Prev;
                    }
                    node.Prev.Next = node.Next;
                    if (node.Next != null)
                    {
                        node.Next.Prev = node.Prev;
                    }
                    node.Prev = null;
                    node.Next = head;
                    head.Prev = node;
                    head = node;
                }
                return dict[key].Value;
            }
            return -1;
        }

        public void set(int key, int value)
        {
            if (dict.Count == this.capacity)
            {
                var n = last;
                last = last.Prev;
                last.Next = null;
                dict.Remove(n.Key);
            }
            var node = new LinkedNode(key, value, head);
            head = node;
            if (last == null) last = node;
            dict.Add(key, node);
        }
    }
}
