using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     *
     */
    class L253MeetingRoomsII
    {
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

            list.Add(new Interval(0, 30));
            list.Add(new Interval(5, 10));
            list.Add(new Interval(15, 20));
            //list.Add(new Interval(9, 10));

            Console.WriteLine(this.MinMeetingRooms(list));
            Console.WriteLine(this.MinMeetingRooms2(list));


            list = new List<Interval>();

            list.Add(new Interval(0, 10));
            list.Add(new Interval(10, 20));
            list.Add(new Interval(0, 15));
            list.Add(new Interval(14, 25));

            Console.WriteLine(this.MinMeetingRooms(list));
            Console.WriteLine(this.MinMeetingRooms2(list));

            // For array sorting.
            //Array.Sort(intervals, (i1, i2) => i1.start - i2.start);
        }

        public int MinMeetingRooms(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0) return 0;
            
            intervals = intervals.OrderBy(i => i.start).ToList();
            Print(intervals);

            var ends = new List<int>();

            for (var i= 0; i < intervals.Count; i++)
            {
                int j = 0;
                for (;j<ends.Count;j++)
                {
                    if (intervals[i].start >= ends[j])
                    {
                        ends[j] = intervals[i].end;
                        break;
                    }
                }
                if ( j == ends.Count)
                {
                    ends.Add(intervals[i].end);
                }
            }

            return ends.Count;
        }


        public int MinMeetingRooms2(IList<Interval> intervals)
        {
            var starts = new List<int>(intervals.Count);
            var ends = new List<int>(intervals.Count);
            for (int i = 0; i < intervals.Count; i++)
            {
                starts.Add(intervals[i].start);
                ends.Add(intervals[i].end);
            }
            starts.Sort();
            ends.Sort();
            int rooms = 0;
            int endsItr = 0;
            for (int i = 0; i < starts.Count; i++)
            {
                if (starts[i] < ends[endsItr])
                    rooms++;
                else
                    endsItr++;
            }
            return rooms;
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
