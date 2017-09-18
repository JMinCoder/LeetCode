using Scenarios.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    class CompareLeafOfTrees
    {
        public void Test()
        {
            var t1 = Helpers.GetTree(new int?[] { 5, 3, 9, 1, 4, 7, 10});
            var t2 = Helpers.GetTree(new int?[] { 11, 3, 9, 1, 4, 7, 10 });
            var t3 = Helpers.GetTree(new int?[] { 11, 3, 9, 1, 4, 7, 12, null, null, null, null, null, null, 10 });

            var myE = new MyEnumerator(t1);
            while (myE.MoveNext()) Console.Write("{0} ", myE.Current.val);
            Console.WriteLine("");
            Console.WriteLine("=================");
            foreach (var n in this.GetLeafs(t1)) Console.Write("{0} ", n.val);
            Console.WriteLine("");
            foreach (var n in this.GetLeafs(t3)) Console.Write("{0} ", n.val);
            Console.WriteLine("");
            Console.WriteLine(this.CompareLeafs1(t1, t1));
            Console.WriteLine(this.CompareLeafs1(t1, t2));
            Console.WriteLine(this.CompareLeafs1(t1, t3));
        }

        bool CompareLeafs1(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            var l1 = new MyEnumerator(t1);
            var l2 = new MyEnumerator(t2);
            return this.Compare(l1, l2);
        }

        bool CompareLeafs2(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            var l1 = this.GetLeafs(t1).GetEnumerator();
            var l2 = this.GetLeafs(t2).GetEnumerator();
            return this.Compare(l1, l2);
        }

        private bool Compare(IEnumerator<TreeNode> e1, IEnumerator<TreeNode> e2)
        {
            while (e1.MoveNext() && e2.MoveNext())
            {
                if (e1.Current.val != e2.Current.val) return false;
            }
            if (e1.MoveNext() || e2.MoveNext()) return false;
            return true;
        }

        IEnumerable<TreeNode> GetLeafs(TreeNode root)
        {
            var s = new Stack<TreeNode>();

            while (root != null || s.Count != 0)
            {
                if (root == null)
                {
                    root = s.Pop();
                    if (root.left == null && root.right == null)
                    {
                        yield return root;
                    }
                    root = root.right;
                }
                while (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }
            }
        }
       
        public class MyEnumerator : IEnumerator<TreeNode>
        {
            private Stack<TreeNode> s;
            
            public MyEnumerator(TreeNode root)
            {
                s = new Stack<TreeNode>();
                Current = null;
                AddNode(root);
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public TreeNode Current
            {
                get;
                private set;
            }

            public bool MoveNext()
            {
                if (s.Count == 0) return false;
                Current = s.Pop();
                if (Current.left == null && Current.right == null)
                {
                    return true;
                }
                AddNode(Current.right);
                return MoveNext();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            private void AddNode(TreeNode node)
            {
                while (node != null)
                {
                    s.Push(node);
                    node = node.left;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
