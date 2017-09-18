using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
     */
    class L149MaxPointsOnALine
    {
        public class Point
        {
            public int x;
            public int y;
            public Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }

        class PointEqualityComparer : IEqualityComparer<Point>
        {
            public bool Equals(Point p1, Point p2)
            {
                if (p2 == null && p1 == null)
                    return true;
                else if (p1 == null | p2 == null)
                    return false;
                else if (p1.x == p2.x && p1.y == p2.y)
                    return true;
                else
                    return false;
            }

            public int GetHashCode(Point p)
            {
                int hCode = p.x  ^ p.y;
                return hCode.GetHashCode();
            }
        }

        public void Test()
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(1,1),
                new Point(2,2),
                new Point(-1,1),
                new Point(3,3),
                new Point(3,4),
            };

            Console.WriteLine("{0}", this.MaxPoints(points));
        }

        public int MaxPoints(Point[] points)
        {
            if (points.Length < 2)
                return points.Length;

            int maxPoint = 0;
            int curMax, overlapPoints, verticalPoints;

            // map to store slope pair
            var slopeMap = new Dictionary<Point, int>(new PointEqualityComparer());
            //unordered_map<pair<int, int>, int> slopeMap;

            //  looping for each point
            for (int i = 0; i < points.Length; i++)
            {
                curMax = overlapPoints = verticalPoints = 0;

                //  looping from i + 1 to ignore same pair again
                for (int j = i + 1; j < points.Length; j++)
                {
                    //  If both point are equal then just
                    // increase overlapPoint count
                    if (points[i] == points[j])
                    {
                        overlapPoints++;
                    }
                    else if (points[i].x == points[j].x)
                    {
                        // If x co-ordinate is same, then both
                        // point are vertical to each other
                        verticalPoints++;
                    }
                    else
                    {
                        int yDif = points[j].y - points[i].y;
                        int xDif = points[j].x - points[i].x;
                        
                        int g = Helpers.GCD(xDif, yDif);

                        // reducing the difference by their gcd
                        yDif /= g;
                        xDif /= g;

                        // increasing the frequency of current slope in map
                        var pDif = new Point(yDif, xDif);
                        if (slopeMap.ContainsKey(pDif))
                        {
                            slopeMap[pDif]++;
                        }
                        else
                        {
                            slopeMap.Add(pDif, 1);
                        }

                        curMax = Math.Max(curMax, slopeMap[pDif]);
                    }

                    curMax = Math.Max(curMax, verticalPoints);
                }

                // updating global maximum by current point's maximum
                maxPoint = Math.Max(maxPoint, curMax + overlapPoints + 1);

                Console.WriteLine("Max till now : {0}", curMax + overlapPoints + 1);
               
                slopeMap.Clear();
            }

            return maxPoint;
        }
    }
}
