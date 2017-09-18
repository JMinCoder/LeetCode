using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    /*
     * There is a brick wall in front of you. The wall is rectangular and has several rows of bricks. The bricks have the same height but different width. You want to draw a vertical line from the top to the bottom and cross the least bricks.

The brick wall is represented by a list of rows. Each row is a list of integers representing the width of each brick in this row from left to right.

If your line go through the edge of a brick, then the brick is not considered as crossed. You need to find out how to draw the line to cross the least bricks and return the number of crossed bricks.

You cannot draw a line just along one of the two vertical edges of the wall, in which case the line will obviously cross no bricks.

Example:
Input: 
[[1,2,2,1],
 [3,1,2],
 [1,3,2],
 [2,4],
 [3,1,2],
 [1,3,1,1]]
Output: 2
     *  
     */
    class L554BrickWall
    {
        public void Test()
        {
            var wall = new List<IList<int>>
            {
                new List<int> { 1, 2, 2, 1 },
                new List<int> { 3, 1, 2},
                new List<int> { 1, 3, 2},
                new List<int> { 2, 4 },
                new List<int> { 3, 1, 2},
                new List<int> { 1, 3, 1, 1}
            };

            Console.WriteLine(this.LeastBricks(wall));
        }

        public int LeastBricks(IList<IList<int>> wall)
        {
            var dict = new Dictionary<int, int>();

            foreach (var list in wall)
            {
                var ending = 0;
                for (var i=0;i<list.Count-1;i++)
                {
                    ending += list[i];
                    if (dict.ContainsKey(ending))
                    {
                        dict[ending]++;
                    }
                    else
                    {
                        dict.Add(ending, 1);
                    }
                }
            }
            int max = 0;
            foreach (var p in dict)
            {
                if (p.Value > max)
                {
                    max = p.Value;
                }
            }

            return wall.Count - max;
        }
    }
}
