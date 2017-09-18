using Scenarios.Common;
using Scenarios.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class Contest36
    {
        public void Test()
        {
            Console.WriteLine("Jaado");
            //var t1 = Helpers.GetTree(new int?[] {1,3,2,5 });
            //var t2 = Helpers.GetTree(new int?[] {2,1,3,null,4,null,7 });
            //var t3 = MergeTrees(t1, t2);
            //Helpers.BFS(t3);

            //StringIterator iterator = new StringIterator("L12e2t1C1o1d1e1");

            ////StringIterator iterator = new StringIterator("L1e2");
            //int count = 1;
            //while (iterator.HasNext())
            //{
            //    Console.WriteLine("{0} [{1}]", count++, iterator.Next());

            //}
            //Console.WriteLine("Last [{0}]", iterator.Next());

            //Console.WriteLine(iterator.Next()); // return 'L'
            //Console.WriteLine(iterator.Next()); // return 'e'
            //Console.WriteLine(iterator.Next()); // return 'e'
            //Console.WriteLine(iterator.Next()); // return 't'
            //Console.WriteLine(iterator.Next()); // return 'C'
            //Console.WriteLine(iterator.Next());// return 'o'
            //Console.WriteLine(iterator.Next()); // return 'd'
            //Console.WriteLine(iterator.HasNext()); // return true
            //Console.WriteLine(iterator.Next()); // return 'e'
            //Console.WriteLine(iterator.HasNext()); // return false
            //Console.WriteLine("[{0}]", iterator.Next()); ; // return ' 

            //Console.WriteLine(this.TriangleNumber(new int[] { 0,0,0 }));
            //Console.WriteLine(this.TriangleNumber(new int[] { 2, 2, 3, 4 }));
            //Console.WriteLine(this.TriangleNumber(new int[] { 10, 21, 22, 100, 101, 200, 300 }));


            Console.WriteLine(this.AddBoldTag("abcdef", new string[] { "ab", "bc", "cd", "de", "ef", "fg", "gh" })); //"<b>abcdef</b>"

            //Console.WriteLine(this.AddBoldTag("abcxyz123", new string[] { "abc", "123" }));
            //Console.WriteLine(this.AddBoldTag("aaabbcc", new string[] { "aaa", "aab", "bc" }));
            //Console.WriteLine(this.AddBoldTag("aaabbcc", new string[] {"aaa", "aab", "bc", "aaabbcc" }));
        }

        public string AddBoldTag(string s, string[] dict)
        {
            var d = new HashSet<string>();
            int i = 0;
            int max = 0;
            for (i = 0; i < dict.Length; i++)
            {
                max = Math.Max(max, dict[i].Length);
                d.Add(dict[i]);
            }
            var ret = new StringBuilder();
            var addedBold = false;
            int lastAdded = -1;
            i = 0;

            while (i < s.Length)
            {
                var cur = new StringBuilder();
                string foundStr = string.Empty;
                for (var j=0;j<max && i+j < s.Length;j++)
                {
                    cur.Append(s[i + j]);
                    if (d.Contains(cur.ToString()))
                    {
                        foundStr = cur.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(foundStr))
                {
                    if (!addedBold)
                    {
                        addedBold = true;
                        ret.Append("<b>");
                    }
                    if (lastAdded == -1 || i > lastAdded)
                    {
                        ret.Append(foundStr);
                    }
                    else
                    {
                        if (i + foundStr.Length - lastAdded > 0)
                        {
                            var t = foundStr.Substring(i + foundStr.Length - lastAdded);
                            ret.Append(t);
                        }
                    }
                    
                    lastAdded = i + foundStr.Length-1;
                    if (lastAdded >= s.Length-1) break;

                    i++;
                }
                else
                {
                    if (lastAdded == -1 || i > lastAdded)
                    {
                        if (addedBold)
                        {
                            ret.Append("</b>");
                            addedBold = false;
                        }

                        ret.Append(s[i]);
                    }
                    i++;
                }
            }

            if (addedBold)
            {
                ret.Append("</b>");
                addedBold = false;
            }
            return ret.ToString();
        }

        public int TriangleNumber(int[] nums)
        {
            if (nums == null || nums.Length < 3) return 0;
            Array.Sort(nums);
            int count = 0;
            for (var i = 0; i < nums.Length-2; i++)
            {
                int k = i + 2;
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    while (k < nums.Length && nums[i] + nums[j] > nums[k])
                        ++k;
                    if (k - j - 1 > 0)
                        count += k - j - 1;
                }
            }
            return count;
        }

        public int TriangleNumber1(int[] nums)
        {
            if (nums == null || nums.Length < 3) return 0;
            Array.Sort(nums);
            int count = 0;
            for (var i=0;i<nums.Length;i++)
            {
                for (var j=i+1;j<nums.Length;j++)
                {
                    for (var k = j+1;k<nums.Length;k++)
                    {
                        if (nums[i] + nums[j] > nums[k]) count++;
                        else break;
                    }
                }
            }
            return count;
        }

        

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            var t = new TreeNode(t1.val + t2.val);
            t.left = MergeTrees(t1.left, t2.left);
            t.right = MergeTrees(t1.right, t2.right);
            return t;
        }


    }
}
