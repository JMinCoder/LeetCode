using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.NotTagged
{
    /*
     * https://leetcode.com/problems/judge-route-circle/description/
     * 
     * Initially, there is a Robot at position (0, 0). Given a sequence of its moves, judge if this robot makes a circle, which means it moves back to the original place.

The move sequence is represented by a string. And each move is represent by a character. The valid robot moves are R (Right), L (Left), U (Up) and D (down). The output should be true or false representing whether the robot makes a circle.

Example 1:
Input: "UD"
Output: true
Example 2:
Input: "LL"
Output: false
     */
    class L657JudgeRouteCircle
    {
        public void Test()
        {
            Console.WriteLine(this.JudgeCircle("UD")); // true
            Console.WriteLine(this.JudgeCircle("LL")); // false
            Console.WriteLine(this.JudgeCircle("DURDLDRRLL"));
        }

        public bool JudgeCircle(string moves)
        {
            int h = 0; int v = 0;
            if (string.IsNullOrEmpty(moves)) return false;

            for (var i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'U': { v++; break; }
                    case 'D': { v--; break; }
                    case 'L': { h--; break; }
                    case 'R': { h++; break; }
                    default: break;
                }
            }
            if (v == 0 && h == 0) return true;
            return false;
        }
    }
}
