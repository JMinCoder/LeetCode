using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

For example,
Given n = 3,

You should return the following matrix:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]
     */
    class L059SpiralMatrix2
    {
        public void Test()
        {
            for (var count = 1; count < 10; count++)
            {
                var mat = this.GenerateMatrix2(count);
                for (var i = 0; i < mat.GetLength(0); i++)
                {
                    for (var j = 0; j < mat.GetLength(1); j++)
                    {
                        Console.Write("{0,4} ", mat[i, j]);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("-------------------");
            }
        }

        public int[,] GenerateMatrix(int n)
        {
            var mat = new int[n, n];

            var count = 1;
            int rs = 0, cs = 0;
            int re = n, ce = n;

            while (rs < re && cs < ce)
            {
                for (var j = cs; j < ce; j++)
                {
                    mat[rs, j] = count++;
                }
                rs++;
                if (rs >= re) break;
                
                for (var i = rs; i < re; i++)
                {
                    mat[i, ce-1] = count++;
                }
                ce--;
                if (cs >= ce) break;
                
                for (var j = ce - 1; j >= cs; j--)
                {
                    mat[re-1, j] = count++;
                }
                re--;
                if (rs >= re) break;
                for (var i = re - 1; i >= rs; i--)
                {
                    mat[i, cs] = count++;
                }
                cs++;
            }

            return mat;
        }

        public int[,] GenerateMatrix2(int n)
        {
            var mat = new int[n, n];
            var dirs = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            var count = 1;
            var nSteps = new int [] { n, n-1};

            int iDir = 0;   // index of direction.
            int ir = 0, ic = -1;    // initial position
            while (nSteps[iDir % 2] != 0)
            {
                for (int i = 0; i < nSteps[iDir % 2]; ++i)
                {
                    ir += dirs[iDir, 0];
                    ic += dirs[iDir, 1];
                    mat[ir, ic] = count++;
                }
                nSteps[iDir % 2]--;
                iDir = (iDir + 1) % 4;
            }
            

            return mat;
        }
    }
}
