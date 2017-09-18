using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Hacker
{
    class HWCS11RoadTrip
    {
        class Query
        {
            public int x, y, index;
            public long ans;
            public Query(int a, int b, int c) { x = a; y = b; index = c; }
            public override string ToString()
            {
                return x + " " + y;
            }
        }

        public void Test()
        {
            string[] a_temp = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int n = a[0]; int q = a[1];

            var roads = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            var gas = new int[n];
            var price = new int[n];

            for (var i = 0; i < n; i++)
            {
                a_temp = Console.ReadLine().Split(' ');
                a = Array.ConvertAll(a_temp, Int32.Parse);
                gas[i] = a[0];
                price[i] = a[1];
            }

            var queries = new Query[q];

            for (var i = 0; i < q; i++)
            {
                a_temp = Console.ReadLine().Split(' ');
                a = Array.ConvertAll(a_temp, Int32.Parse);
                queries[i] = new Query(a[0] - 1, a[1] - 1, i);
            }

            /*
            int n = 6; int q = 4;
            var roads = new int[] { 2, 6, 1, 5, 3};
            var gas = new int[] { 3, 4, 3, 1, 4, 9};
            var price = new int[] { 1, 2, 1, 4, 6, 3};

            var queries = new Query[]
            {
                new Query(1, 4, 0),
                new Query(0, 5, 1),
                new Query(2, 4, 2),
                new Query(3, 5, 3),
            };
            */

            queries = queries.OrderBy(x => x.x).ThenBy(y => y.y).ToArray();

            // Find the last y to be queried for for each x.
            var last = new int[n];
            for (var i = 0; i < n; i++) last[i] = -1;

            for (var i = 0; i < q; i++) last[queries[i].x] = Math.Max(last[queries[i].x], queries[i].y);

            int cur = 0;
            while (cur < q) cur = RoadTrip(roads, gas, price, queries, cur, last);

            Console.WriteLine(String.Join(Environment.NewLine, queries.OrderBy(x => x.index).Select(x => x.ans)));
        }

        private int RoadTrip(int[] roads, int[] gas, int[] price, Query[] queries, int curIndex, int []last)
        {
            long r = 0;

            int x = queries[curIndex].x;
            int y = last[x];

            long minPrice = price[x];
            long cur = gas[x];
            if (queries[curIndex].y == x) { queries[curIndex].ans = r; curIndex++; }
            while (x < y)
            {
                cur -= roads[x];
                x++;

                if (cur < 0)
                {
                    r += (minPrice * -1 * cur);
                    cur = 0;
                }

                if (queries[curIndex].y == x) { queries[curIndex].ans = r; curIndex++; }
                minPrice = Math.Min(minPrice, price[x]);
                cur += gas[x];
            }

            return curIndex;
        }


        public void Test2()
        {
            string[] a_temp = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int n = a[0]; int q = a[1];
            a_temp = Console.ReadLine().Split(' ');
            a = Array.ConvertAll(a_temp, Int32.Parse);

            var roads = new int[n + 1];
            Array.Copy(a, 0, roads, 1, n - 1);

            var gas = new int[n + 1];
            var price = new int[n + 1];

            for (var i = 1; i < n + 1; i++)
            {
                a_temp = Console.ReadLine().Split(' ');
                a = Array.ConvertAll(a_temp, Int32.Parse);
                gas[i] = a[0];
                price[i] = a[1];
            }

            var queries = new int[q][];

            for (var i = 0; i < q; i++)
            {
                a_temp = Console.ReadLine().Split(' ');
                a = Array.ConvertAll(a_temp, Int32.Parse);
                queries[i] = new int[] { a[0], a[1] };
            }

            RoadTrip2(roads, gas, price, queries);


            /*
            var roads = new int[] { 0, 2, 6, 1, 5, 3};
            var gas = new int[] { 0, 3, 4, 3, 1, 4, 9};
            var price = new int[] { 0, 1, 2, 1, 4, 6, 3};

            var queries = new int[][]
            {
                new int [] { 2, 5 },
                new int [] { 1, 6 },
                new int [] { 3, 5 },
                new int [] { 4, 6 },
            };

            RoadTrip(roads, gas, price, queries);  
            */
        }

        private void RoadTrip2(int[] roads, int[] gas, int[] price, int[][] queries)
        {
            for (var i = 0; i < queries.Length; i++)
            {
                int s = queries[i][0];
                int d = queries[i][1];

                int cost = 0;
                int g = 0;
                int p = price[s];
                while (s != d)
                {
                    g += gas[s];
                    p = Math.Min(p, price[s]);
                    if (g < roads[s])
                    {
                        cost += p * (roads[s] - g);
                        g = roads[s];
                    }
                    g -= roads[s];
                    s++;
                }

                Console.WriteLine(cost);
            }
        }
    }
}
