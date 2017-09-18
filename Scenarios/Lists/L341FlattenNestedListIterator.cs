using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Lists
{
    public class L341FlattenNestedListIterator
    {
        /*
         * Given a nested list of integers, implement an iterator to flatten it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Example 1:
Given the list [[1,1],2,[1,1]],

By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,1,2,1,1].

Example 2:
Given the list [1,[4,[6]]],

By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,4,6].

Subscribe to see which companies asked this question.
         */

        public void Test()
        {
            var l1 = new List<NestedInteger>();
            l1.Add(new NestedInteger(1));
            l1.Add(new NestedInteger(1));

            var l2 = new List<NestedInteger>();
            l2.Add(new NestedInteger(l1));
            l2.Add(new NestedInteger(2));

            var l3 = new List<NestedInteger>();
            l3.Add(new NestedInteger(1));
            l3.Add(new NestedInteger(1));

            l2.Add(new NestedInteger(l3));

            var itr = new NestedIterator(l2);
            while (itr.HasNext())
            {
                Console.Write(itr.Next() + " " );
            }

            Console.WriteLine("");
            var itr2 = new NestedIterator2(l2);
            while (itr2.HasNext())
            {
                Console.Write(itr2.Next() + " ");
            }
            Console.WriteLine("");
        }

        public class NestedInteger
        {
            private bool hasInt = false;
            private int value = 0;
            private IList<NestedInteger> list = null;

            public NestedInteger(int val)
            {
                this.hasInt = true;
                this.value = val;
            }

            public NestedInteger(IList<NestedInteger> list)
            {
                this.hasInt = false;
                this.list = list;
            }

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            public bool IsInteger()
            {
                return this.hasInt;
            }

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            public int GetInteger()
            {
                Debug.Assert(this.hasInt);
                return value;
            }

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            public IList<NestedInteger> GetList()
            {
                if (this.hasInt == false)
                    return this.list;
                return null;
            }
        }

        public class NestedIterator
        {
            private IList<int> list;
            int count = 0;
            
            public NestedIterator(IList<NestedInteger> nestedList)
            {
                this.list = new List<int>();

                this.AddElements(nestedList);
            }

            public bool HasNext()
            {
                return (this.count < this.list.Count);
            }

            public int Next()
            {
                return this.list[this.count++];
            }

            private void AddElements(IList<NestedInteger> nestedList)
            {
                for (var i=0;i<nestedList.Count;i++)
                {
                    if (nestedList[i].IsInteger())
                    {
                        this.list.Add(nestedList[i].GetInteger());
                    }
                    else
                    {
                        this.AddElements(nestedList[i].GetList());
                    }
                }
            }
        }

        public class NestedIterator2
        {

            private Stack<NestedInteger> stack = new Stack<NestedInteger>();

            public NestedIterator2(IList<NestedInteger> nestedList)
            {
                for (int i = nestedList.Count() - 1; i >= 0; i--)
                {
                    stack.Push(nestedList.ElementAt(i));
                }
            }

            public bool HasNext()
            {
                while (stack.Count != 0)
                {
                    NestedInteger top = stack.Peek();
                    if (top.IsInteger())
                    {
                        return true;
                    }

                    stack.Pop();
                    for (int i = top.GetList().Count() - 1; i >= 0; i--)
                    {
                        stack.Push(top.GetList().ElementAt(i));
                    }
                }
                return false;
            }

            public int Next()
            {
                return stack.Pop().GetInteger();
            }
        }
    }
}
