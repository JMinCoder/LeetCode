using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class Contest38
    {
        private void Print(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public void Test()
        {
            //Print(this.MaximumProduct(new int[] { 1, 2, 3 }));
            //Print(this.MaximumProduct(new int[] { 1, 2, 3, 4 }));
            //Print(this.MaximumProduct(new int[] { 1, 2, 3, 4, -10 }));
            //Print(this.MaximumProduct(new int[] { 1, 2, 3, 4, -10, -2 }));

            //// 4
            //Print(this.ScheduleCourse1(new int[,] {
            //    {7,16},{2,3},{3,12},{3,14},{10,19},{10,16},{6,8},{6,11},{3,13},{6,16}
            //}));

            ////2 
            //Print(this.ScheduleCourse1(new int[,] {
            //    {5,5 }, {4,6 }, {2,6 }
            //    }));


            //// 4
            //Print(this.ScheduleCourse1(new int[,] {
            //    {7,17},{3,12},{10,20},{9,10},{5,20},{10,19},{4,18}
            //}));



            //// 3
            //Print(this.ScheduleCourse1(new int[,] {
            //    { 100, 200},
            //    { 1000, 1250 },
            //    { 2000, 3200 },
            //    { 200, 1300 }
            //}));

            //var e = new Excel(3, 'C');
            //e.Set(1, 'A', 2);
            //e.Sum(3, 'C', new string[] { "A1", "A1:B2" });
            //e.Set(2, 'B', 2);  


            Print(this.KInversePairs(3, 0));
            Print(this.KInversePairs(3, 1));
        }

       

        public int KInversePairs(int n, int k)
        {
            long[,] dp = new long[n, k + 1];
            dp[0, 0] = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    for (int m = j; m >= 0 && m >= (j - i); m--)
                    {
                        dp[i, j] += dp[i - 1, m];
                    }
                    dp[i, j] = dp[i, j] % 1000000007;
                }
            }
            return (int)dp[n - 1, k];
        }

        public int ScheduleCourse1(int[,] courses)
        {
            int n = courses.GetLength(0);

            var list = new List<KeyValuePair<int, int>>(n);
            for (var i = 0; i < courses.GetLength(0); i++)
            {
                list.Add(new KeyValuePair<int, int>(courses[i, 0], courses[i, 1]));
            }
            list.Sort((x, y) => x.Value - y.Value);

            var cls = new SortedSet<int>();
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                // if we have enough time, we will take this course
                if (sum + list[i].Key <= list[i].Value)
                {
                    cls.Add(list[i].Key);
                    sum += list[i].Key;
                }
                else if (cls.Max > list[i].Key)
                {
                    // if we don't have enough time, we switch out a longer course
                    sum += list[i].Key - cls.Max;
                    cls.Remove(cls.Max);
                    cls.Add(list[i].Key);
                } // if we don't have enough time for course[i], 
                  //and it's longer than any courses taken, then we ignore it
            }

            return cls.Count;
        }

        public int ScheduleCourse(int[,] courses)
        {
            int n = courses.GetLength(0);

            var list = new List<KeyValuePair<int, int>>(n);
            for (var i = 0; i < courses.GetLength(0); i++)
            {
                list.Add(new KeyValuePair<int, int>(courses[i, 0], courses[i, 1]));
            }
            list.Sort((x, y) => x.Value - y.Value);

            int maxTime = list[n - 1].Value;
            var dp = new int[n + 1][];

            for (var i = 0; i <= n; i++)
            {
                dp[i] = new int[maxTime + 1];
            }

            for (var i = 1; i <= n; i++)
            {
                for (var t = 0; t <= maxTime; t++)
                {
                    var tdiff = Math.Min(t, list[i - 1].Value) - list[i - 1].Key;
                    if (tdiff < 0)
                    {
                        dp[i][t] = dp[i - 1][t];
                    }
                    else
                    {
                        dp[i][t] = Math.Max(dp[i - 1][t], 1 + dp[i - 1][ tdiff]);
                    }
                }
            }

            return dp[n][ maxTime];
        }

        public class Excel
        {

            public Excel(int H, char W)
            {

            }

            public void Set(int r, char c, int v)
            {

            }

            public int Get(int r, char c)
            {
                return 0;
            }

            public int Sum(int r, char c, string[] strs)
            {
                return 0;
            }
        }

       

        public int MaximumProduct(int[] nums)
        {
            if (nums == null || nums.Length < 3) return 0;

            int len = nums.Length;

            Array.Sort(nums);
            return Math.Max(nums[0] * nums[1] * nums[len - 1], nums[len - 1] * nums[len - 2] * nums[len - 3]);
        }

    }
}
