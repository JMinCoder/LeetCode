using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    class BinarySearch
    {
        public void Test()
        {
            var data = new int[][]
            {
                new int[]{ 1, 2, 4, 6, 7, 8, 100},
                new int[]{ 8, 22, 33, 34, 41, 45, 46, 47, 60, 80, 100 }
            };

            var toSearch = new int[] { 7, 22, 8, 60, 75 };

            //for (var i = 0; i < data.Length; i++)
            //{
            //    for (var j = 0; j < toSearch.Length; j++)
            //    {
            //        if (BSIterative(data[i], toSearch[j]) != BSRecursive(data[i], 0, data[i].Length, toSearch[j]))
            //        {
            //            Console.WriteLine("Iter : {0}, Rec : {1}, Elem : {2}",
            //                BSIterative(data[i], toSearch[j]),
            //                BSRecursive(data[i], 0, data[i].Length, toSearch[j]),
            //                toSearch[j]);
            //        }
            //    }
            //}

            CeilIndex(data[1], -1, data[1].Length - 1, 60);

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < toSearch.Length; j++)
                {
                    Console.WriteLine("CeilIndex for {0} is {1} in {2}",
                        toSearch[j],
                        CeilIndex(data[i], -1, data[i].Length-1, toSearch[j]),
                        String.Join(",", data[i]));
                }
            }
        }

        public static int BSIterative(int []arr, int x)
        {
            int low = 0; int high = arr.Length;
            
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == x) return mid;
                if (arr[mid] > x)
                    high = mid;
                else
                    low = mid+1;
            }

            return -1;
        }

        public static int BSRecursive(int[] arr, int low, int high, int x)
        {
            if (low >= high) return -1;
            int mid = low + (high - low) / 2;

            if (arr[mid] == x)
                return mid;

            if (arr[mid] > x)
                return BSRecursive(arr, low, mid, x);

            return BSRecursive(arr, low + 1, high, x);
        }

        /*
         * Find the index of the element just greater equal to number x
         * 
         * Call with -1, arr.Length-1
         */
        public static int CeilIndex(int []arr, int low, int high, int x)
        {
            if (low >= high) return -1;
            
            while (high - low > 1)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] >= x)
                    high = mid;
                else
                    low = mid;
            }

            return high;
        }
    }
}
