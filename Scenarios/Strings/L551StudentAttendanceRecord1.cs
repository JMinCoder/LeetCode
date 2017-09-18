using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * You are given a string representing an attendance record for a student. The record only contains the following three characters:

'A' : Absent.
'L' : Late.
'P' : Present.
A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

You need to return whether the student could be rewarded according to his attendance record.

Example 1:
Input: "PPALLP"
Output: True
Example 2:
Input: "PPALLL"
Output: False
    */
    class L551StudentAttendanceRecord1
    {
        public void Test()
        {
            var strs = new String[] { "PPALLP", "PPALLL", "PPALLPA", "PPLLALLPL" };
            for (var i = 0; i < strs.Length; i++)
            {
                if (this.CheckRecord(strs[i]) != this.CheckRecord2(strs[i]))
                {
                    Console.WriteLine("{0} : {1} {2}", strs[i], this.CheckRecord(strs[i]), this.CheckRecord2(strs[i]));
                }
            }
        }
        public bool CheckRecord(string s)
        {
            var hasA = false;
            var lcount = 0;

            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'A':
                        if (hasA) return false;
                        hasA = true;
                        lcount = 0;
                        break;
                    case 'L':
                        lcount++;
                        if (lcount > 2) return false;
                        break;
                    default:
                        lcount = 0;
                        break;
                }
            }
            return true;
        }

        public bool CheckRecord2(string s)
        {
            return !Regex.IsMatch(s, @".*LLL.*|.*A.*A.*");
        }
    }
}
