using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    class MatrixChainOrder
    {
        //30 35 15 5 10 20 25
        public void Test()
        {
            int[] matrixdimensions = { 30, 35, 15, 5, 10, 20, 25 };
            Console.WriteLine(this.FindMinimumMultiplications(matrixdimensions));
        }

        public int FindMinimumMultiplications(int []p)
        {
            int n = p.Length-1;
            int[,] M = new int[n,n];
            
            for (var l = 2; l <= n; l++)
            {
                for (var i = 0; i < n-l+1; i++)
                {
                    int j = i + l - 1;

                    M[i, j] = Int32.MaxValue;
                    for (var k=i;k<j;k++)
                    {
                        //Console.WriteLine("M[{0},{1}]= M[{0},{2}] + M[{3},{1}] + p[{0}]*p[{3}]*p[{4}]",i,j,k,k+1,j+1);

                        M[i, j] = Math.Min(M[i, j],
                                   M[i, k] + M[k+1, j] + p[i] * p[k+1] * p[j+1]);
                    }
                }
            }
            //Print(M);
            return M[0, n-1];
        }

        private void Print(int [,] arr)
        {
            for (var i=0;i<arr.GetLength(0);i++)
            {
                for (var j=0;j<arr.GetLength(1);j++)
                {
                    Console.Write("{0,6} ", arr[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
