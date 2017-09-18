using Scenarios.Lists;
using Scenarios.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Common
{
    public static class Helpers
    {
        public static ListNode GetList(int numElements)
        {
            var h = new ListNode(0);
            ListNode p = h;
            for (var i=0;i<numElements;++i)
            {
                p.next = new ListNode(i + 1);
                p = p.next;
            }
            
            return h.next;
        }

        public static void Print(ListNode h)
        {
            var p = h;
            while (p != null)
            {
                Console.Write(p.val + " ");
                p = p.next;
            }
            Console.WriteLine("");
        }

        public static void Print<T>(this IList<T> list)
        {
            Console.WriteLine(String.Join(", ", list));               
        }

        public static void Print<T>(this IList<IList<T>> list)
        {
            Console.WriteLine(
                String.Join(Environment.NewLine,
                list.Select(x => String.Join(", ", x))));  
        }

        public static int ListLength(ListNode h)
        {
            int count = 0;
            while (h != null)
            {
                count++;
                h = h.next;
            }
            return count;
        }

        public static TreeNode GetTree(int numOfElements, int eachLevel=1)
        {
            TreeNode root = null;
            
            for (int i=0;i<numOfElements;i+=eachLevel)
            {
                for (var j = eachLevel - 1; j >= 0; j--)
                {
                    if (i + j < numOfElements)
                    {
                        root = CreateBST.InsertToBST(root, i + j);
                    }
                }
            }

            return root;
        }

        public static TreeNode GetTree(int? []arr)
        {
            var trees = new TreeNode[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].HasValue)
                {
                    trees[i] = new TreeNode(arr[i].Value);
                    if (i != 0)
                    {
                        int par = (i-1) / 2;
                        if ( (par * 2 + 1) == i)
                        {
                            trees[par].left = trees[i];
                        }
                        else
                        {
                            trees[par].right = trees[i];
                        }
                    }
                }
            }

            return trees[0];
        }

        public static void BFS(TreeNode root)
        {
            if (root == null) return;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    root = q.Dequeue();
                    Console.Write("{0} ", root.val);
                    if (root.left != null) q.Enqueue(root.left);
                    if (root.right != null) q.Enqueue(root.right);
                }
                Console.WriteLine("");
            }
        }

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static bool IsSame(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}
