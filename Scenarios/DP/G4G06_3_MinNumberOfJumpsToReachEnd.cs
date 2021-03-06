﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * http://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/
     * 
     * Given an array of integers where each element represents the max number of steps that can be made forward from that element. 
     * Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). 
     * If an element is 0, then cannot move through that element.
     * 
     * Example:
     * Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
     * Output: 3 (1-> 3 -> 8 ->9)
     * First element is 1, so can only go to 3. Second element is 3, so can make at most 3 steps eg to 5 or 8 or 9.
     */
    class G4G06_3_MinNumberOfJumpsToReachEnd
    {
        public void Test()
        {
            Console.WriteLine(this.MinJumps(new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 }));
        }

        public int MinJumps(int []arr)
        {
            return 0;
        }
    }
}
