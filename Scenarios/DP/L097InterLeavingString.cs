using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    /*
     * Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

        For example,
        Given:
        s1 = "aabcc",
        s2 = "dbbca",

        When s3 = "aadbbcbcac", return true.
        When s3 = "aadbbbaccc", return false.
     */
    class L097InterLeavingString
    {
        public void Test()
        {
            var inputs = new string[,]
            {
                { "a", "b", "ab"},
                { "a", "b", "aa"},
                { "aabcc", "dbbca", "aadbbcbcac"},
                { "aabcc", "dbbca", "aadbbbaccc"},
                { "aabccaabb", "dbbca", "aadbbbaccaabbc"}
            };
            var outputs = new bool[]
            {
                true,
                false,
                true,
                false,
                false
            };

            for (var i=0;i<inputs.GetLength(0);i++)
            {
                counter = 0;
                var res = this.IsInterleave(inputs[i,0], inputs[i,1], inputs[i,2]);
                Console.WriteLine("{5} I({0},{1}={2}) => {3}. Expected {4}", inputs[i, 0], inputs[i, 1], inputs[i, 2], res, outputs[i], counter);

                counter = 0;
                res = this.IsInterleave1(inputs[i, 0], inputs[i, 1], inputs[i, 2]);
                Console.WriteLine("{5} I({0},{1}={2}) => {3}. Expected {4}", inputs[i, 0], inputs[i, 1], inputs[i, 2], res, outputs[i], counter);

                Debug.Assert(res == outputs[i], String.Format("I({0},{1}={2}) => {3}. Expected {4}", inputs[i, 0], inputs[i, 1], inputs[i, 2], res, outputs[i]));
            }
        }

        static int counter = 0;

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            return Recurse(s1, 0, s2, 0, s3, 0);
        }

        private bool Recurse(string s1, int i1, string s2, int i2, string s3, int i3)
        {
            if (i3 == s3.Length) return true;

            counter++;

            if (i1 < s1.Length && s1[i1] == s3[i3] && this.Recurse(s1, i1 + 1, s2, i2, s3, i3 + 1)) return true;
            if (i2 < s2.Length && s2[i2] == s3[i3] && this.Recurse(s1, i1, s2, i2 + 1, s3, i3 + 1)) return true;

            return false;
        }

        public bool IsInterleave1(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;
            var mat = new bool?[s1.Length + 1, s2.Length + 1];

            return Recurse1(mat, s1, 0, s2, 0, s3, 0);
        }

        private bool Recurse1(bool?[,] mat, string s1, int i1, string s2, int i2, string s3, int i3)
        {
            if (i3 == s3.Length)
            {
                return true;
            }

            if (mat[i1, i2].HasValue) return mat[i1, i2].Value;

            counter++;

            if (i1 < s1.Length)
            {
                if (s1[i1] == s3[i3])
                {
                    mat[i1, i2] = this.Recurse1(mat, s1, i1 + 1, s2, i2, s3, i3 + 1);
                    if (mat[i1, i2].Value)
                    {
                        return true;
                    }
                }
                else
                {
                    mat[i1, i2] = false;
                }
            }
            else
            {
                mat[i1, i2] = false;
            }

            if (i2 < s2.Length)
            {
                if (s2[i2] == s3[i3])
                {
                    mat[i1, i2] = this.Recurse1(mat, s1, i1, s2, i2 + 1, s3, i3 + 1);
                    if (mat[i1, i2].Value)
                    {
                        return true;
                    }
                }
                else
                {
                    mat[i1, i2] = false;
                }
            }
            else
            {
                mat[i1, i2] = false;
            }

            return false;
        }
    }
}
