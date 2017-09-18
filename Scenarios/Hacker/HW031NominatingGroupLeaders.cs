using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Hacker
{
    class HW031NominatingGroupLeaders
    {
        public void Test()
        {
            GroupLeaders(new int[] { 0, 1, 4, 0, 3 },
                new int[][]
                {
                    new int[] {0, 4, 1, 0 },
                    new int[] {2, 4, 2, 1 }
                });
            GroupLeaders(new int[] { 4, 3, 0, 0, 0 },
                new int[][]
                {
                    new int[] {0, 1, 1, 0 },
                    new int[] {2, 4, 3, 1 }
                });

            //GroupLeadersWithoutMo(new int[] { 0, 1, 4, 0, 3 },
            //    new int[][]
            //    {
            //        new int[] {0, 4, 1 },
            //        new int[] {2,4,2 }
            //    });
            //GroupLeadersWithoutMo(new int[] { 4, 3, 0, 0, 0 },
            //    new int[][]
            //    {
            //        new int[] {0, 1, 1 },
            //        new int[] {2,4,3 }
            //    });

            //GroupLeaders(new int[] { 0, 1, 0, 2, 1 },
            //    new int[][]
            //    {
            //        new int[] {2, 4, 2 }
            //    });
            //GroupLeaders(new int[] { 0, 1, 4, 0, 3 },
            //    new int[][]
            //    {
            //        new int[] {1, 3, 1 }
            //    });
        }

        /*
                
                for (var j=ranges[i][0];j<=ranges[i][1];j++)
                {
                    counts[arr[j]]++;                    
                }

                int index = -1;
                for (var j = 0; j < counts.Length; j++)
                {
                    if (counts[j] == ranges[i][2])
                    {
                        index = j;
                        break;
                    }
                }
                //Console.WriteLine("{0} : {1}", String.Join(",", ranges[i]), index);
                Console.WriteLine(index);
            }
         */
        public void GroupLeaders(int []arr, int [][] queries)
        {
            var N = arr.Length;
            var Q = queries.Length;

            int BLOCK_SIZE = (int)Math.Sqrt(N);
            var answers = new long[Q];

            Array.Sort(queries, (x, y) => {
                int block_x = x[0] / BLOCK_SIZE;
                int block_y = y[0] / BLOCK_SIZE;
                if (block_x != block_y)
                    return block_x - block_y;
                return x[1] - y[1];
            });

            var counts = new int[arr.Length];
            int mo_left = 0, mo_right = -1;

            // Usual Mo's algorithm stuff.
            for (var i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int answer_idx = queries[i][3];

                while (mo_right < right)
                {
                    mo_right++;
                    counts[arr[mo_right]]++;
                    //solver.Add(arr[mo_right]);
                }

                while (mo_right > right)
                {
                    //solver.Remove(arr[mo_right]);
                    counts[arr[mo_right]]--;
                    mo_right--;
                }

                while (mo_left < left)
                {
                    //solver.Remove(arr[mo_left]);
                    counts[arr[mo_left]]--;
                    mo_left++;
                }

                while (mo_left > left)
                {
                    mo_left--;
                    //solver.Add(arr[mo_left]);
                    counts[arr[mo_left]]++;
                }

                int index = -1;
                for (var j = 0; j < counts.Length; j++)
                {
                    if (counts[j] == queries[i][2])
                    {
                        index = j;
                        break;
                    }
                }

                //answers[answer_idx] = solver.Answer;
                answers[answer_idx] = index;
            }

            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(answers[i]);
            }            
        }

        public IList<int> GroupLeadersWithoutMo(int[] arr, int[][] ranges)
        {
            //Console.WriteLine(String.Join(",", arr));
            var res = new List<int>(ranges.Length);
            for (int i = 0; i < ranges.Length; i++)
            {
                var counts = new int[arr.Length];

                for (var j = ranges[i][0]; j <= ranges[i][1]; j++)
                {
                    counts[arr[j]]++;
                }

                int index = -1;
                for (var j = 0; j < counts.Length; j++)
                {
                    if (counts[j] == ranges[i][2])
                    {
                        index = j;
                        break;
                    }
                }
                //Console.WriteLine("{0} : {1}", String.Join(",", ranges[i]), index);
                Console.WriteLine(index);
                res.Add(index);
            }
            return res;
        }
    }
}
