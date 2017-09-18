using Scenarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.DP
{
    class L418SentenceScreenFitting
    {
        public void Test()
        {
            var ex = new Expected[]
            {
                new Expected()
                {
                    Sentence = new string[] { "hello", "world"},
                    Rows = 4,
                    Cols = 8,
                    Result = 2
                },
                new Expected()
                {
                    Sentence = new string[] { "a", "bcd", "e"},
                    Rows = 3,
                    Cols = 6,
                    Result = 2
                },
                new Expected()
                {
                    Sentence = new string[] { "I", "had", "apple", "pie"},
                    Rows = 4,
                    Cols = 5,
                    Result = 1
                },
                new Expected()
                {
                    Sentence = new string[] { "I", "had", "apple", "pie"},
                    Rows = 20000,
                    Cols = 20000,
                    Result = 25000000
                },
                new Expected()
                {
                    Sentence = new string[] { "Some", "long", "apple", "pie", "words", "that", "makes", "a",
                    "very", "veryy", "something", "nothing", "graph", "a", "world", "in", "this"},
                    Rows = 20000,
                    Cols = 20000,
                    Result = 4444000
                }

            };
            int res;

            for (var i = 0; i < ex.Length; i++)
            {
                using (var t = new Timer())
                {
                    res = this.WordsTyping(ex[i].Sentence, ex[i].Rows, ex[i].Cols);
                }

                if (res != ex[i].Result)
                {
                    Console.WriteLine("First {0}: A:{1} Expected:{2}", i, res, ex[i].Result);
                }

                using (var t = new Timer())
                {
                    res = this.WordsTyping1(ex[i].Sentence, ex[i].Rows, ex[i].Cols);
                }
                if (res != ex[i].Result)
                {
                    Console.WriteLine("Second {0}: A:{1} Expected:{2}", i, res, ex[i].Result);
                }

                using (var t = new Timer())
                {
                    res = this.WordsTyping2(ex[i].Sentence, ex[i].Rows, ex[i].Cols);
                }
                if (res != ex[i].Result)
                {
                    Console.WriteLine("Two {0}: A:{1} Expected:{2}", i, res, ex[i].Result);
                }
            }
        }

        int WordsTyping2(string[] sentence, int rows, int cols)
        {
            // memoize if starting with word, how many more words can be added.
            var mem = new int[sentence.Length];
            int count = 0, N = sentence.Length, start = 0;
            for (var i=0;i<rows;i++)
            {
                start = count % N;
                if (mem[start] == 0)
                {
                    int len = 0, c = 0;
                    while (len + sentence[(start + c)%N].Length <= cols)
                    {
                        len += sentence[(start + c) % N].Length + 1;
                        c++;
                    }
                    mem[start] = c;
                }
                count += mem[start];
            }
            return count / N;
        }

        int WordsTyping1(string[] sentence, int rows, int cols)
        {
            var s = String.Join(" ", sentence) + " ";
            int start = 0, len = s.Length;
            for (var i=0;i<rows;i++)
            {
                start += cols;
                if (s[start % len] == ' ') start++;
                else
                {
                    while (start > 0 && s[(start - 1) % len] != ' ') start--;
                }
            }
            return start / len;
        }

        int WordsTyping(string []sentence, int rows, int cols)
        {
            int r = 0, c = 0, count = 0;
            while (true)
            {
                for (var i=0;i<sentence.Length;i++)
                {
                    if (sentence[i].Length > cols) return 0;
                    if (c + sentence[i].Length > cols)
                    {
                        c = 0;
                        r++;
                        if (r >= rows) return count;
                    }

                    c += sentence[i].Length + 1;
                }
                count++;
            }
        }

        private class Expected
        {
            public string[] Sentence;
            public int Rows;
            public int Cols;
            public int Result;
        }
    }
}
