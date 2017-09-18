using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    /*
     * https://leetcode.com/problems/find-k-closest-elements/description/
     * 
     * Given a sorted array, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

Example 1:
Input: [1,2,3,4,5], k=4, x=3
Output: [1,2,3,4]
Example 2:
Input: [1,2,3,4,5], k=4, x=-1
Output: [1,2,3,4]
Note:
The value k is positive and will always be smaller than the length of the sorted array.
Length of the given array is positive and will not exceed 104
Absolute value of elements in the array and x will not exceed 104
     */
    class L658FindKClosestElements
    {
        public void Test()
        {
            Helpers.Print(FindClosestElements(new List<int> { 0, 0, 1, 2, 3, 3, 4, 7, 7, 8 }, 3, 5)); // [[3,3,4]]
            Helpers.Print(FindClosestElements(new List<int> { 0, 1, 1, 1, 2, 3, 6, 7, 8, 9 }, 9, 4)); // [0,1,1,1,2,3,6,7,8]

            Helpers.Print(FindClosestElements(new List<int> { 1, 2, 3, 4, 5 }, 4, 3));
            Helpers.Print(FindClosestElements(new List<int> { 1, 2, 3, 4, 5 }, 4, -1));
        }

        public IList<int> FindClosestElements(IList<int> arr, int k, int x)
        {
            var res = arr.ToList();
            res.Sort((a, b) => Math.Abs(a - x) - Math.Abs(b - x));
            res.RemoveRange(k, arr.Count - k);
            res.Sort();
            return res;
        }

        public IList<int> FindClosestElements1(IList<int> arr, int k, int x)
        {
            var i = 0;
            for (i = 0; i < arr.Count; i++)
            {
                if (arr[i] >= x)
                    break;
            }
            var res = new List<int>();
            //res.Add(arr[i]);
            var p = i - 1; var q = i;
            //k--;
            while (k > 0 && p >= 0 && q < arr.Count)
            {
                if (Math.Abs(x - arr[p]) <= Math.Abs(x - arr[q]))
                {
                    res.Add(arr[p]); p--;
                }
                else
                {
                    res.Add(arr[q]); q++;
                }
                k--;
            }

            while (k > 0 && p >= 0)
            {
                res.Add(arr[p]); p--; k--;
            }
            while (k > 0 && q < arr.Count)
            {
                res.Add(arr[q]); q++; k--;
            }
            res.Sort();

            return res;
        }
    }
}
