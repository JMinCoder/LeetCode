using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Graph
{
    class Maze2
    {
        public void Test()
        {
            int[][] maze1 = new int[][]
            {
                new int [] { 0, 0 , 1, 0 , 0},
                new int [] { 0, 0 , 0, 0 , 0},
                new int [] { 0, 0 , 0, 1 , 0},
                new int [] { 1, 1 , 0, 1 , 1},
                new int [] { 0, 0 , 0, 0 , 0},
            };
            int[] start = new int[] { 0, 4 };
            int[] destination = new int[] { 4, 4 };
            int[] destination2 = new int[] { 3, 2 };

            Console.WriteLine(this.shortestDistance(maze1, start, destination));
            Console.WriteLine(this.shortestDistance(maze1, start, destination2));
        }

        class Point
        {
            public int x;
            public int y;
            public int l;
            public Point(int x, int y, int l)
            {
                this.x = x;
                this.y = y;
                this.l = l;
            }
        }
        public int shortestDistance(int [][]maze, int[] start, int []destination)
        {
            int m = maze.Length;
            int n = maze[0].Length;

            int[,] length = new int[m,n];
            for (var i = 0; i < m * n; i++) length[i / n,i % n] = Int32.MaxValue;
            int[][] dir = new int[][] { 
                new int[]{ -1, 0 },
                new int[]{ 0, 1 },
                new int[]{ 1, 0 },
                new int[]{ 0, -1 } };

            SimplePriorityQueue<Point> list = new SimplePriorityQueue<Point>();
            list.Enqueue(new Point(start[0], start[1], 0), 0);
            while (list.Count > 0)
            {
                var p = list.Dequeue();
                if (length[p.x,p.y] <= p.l) continue;
                length[p.x, p.y] = p.l;

                for (int i=0;i<4;i++)
                {
                    int xx = p.x, yy = p.y, l = p.l;
                    while (xx>=0 && xx<m && yy>=0 && yy<n && maze[xx][yy]==0)
                    {
                        xx += dir[i][0];
                        yy += dir[i][1];
                        l++;
                    }
                    xx -= dir[i][0];
                    yy -= dir[i][1];
                    l--;

                    list.Enqueue(new Point(xx, yy, l), l);
                }
            }

            return length[destination[0],destination[1]]==Int32.MaxValue
                 ? -1
                 : length[destination[0], destination[1]];
        }
    }
}
