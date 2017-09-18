using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * http://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/
     * 
     * Given two strings str1 and str2 and below operations that can performed on str1. Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.

Insert
Remove
Replace
All of the above operations are of equal cost.

Examples:

Input:   str1 = "geek", str2 = "gesek"
Output:  1
We can convert str1 into str2 by inserting a 's'.

Input:   str1 = "cat", str2 = "cut"
Output:  1
We can convert str1 into str2 by replacing 'a' with 'u'.

Input:   str1 = "sunday", str2 = "saturday"
Output:  3
Last three and first characters are same.  We basically
need to convert "un" to "atur".  This can be done using
below three operations. 
Replace 'n' with 'r', insert t, insert a
    */
    class G4G05_EditDistance
    {
        public void Test()
        {
            Console.WriteLine(this.FindEditDistance("geek", "gesek")); // 1
            Console.WriteLine(this.FindEditDistance("cat", "cut")); // 1
            Console.WriteLine(this.FindEditDistance("sunday", "saturday")); // 3
        }

        public int FindEditDistance(string s1, string s2)
        {
            return 0;
        }
    }
}
