using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    class L289GameOfLife
    {
        public static void Test()
        {
            var g = new L289GameOfLife();
            var board = new int[2, 2] { { 1, 1 }, { 1, 0 } };
            g.GameOfLife(board);
            g.Print(board);
        }

        public void GameOfLife(int[,] board)
        {
            var copy = new int[board.GetLength(0), board.GetLength(1)];

            // Copy
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    copy[i, j] = board[i, j];
                }
            }

            var dirs = new int[8][] {
            new int[] {-1,-1},
            new int[] {-1,0},
            new int[] {-1,1},
            new int[] {0,-1},
            new int[] {0,1},
            new int[] {1,-1},
            new int[] {1,0},
            new int[] {1,1},
            };
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    int live = 0;
                    for (var k = 0; k < dirs.Length; k++)
                    {
                        int x = i + dirs[k][0]; int y = j + dirs[k][1];
                        if (x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
                        {
                            if (copy[x, y] == 1) live++;
                        }
                    }
                    if (copy[i, j] == 1)
                    {
                        if (live < 2 || live > 3) board[i, j] = 0;
                    }
                    else
                    {
                        if (live == 3) board[i, j] = 1;
                    }
                }
            }
        }

        public void Print(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("=========");
        }
    }
}
