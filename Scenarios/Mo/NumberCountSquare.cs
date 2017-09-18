using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Mo
{
    class NumberCountSquare
    {
        /*
         * You have an array Arr of N numbers ranging from 0 to 99. Also you have Q queries [L, R]. 
         * For each such query you must print 
            V([L, R]) = ∑i=0..99 count(i)^2 * i 
            where count(i) is the number of times i occurs in Arr[L..R].
            
            Constraints are N ≤ 105, Q ≤ 105.
         */
        

        /*
         * Take out adding\removing logic into separate class.
         * It provides functions to add and remove numbers from
         * our structure, while maintaining cnt[] and current_answer.
         * 
         */
        public class Mo
        {
            static readonly int MAX_VALUE = 1005000;
            long []cnt;

            void process(int number, int delta)
            {
                Answer -= cnt[number] * cnt[number] * number;
                cnt[number] += delta;
                Answer += cnt[number] * cnt[number] * number;
            }
            public Mo()
            {
                cnt = new long[MAX_VALUE];
                Answer = 0;
            }

            public long Answer
            {
                get;set;
            }

            public void Add(int number)
            {
                process(number, 1);
            }

            public void Remove(int number)
            {
                process(number, -1);
            }
        };
        
        public void Test()
        {
            var arr = new int[] { 0, 1, 1, 0, 2, 3, 4, 1, 3, 5, 1, 5, 3, 5, 4, 0, 2, 2 };
            var queries = new int[][]
            {
                new int[] {0, 8, 0},
                new int[] {2, 5, 1},
                new int[] {2, 11, 2},
                new int[] {16, 17, 3},
                new int[] {13, 14, 4},
                new int[] {1, 17, 5},
                new int[] {17, 17, 6 }
            };

            NumberCounts(arr, queries);        
        } 
        
        public void NumberCounts(int[] arr, int[][] queries)
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

            Mo solver = new Mo();
            int mo_left = 0, mo_right = -1;

            // Usual Mo's algorithm stuff.
            for (var i=0;i<queries.Length;i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int answer_idx = queries[i][2];

                while (mo_right < right)
                {
                    mo_right++;
                    solver.Add(arr[mo_right]);
                }

                while (mo_right > right)
                {
                    solver.Remove(arr[mo_right]);
                    mo_right--;
                }

                while (mo_left < left)
                {
                    solver.Remove(arr[mo_left]);
                    mo_left++;
                }

                while (mo_left > left)
                {
                    mo_left--;
                    solver.Add(arr[mo_left]);
                }

                answers[answer_idx] = solver.Answer;
            }

            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(answers[i]);
            }
        }
    }
}
