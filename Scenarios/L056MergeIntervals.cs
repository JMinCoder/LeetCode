using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L056MergeIntervals
    {
        /*
         * 
         * Given a collection of intervals, merge all overlapping intervals.

            For example,
            Given [1,3],[2,6],[8,10],[15,18],
            return [1,6],[8,10],[15,18].
         */

        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        public void Test()
        {
            var list = new List<Interval>();
            
            list.Add(new Interval(3, 6));
            list.Add(new Interval(1, 3));
            //list.Add(new Interval(4, 11));
            //list.Add(new Interval(9, 10));

            var r = this.Merge(list);
            this.Print(r);
        }
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1) return intervals;

            var sorted = intervals.OrderBy( i => i.start).ToList();

            var ret = new List<Interval>();
            ret.Add(new Interval(sorted[0].start, sorted[0].end));

            for (var i =1;i < sorted.Count; ++i)
            {
                if (sorted[i].start <= ret[ret.Count-1].end && sorted[i].start >= ret[ret.Count - 1].start)
                {
                    ret[ret.Count - 1].end = Math.Max(ret[ret.Count - 1].end, sorted[i].end);
                }
                else
                {
                    ret.Add(new Interval(sorted[i].start, sorted[i].end));
                }
            }
            return ret;
        }

        private void Print(IList<Interval> list)
        {
            foreach (var interval in list)
            {
                Console.Write("[{0},{1}] ", interval.start, interval.end);
            }
            Console.WriteLine("");
        }
    }
 }
