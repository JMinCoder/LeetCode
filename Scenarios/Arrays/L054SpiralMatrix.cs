using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * Print a two dimensional matrix in a spiral fashion.
     */
    class L054SpiralMatrix
    {
        public void Test()
        {
            var m = new int[,]
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 }
            };
            Console.WriteLine(String.Join(", ",this.GetSpiral(m)));
        }

        IList<int> GetSpiral(int [,] matrix)
        {
            int rs = 0, re = matrix.GetLength(0);
            int cs = 0, ce = matrix.GetLength(1);
            var list = new List<int>(re * ce);

            while (rs < re && cs < ce)
            {
                for (var j = cs; j < ce; j++)
                    list.Add(matrix[rs, j]);
                rs++;
                if (rs >= re) break;
                for (var i = rs; i < re; i++)
                    list.Add(matrix[i, ce - 1]);
                ce--;
                if (cs >= ce) break;
                for (var j = ce -1; j >= cs; j--)
                    list.Add(matrix[re - 1, j]);
                re--;
                if (rs >= re) break;
                for (var i = re - 1; i >= rs; i--)
                    list.Add(matrix[i, cs]);

                cs++;
            }

            return list;
        }
    }
}
