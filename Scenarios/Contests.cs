using Scenarios.Common;
using Scenarios.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class Contests
    {
        public void Test()
        {
            Print("Hello");
            //Print(this.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4));

            //int[] res;
            //res = this.ExclusiveTime(2, new List<string> {
            //    "0:start:0",
            //    "1:start:2",
            //    "1:end:5",
            //    "0:end:6" });

            //Print(res);

            //res = this.ExclusiveTime(3, new List<string> {
            //    "0:start:0",
            //    "1:start:2",
            //    "2:start:3",
            //    "2:end:4",
            //    "1:end:5",
            //    "0:end:6" });

            //Print(res);

            //res = this.ExclusiveTime(1, new List<string> {
            //   "0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7"});

            //Print(res);

            //var a = new AutocompleteSystem(new string[] { "i love you", "island", "ironman", "i love leetcode" }, new int[] { 5, 3, 2, 2 });
            //var res = a.Input('i');
            //Print(String.Join(",", res));
            //res = a.Input(' ');
            //Print(String.Join(",", res));
            //res = a.Input('a');
            //Print(String.Join(",", res));
            //res = a.Input('#');
            //Print(String.Join(",", res));

            //Console.WriteLine(this.CheckPossibility(new int[] { 3, 4, 2, 3 }));
            //Console.WriteLine(this.CheckPossibility(new int[] {4,2,3 }));
            //Console.WriteLine(this.CheckPossibility(new int[] { 4, 2, 1 }));

            //Console.WriteLine(this.PathSum(new int[] { 113, 215, 221 }));
            //Console.WriteLine(this.PathSum(new int[] { 113, 221 }));

            //Console.WriteLine(this.FindLengthOfLCIS(new int[] { 1, 3, 5, 4, 7 }));
            //Console.WriteLine(this.FindLengthOfLCIS(new int[] { 2,2,2,2,2 }));

            //var m = new MagicDictionary();
            //m.BuildDict(new string[] { "hello", "leetcode" });
            //Console.WriteLine(m.Search("hello"));
            //Console.WriteLine(m.Search("hhllo"));
            //Console.WriteLine(m.Search("hell"));
            //Console.WriteLine(m.Search("leetcoded"));

            //Console.WriteLine(this.ValidPalindrome("bddb"));
            //Console.WriteLine(this.ValidPalindrome("beceecb"));
            //Console.WriteLine(this.ValidPalindrome("abcbaabba"));
            //Console.WriteLine(this.ValidPalindrome("ebcbbececabbacecbbcbe"));
            //Console.WriteLine(this.ValidPalindrome("aba"));
            //Console.WriteLine(this.ValidPalindrome("abca"));
            //Console.WriteLine(this.ValidPalindrome("abdca"));
            //var m = new MapSum();
            //m.Insert("apple", 3);
            //Console.WriteLine(m.Sum("ap"));
            //m.Insert("app", 2);
            //Console.WriteLine(m.Sum("ap"));

            //Console.WriteLine(this.CheckValidString(""));
            //Console.WriteLine(this.CheckValidString("()"));
            //Console.WriteLine(this.CheckValidString("(*)"));
            //Console.WriteLine(this.CheckValidString("(*))"));


            Console.WriteLine(this.JudgePoint24(new int[] { 8, 1, 6, 6 }));
            Console.WriteLine(this.JudgePoint24(new int[] { 6, 1, 6, 8 }));
            //Console.WriteLine(this.JudgePoint24(new int[] { 1, 3, 4 ,6 }));
            //Console.WriteLine(this.JudgePoint24(new int[] { 4, 1, 8, 7 }));
            //Console.WriteLine(this.JudgePoint24(new int[] { 1, 2, 1, 2 }));
        }

        public bool JudgePoint24(int[] nums)
        {
            var visited = new bool[nums.Length];
            return Permute(nums, new List<int>(), visited);
        }

        private bool Permute(int[] nums, IList<int> cur, bool[] visited)
        {
            if (cur.Count == nums.Length)
            {
                //Console.WriteLine(String.Join(", ", cur));
                return CheckOperations(cur);
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    cur.Add(nums[i]);
                    if (Permute(nums, cur, visited)) return true;
                    cur.RemoveAt(cur.Count - 1);
                    visited[i] = false;
                }
            }
            return false;
        }

        private bool CheckOperations(IList<int> a)
        {
            string[] ops = new string[] { "+", "-", "*", "/" };

            for (var i=0;i<ops.Length;i++)
            {
                for (var j=0;j< ops.Length; j++)
                {
                    for (var k = 0; k < ops.Length; k++)
                    {
                        double r = 0;

                        r = this.Apply(a[0], ops[i], this.Apply(a[1], ops[j], this.Apply(a[2], ops[k], a[3])));
                        if (r == 24) return true;

                        r = this.Apply(this.Apply(a[0], ops[i], a[1]), ops[j], this.Apply(a[2], ops[k], a[3]));
                        if (r == 24) return true;

                        r = this.Apply(this.Apply(this.Apply(a[0], ops[i], a[1]), ops[j], a[2]), ops[k], a[3]);
                        if (r == 24) return true;
                    }
                }
            }
            return false;
        }

        private double Apply(double a, string op, double b)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                default: return double.NaN;
            }
        }

        public bool CheckValidString(string s)
        {
            if (String.IsNullOrEmpty(s)) return true;
            return CheckValidString(s, 0, 0);
        }

        public bool CheckValidString(string s, int index, int count)
        {
            for (var i = index; i < s.Length; i++)
            {
                if (s[i] == '(') count++;
                else if (s[i] == ')')
                {
                    count--;
                    if (count < 0) return false;
                }
                else if (s[i] == '*')
                {
                    if (CheckValidString(s, i + 1, count) || CheckValidString(s, i + 1, count+1) || CheckValidString(s, i + 1, count-1))
                        return true;
                    else
                        return false;
                }
            }
            return count == 0;
        }

        public class MapSum
        {
            Dictionary<string, int> dict;

            /** Initialize your data structure here. */
            public MapSum()
            {
                dict = new Dictionary<string, int>();
            }

            public void Insert(string key, int val)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = val;
                }
                else
                {
                    dict.Add(key, val);
                }
            }

            public int Sum(string prefix)
            {
                var sum = 0;
                foreach (var key in dict.Keys)
                {
                    if (key.StartsWith(prefix))
                    {
                        sum += dict[key];
                    }
                }
                return sum;
            }

        }

        public bool ValidPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s)) return false;
            if (s.Length < 3) return true;
            var i = 0; var j = s.Length - 1;
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++; j--;
                }
                else
                {
                    if (IsPalindrome(s, i + 1, j) || IsPalindrome(s, i, j-1))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

        private bool IsPalindrome(string s, int low, int high)
        {
            while (low <= high)
            {
                if (s[low] != s[high]) return false;
                low++;
                high--;
            }
            return true;
        }

        public class MagicDictionary
        {
            private string[] dict = null;
            /** Initialize your data structure here. */
            public MagicDictionary()
            {

            }

            /** Build a dictionary through a list of words */
            public void BuildDict(string[] dict)
            {
                this.dict = dict;
            }

            /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
            public bool Search(string word)
            {
                var len = word.Length;
                for (var i=0;i<dict.Length;i++)
                {
                    if (dict[i].Length != len) continue;
                    int dif = 0;
                    for (var j=0;j<len;j++)
                    {
                        if (word[j] != dict[i][j]) dif++;
                        if (dif > 1) break;
                    }
                    if (dif == 1) return true;
                }
                return false;
            }
            
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int max = 1;
            int cur = 1;

            for (int i=1;i<nums.Length;i++)
            {
                if (nums[i] > nums[i-1])
                {
                    cur++;
                }
                else
                {
                    cur = 1;
                }
                max = Math.Max(max, cur);
            }
            return max;
        }

        public int PathSum(int[] nums)
        {
            var trees = new int?[31];

            for (var i=0;i<nums.Length;i++)
            {
                int v = nums[i] % 10;
                nums[i] = nums[i] / 10;
                int p = nums[i] % 10;
                int d = nums[i] / 10;

                trees[(int)Math.Pow(2, d - 1) + p - 2] = v;
            }

            int sum = 0;

            Inorder(trees, 0, ref sum, trees[0].Value);

            return sum;
        }

        private void Inorder(int ?[] trees, int pos, ref int sum, int cur)
        {
            if (trees[pos] == null) return;

            if (trees[pos*2+1] == null && trees[pos*2+2] == null)
            {
                sum += cur;
                return;
            }

            if (trees[pos * 2 + 1] != null)
            {
                Inorder(trees, pos * 2 +1, ref sum, cur + trees[pos * 2 +1].Value);
            }

            if (trees[pos * 2 + 2] != null)
            {
                Inorder(trees, pos * 2 + 2, ref sum, cur + trees[pos * 2 + 2].Value);
            }
        }

        public bool CheckPossibility(int[] nums)
        {
            int count = 0;
            var flags = new bool[10001];
            for (var i=1;i<nums.Length;i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        if (!flags[j])
                        {
                            flags[j] = true;
                            count++;
                        }
                            
                    }
                }
            }
            if (count <= 1) return true;
            return false;
        }

        public void IterativePostOrder(TreeNode root)
        {
            TreeNode cur = root;
            TreeNode pre = root;
            var s = new Stack<TreeNode>();

            if (root != null)
                s.Push(root);
            
            while (s.Count != 0) {
                cur = s.Peek();
                if (cur == pre || cur == pre.left || cur == pre.right) {// we are traversing down the tree
                    if (cur.left != null) {
                        s.Push(cur.left);
                    }
                    else if (cur.right != null) {
                        s.Push(cur.right);
                    }
                    if (cur.left == null && cur.right == null) {
                        Console.WriteLine(s.Pop().val);
                    }
                } else if (pre == cur.left) {// we are traversing up the tree from the left
                    if (cur.right != null) {
                        s.Push(cur.right);
                    } else if (cur.right == null) {
                        Console.WriteLine(s.Pop().val);
                    }
                } else if (pre == cur.right) {// we are traversing up the tree from the right
                    Console.WriteLine(s.Pop().val);
                }
                pre = cur;
            }
        }


        public void IterativePostOrder1(TreeNode root)
        {
            var leftStack = new Stack<TreeNode>();
            var rightStack = new Stack<TreeNode>();

            TreeNode currentNode = root;

            while (leftStack.Count != 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    leftStack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = leftStack.Pop();

                    rightStack.Push(currentNode);
                    currentNode = currentNode.right;
                }
            }

            while (rightStack.Count != 0)
            {
                currentNode = rightStack.Pop();

                Console.WriteLine(currentNode.val);
            }
        }

        

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;

            if (s.val == t.val && IsSameTree(s, t)) return true;
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;
            if (s.val != t.val) return false;

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }

        public class AutocompleteSystem
        {
            private Dictionary<String, int> map = new Dictionary<String, int>();
            private StringBuilder build = new StringBuilder();
            private List<KeyValuePair<String, int>> answers = new List<KeyValuePair<String, int>>();

            public AutocompleteSystem(String[] sentences, int[] times)
            {
                for (int idx = 0; idx < sentences.Length; idx++)
                    map.Add(sentences[idx], times[idx]);
            }

            //public List<String> input(char c)
            //{
            //    List<String> ans = new List<String>();
            //    if (c == '#')
            //    {
            //        if (map.ContainsKey(build.ToString()))
            //        {
            //            map[build.ToString()]++;
            //        }
            //        else
            //        {
            //            map.Add(build.ToString(), 1);
            //        }

            //        build.Clear();
            //        answers.Clear();
            //    }
            //    else
            //    {
            //        build.Append(c);
            //        if (build.Length == 1)
            //        {
            //            foreach (var k in map.Keys)
            //                if (k.StartsWith(build.ToString())) answers.Add(new KeyValuePair<string, int>(k, map[k]));

            //            answers.Sort((a, b) => {
            //                if (a.Value == b.Value)
            //                {
            //                    return a.Key.CompareTo(b.Key);
            //                }
            //                else
            //                {
            //                    return b.Value - a.Value;
            //                }
            //            });                        
            //        }
            //        else
            //        {
            //            //foreach (var itr in answers)
            //            //{
            //            //    if (!itr.next().getKey().startsWith(build.toString())) itr.remove();
            //            //}
            //        }
            //        for (int idx = 0; idx < 3 && idx < answers.size(); idx++) ans.add(answers.get(idx).getKey());
            //    }
            //    return ans;
            //}
        }


        public class AutocompleteSystem1
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            List<KeyValuePair<int, string>> cur = new List<KeyValuePair<int, string>>();

            public AutocompleteSystem1(string[] sentences, int[] times)
            {
                for (var i=0;i<sentences.Length;i++)
                {
                    dict.Add(sentences[i], times[i]);
                }
            }

            public IList<string> Input(char c)
            {
                var res = new List<string>();

                var s = sb.ToString();
                if (c == '#')
                {
                    if (dict.ContainsKey(s))
                    {
                        dict[s]++;
                    }
                    else
                    {
                        dict.Add(s, 1);
                    }
                    sb = new StringBuilder();
                    cur = new List<KeyValuePair<int, string>>();
                    return res;
                }

                sb.Append(c);
                s = sb.ToString();

                if (cur.Count == 0)
                {
                    foreach (var key in dict.Keys)
                    {
                        if (key.StartsWith(s))
                        {
                            cur.Add(new KeyValuePair<int, string>(dict[key], key));
                        }
                    }

                    cur.Sort((a, b) => {
                        if (a.Key == b.Key)
                        {
                            return a.Value.CompareTo(b.Value);
                        }
                        else
                        {
                            return b.Key - a.Key;
                        }
                    });
                }
                else
                {
                    cur = cur.Where(a => a.Value.StartsWith(s)).ToList();
                }

                for (var i=0;i<cur.Count && i < 3;i++)
                {
                    res.Add(cur[i].Value);
                }

                return res;
            }
        }


        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var res = new int[n];
            var s = new Stack<KeyValuePair<int,int>>();
            int old = 0;

            for (var i=0;i<logs.Count;i++)
            {
                var arr = logs[i].Split(':');
                int id = Int32.Parse(arr[0]);
                int ts = Int32.Parse(arr[2]);
                if (arr[1].Equals("start"))
                {
                    if (s.Count != 0)
                    {
                        res[s.Peek().Key] += ts - old;
                    }
                    s.Push(new KeyValuePair<int, int>(id, ts));
                    old = ts;
                }
                else
                {
                    var k = s.Pop();
                    if (k.Key != id) throw new InvalidOperationException();
                    
                    res[id] += ts - old + 1;
                    
                    old = 1 + ts;
                }
            }
            return res;
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            if (nums == null || nums.Length < k) return 0;
            double sum = 0;
            for (var i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            double max = sum/k;
            int len = k;
            double avg = max;

            for (var i = k; i < nums.Length; i++)
            {
                len++;
                sum += nums[i];
                avg = sum / len;

                double tSum = sum;
                double tAvg = avg;
                for (var j=len-1;j>=k;j--)
                {
                    tSum -= nums[i - j];
                    tAvg = tSum / j;
                    if (tAvg > avg)
                    {
                        avg = tAvg;
                        sum = tSum;
                        len = j;
                    }
                }
                max = Math.Max(max, avg);
            }
            return max;
        }

        public double FindMaxAverage1(int[] nums, int k)
        {
            if (nums == null || nums.Length < k) return 0;
            double sum = 0;
            for (var i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            double max = sum;
            for (var i = k; i < nums.Length; i++)
            {
                sum -= nums[i - k];
                sum += nums[i];
                max = Math.Max(max, sum);
            }
            return max / k;
        }

        public void Test1()
        {
            //TreeNode tree = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
            //var tree = Helpers.GetTree(new int?[] {1, 2, null, 3, 4 });
            //Console.WriteLine(this.FindTilt(tree));

            //var arr = new int[] { 1, 4, 3, 2 };
            //Console.WriteLine(this.ArrayPairSum(arr));

            //var m = new int[,]
            //{
            //    { 0, 1, 1, 0 },
            //    { 1, 1, 1, 1 },
            //    { 0, 0, 0, 1 }
            //};
            //Console.WriteLine(this.LongestLine(m));

            //var m = new int[,]
            //{
            //    {1,2 },
            //    {3,4 }
            //};
            //Print(this.MatrixReshape(m, 1, 5));

            //Console.WriteLine(this.SubarraySum(new int[] { -1, -1, 1 }, 0));//1
            //Console.WriteLine(this.SubarraySum(new int[] { 1, 2, 3 }, 3)); //2
            //Console.WriteLine(this.SubarraySum(new int[] { 1 }, 1)); //1

            //Console.WriteLine(this.CheckInclusion("ab", "eid"));
            //Console.WriteLine(this.CheckInclusion("abc", "bbbca"));
            //Console.WriteLine(this.CheckInclusion("ab", "ab"));
            //Console.WriteLine(this.CheckInclusion("dep", "encyclopedia"));
            //Console.WriteLine(this.CheckInclusion("ab", "eidbaooo"));
            //Console.WriteLine(this.CheckInclusion("ab", "eidboaoo"));

            //var f0 = new int[,]
            //{
            //    {0,1,0,1,1 },
            //    {1,0,0,1,1 },
            //    {1,0,0,1,0 },
            //    {0,1,0,0,0 },
            //    {0,0,0,1,0 }
            //};
            //var d0 = new int[,]
            //{
            //    {0,4,1,6,6},
            //    {4,3,3,0,1 },
            //    {3,6,6,5,0 },
            //    {1,3,1,1,4 },
            //    {5,3,3,3,4 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f0, d0)); // 23




            //var f1 = new int[,]
            //{
            //    {0,1,1 },
            //    {1,0,1 },
            //    {1,1,0 }
            //};
            //var d1 = new int[,]
            //{
            //    { 1,3,1},
            //    {6,0,3 },
            //    {3,3,3 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f1, d1)); // 12

            //var f2 = new int[,]
            // {
            //        {0,0,0 },
            //        {0,0,0 },
            //        {0,0,0 }
            // };
            //var d2 = new int[,]
            //{
            //        { 1,1,1},
            //        {7,7,7 },
            //        {7,7,7 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f2, d2)); // 3

            //var f3 = new int[,]
            // {
            //    {0,1,1 },
            //    {1,0,1 },
            //    {1,1,0 }
            // };
            //var d3 = new int[,]
            //{
            //    { 7,0,0},
            //    {0,7,0 },
            //    {0,0,7 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f3, d3)); // 21

            //var f4 = new int[,]
            // {
            //    {0,1,0 },
            //    {0,0,0 },
            //    {0,0,0 }
            // };
            //var d4 = new int[,]
            //{
            //    { 0,0,7},
            //    {2,0,0 },
            //    {7,7,7 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f4, d4)); // 7

            //var f5 = new int[,]
            // {
            //    {0,0,1,0,0 },
            //    {0,0,0,1,1 },
            //    {0,0,0,0,1 },
            //    {0,1,1,0,0 },
            //    {0,1,0,1,0 }
            // };
            //var d5 = new int[,]
            //{
            //    {3,1,6,2,2},
            //    {1,3,5,6,5 },
            //    {3,2,5,0,0 },
            //    {2,3,5,4,3 },
            //    {3,3,1,5,4 }
            //};
            //Console.WriteLine(this.MaxVacationDays(f5, d5)); // 22

            //var t1 = Helpers.GetTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
            //var t2 = Helpers.GetTree(new int?[] { 4, 1, 2 });
            //Console.WriteLine(this.IsSubtree(t1, t2));

            //Console.WriteLine(this.DistributeCandies(new int[] { 1, 1, 2, 2, 3, 3 }));
            //Console.WriteLine(this.DistributeCandies(new int[] { 1, 1, 1, 1, 1, 1, 2, 3}));

            //Console.WriteLine(this.MinDistance(5, 7, new int[] { 2, 2 }, new int[] { 4, 4 },
            //    new int[,] { { 3, 0 }, { 2, 5 } })); // 12

            //Console.WriteLine(this.MinDistance(5, 5, new int[] { 3, 2 }, new int[] { 0, 1 },
            //    new int[,] { { 2, 0 }, { 4, 1 }, { 0, 4 }, { 1, 3 }, { 1, 0 }, { 3, 4 }, { 3, 0 }, { 2, 3 }, { 0, 2 },
            //         { 0, 0 }, { 2, 2 }, { 4, 2 }, { 3, 3 }, { 4, 4 }, { 4, 0 }, { 4, 3 }, { 3, 1 }, { 2, 1 }, { 1, 4 }, { 2, 4 } })); // 100

            //Console.WriteLine(this.FindPaths(2,2,2, 0,0)); // 6
            //Console.WriteLine(this.FindPaths(1, 3, 3, 0, 1)); // 12

            //for (var i = 1; i < 15; i++)
            //{
            //    Console.WriteLine("{0} : {1} {2}", i,this.CountArrangement(i), this.Fact(i));
            //}

            //this.StringPermutation("abc");

            //var res = this.WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
            //Console.WriteLine(String.Join(",", res));

            //var res = this.WordBreak("aaaaaaa", new List<string>() { "aaaa", "aa", "a" });
            //Console.WriteLine(String.Join(Environment.NewLine, res));

            //Console.WriteLine(String.Join(Environment.NewLine, this.RemoveInvalidParentheses("(a)())()")));
            //Console.WriteLine(String.Join(Environment.NewLine, this.RemoveInvalidParenthesesBFS("()((c))()())(m)))()(")));

            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 2, 3, 3, 2, 4 })); // 3
            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 3, 2, 3, 2, 4 })); // 4
            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 1, 2, 3, 4 })); // 0
            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 })); // 5
            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 1, 15 })); // 6
            //Console.WriteLine(this.FindUnsortedSubarray(new int[] { 2, 6, 1, 8, 10, 17, 15 })); // 7

            //Console.WriteLine(String.Join(",", this.KillProcess(new List<int>() { 1, 3, 10, 5 }, new List<int>() { 3, 0, 5, 3 }, 5)));
            //Console.WriteLine(this.MinDistance("", "a"));
            //Console.WriteLine(this.MinDistance("sea", "eat"));

            //Console.WriteLine(getMaxMonsters(7, 8, 6, new int[] { 16, 19, 7, 11, 23, 8, 16 }));




            //int src = 9; int n = 12; int tot = 4;
            //for (var i = 1; i <= tot; i++)
            //{
            //    Console.WriteLine((src + i) % n);
            //    Console.WriteLine((src + n - i) % n);
            //}

            //Console.WriteLine(this.AccurateSorting(new int[] { 1, 0, 3, 2 })); // True
            //Console.WriteLine(this.AccurateSorting(new int[] { 2, 1, 0})); // False
            //Console.WriteLine(this.AccurateSorting(new int[] { 1, 3, 2, 0, 4 })); // True

            //Console.WriteLine(geometricTrick("ccaccbbbaccccca")); // 2
            //int n = 16;
            //var s = "ccaccbbbaccccca";
            //var sb = new StringBuilder(s);
            //for (var i = 1; i < n; i++)
            //{
            //    sb.Append(sb.ToString());
            //}
            //Console.WriteLine(geometricTrick(sb.ToString()));

            //Console.WriteLine(this.FindLHS(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 }));

            //Console.WriteLine(this.ValidSquareInternal(new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 1 }));
            //Console.WriteLine(this.ValidSquare(new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0,0 }));
            //Console.WriteLine(this.ValidSquare(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));

            //Console.WriteLine(this.FractionAddition("-1/2+1/2")); // 0/1
            //Console.WriteLine(this.FractionAddition("-1/2+1/2+1/3")); // 1/3
            //Console.WriteLine(this.FractionAddition("1/3-1/2")); // -1/6
            //Console.WriteLine(this.FractionAddition("5/3+1/3")); //2/1

            //Console.WriteLine(this.GetMagicNumber("12212", 3, 3, 5));
            //Console.WriteLine(this.GetMagicNumber("111101", 4, 2, 15));

            //var commands = new string[] {
            //    "crt phonebook","crt phonebook","crt phonebook","crt todo",
            //    "crt phonebook","del phonebook","del phonebook(2)",
            //    "crt phonebook","crt phonebook","crt phonebook","rnm phonebook(2) todo"
            //};

            //FileCommands(commands);

            //CityConstruction(4, new int[][]
            //    {
            //        new int[] { 1, 2 },
            //        new int[] { 1, 3 },
            //        new int[] { 2, 4 },
            //        new int[] { 3, 4 }
            //    }, new int[][]
            //    {
            //        new int[] { 1, 2, 0 },
            //        new int[] { 2, 3, 5 },
            //        new int[] { 2, 1, 5 },
            //        new int[] { 1, 1, 1 },
            //        new int[] { 2, 6, 4 }
            //    }
            //    );

            //Console.WriteLine(this.SolveBitMask(new int[] { 7, 14, 28 }));
            //Console.WriteLine(this.SolveBitMask(new int[] { 3, 10, 28 }));
            //Console.WriteLine(this.SolveBitMask(new int[] { 4, 14, 25 }));

            //Console.WriteLine("");

            //Console.WriteLine(MaxCount(3, 3, new int[2,2] { { 2, 2 }, { 3, 3 } }));
            //Console.WriteLine(MaxCount(40000, 40000, new int[,] { }));
            //Console.WriteLine(MaxCount(26, 17, new int[,] { { 2, 3 }, { 2, 4 } }));
            //Console.WriteLine(MaxCount2(26, 17, new int[,] { { 2, 3 }, { 2, 4 } }));

            //Console.WriteLine(String.Join(",", FindRestaurant(
            //    new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, 
            //    new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" })));
            //Console.WriteLine(String.Join(",", FindRestaurant(
            //    new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, 
            //    new string[] { "KFC", "Shogun", "Burger King" })));

            //            Console.WriteLine(ArrayNesting(new int[] { 5, 4, 0, 3, 1, 6, 2 }));


            //Console.WriteLine(FindIntegers(999999999));
            //Console.WriteLine(FindIntegers(1000000000));
            //var l1 = new List<int>();
            //var l2 = new List<int>();
            //int old = -1;
            //int count = 0;
            //for (var i = 0; i <= 1000000000; i++)
            //{
            //    //count = FindIntegers(i);
            //    if ((i & (i << 1)) == 0) count++;

            //    if (count != old)
            //    {
            //        l1.Add(i);
            //        l2.Add(count);
            //        old = count;
            //    }
            //}

            //for (var i=0;i<l1.Count;i++)
            //{
            //    if ((l1[i] & l1[i] - 1) == 0)
            //    {
            //        Console.WriteLine("{0},", l2[i]);
            //    }
            //}
            //System.IO.File.WriteAllText(@"c:\temp\1.txt", String.Join(",", l1));
            //System.IO.File.WriteAllText(@"c:\temp\2.txt", String.Join(",", l2));
            //Console.WriteLine(String.Join(",", l1));
            //Console.WriteLine(String.Join(",", l2));

            //FindIntegers2(999999999);

            //for (var i = 0; i <= 1000; i++)
            //{
            //    int count1 = FindIntegers(i);
            //    int count2 = FindIntegers2(i);
            //    if (count1 != count2)
            //    {
            //        Console.WriteLine("{0} {1} {2}", i, count1, count2);
            //    }
            //}

            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1));
            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 2));
            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 1 }, 1));
            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 1, 0, 0 }, 2));
            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 0 }, 1));
            //Console.WriteLine(this.CanPlaceFlowers(new int[] { 1 }, 0));

            //Console.WriteLine(this.Tree2str(Helpers.GetTree(new int?[] { 1,2,3,4})));
            //Console.WriteLine(this.Tree2str(Helpers.GetTree(new int?[] { 1,2,3,null, 4})));

            //var l = this.FindDuplicate(new string[]
            //    { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"} );
            //for (var i = 0; i < l.Count; i++)
            //{
            //    Console.WriteLine(String.Join(",", l[i]));
            //}

            //var input = new string[]
            //{
            //    "<![CDATA[ABC]]><TAG>sometext</TAG>",
            //    "123456",
            //    "<DIV>This is the first line <![CDATA[<div>]]></DIV>",
            //    "<TRUe><![CDATA[123123]]]]><![CDATA[>123123]]></TRUe>",
            //    "<DIV></DIV>",
            //    "<DIV>Hello world</DIV>",
            //    "<DIV>This is the first line <![CDATA[<div>]]></DIV>",
            //    "<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>",
            //    "<A>  <B> </A>   </B>",
            //    "<DIV>  div tag is not closed  <DIV>",
            //    "<DIV>  unmatched <  </DIV>",
            //    "<DIV> closed tags with invalid tag name  <b>123</b> </DIV>",
            //    "<DIV> unmatched tags with invalid tag name  </1234567890> and <CDATA[[]]>  </DIV>",
            //    "<DIV>  unmatched start tag <B>  and unmatched end tag </C>  </DIV>"
            //};

            //for (var i=0;i<input.Length;i++)
            //{
            //    Console.WriteLine("{0} : {1}", input[i], this.IsValid(input[i]));
            //}

            //Print(this.JudgeSquareSum(2));
            //Print(this.JudgeSquareSum(5));
            //Print(this.JudgeSquareSum(3));
            //Print(this.JudgeSquareSum(4));

            //Print(this.FindDerangement(3));
            //Print(this.FindDerangement(4));
            //Print(this.FindDerangement(23213));

            //var r = this.AverageOfLevels(Helpers.GetTree(new int?[] { 3, 9, 20, null, null, 15, 7 }));
            //foreach (var n in r)
            //{
            //    Console.Write("{0} ", n);
            //}
        }





        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null) return new List<double>();
            var res = new List<double>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var count = q.Count;
                double sum = 0;
                for (var i=0;i<count;i++)
                {
                    root = q.Dequeue();
                    sum += root.val;
                    if (root.left != null ) q.Enqueue(root.left);
                    if (root.right != null) q.Enqueue(root.right);
                }
                res.Add(sum / count);
            }

            return res;
        }

        public int FindDerangement(int n)
        {
            return this.Fact(n - 1);
        }

        public int Fact(int n)
        {
            if (n <= 1) return 1;
            long res = 1;
            for (var i = 2; i <= n; i++)
            {
                res = (res * i) % 1000000007;
            }
            return (int)res;
        }

        public bool JudgeSquareSum(int c)
        {
            for (var i=0;i< (int)Math.Sqrt(c)+1;i++)
            {
                int b = (int)Math.Sqrt(c - i * i);
                if ( b* b+ i*i == c)
                {
                    return true;
                }
            }
            return false;
        }

        private void Print(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public bool IsValid(string code)
        {
            if (string.IsNullOrEmpty(code)) return false;

            if (code[0] != '<') return false;

            var s = new Stack<string>();
            var sb = new StringBuilder();
            string tag = string.Empty;
            var cdataStart = "![CDATA[";

            
            for (var i=0;i<code.Length;i++)
            {
                switch (code[i])
                {
                    case '<':
                        i++;
                        bool closing = false;
                        
                        if (i < code.Length) 
                        {
                            if (code[i] == '/')
                            {
                                i++;
                                closing = true;
                            }
                            else if (code.Length-i > cdataStart.Length && code.Substring(i, cdataStart.Length).Equals(cdataStart))
                            {
                                bool cdata = false;
                                i += cdataStart.Length;
                                while (i < code.Length - 3)
                                {
                                    if (code[i] == ']' && code[i+1] == ']' && code[i+2] == '>')
                                    {
                                        i += 2;
                                        cdata = true;
                                        break;
                                    }
                                    i++;
                                }
                                if (!cdata) return false;
                                if (s.Count == 0) return false;
                                continue;
                            }
                        }
                        
                        while (i < code.Length && code[i] != '>')
                        {
                            if (code[i] >= 'A' && code[i] <= 'Z')
                            {
                                sb.Append(code[i]);
                            }
                            else
                            {
                                return false;
                            }
                            i++;
                        }
                        
                        tag = sb.ToString();
                        sb.Clear();
                        if (tag.Length == 0 || tag.Length > 9) return false;
                        if (closing)
                        {
                            if (s.Count == 0 || s.Peek() != tag) return false;
                            s.Pop();
                            if (s.Count == 0 && i != code.Length - 1) return false;
                        }
                        else
                        {
                            s.Push(tag);
                        }
                        
                        break;
                    default:
                        break;

                }
            }

            return s.Count == 0;
        }

        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var dict = new Dictionary<string, IList<string>>();

            for (var i=0;i<paths.Length;i++)
            {
                var s = paths[i].Split(' ');
                for (var j=1;j<s.Length;j++)
                {
                    int index = s[j].IndexOf('(');
                    var fname = s[0] + "/" + s[j].Substring(0, index);
                    var content = s[j].Substring(index+1, s[j].Length - index - 2);
                    if (dict.ContainsKey(content))
                    {
                        dict[content].Add(fname);
                    }
                    else
                    {
                        dict.Add(content, new List<string>() { fname });
                    }
                }
            }
            var ret = new List<IList<string>>();
            foreach (var key in dict.Keys)
            {
                if (dict[key].Count > 1)
                {
                    ret.Add(dict[key]);
                }
            }
            return ret;
        }

        public string Tree2str(TreeNode t)
        {
            var sb = new StringBuilder();
            PreOrder(t, sb);
            var s = sb.ToString().Substring(1);
            return s.Substring(0, s.Length-1);
        }

        public void PreOrder(TreeNode t, StringBuilder sb)
        {
            if (t == null) { sb.Append("()"); return; }

            if (t.left == null && t.right == null)
            {
                sb.Append(String.Format("({0})", t.val));
            }
            else if (t.right != null)
            {
                sb.Append(String.Format("({0}", t.val));
                PreOrder(t.left, sb);
                PreOrder(t.right, sb);
                sb.Append(")");
            }
            else
            {
                sb.Append(String.Format("({0}", t.val));
                PreOrder(t.left, sb);                
                sb.Append(")");
            }
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int count = 0;
            int z = 0;
            if (n > flowerbed.Length) return false;
            if (n <= 0) return true;

            if (flowerbed.Length == 1)
            {
                return flowerbed[0] == 0;
            }
            for (var i=0;i<flowerbed.Length;i++)
            {
                if (flowerbed[i] == 0)
                {
                    z++;
                    if (z == 2)
                    {
                        if (i == 1 || i == flowerbed.Length - 1)
                        {
                            count++; z = 1;
                        }
                    }
                    else if (z == 3)
                    {
                        count++;
                        z = 1;
                    }
                }
                else
                {
                    z = 0;
                }

                if (count >= n) return true;
            }
            return false;
        }

        public int FindIntegers(int num)
        {
            int count = 0;
            for (var i=0;i<=num;i++)
            {
                if ((i & (i << 1)) == 0)
                {                    
                    count++;
                }
            }
            return count;
        }

        int MaxPower(int num)
        {
            if (num == 0) return 0;
            int count = 1;
            int pow = 1;

            while (num < pow)
            {
                pow *= 2;
                count++;
            }

            return count;
        }

        public int FindIntegers2(int num)
        {
            var arr = new int[] { 1, 2, 3, 4, 6,
                                  9, 14, 22, 35, 56,
                                  90, 145, 234, 378, 611,
                 988, 1598, 2585, 4182, 6766,
                10947, 17712, 28658, 46369, 75026,
                121394, 196419, 317812, 514230, 832041,
                1346270 };

            int pow = MaxPower(num);
            int count = arr[pow];
            for (var i = (int)Math.Pow(2, pow); i <= num; i++)
            {
                if ((i & (i << 1)) == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int ArrayNesting(int[] nums)
        {
            var dp = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == i)
                {
                    dp[i] = 1;
                }
                else
                {
                    dp[i] = -1;
                }
            }

            int max = -1;

            for (var i=0;i<nums.Length;i++)
            {
                max = Math.Max(max, FindArrayNesting(nums, dp, i));
            }

            return max;
        }

        private int FindArrayNesting(int[] nums, int[] dp, int index)
        {
            if (dp[index] == -1)
            {
                dp[index] = -2;
                dp[index] = 1 + FindArrayNesting(nums, dp, nums[index]);
            }
            else if (dp[index] == -2)
            {
                return 0;
            }
            return dp[index];
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var dict = new Dictionary<string, int>();
            for (var i=0;i<list1.Length;i++)
            {
                dict.Add(list1[i], i);
            }

            int min = Int32.MaxValue;
            var list = new List<string>();

            for (var i = 0; i < list2.Length; i++)
            {
                if (dict.ContainsKey(list2[i]))
                {
                    if (i + dict[list2[i]] < min)
                    {
                        min = i + dict[list2[i]];
                        list = new List<string>();
                        list.Add(list2[i]);
                    }
                    else if (i + dict[list2[i]] == min)
                    {
                        list.Add(list2[i]);
                    }
                }
            }
            return list.ToArray();
        }

        public int MaxCount(int m, int n, int[,] ops)
        {
            if (ops.GetLength(0) == 0) return m * n;

            int xmin = Int32.MaxValue;
            int ymin = Int32.MaxValue;

            for (var i = 0; i < ops.GetLength(0); i++)
            {
                xmin = Math.Min(xmin, ops[i, 0]);
                ymin = Math.Min(ymin, ops[i, 1]);
            }

            int count = 0;

            int min = Math.Min(xmin, ymin);
            count = min * min;

            if (xmin < ymin)
            {
                count += (min * (ymin - xmin));
            }
            else
            {
                count += (min * (xmin - ymin));
            }
            return count;
        }

        public int MaxCount2(int m, int n, int[,] ops)
        {
            var mat = new int[m, n];

            for (var i=0;i<ops.GetLength(0);i++)
            {
                for (var j=0;j<ops[i,0];j++)
                {
                    for (var k=0;k<ops[i,1];k++)
                    {
                        mat[j, k]++;
                    }
                }
            }

            int count = 0;

            for (var j = 0; j < m; j++)
            {
                for (var k = 0; k < n; k++)
                {
                    if (mat[j,k] == mat[0,0])
                    {
                        count++;
                    }
                }
            }

            return count;
        }







        public static int NumberOfTrailingZeros(int n)
        {
            int mask = 1;
            for (int i = 0; i < 32; i++, mask <<= 1)
                if ((n & mask) != 0)
                    return i;

            return 32;
        }


        int SolveBitMask(int []a)
        {
            int res = 0;
            
            Array.Sort(a, (x, y) => NumberOfTrailingZeros(y) - NumberOfTrailingZeros(x)) ;
            
            for (var i = 0; i < a.Length; i++)
            {
                if ((a[i] & res) == 0)
                {
                    int mask = 1 << NumberOfTrailingZeros(a[i]);
                    res |= mask;
                }
            }
              
            return res;
        }

        void CityConstruction(int n, int [][]roads, int[][]commands)
        {
            int count = 0;
            for (int i=0;i<commands.Length;i++)
            {
                if (commands[i][0] == 1) count++;
            }
            int total = n + count + 1;

            var graph = new HashSet<int>[n + count + 1];
            var rev = new HashSet<int>[n + count + 1];
            for (var i=1;i< graph.Length; i++)
            {
                graph[i] = new HashSet<int>();
                rev[i] = new HashSet<int>();
            }

            for (var i=0;i<roads.Length;i++)
            {
                AddRoad(graph, rev, roads[i][0], roads[i][1]);
            }

            for (var i=0;i<commands.Length;i++)
            {
                if (commands[i][0] == 1)
                {
                    n++;
                    if (commands[i][2] == 0)
                    {
                        AddRoad(graph, rev, commands[i][1], n);                        
                    }
                    else
                    {
                        AddRoad(graph, rev, n, commands[i][1]);                        
                    }
                }
                else
                {
                    if (graph[commands[i][1]].Contains(commands[i][2]))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
            }

        }

        static void AddRoad(HashSet<int>[] graph, HashSet<int>[] rev, int src, int dst)
        {
            graph[src].Add(dst);

            foreach (var s in rev[src])
            {
                if (!graph[s].Contains(dst))
                {
                    graph[s].Add(dst);
                    rev[dst].Add(s);
                }
            }
            rev[dst].Add(src);

            foreach (var d in graph[dst])
            {
                if (!graph[src].Contains(d))
                {
                    graph[src].Add(d);
                    rev[d].Add(src);
                }
            }            
        }


        bool FindPath(int n, List<int>[] graph, int src, int dst, bool []visited, HashSet<KeyValuePair<int,int>> hash)
        {
            if (hash.Contains(new KeyValuePair<int, int>(src, dst))) return true;
            if (src == dst) return true;

            for (var i=0;i<graph[src].Count;i++)
            {
                if (!visited[graph[src][i]])
                {
                    if (hash.Contains(new KeyValuePair<int, int>(graph[src][i], dst))) return true;
                    visited[graph[src][i]] = true;
                    if (FindPath(n, graph, graph[src][i], dst, visited, hash))
                    {
                        hash.Add(new KeyValuePair<int, int>(graph[src][i], dst));
                        return true;
                    }
                }
            }
            return false;
        }

        void FileCommands(string [] commands)
        {
            var dict = new Dictionary<string, bool[]>();

            for (var i=0;i<commands.Length;i++)
            {
                var split = commands[i].Split(' ');
                switch (split[0])
                {
                    case "crt":
                        {
                            AddFile(dict, split[1], true);

                            break;
                        }
                    case "del":
                    { 
                        string fileName = split[1];
                        int index = split[1].IndexOf('(');
                        int fileNum = 0;
                        if (index != -1)
                        {
                            fileNum = Int32.Parse(split[1].Substring(index + 1, split[1].Length - index - 2));
                            fileName = fileName.Substring(0, index);
                        }

                        if (!dict.ContainsKey(fileName))
                        {
                            Console.WriteLine("error: Can't delete {0}", split[1]);
                        }
                        else
                        {
                            var arr = dict[fileName];
                            if (arr[fileNum])
                            {
                                arr[fileNum] = false;
                                Console.WriteLine("- {0}", split[1]);
                            }
                            else
                            {
                                Console.WriteLine("error1: Can't delete {0}", split[1]);
                            }
                        }

                        break;
                    }
                    case "rnm":
                    {
                        string fileName = split[1];
                        int index = split[1].IndexOf('(');
                        int fileNum = 0;
                        if (index != -1)
                        {
                            fileNum = Int32.Parse(split[1].Substring(index + 1, split[1].Length - index - 2));
                            fileName = fileName.Substring(0, index);
                        }

                        if (!dict.ContainsKey(fileName))
                        {
                            Console.WriteLine("error: Can't delete {0}", split[1]);
                        }
                        else
                        {
                            var arr = dict[fileName];
                            if (arr[fileNum])
                            {
                                arr[fileNum] = false;
                                int added = AddFile(dict, split[2], false);

                                if (added <= 0)
                                {
                                    Console.WriteLine("r {0} -> {1}", split[1], split[2]);
                                }
                                else
                                {
                                    Console.WriteLine("r {0} -> {1}({2})", split[1], split[2], added);
                                }
                            }
                            else
                            {
                                Console.WriteLine("error1: Can't delete {0}", split[1]);
                            }
                        }
                            break;
                    }
                }
            }
        }

        private static int AddFile(Dictionary<string, bool[]> dict, string file, bool print)
        {
            if (dict.ContainsKey(file))
            {
                var arr = dict[file];
                var j = 0;
                while (j < arr.Length)
                {
                    if (!arr[j]) break;
                    j++;
                }
                arr[j] = true;
                if (print)
                {
                    if (j != 0)
                    {
                        Console.WriteLine("+ {0}({1})", file, j);
                    }
                    else
                    {
                        Console.WriteLine("+ {0}", file);
                    }
                }
                return j;
            }
            else
            {
                var arr = new bool[100000];
                arr[0] = true;
                dict.Add(file, arr);
                if (print) Console.WriteLine("+ {0}", file);
                return 0;
            }
        }

        int GetMagicNumber(string s, int k, int b, int m)
        {
            int sum = 0;
            int res = 0;

            if (string.IsNullOrEmpty(s) || k <= 0 || k > s.Length) return 0;

            int pow = 1;
            for (var i=0;i<k;i++)
            {
                res = res * b + (s[i] - '0');
                if (i != 0 ) pow *= b;
            }

            sum = res % m;
            
            for (var i = k;i<s.Length;i++)
            {
                res = res % pow;
                res = res * b + (s[i] - '0');

                sum += (res % m);
            }

            return sum;
        }

        public string FractionAddition(string expression)
        {
            if (string.IsNullOrEmpty(expression) || expression.Length < 3) return string.Empty;

            Fraction res = null;
            
            var split = expression.Split('/');
            if (split.Length < 2) return string.Empty;

            int prevNum = Int32.Parse(split[0]);
            bool add = false;
            for (var i=1;i<split.Length;i++)
            {
                var s2 = split[i].Split('+');
                if (s2.Length == 2)
                {
                    var den = Int32.Parse(s2[0]);
                    if (i == 1)
                    {
                        res = new Fraction(prevNum, den);
                    }
                    else
                    {
                        var f1 = new Fraction(prevNum, den);
                        if (add)
                        {
                            res = res + f1;
                        }
                        else
                        {
                            res = res - f1;
                        }
                    }
                    add = true;                    
                    prevNum = Int32.Parse(s2[1]);
                }
                else
                {
                    s2 = split[i].Split('-');
                    if (s2.Length == 2)
                    {
                        var den = Int32.Parse(s2[0]);
                        if (i == 1)
                        {
                            res = new Fraction(prevNum, den);
                        }
                        else
                        {
                            var f1 = new Fraction(prevNum, den);
                            if (add)
                            {
                                res = res + f1;
                            }
                            else
                            {
                                res = res - f1;
                            }
                        }
                        add = false;
                        prevNum = Int32.Parse(s2[1]);
                    }
                    else if (s2.Length == 1)
                    {
                        if (i != split.Length - 1) throw new NotSupportedException();
                        var den = Int32.Parse(split[i]);
                        if (i == 1)
                        {
                            res = new Fraction(prevNum, den);
                        }
                        else
                        {
                            var f1 = new Fraction(prevNum, den);
                            if (add)
                            {
                                res = res + f1;
                            }
                            else
                            {
                                res = res - f1;
                            }
                        }
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }
                }
            }

            return res.ToString();
        }

        class Fraction
        {
            public int Num;
            public int Dem;

            public Fraction()
            {

            }

            public Fraction(int n, int d)
            {
                if (d < 0)
                {
                    d = d * -1;
                    n = n * -1;
                }
                this.Num = n;
                this.Dem = d;
            }

            public Fraction(string s)
            {

            }

            public static Fraction operator +(Fraction f1, Fraction f2)
            {
                int num = f1.Num * f2.Dem + f1.Dem * f2.Num;
                int den = f1.Dem * f2.Dem;
                if (num == 0) den = 1;
                else
                {
                    int gcd = Helpers.GCD(num, den);
                    num /= gcd;
                    den /= gcd;
                }
                return new Fraction(num, den);
            }

            
            public static Fraction operator -(Fraction f1, Fraction f2)
            {
                int num = f1.Num * f2.Dem - f1.Dem * f2.Num;
                int den = f1.Dem * f2.Dem;
                if (num == 0) den = 1;
                else
                {
                    int gcd = Helpers.GCD(num, den);
                    num /= gcd;
                    den /= gcd;
                }
                return new Fraction(num, den);
            }

            public override string ToString()
            {
                return this.Num + "/" + this.Dem;
            }
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            if (IsSame(p1, p2) || IsSame(p1, p3) || IsSame(p1, p4) || IsSame(p2, p3) || IsSame(p2, p4) || IsSame(p3, p4)) return false;

            return ValidSquareInternal(p1, p2, p3, p4) ||
                   ValidSquareInternal(p1, p3, p4, p2) ||
                   ValidSquareInternal(p1, p4, p2, p3);
        }

        public bool ValidSquareInternal(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            double distance = Distance(p1, p2);
            double diagonal = Distance(p1, p4);

            if (distance == Distance(p1, p3) &&
                distance == Distance(p4, p3) && 
                distance == Distance(p4, p2) && 
                diagonal == Distance(p2, p3))
                return true;

            return false;
        }

        public static bool IsSame(int[] p1, int[] p2)
        {
            if (p1[0] == p2[0] && p1[1] == p2[1]) return true;
            return false;
        }

        public static double Distance(int[] p1, int[] p2)
        {
            return Math.Pow(Math.Abs(p1[0] - p2[0]), 2) + Math.Pow(Math.Abs(p1[1] - p2[1]), 2);
        }

        private static bool IsItASquare(Point[] points)
        {
            Tuple<Point, int>[] distances = new Tuple<Point, int>[3];
            int ctr = 0;
            foreach (Point point in points.Except(new[] { points[0] }))
                distances[ctr++] = Tuple.Create(point, point.DistanceSquaredTo(points[0]));
            distances = distances.OrderBy(d => d.Item2).ToArray();

            if (distances[0].Item2 != distances[1].Item2)
                return false;

            Point origin = distances[0].Item1;
            return origin.DistanceSquaredTo(distances[2].Item1) == origin.DistanceSquaredTo(points[0]) && origin.DistanceSquaredTo(distances[1].Item1) == points[0].DistanceSquaredTo(distances[2].Item1);
        }

        private class Point
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int DistanceSquaredTo(Point otherPoint)
            {
                return (int)Math.Pow(Math.Abs(X - otherPoint.X), 2) + (int)Math.Pow(Math.Abs(Y - otherPoint.Y), 2);
            }
        }




        
        public int FindLHS(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (var i=0;i<nums.Length;i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]]++;
                else
                    dict.Add(nums[i], 1);
            }
            int max = 0;
            foreach (var elem in dict.Keys)
            {
                if (dict.ContainsKey(elem-1))
                {
                    max = Math.Max(max, dict[elem] + dict[elem - 1]);
                }
                if (dict.ContainsKey(elem + 1))
                {
                    max = Math.Max(max, dict[elem] + dict[elem + 1]);
                }
            }
            return max;
        }

        static int geometricTrick(string s)
        {
            // (j+1) ^ 2 = (i+1)(k+1)
            if (string.IsNullOrEmpty(s) || s.Length <= 3) return 0;
            int count = 0;
            for (long j=1;j<s.Length;j++)
            {
                if (s[(int)j] == 'b')
                {
                    long j2 = (j + 1) * (j + 1);
                    
                    if (s[0] != 'b')
                    {
                        if ((j2 - 1) < s.Length)
                        {
                            int l = 0;
                            int r = (int)(j2 - 1);
                            if (!(s[l] == 'b' || s[r] == 'b' || s[l] == s[r]))
                            {
                                count++;
                            }
                        }
                    }
                    
                    for (var l = j - 1; l >= 2; l--)
                    {
                        if (s[(int)l-1] != 'b' && j2 % l == 0)
                        {
                            if ((j2 / l) <= s.Length)
                            {
                                int r = (int)(j2 / l)-1;
                                if (!(s[(int)l-1] == 'b' || s[r] == 'b' || s[(int)l-1] == s[r]))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    //var factors = GetFactors(j + 1, s.Length);
                    //foreach (var factor in factors)
                    //{
                    //    if (s[(int)factor.Key - 1] == 'a' && s[(int)factor.Value - 1] == 'c')
                    //    {
                    //        count++;
                    //    }
                    //    else if (s[(int)factor.Value - 1] == 'a' && s[(int)factor.Key - 1] == 'c')
                    //    {
                    //        count++;
                    //    }
                    //}
                }
            }
            return count++;
        }
       
        static IList<KeyValuePair<long,long>> GetFactors(long n, long maxVal)
        {
            var facts = new List< KeyValuePair<long, long>>();

            if (n * n <= maxVal)
            {
                facts.Add(new KeyValuePair<long, long>(1, n * n));
            }
            for (var i=n-1;i>=2;i--)
            {
                if ( (n*n) % i == 0)
                {
                    if (((n * n) / i) <= maxVal)
                    {
                        facts.Add(new KeyValuePair<long, long>(i, (n * n) / i));
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return facts;
        }

        // H Week 31.
        bool AccurateSorting(int []arr)
        {
            for (var i=0;i<arr.Length-1;i++)
            {
                if (arr[i+1] == arr[i]-1)
                {
                    // Swap
                    int t = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = t;
                }
            }
            for (var i = 0; i < arr.Length; i++)
                if (arr[i] != i) return false;

            return true;
        }

        

        static int getMaxMonsters(int n, int hit, int t, int[] h)
        {
            Array.Sort(h);
            int count = 0;
            for (var i = 0; i < h.Length && t > 0; i++)
            {
                while (h[i] > 0 && t > 0)
                {
                    h[i] -= hit; t--;
                }
                if (h[i] <= 0) count++;
            }
            return count;
        }

        //583
        public int MinDistance(string word1, string word2)
        {
            var counts1 = new char[26];
            var counts2 = new char[26];
            for (var i = 0; i < word1.Length; i++) counts1[word1[i] - 'a']++;

            int res = 0;
            var sb = new StringBuilder();
            for (var i = 0; i < word2.Length; i++)
            {
                counts2[word2[i] - 'a']++;
                if (counts1[word2[i]-'a'] != 0)
                {
                    sb.Append(word2[i]);
                }
                else
                {
                    res++;
                }
            }

            var s2 = sb.ToString();
            sb.Clear();
            for (var i = 0; i < word1.Length; i++)
            {
                if (counts2[word1[i] - 'a'] != 0)
                {
                    sb.Append(word1[i]);
                }
                else
                {
                    res++;
                }
            }
            var s1 = sb.ToString();
            int lcs = this.LCS(s1, s2);
            return res + s1.Length - lcs + s2.Length - lcs;
        }

        public int LCS(string first, string second)
        {
            int n = first.Length + 1;
            int m = second.Length + 1;
            var dp = new int[n, m];
            int i, j;
            for (i = 1; i < n; i++)
            {
                for (j = 1; j < m; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[first.Length, second.Length];
        }
        public class GTree
        {
            public int Val;
            public IList<GTree> Childs;

            public GTree(int v)
            {
                this.Val = v;
                this.Childs = new List<GTree>();
            }
        }
        // 582
        public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
        {
            var trees = new Dictionary<int, GTree>(pid.Count);
            for (var i = 0;i<pid.Count;i++)
            {
                trees.Add(pid[i], new GTree(pid[i]));
            }
            GTree root = null;
            for (var i = 0; i < ppid.Count; i++)
            {
                if (ppid[i] == 0)
                {
                    root = trees[pid[i]];
                }
                else
                {
                    trees[ppid[i]].Childs.Add(trees[pid[i]]);
                }
            }
            var q = new Queue<GTree>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                root = q.Dequeue();
                if (root.Val == kill) break;
                foreach (var child in root.Childs) q.Enqueue(child);
            }
            var result = new List<int>();
            q.Clear();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                root = q.Dequeue();
                result.Add(root.Val);
                foreach (var child in root.Childs) q.Enqueue(child);
            }

            return result;
        }

        //581
        public int FindUnsortedSubarray2(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return 0;
            var arr = new int[nums.Length];
            Array.Copy(nums, arr, nums.Length);
            Array.Sort(arr);

            int low = 0;
            while (low < nums.Length && arr[low] == nums[low]) low++;
            if (low == nums.Length) return 0;

            int h = nums.Length - 1;
            while (h >= 0 && arr[h] == nums[h]) h--;
            return h - low + 1;
        }

        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return 0;
            int b = -1, e = -2, min = nums[nums.Length - 1], max = nums[0];
            for (var i=1;i<nums.Length;i++)
            {
                if (nums[i] < max)
                {
                    e = i;
                }
                else
                {
                    max = nums[i];
                }
                if (nums[nums.Length - 1 - i] > min)
                {
                    b = nums.Length - 1 - i;
                }
                else
                {
                    min = nums[nums.Length - 1 - i];
                }
            }
            return e - b + 1;
        }

        // 301
        public IList<string> RemoveInvalidParenthesesBFS(string s)
        {
            var res = new List<string>();
            if (string.IsNullOrEmpty(s))
            {
                res.Add(string.Empty);
                return res;
            }
            var h = new HashSet<string>();
            var q = new Queue<string>();

            q.Enqueue(s);
            h.Add(s);

            var found = false;

            while (q.Count > 0)
            {
                s = q.Dequeue();
                if (this.IsValidParen(s))
                {
                    res.Add(s);
                    found = true;
                }
                if (found) continue;

                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(' || s[i] == ')')
                    {
                        var substr = s.Substring(0, i) + s.Substring(i + 1);
                        if (!h.Contains(substr))
                        {
                            q.Enqueue(substr);
                            h.Add(substr);
                        }
                    }
                }
            }
            return res;
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            var map = new Dictionary<string, IList<string>>();
            return RemoveInvalidParentheses(s, map);
        }

        public IList<string> RemoveInvalidParentheses(string s, Dictionary<string, IList<string>> map)
        {
            if (map.ContainsKey(s)) return map[s];
            var res = new List<string>();
            if (string.IsNullOrEmpty(s)) {
                //res.Add(string.Empty); map[s] = res;
                return res;
            }

            if (this.IsValidParen(s)) { res.Add(s); }
            else
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(' || s[i] == ')')
                    {
                        string substr = s.Substring(0, i) + s.Substring(i + 1);
                        var t = this.RemoveInvalidParentheses(substr, map);
                        if (t.Count > 0)
                        {
                            int max = -1;
                            res.AddRange(t);
                            for (var j = 0; j < res.Count; j++)
                            {
                                max = Math.Max(max, res[j].Length);
                            }
                            var t2 = new List<string>();
                            for (var j = 0; j < res.Count; j++)
                            {
                                if (res[j].Length == max && !t2.Contains(res[j])) t2.Add(res[j]);
                            }
                            res = t2;
                        }
                    }
                }
            }
            map[s] = res;
            return res;
        }

        private bool IsValidParen(string s)
        {
            int count = 0;
            for (var i=0;i<s.Length;i++)
            {
                if (s[i] == '(') count++;
                else if (s[i] == ')')
                {
                    count--;
                    if (count < 0) return false;
                }
            }
            return count == 0;
        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var map = new Dictionary<string, IList<string>>();
            var res = WordBreakRecurse(s, wordDict, map);
            return res;
        }

        private IList<string> WordBreakRecurse(string s, IList<string> wordDict, Dictionary<string, IList<string>> map)
        {
            if (map.ContainsKey(s)) { return map[s]; }
            
            var res = new List<string>();
            if (s == string.Empty) { res.Add(string.Empty); map[s] = res; return res; }

            for (var i=1;i<=s.Length;i++)
            {
                var substr = s.Substring(0, i);
                if (wordDict.Contains(substr))
                {
                    var cur = WordBreakRecurse(s.Substring(i), wordDict, map);
                    foreach (var word in cur)
                    {
                        res.Add(substr + (string.IsNullOrEmpty(word) ? string.Empty : (" " + word)));
                    }
                }
            }

            map[s] = res;
            return res;
        }

        public void StringPermutation(String str)
        {
            PermutationHelper("", str);
        }

        private void PermutationHelper(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0)
                Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < n; i++)
                {
                    PermutationHelper(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1));
                }
            }
        }

        public int CountArrangement(int n)
        {
            var arr = new bool[n];
            var list = new ArrayList();            
            int count = this.BRecurse(arr, list);
            return count;
        }

        public int BRecurse(bool []arr, ArrayList list)
        {
            if (list.Count == arr.Length)
            {
                //Console.WriteLine(String.Join("", list.ToArray()));
                return 1;
            }
            int count = 0;
            for (var i=1;i<=arr.Length;i++)
            {
                int newPos = list.Count + 1;
                if (!arr[i-1])// && ( (i % newPos == 0) || (newPos % i == 0)))
                {
                    arr[i-1] = true;
                    list.Add(i);
                    count += this.BRecurse(arr, list);
                    list.Remove(i);
                    arr[i-1] = false;
                }
            }
            return count;
        }

        public int BeautifulArrangement1(int n)
        {
            int tot = this.Fact(n);
            for (var i=n;i>1;i--)
            {
                for (var j=2;j<=n;j++)
                {
                    if (i % j == 0 || j % i == 0) continue;
                    tot = tot - this.Fact(i - 1);
                }
            }

            return tot;
        }

        

        public int FindPaths(int m, int n, int N, int x, int y)
        {
            int NUM = 1000000007;
            int paths = 0;
            for (int i=1;i<=N;i++)
            {
                var mem = new int[m, n, i+1];
                for (var a = 0; a<m;a++)
                {
                    for (var b = 0;b<n;b++)
                    {
                        for (var c = 0; c <= i; c++)
                        {
                            mem[a, b, c] = -1;
                        }
                    }
                }
                paths += PHelper(mem, m, n, i, x, y);
                paths = paths % NUM;
            }

            return paths;
        }

        private int PHelper(int[,,] mem, int m, int n, int N, int x, int y)
        {
            int NUM = 1000000007;

            if (N == 0) return 0;
            int paths = 0;
            if (mem[x, y, N] != -1) return mem[x, y, N];

            if (N == 1)
            {
                if (x == 0) paths++;
                if (y == 0) paths++;
                if (x == m-1) paths++;
                if (y == n-1) paths++;
                mem[x, y, N] = paths;
                return paths;
            }
            var dirs = new int[][] 
            {
                new int [] { -1, 0},
                new int [] { 1, 0},
                new int [] { 0, -1},
                new int [] { 0, 1},
            };

            for (var i=0;i<dirs.Length;i++)
            {
                int nx = x + dirs[i][0];
                int ny = y + dirs[i][1];
                if (nx >= 0 && nx < m && ny >=0 && ny < n)
                {
                    paths += this.PHelper(mem, m, n, N - 1, nx, ny) % NUM;
                }
            }
            mem[x, y, N] = paths;
            return paths;
        }

        public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[,] nuts)
        {
            int tot = 0;
            var tDis = new int[nuts.GetLength(0)];
            var sDis = new int[nuts.GetLength(0)];

            for (var i = 0; i < nuts.GetLength(0); i++)
            {
                tDis[i] = GetDistance(tree[0], tree[1], nuts[i, 0], nuts[i, 1]);
                sDis[i] = GetDistance(squirrel[0], squirrel[1], nuts[i, 0], nuts[i, 1]);

                tot += tDis[i] * 2;
            }

            int min = Int32.MaxValue;
            
            for (var i = 0; i < nuts.GetLength(0); i++)
            {
                min = Math.Min(min, tot - tDis[i] + sDis[i]);
            }

            return min;
        }
        
        private int GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
        }

        public int DistributeCandies(int[] candies)
        {
            var dict = new Dictionary<int, int>();
            for (var i=0;i<candies.Length;i++)
            {
                if (dict.ContainsKey(candies[i]))
                {
                    dict[candies[i]] += 1;
                }
                else
                {
                    dict.Add(candies[i], 1);
                }
            }
            return dict.Count < candies.Length / 2 ? dict.Count : candies.Length / 2;
        }

        

        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            int N = days.GetLength(0);
            int K = days.GetLength(1);
            int max = 0;
            int mCity = -1; int mWeek = -1;

            var dp = new int[N, K];
            var par = new int[N, K];

            for (var j = 0; j < K; j++)
            {
                for (var i = 0; i < N; i++)
                {
                    dp[i, j] = -1;
                    par[i, j] = -1;
                }
            }

            for (var i=0;i<N;i++)
            {
                if (i == 0 || flights[0,i] == 1)
                {
                    dp[i,0] = days[i,0];
                    par[i, 0] = 0;
                }
            }

            for (var j=1;j<K;j++)
            {
                for (var i=0;i<N;i++)
                {
                    for (var x=0;x<N;x++)
                    {
                        if (dp[x, j - 1] != -1 && (flights[x,i] == 1 || x == i))
                        {
                            //dp[i, j] = Math.Max(dp[i, j], dp[x, j - 1] + days[i, j]);
                            if (dp[x, j - 1] + days[i, j] > dp[i, j])
                            {
                                dp[i, j] = dp[x, j - 1] + days[i, j];
                                par[i, j] = x;
                            }
                        }
                    }
                    //max = Math.Max(max, dp[i,j]);
                    if (dp[i, j] > max)
                    {
                        max = dp[i, j];
                        mCity = i;
                        mWeek = j;
                    }
                }
            }

            this.Print(flights); Console.WriteLine("---------------");
            this.Print(days); Console.WriteLine("-------------");
            this.Print(dp); Console.WriteLine("-------------");
            while (mWeek >= 0)
            {
                Console.WriteLine("[{0},{1}] = {2}", mCity, mWeek, dp[mCity, mWeek]);
                mCity = par[mCity, mWeek];
                mWeek--;
            }
            Console.WriteLine("***********************************************");

            return max;
        }

        /*
         * this.Print(flights);
            Console.WriteLine("---------------");
            this.Print(days);
            Console.WriteLine("-------------");
            this.Print(dp);
        */

        //private bool TraverseBack(int [,]dp, int [,]f, int index, int [,]par)
        //{
        //    int N = dp.GetLength(0);
        //    int K = dp.GetLength(1);

        //    int j = K - 1;
            
        //    while (j >= 0)
        //    {
        //        if (par[index, j] == index)
        //            j--;
        //        else if (f[par[index, j], index] == 1)
        //        {
        //            index = par[index, j];
        //            j--;
        //        }
        //        else
        //            return false;
        //    }

        //    return true;
        //}

        public bool CheckInclusion(string s1, string s2)
        {
            var a = new int[26];
            var b = new int[26];

            if (s2.Length < s1.Length) return false;

            for (int i = 0; i < s1.Length; i++)
            {
                a[s1[i] - 'a']++;
                b[s2[i] - 'a']++;
            }

            for (int i = 0; i < (s2.Length - s1.Length); i++)
            {
                if (AreEqual(a, b)) return true;
                
                b[s2[i] - 'a']--;
                b[s2[i + s1.Length] - 'a']++;
            }

            return AreEqual(a, b);
        }

        bool AreEqual(int []a, int []b)
        {
            for (var i=0;i<a.Length;i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        public int SubarraySum(int[] nums, int k)
        {
            var sums = new int[nums.Length];
            sums[0] = nums[0];
            int count = 0;

            if (nums[0] == k) count++;

            for (var i=1;i<nums.Length;i++)
            {
                sums[i] += sums[i - 1] + nums[i];
            }
            
            for (var i=1;i<nums.Length;i++)
            {
                if (sums[i] == k) count++;
                for (var j=0;j<i;j++)
                {
                    if (sums[i] - sums[j] == k) count++;
                }
            }

            return count;
        }

        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            if (nums.GetLength(0) * nums.GetLength(1) != r * c) return nums;

            var res = new int[r, c];
            var i1 = 0; var j1 = 0;
            for (var i=0;i<r;i++)
            {
                for (var j=0;j<c;j++)
                {
                    res[i, j] = nums[i1, j1];
                    j1++;
                    if (j1 == nums.GetLength(1))
                    {
                        j1 = 0;
                        i1++;
                    }
                }
            }

            return res;
        }

        void Print(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                Console.Write("{0} ", nums[i]);
            }
            Console.WriteLine("");
        }

        void Print(int[,] nums)
        {
            for (var i=0;i<nums.GetLength(0);i++)
            {
                for (var j=0;j<nums.GetLength(1);j++)
                {
                    Console.Write("{0,4} ", nums[i, j]);
                }
                Console.WriteLine("");
            }
        }


        public string NearestPalindromic(string n)
        {
            var cs = n.ToCharArray();
            if (cs.Length == 1)
            {
                if (n.Equals("0")) return "1";
                cs[0]--;
                return new string(cs);
            }

            var mid = cs.Length / 2;

            for (var i =0;i< mid; i++)
            {
                cs[cs.Length - 1 - i] = cs[i];
            }
            var ret = new string(cs);
            if (ret.Equals(n))
            {
                return "ee";
            }
            else
            {
                return ret;
            }
        }

        public int LongestLine(int[,] M)
        {
            int max = 0;
            for (var i=0;i<M.GetLength(0);i++)
            {
                for (var j=0;j<M.GetLength(1);j++)
                {
                    if (M[i,j] == 1)
                    {
                        max = Math.Max(max, this.GetMax(M, i, j));
                    }
                }
            }
            return max;
        }

        private int GetMax(int[,] M, int r, int c)
        {
            // Horizontal
            int hc = 1;
            var j = c - 1;
            while (j >= 0 && M[r, j] == 1) { hc++; j--; }
            j = c + 1;
            while (j < M.GetLength(1) && M[r, j] == 1) { hc++; j++; }

            // Vertical
            int vc = 1;
            var i = r - 1;
            while (i >= 0 && M[i, c] == 1) { vc++; i--; }
            i = r + 1;
            while (i < M.GetLength(0) && M[i, c] == 1) { vc++; i++; }

            // Diag
            int dc = 1;
            i = r - 1; j = c - 1;
            while (i >=0 && j >= 0 && M[i,j] == 1) { dc++; i--; j--; }
            i = r + 1; j = c + 1; 
            while (i < M.GetLength(0) && j < M.GetLength(1) && M[i, j] == 1) { dc++; i++; j++; }

            // Anti diag
            int ac = 1;
            i = r + 1; j = c - 1;
            while (i < M.GetLength(0) && j >= 0 && M[i, j] == 1) { ac++; i++; j--; }
            i = r - 1; j = c + 1;
            while (j < M.GetLength(1) && i >= 0 && M[i, j] == 1) { ac++; i--; j++; }

            return Math.Max(hc, Math.Max(vc, Math.Max(dc, ac)));
        }

        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            for (var i=0;i<nums.Length;i+=2)
            {
                sum += nums[i];
            }

            return sum;
        }

        public int FindTilt(TreeNode root)
        {
            int tilt = 0;

            this.InOrder(root, ref tilt);

            return tilt;
        }

        int InOrder(TreeNode root, ref int tilt)
        {
            if (root == null) return 0;

            //lsum = 0; rsum = 0;
            var lt = this.InOrder(root.left, ref tilt);
            var rt = this.InOrder(root.right, ref tilt);

            if (root.left != null) lt += root.left.val;
            if (root.right != null) rt += root.right.val;

            tilt += Math.Abs(lt - rt);
            return lt+ rt;
        }
    }
}
