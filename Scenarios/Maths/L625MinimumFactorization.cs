using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Maths
{
    /*
     * https://leetcode.com/problems/minimum-factorization
     * 
     * Given a positive integer a, find the smallest positive integer b whose multiplication of each digit equals to a.
     * 
     * If there is no answer or the answer is not fit in 32-bit signed integer, then return 0.
     * 
     * Input: 48 Output: 68
     * Input: 15 Output: 35
     */
    class L625MinimumFactorization
    {
        public void Test()
        {
            Console.WriteLine(this.SmallestFactorization1(27000000));
            Console.WriteLine(this.SmallestFactorization1(18000000));


            for (var i = 1; i < 20; i++)
            {
                Console.WriteLine("{0} : {1}", i, this.SmallestFactorization1(i));
            }

            Console.WriteLine(this.SmallestFactorization1(48));
            Console.WriteLine(this.SmallestFactorization1(15));
        }

        public int SmallestFactorization1(int a)
        {
            if (a < 2) return a;

            long res = 0;
            long mul = 1;
            for (var i = 9; i >= 2; i--)
            {
                while (a % i == 0)
                {
                    a /= i;
                    res += mul * i;
                    mul *= 10;
                }
            }

            if (a < 2 && res <= Int32.MaxValue)
                return (int)res;
            return 0;
        }

        public int SmallestFactorization(int a)
        {
            var arr = new int[10];
            int n = a;

            if (n == 1) return 1;
            while (n % 2 == 0)
            {
                arr[2]++;
                n = n / 2;
            }

            for (int i = 3; i <= (int)Math.Sqrt(n); i = i + 2)
            {
                while (n % i == 0)
                {
                    if (i < 10)
                        arr[i]++;
                    n = n / i;
                }
            }

            if (n > 2)
            {
                if (n < 10)
                    arr[n]++;
            }

            var prod = 1;
            for (var i = 0; i < arr.Length; i++)
            {
                int count = arr[i];
                while (count > 0)
                {
                    prod *= i;
                    count--;
                }
            }
            if (prod != a) return 0;

            arr[9] = arr[3] / 2;
            arr[3] = arr[3] % 2;
            arr[8] = arr[2] / 3;
            arr[2] = arr[2] % 3;

            if (arr[2] >= 1 && arr[3] == 1)
            {
                arr[6] = 1;
                arr[2]--;
                arr[3] = 0;
            }
            arr[4] = arr[2] / 2;
            arr[2] = arr[2] % 2;
            int res = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                int count = arr[i];
                while (count > 0)
                {
                    if (res < Int32.MaxValue / 10)
                        res = res * 10 + i;
                    else
                        return 0;
                    count--;
                }
            }
            return res;
        }
    }
}
