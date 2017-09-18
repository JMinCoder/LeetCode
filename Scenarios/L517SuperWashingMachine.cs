using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * You have n super washing machines on a line. Initially, each washing machine has some dresses or is empty.

For each move, you could choose any m (1 ≤ m ≤ n) washing machines, and pass one dress of each washing machine to one of its adjacent washing machines at the same time .

Given an integer array representing the number of dresses in each washing machine from left to right on the line, you should find the minimum number of moves to make all the washing machines have the same number of dresses. If it is not possible to do it, return -1.

Example1

Input: [1,0,5]

Output: 3

Explanation: 
1st move:    1     0 <-- 5    =>    1     1     4
2nd move:    1 <-- 1 <-- 4    =>    2     1     3    
3rd move:    2     1 <-- 3    =>    2     2     2   
Example2

Input: [0,3,0]

Output: 2

Explanation: 
1st move:    0 <-- 3     0    =>    1     2     0    
2nd move:    1     2 --> 0    =>    1     1     1     
Example3

Input: [0,2,0]

Output: -1

Explanation: 
It's impossible to make all the three washing machines have the same number of dresses. 
Note:
The range of n is [1, 10000].
The range of dresses number in a super washing machine is [0, 1e5].
     */
    class L517SuperWashingMachine
    {
        public void Test()
        {
            int[][] machs = {
                    new int[] {1, 0, 5},
                    new int[] {0, 3, 0},
                    new int[] {0, 2, 0},
                    new int[] {5, 0, 1},
                    new int[] {0,0,8,0},
                    new int[] { 10,0,10,0},
                    new int[] { 10,0,10,0,10,0,10,0,10,0,10,0 },
                    new int[] { 100000,0,100000,0,100000,0,100000,0,100000,0,100000,0 },
                    new int[] {2, 2}
            };
            foreach (var mach in machs)
            {
                Print(mach); 
                Console.WriteLine(" :::: " + FindMinMoves(mach));
            }
        }

        public int FindMinMoves(int[] machines)
        {
            int len = machines.Length;
            int[] sums = new int[len + 1];
            
            for (var i = 0; i < len; i++)
            {
                sums[i+1] = sums[i] + machines[i];
            }

            if (sums[len] % len != 0) return -1;

            int avg = sums[len] / len;
            int moves = 0;
            for (var i = 0; i < len; i++)
            {
                int left = i * avg - sums[i];
                int right = (len - 1 - i) * avg - (sums[len] - sums[i] - machines[i]);

                if (left > 0 && right > 0)
                {
                    moves = Math.Max(moves, Math.Abs(left) + Math.Abs(right));
                }
                else
                {
                    moves = Math.Max(moves, Math.Max(Math.Abs(left), Math.Abs(right)));
                }
            }
            return moves;
        }

        //public int FindMinMoves(int[] machines)
        //{
        //    int[] sums = new int[machines.Length + 1];
        //    sums[0] = machines[0];
        //    for (var i = 1; i < machines.Length; i++)
        //    {
        //        sums[i] = sums[i - 1] + machines[i];
        //    }

        //    if (sums[sums.Length - 1] % sums.Length != 0) return -1;

        //    int avg = sums[sums.Length - 1] / machines.Length;
        //    int moves = 0;
        //    for (var i = 0; i < machines.Length; i++)
        //    {
        //        int left = i * avg - sums[i];
        //        int right = (sums.Length - 1 - i) * avg - (sums[sums.Length-1] - sums[i] - machines[i]);

        //        if (left > 0 && right > 0)
        //        {
        //            moves = Math.Max(moves, Math.Abs(left) + Math.Abs(right));
        //        }
        //        else
        //        {
        //            moves = Math.Max(moves, Math.Max(Math.Abs(left), Math.Abs(right)));
        //        }
        //    }
        //    return moves;
        //}

        private void Print(int[] machines)
        {
            for (var i = 0; i < machines.Length; i++)
            {
                Console.Write(machines[i] + " ");
            }
            //Console.WriteLine("");
        }
    }
}
