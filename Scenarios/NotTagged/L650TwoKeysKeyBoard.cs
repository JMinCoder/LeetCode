using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.NotTagged
{
    /*
     * https://leetcode.com/problems/2-keys-keyboard/description/
     * 
     * Initially on a notepad only one character 'A' is present. You can perform two operations on this notepad for each step:

Copy All: You can copy all the characters present on the notepad (partial copy is not allowed).
Paste: You can paste the characters which are copied last time.
Given a number n. You have to get exactly n 'A' on the notepad by performing the minimum number of steps permitted. Output the minimum number of steps to get n 'A'.

Example 1:
Input: 3
Output: 3
Explanation:
Intitally, we have one character 'A'.
In step 1, we use Copy All operation.
In step 2, we use Paste operation to get 'AA'.
In step 3, we use Paste operation to get 'AAA'.
Note:
The n will be in the range [1, 1000].
     */
    class L650TwoKeysKeyBoard
    {
        public void Test()
        {
        }

        public int MinSteps(int n)
        {
            if (n <= 1) return 0;
            if (IsPrime(n)) return n;
            var primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            for (var i = 0; i < primes.Length; i++)
            {
                if (n % primes[i] == 0)
                {
                    return MinSteps(n / primes[i]) + primes[i];
                }
            }

            return -1;
        }

        private static bool IsPrime(int num)
        {
            if (num % 2 == 0)
                return false;
            for (int i = 3; i * i <= num; i += 2)
                if (num % i == 0) return false;
            return true;
        }
    }
}
