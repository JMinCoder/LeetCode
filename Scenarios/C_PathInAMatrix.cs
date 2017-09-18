using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * Given a two dimensional matrix of 0 and 1, find is there exists a path between src and dest.
     * Path is only if there is a 1 in any direction
     */
    class C_PathInAMatrix
    {
        public void Test()
        {
            int[,] a = new int[5, 5]
            {
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0 },
                { 1, 1, 0, 1, 1 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 1, 1, 1 }
            };
            
            Console.WriteLine(this.DoesPathExist(a, new KeyValuePair<int, int>(3, 1), new KeyValuePair<int, int>(0, 4)));
            this.Print(a);
        }

        public bool DoesPathExist(int[,] a, KeyValuePair<int, int> src, KeyValuePair<int, int> dst)
        {
            int count = 2;

            a[src.Key, src.Value] = count++;
            return this.DoesPathExist(a, new KeyValuePair<int, int>(3, 1), new KeyValuePair<int, int>(0, 4), ref count);
        }

        private bool DoesPathExist(int [,] a, KeyValuePair<int,int> src, KeyValuePair<int,int> dst, ref int count)
        {
            int[,] dir = new int[4, 2] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            if (src.Key == dst.Key && src.Value == dst.Value) return true;

            for (var i = 0; i < dir.GetLength(0); i++)
            {
                int x = src.Key + dir[i, 0];
                int y = src.Value + dir[i, 1];

                if (x>=0 && x < a.GetLength(0) && y>=0 && y<a.GetLength(1) && a[x,y] == 1)
                {
                    a[x, y] = count++;
                    if (this.DoesPathExist(a, new KeyValuePair<int, int>(x, y), dst, ref count))
                    {
                        return true;
                    }
                    --count;
                    a[x, y] = 1;
                }
            }

            return false;
        }

        private void Print(int [,]a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", a[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
