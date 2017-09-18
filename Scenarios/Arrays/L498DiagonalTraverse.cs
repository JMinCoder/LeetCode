using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.
        Example:
        Input:
        [
         [ 1, 2, 3 ],
         [ 4, 5, 6 ],
         [ 7, 8, 9 ]
        ]
        Output:  [1,2,4,7,5,3,6,8,9]
     */
    class L498DiagonalTraverse
    {
        public void Test()
        {
            //var matrix = new int[,]
            //{
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};

            var matrix = new int[,]
            {
                {1 },
                {2 }
            };
            Console.WriteLine(String.Join(",", this.FindDiagonalOrder1(matrix)));
            Console.WriteLine(String.Join(",", this.FindDiagonalOrder(matrix)));
        }

        public int[] FindDiagonalOrder1(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return new int[0];

            int m = matrix.GetLength(0), n = matrix.GetLength(1);

            int[] result = new int[m * n];
            int row = 0, col = 0, d = 1;

            for (int i = 0; i < m * n; i++)
            {
                result[i] = matrix[row, col];
                row -= d;
                col += d;

                if (row >= m) { row = m - 1; col += 2; d = -d; }
                if (col >= n) { col = n - 1; row += 2; d = -d; }
                if (row < 0) { row = 0; d = -d; }
                if (col < 0) { col = 0; d = -d; }
            }

            return result;
        }

        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return new int[0];

            var result = new int[matrix.GetLength(0) * matrix.GetLength(1)];

            int i = 0; int j = 0; int count = 0; int d = 1;

            while (count < matrix.GetLength(0) * matrix.GetLength(1))
            {
                result[count++] = matrix[i, j];
                i -= d;
                j += d;
            
                if (i >= matrix.GetLength(0))
                {
                    i--;
                    j += 2;
                }

                if (j >= matrix.GetLength(1))
                {
                    j--;
                    i += 2;
                }

                if (i < 0)
                {
                    i = 0;
                }

                if (j<0)
                {
                    j = 0;
                }
            }

            return result;
        }
    }
}
