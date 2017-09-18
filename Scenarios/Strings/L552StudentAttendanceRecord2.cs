using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * Given a positive integer n, return the number of all possible attendance records with length n, which will be 
     * regarded as rewardable. The answer may be very large, return it after mod 10^9 + 7.
     * 
     * A student attendance record is a string that only contains the following three characters:

    'A' : Absent.
    'L' : Late.
    'P' : Present.
    A record is regarded as rewardable if it doesn't contain more than one 'A' (absent) or more than two continuous 'L' 
    (late).

    Example 1:
    Input: n = 2
    Output: 8 
    Explanation:
    There are 8 records with length 2 will be regarded as rewardable:
    "PP" , "AP", "PA", "LP", "PL", "AL", "LA", "LL"
    Only "AA" won't be regarded as rewardable owing to more than one absent times. 
    Note: The value of n won't exceed 100,000.
     */
    class L552StudentAttendanceRecord2
    {
        public void Test()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} : {1}", i, this.CheckRecord(i));
            }

            Console.WriteLine("{0}", this.CheckRecord(50));
        }

        public int CheckRecord(int n)
        {
            int MOD = 1000000007;
            if (n <= 0) return 0;

            var M = new int[n+1, 2, 3];

            M[0, 0, 0] = 1;
            M[0, 0, 1] = 1;
            M[0, 0, 2] = 1;
            M[0, 1, 0] = 1;
            M[0, 1, 1] = 1;
            M[0, 1, 2] = 1;

            for (int i = 1; i <= n; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        int val = M[i - 1, j, 2]; // ...P
                        if (j > 0) val = (val + M[i - 1, j - 1, 2]) % MOD; // ...A
                        if (k > 0) val = (val + M[i - 1, j, k - 1]) % MOD; // ...L
                        M[i, j, k] = val;
                    }

            return M[n, 1, 2];


            //for (var i = 0; i < n + 1; i++)
            //{
            //    for (var j = 0; j < 2; j++)
            //    {
            //        for (var k = 0; k < 3; k++)
            //        {
            //            M[i, j, k] = -1;
            //        }
            //    }
            //}

            //return Counts(ref M, n, false, 0);            
        }

        private int Counts(ref int [,,] M, int n, bool usedA, int lCount)
        {
            int MOD = 1000000007;

            if (M[n, usedA ? 1 : 0, lCount] != -1) return M[n, usedA ? 1 : 0, lCount];

            int res = 0;
            if (n == 1)
            {
                res = 1;
                if (!usedA) res++;
                if (lCount < 2) res++;

                M[n, usedA ? 1 : 0, lCount] = res;
                return res;
            }

            // Current one is P
            res = Counts(ref M, n - 1, usedA, 0);

            // Current = A
            if (!usedA)
            {
                res = (res + Counts(ref M, n - 1, true, 0) % MOD);
            }

            // Current = L
            if (lCount < 2)
            {
                res = (res + Counts(ref M, n - 1, usedA, lCount + 1)) % MOD;
            }

            M[n, usedA ? 1 : 0, lCount] = res;

            return res;
        }

        /*
         * 
         * Approach #4 Dynamic Programming with Constant Space [Accepted]
         * Algorithm
         * We can observe that the number and position of PP's in the given string is irrelevant. Keeping into account this fact, we can obtain a state diagram that represents the transitions between the possible states as shown in the figure below:

         * This state diagram contains the states based only upon whether an AA is present in the string or not, and on the number of LL's that occur at the trailing edge of the string formed till now. The state transition occurs whenver we try to append a new character to the end of the current string.

Based on the above state diagram, we keep a track of the number of unique transitions from which a rewardable state can be achieved. We start off with a string of length 0 and keep on adding a new character to the end of the string till we achieve a length of nn. At the end, we sum up the number of transitions possible to reach each rewardable state to obtain the required result.

We can use variables corresponding to the states. axlyaxly represents the number of strings of length ii containing xx a'sa
​′
​​ s and ending with yy l'sl
​′
​​ s.
         * 
         * 
         * long M = 1000000007;
    public int checkRecord(int n) {
        long a0l0 = 1;
        long a0l1 = 0, a0l2 = 0, a1l0 = 0, a1l1 = 0, a1l2 = 0;
        for (int i = 0; i < n; i++) {
            long new_a0l0 = (a0l0 + a0l1 + a0l2) % M;
            long new_a0l1 = a0l0;
            long new_a0l2 = a0l1;
            long new_a1l0 = (a0l0 + a0l1 + a0l2 + a1l0 + a1l1 + a1l2) % M;
            long new_a1l1 = a1l0;
            long new_a1l2 = a1l1;
            a0l0 = new_a0l0;
            a0l1 = new_a0l1;
            a0l2 = new_a0l2;
            a1l0 = new_a1l0;
            a1l1 = new_a1l1;
            a1l2 = new_a1l2;
        }
        return (int)((a0l0 + a0l1 + a0l2 + a1l0 + a1l1 + a1l2) % M);
    }
         */
    }
}
