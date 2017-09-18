using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class NewYorkPath
    {
        public void Test()
        {
            var arr = new int[,]
            {
                {1, 0, 0, 1 },
                {0, 0, 0, 1 },
                {0, 1, 0, 0 }
            };
            Console.WriteLine("Meeting distance : {0}", this.GetMeetingDistance(arr));
        }


















        public int GetMeetingDistance(int [,]loc)
        {
            int[] rows = new int[loc.GetLength(0)];
            int[] cols = new int[loc.GetLength(1)];

            for (var i = 0; i < loc.GetLength(0); i++)
            {
                for (var j = 0; j < loc.GetLength(1); j++)
                {
                    if (loc[i, j] == 1)
                    {
                        rows[i]++;
                        cols[j]++;
                    }
                }
            }

            int meetingRow = GetLocation(rows);
            int meetingCol = GetLocation(cols);

            Console.WriteLine("Meeting point : {0},{1}", meetingRow, meetingCol);
            int totalDistance = 0;

            for (var i = 0; i < loc.GetLength(0); i++)
            {
                for (var j = 0; j < loc.GetLength(1); j++)
                {
                    if (loc[i, j] == 1)
                    {
                        totalDistance += Math.Abs(meetingRow - i);
                        totalDistance += Math.Abs(meetingCol - j);
                    }
                }
            }

            return totalDistance;
        }

        private static int GetLocation(int[] arr)
        {
            int s = 0, e = arr.Length-1, sSum = 0 , eSum = 0;

            while (s < e)
            {
                if (sSum <= eSum)
                {
                    sSum += arr[s];
                    s++;
                }
                else
                {
                    eSum += arr[e];
                    e--;
                }
            }

            return s;
        }
    }
}
