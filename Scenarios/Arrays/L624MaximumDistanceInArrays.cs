using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/maximum-distance-in-arrays
     * 
     * Given m arrays, and each array is sorted in ascending order. Now you can pick up two integers from two different arrays (each array picks one) 
     * and calculate the distance. We define the distance between two integers a and b to be their absolute difference |a-b|. 
     * Your task is to find the maximum distance.
     * 
     * Example 1:
     * Input: 
     * [[1,2,3],
     *  [4,5],
     *  [1,2,3]]
     * Output: 4
     * Explanation: 
        One way to reach the maximum distance 4 is to pick 1 in the first or third array and pick 5 in the second array.
    Note:
    Each given array will have at least 1 number. There will be at least two non-empty arrays.
    The total number of the integers in all the m arrays will be in the range of [2, 10000].
    The integers in the m arrays will be in the range of [-10000, 10000].
     * 
     */
    class L624MaximumDistanceInArrays
    {
        public void Test()
        {
            var arr = new List<IList<int>>();
            arr.Add((new int[] { 1, 2, 3 }).ToList());
            arr.Add((new int[] { 4, 5 }).ToList());
            arr.Add((new int[] { 1, 2, 3 }).ToList());
            Console.WriteLine(this.MaxDistance(arr));

            arr = new List<IList<int>>();
            arr.Add((new int[] { -1, 1 }).ToList());
            arr.Add((new int[] { -3, 1, 4 }).ToList());
            arr.Add((new int[] { -2, -1, 0, 2 }).ToList());

            Console.WriteLine(this.MaxDistance(arr));
        }

        public int MaxDistance(IList<IList<int>> arrays)
        {
            var minArray = new KeyValuePair<int, int>[arrays.Count];
            var maxArray = new KeyValuePair<int, int>[arrays.Count];

            for (var i = 0; i < arrays.Count; i++)
            {
                minArray[i] = new KeyValuePair<int, int>(arrays[i][0], i);
                maxArray[i] = new KeyValuePair<int, int>(arrays[i][arrays[i].Count - 1], i);
            }

            Array.Sort(minArray, (x, y) => x.Key - y.Key);
            Array.Sort(maxArray, (x, y) => y.Key - x.Key);
            if (minArray[0].Value != maxArray[0].Value)
            {
                return Math.Abs(maxArray[0].Key - minArray[0].Key);
            }
            else
            {
                return Math.Max(
                    Math.Abs(maxArray[0].Key - minArray[1].Key),
                    Math.Abs(maxArray[1].Key - minArray[0].Key)
                    );
            }
        }
    }
}
