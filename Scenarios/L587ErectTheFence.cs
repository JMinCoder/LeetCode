using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class L587ErectTheFence
    {
        public void Test()
        {
            var points = new Point[]
            {
                new Point(4,2),
                new Point(2,4),
                new Point(2,2),
                new Point(2,0),
                new Point(3,3),
                new Point(1,1)
            };
            var res = this.OuterTrees(points);            
            //[[1,1],[2,0],[4,2],[3,3],[2,4]]
            for (var i=0;i<res.Count;i++)
            {
                Console.Write("[{0},{1}], ", res[i].x, res[i].y);
            }
            Console.WriteLine("");
        }

        public List<Point> OuterTrees(Point[] points)
        {
            if (points.Length <= 1)
                return points.ToList();

            SortByPolar(points, BottomLeft(points));
            var stack = new Stack<Point>();
            stack.Push(points[0]);
            stack.Push(points[1]);

            for (int i = 2; i < points.Length; i++)
            {
                Point top = stack.Pop();
                while (CCW(stack.Peek(), top, points[i]) < 0)
                    top = stack.Pop();
                stack.Push(top);
                stack.Push(points[i]);
            }

            return stack.ToList();
        }

        private static Point BottomLeft(Point[] points)
        {
            Point bottomLeft = points[0];
            foreach (Point p in points)
                if (p.y < bottomLeft.y || p.y == bottomLeft.y && p.x < bottomLeft.x)
                    bottomLeft = p;
            return bottomLeft;
        }

        /**
         * @return positive if counter-clockwise, negative if clockwise, 0 if collinear
         */
        private static int CCW(Point a, Point b, Point c)
        {
            return a.x * b.y - a.y * b.x + b.x * c.y - b.y * c.x + c.x * a.y - c.y * a.x;
        }

        private static void SortByPolar(Point[] points, Point r)
        {
            Array.Sort(points, (p1, q1) => {
                int x1 = p1.x - r.x;
                int y1 = p1.y - r.y;
                int x2 = q1.x - r.x;
                int y2 = q1.y - r.y;
                int compPolar = x2 * y1 - x1 * y2;
                int compDist = (x1 * x1 + y1 * y1) - (x2 * x2 + y2 * y2);
                return compPolar == 0 ? compDist : compPolar;
            });

            // find collinear points in the end positions
            Point p = points[0], q = points[points.Length - 1];
            int i = points.Length - 2;
            while (i >= 0 && CCW(p, q, points[i]) == 0)
                i--;
            // reverse sort order of collinear points in the end positions
            for (int l = i + 1, h = points.Length - 1; l < h; l++, h--)
            {
                Point tmp = points[l];
                points[l] = points[h];
                points[h] = tmp;
            }
        }

        public class Point
        {
            public int x;
            public int y;
            public Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }
    }
}
