using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/image-smoother/description/
     * 
     * Given a 2D integer matrix M representing the gray scale of an image, you need to design a smoother to make the gray scale of each cell becomes the average gray scale (rounding down) of all the 8 surrounding cells and itself. If a cell has less than 8 surrounding cells, then use as many as you can.

Example 1:
Input:
[[1,1,1],
 [1,0,1],
 [1,1,1]]
Output:
[[0, 0, 0],
 [0, 0, 0],
 [0, 0, 0]]
Explanation:
For the point (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the point (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0
Note:
The value in the given matrix is in the range of [0, 255].
The length and width of the given matrix are in the range of [1, 150].
     */
    class L661ImageSmoother
    {
        public void Test()
        {
            var res = this.ImageSmoother(
                new int[3, 3] { { 1, 1, 1 },
                             { 1, 0, 1},
                             { 1, 1, 1} });
            for (var i = 0; i < res.GetLength(0); i++)
            {
                for (var j = 0; j < res.GetLength(1); j++)
                {
                    Console.Write("{0} ", res[i, j]);
                }
                Console.WriteLine("");
            }
        }

        public int[,] ImageSmoother(int[,] M)
        {
            var res = new int[M.GetLength(0), M.GetLength(1)];

            var dirs = new int[8, 2] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };
            for (var i = 0; i < M.GetLength(0); i++)
            {
                for (var j = 0; j < M.GetLength(1); j++)
                {
                    double val = M[i, j];
                    int count = 1;
                    for (var k = 0; k < dirs.GetLength(0); k++)
                    {
                        var x = i + dirs[k, 0]; var y = j + dirs[k, 1];
                        if (x >= 0 && x < M.GetLength(0) && y >= 0 && y < M.GetLength(1))
                        {
                            val += M[x, y];
                            count++;
                        }
                    }
                    res[i, j] = (int)Math.Floor(val / count);
                }
            }

            return res;
        }
    }
}
