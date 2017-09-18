using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * House coloring with red, blue and green.
     * There are a row of houses, each house can be painted with three colors red, blue and green. 
     * The cost of painting each house with a certain color is different. 
     * You have to paint all the houses such that no two adjacent houses have the same color. 
     * You have to paint the houses with minimum cost. How would you do it?
     * 
     * Note: Painting house-1 with red costs different from painting house-2 with red. 
     * The costs are different for each house and each color.
     */
    class HouseColoring
    {
        enum Colors
        {
            Red = 0,
            Green = 1,
            Blue = 2
        } 

        public void Test()
        {
            int[][] costMatrix = {
                new int [] {7, 5, 10},
                new int [] {3, 6, 1},
                new int [] {8, 7, 4},
                new int [] {6, 2, 9},
                new int [] {1, 4, 7},
                new int [] {2, 3, 6}
            };

            int cost = 0;
            var list = CalcHouseColoringCost(costMatrix, ref cost);
            Console.WriteLine("Cost of coloring the house is : {0}", cost);
            Console.WriteLine(String.Join(", ", list));
        }

        public IList<string> CalcHouseColoringCost(int[][] M, ref int finalCost)
        {
            int r = M.Length + 1;
            int c = M[0].Length;
            int[,] cost = new int[r,c];
            

            for (var i=0;i<c;i++)
            {
                cost[0,i] = 0;
            }

            for (var i=1;i<r;i++)
            {
                cost[i,0] = M[i - 1][0] + Math.Min(cost[i - 1, 1], cost[i - 1, 2]);
                cost[i,1] = M[i - 1][1] + Math.Min(cost[i - 1, 0], cost[i - 1, 2]);
                cost[i,2] = M[i - 1][2] + Math.Min(cost[i - 1, 0], cost[i - 1, 1]);
            }

            Print(cost);
            finalCost = Math.Min(cost[M.Length, 0], Math.Min(cost[M.Length, 1], cost[M.Length, 2]));

            //
            // Try to get the list of colors
            //
            var list = new List<string>(M.Length);
            int prev = 0;
            int curCost = finalCost;

            if (finalCost == cost[M.Length, 0])
            {
                prev = 0;
            }
            else if (finalCost == cost[M.Length, 1])
            {
                prev = 1;
            }
            else
            {
                prev = 2;
            }

            list.Add(((Colors)prev).ToString());

            for (var i = M.Length-1; i > 0; i--)
            {
                curCost -= M[i][prev];
                var n1 = (prev + 1) % 3;
                var n2 = (prev + 2) % 3;
                if (cost[i, n1] == curCost)
                {
                    prev = n1;
                }
                else
                {
                    prev = n2;
                }
                list.Add(((Colors)prev).ToString());
            }

            list.Reverse();

            return list;
        }

        private void Print(int[,] cost)
        {
            for (var i=0;i<cost.GetLength(0);i++)
            {
                for (var j=0;j<cost.GetLength(1);j++)
                {
                    Console.Write("{0,5}", cost[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
