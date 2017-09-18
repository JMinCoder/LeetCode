using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * http://www.geeksforgeeks.org/?p=753
     * 
     * Ugly numbers are numbers whose only prime factors are 2, 3 or 5. The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … 
     * shows the first 11 ugly numbers. By convention, 1 is included.
     * 
     * Given a number n, the task is to find n’th Ugly number.
     * 
     * Input  : n = 7   Output : 8
     * Input  : n = 10  Output : 12
     * Input  : n = 15  Output : 24
     * Input  : n = 150 Output : 5832
     */
    class G4G_UglyNumbers
    {
        public void Test()
        {
            var n = 2000;
            var sw = new Stopwatch();
            sw.Start();
            this.GetNthUglyNumber(n);
            sw.Stop();
            Console.WriteLine("Time : {0}", sw.ElapsedMilliseconds);
            var sw1 = new Stopwatch();
            sw1.Start();
            this.GetNthUglyNumber1(n);
            sw1.Stop();
            Console.WriteLine("Time : {0}", sw1.ElapsedMilliseconds);

            for (var i=1;i<100;i++)
            {
                if (this.GetNthUglyNumber1(i) != this.GetNthUglyNumber(i))
                {
                    Console.WriteLine("{0} => {1}:{2}", i, this.GetNthUglyNumber1(i), this.GetNthUglyNumber(i));
                }
            }            
        }

        public int GetNthUglyNumber(int n)
        {
            var dp = new int[n];
            dp[0] = 1;
            int f2 = 0; int f3 = 0; int f5 = 0;

            for (var i=1;i<n;i++)
            {
                int x2 = dp[f2] * 2;
                int x3 = dp[f3] * 3;
                int x5 = dp[f5] * 5;

                var min = Math.Min(x2, Math.Min(x3, x5));
                if (x2 == min) f2++;
                if (x3 == min) f3++;
                if (x5 == min) f5++;
                dp[i] = min;
            }

            return dp[n - 1];
        }

        public int GetNthUglyNumber1(int n)
        {
            if (n <= 0) return -1;
            if (n == 1) return 1;
            int count = 1;
            int cur = 1;
            while ( count < n)
            {
                if (this.IsUgly(++cur))
                {
                    count++;
                }
            }
            return cur;
        }

        private bool IsUgly(int n)
        {
            n = this.DivideBy(n, 2);
            n = this.DivideBy(n, 3);
            n = this.DivideBy(n, 5);

            return n == 1;
        }

        private int DivideBy(int n, int d)
        {
            while (n % d == 0)
            {
                n = n / d;
            }
            return n;
        }
    }
}
