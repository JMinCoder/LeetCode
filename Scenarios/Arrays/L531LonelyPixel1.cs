using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    class L531LonelyPixel1
    {
        /*
         *Given a picture consisting of black and white pixels, find the number of black lonely pixels.

The picture is represented by a 2D char array consisting of 'B' and 'W', which means black and white pixels respectively.

A black lonely pixel is character 'B' that located at a specific position where the same row and same column don't have any other black pixels.

Example:
Input: 
[['W', 'W', 'B'],
 ['W', 'B', 'W'],
 ['B', 'W', 'W']]

Output: 3
Explanation: All the three 'B's are black lonely pixels.
         */

        public void Test()
        {
            var p1 = new Char[3, 3]
            {
                { 'W', 'W', 'B' },
                { 'B', 'W', 'W' },
                { 'W', 'B', 'W' },
               
            };

            Console.WriteLine(this.FindLonelyPixel(p1));
        }

        public int FindLonelyPixel(char[,] picture)
        {
            int []row = new int[picture.GetLength(0)];
            int []col = new int[picture.GetLength(1)];

            for (var i=0;i< picture.GetLength(0);++i)
            {
                for (var j=0;j<picture.GetLength(1);++j)
                {
                    if (picture[i,j] == 'B')
                    {
                        row[i]++;
                        col[j]++;
                    }
                }
            }

            int count = 0;
            for (var i=0;i<row.Length;++i)
            {
                if (row[i] == 1)
                {
                    for (var j = 0; j < picture.GetLength(1); ++j)
                    {
                        if (picture[i, j] == 'B')
                        {
                            if (col[j] == 1)
                                count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }
    }
}
