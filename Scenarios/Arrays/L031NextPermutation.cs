using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Arrays
{
    public class L031NextPermutation
    {
        /*
         * https://leetcode.com/problems/next-permutation
         * 
         * Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
         * If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).
         * The replacement must be in-place, do not allocate extra memory.
         * Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
         * 1,2,3 → 1,3,2
         * 3,2,1 → 1,2,3
         * 1,1,5 → 1,5,1
         */
        public void Test()
        {
            int[][][] ns = {
                    //new int[][] { new int[] { }, new int[] { } },
                    //new int[][] { new int[] {0 },  new int[] { 0 } },
                    //new int[][] { new int[] {0, 1 },  new int[] { 1, 0} },
                    new int[][] { new int[] {1, 2, 3 },  new int[] {1, 3, 2 } },
                    new int[][] { new int[] {1, 3, 2}, new int[] {2, 1, 3} },
                    new int[][] { new int[] {3, 2, 1 },new int[] {1, 2, 3 } },                    
                    new int[][] { new int[] {1, 1 , 5 }, new int[] {1, 5, 1} },
                    new int[][] { new int[] {1, 1}, new int[] {1, 1} },
                    new int[][] { new int[] {1, 2, 3, 4}, new int[] {1, 2, 4, 3} },
                    new int[][] { new int[] {7, 8, 4, 6, 5, 2, 1 }, new int[] {7, 8, 5, 1, 2, 4, 6} },
                    new int[][] { new int[] { 3,6,5,4,2,1}, new int[] { 4, 1, 2, 3, 5, 6} }
            };
            for (var i = 0; i < ns.Length; i++)
            {
                //Print(ns[i][0]);
                this.NextPermutation(ns[i][0]);
                if (!Helpers.IsSame(ns[i][0], ns[i][1]))
                {
                    Console.WriteLine("Not same Input[{0}]", i);
                    Print(ns[i][0]);
                    Print(ns[i][1]);
                    Console.WriteLine("---------");
                }
            }
           
            //int[] num = { 1, 2, 3 };
            //for (var i=0;i< this.Fact(num.Length)+5;i++)
            //{
            //    Print(num);
            //    this.NextPermutation(num);
            //}
        }

        public void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1) return;
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i+1]) i--;

            if (i != -1)
            {
                int j = nums.Length - 1;
                while (j > i && nums[j] <= nums[i]) j--;
                this.Swap(nums, i, j);

                this.Reverse(nums, i+1);
            }
            else
            {
                this.Reverse(nums, 0);
            }
        }


        private void Swap(int []arr, int x, int y)
        {
            int tmp = arr[x];
            arr[x] = arr[y];
            arr[y] = tmp;
        }

        private void Reverse(int []arr, int start)
        {
            int i = start;
            int j = arr.Length - 1;

            while (i<j)
            {
                this.Swap(arr, i, j);
                ++i;
                --j;
            }
        }

        private void Print(int[] machines)
        {
            for (var i = 0; i < machines.Length; i++)
            {
                Console.Write(machines[i] + ", ");
            }
            Console.WriteLine("");
        }

        private int Fact(int n)
        {
            if (n <= 1) return 1;
            return n * Fact(n - 1);
        }
    }
}