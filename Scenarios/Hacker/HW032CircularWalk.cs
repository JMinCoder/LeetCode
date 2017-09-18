using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Hacker
{
    class HW032CircularWalk
    {
        /*
         * Consider the following recurrence relation: where , , , and  are given values.
         * We have a circular walk with  points numbered sequentially from  to  (evenly spaced  unit apart) located along its circumference. From any position , Jen can jump up to  units along the circle's circumference in either the clockwise or counterclockwise direction. For example, if , she can jump to any position in .

Jen is standing at point , and her friend is standing at point . Assuming a single jump takes  second, can you find the minimum number of seconds it takes for Jen to reach her friend? If it's impossible for her to reach her friend (e.g., she's stuck in a position where ), print  instead.

Note: If Jen and her friend start out at the same location, she reaches her friend in  seconds.

Input Format

The first line contains three space-separated integers describing the respective values of , , and . 
The second line contains four space-separated integers describing the respective values of , , , and .

Constraints

Output Format

Print the minimum number of seconds Jen needs to get to her friend. If she is unable to reach her friend, print -1 instead.

Sample Input 0

9 0 2
1 3 4 7
Sample Output 0

2
         */
        public void Test()
        {
            Console.WriteLine(circularWalk1(9, 0, 2, 1, 3, 4, 7)); //2
            Console.WriteLine(circularWalk1(300000, 238682, 218897, 1220, 41, 2106, 2803)); // 8
        }

        static int circularWalk1(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            int maxn = 10000005;

            var wal = new bool[maxn];
            var b = new int[maxn];
            var a = new int[maxn];

            a[0] = r_0;
            for (int i = 1; i < n; i++) a[i] = (a[i - 1] * g +seed) % p;
            for (int i = s; i < n; i++) b[i - s] = a[i];
            for (int i = 0; i < s; i++) b[i + n - s] = a[i];
            t = (t - s + n) % n;
            int l = 0, r = 0;
            for (int i = 0; i <= n; i++)
            {
                if (t <= r || t >= n + l) { return i; }
                int pl = l, pr = r;
                for (int j = pl; j < 0; j++)
                {
                    if (wal[j + n]) break;
                    else
                    {
                        r = Math.Max(r, j + b[j + n]);
                        l = Math.Min(l, j - b[j + n]);
                        wal[j + n] = true;
                    }
                }
                for (int j = pr; j >= 0; j--)
                {
                    if (wal[j]) break;
                    else
                    {
                        r = Math.Max(r, j + b[j]);
                        l = Math.Min(l, j - b[j]);
                        wal[j] = true;
                    }
                }
            }
            
            return -1;
        }

        static int circularWalk2(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            if (s == t) return 0;
            if (s < 0 || s >= n || t < 0 || t >= n || r_0 == 0) return -1;

            var R = new int[n];
            R[0] = r_0;
            for (var i = 1; i < n; i++)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }

            var visited = new bool[n];
            var dis = new int[n];
            for (var i = 0; i < n; i++) dis[i] = Int32.MaxValue;
            dis[s] = 0;
            var q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            while (q.Count > 0)
            {
                int src = q.Dequeue();

                if (R[src] != 0)
                {
                    foreach (var neighbor in GetNeighor(src, R))
                    {
                        if (dis[neighbor] > dis[src] + 1)
                        {
                            q.Enqueue(neighbor);
                            dis[neighbor] = dis[src] + 1;
                        }
                        dis[neighbor] = Math.Min(dis[neighbor], dis[src] + 1);
                    }
                }
            }

            return dis[t] == Int32.MaxValue ? -1 : dis[t];
        }

        static int circularWalk(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            if (s == t) return 0;
            if (s < 0 || s >= n || t < 0 || t >= n || r_0 == 0) return -1;

            var R = new int[n];
            R[0] = r_0;
            for (var i = 1; i < n; i++)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }

            var visited = new bool[n];
            var dis = new int[n];
            for (var i = 0; i < n; i++) dis[i] = Int32.MaxValue;
            dis[s] = 0;
            var q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            while (q.Count > 0)
            {
                int src = q.Dequeue();

                if (R[src] != 0)
                {
                    foreach (var neighbor in GetNeighor(src, R))
                    {
                        if (dis[neighbor] > dis[src] + 1)
                        {
                            q.Enqueue(neighbor);
                            dis[neighbor] = dis[src] + 1;
                        }
                        dis[neighbor] = Math.Min(dis[neighbor], dis[src] + 1);
                    }
                }
            }

            return dis[t] == Int32.MaxValue ? -1 : dis[t];
        }

        static Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

        static IList<int> GetNeighor(int src, int[] R)
        {
            if (dict.ContainsKey(src)) return dict[src];

            var res = new List<int>();
            int n = R.Length;
            for (var i = 1; i <= R[src]; i++)
            {
                res.Add((src + i) % n);
                res.Add((src + n - i) % n);
            }
            dict.Add(src, res);
            return res;
        }
    }
}
