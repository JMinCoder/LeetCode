using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Strings
{
    /*
     * Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, 
     * such that:

Only one letter can be changed at a time
Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
For example,

Given:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log","cog"]
Return
  [
    ["hit","hot","dot","dog","cog"],
    ["hit","hot","lot","log","cog"]
  ]
Note:
Return an empty list if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
You may assume no duplicates in the word list.
You may assume beginWord and endWord are non-empty and are not the same.
     */
    class L126WordLadderII
    {
        public void Test()
        {
            var lists = this.FindLadders("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });
            this.Print(lists);

            /*
            var lists1 = this.FindLadders("qa", "sq", new List<string> {
                "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br",
    "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh",
    "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz",
    "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi",
    "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye"});

            this.Print(lists1);
            */
            
        }
          
        public IList<IList<String>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var map = new Dictionary<String, List<String>>();
            var results = new List<IList<String>>();

            if (wordList.Count == 0)
                return results;

            int min = Int32.MaxValue;

            var queue = new Queue<String>();
            queue.Enqueue(beginWord);

            var ladder = new Dictionary<String, int>();
            foreach (var word in wordList)
            {
                ladder.Add(word, Int32.MaxValue);
            }
            if (ladder.ContainsKey(beginWord))
            {
                ladder[beginWord] = 0;
            }
            else
            {
                ladder.Add(beginWord, 0);
            }

            // TODO :: dict.add(end);

            //BFS: Dijisktra search
            while (queue.Count != 0)
            {
                String word = queue.Dequeue();

                int step = ladder[word] + 1;//'step' indicates how many steps are needed to travel to one word. 

                if (step > min) break;

                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder builder = new StringBuilder(word);
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        builder[i] = ch;
                        String new_word = builder.ToString();
                        if (ladder.ContainsKey(new_word))
                        {
                            if (step > ladder[new_word])
                            {
                                //Check if it is the shortest path to one word.
                                continue;
                            }
                            else if (step < ladder[new_word])
                            {
                                queue.Enqueue(new_word);
                                ladder[new_word] = step;
                            }
                            else
                            {
                                
                            }

                            // It is a KEY line. If one word already appeared in one ladder,
                            // Do not insert the same word inside the queue twice. Otherwise it gets TLE.
                            if (map.ContainsKey(new_word))
                            {
                                //Build adjacent Graph
                                map[new_word].Add(word);
                            }
                            else
                            {
                                List<String> list = new List<String>();
                                list.Add(word);
                                map.Add(new_word, list);
                            }

                            if (new_word.Equals(endWord))
                            {
                                min = step;
                            }
                        }//End if dict contains new_word
                    }//End:Iteration from 'a' to 'z'
                }//End:Iteration from the first to the last
            }//End While

            Console.WriteLine("Ladder : {0}", 
                string.Join(", ", ladder.OrderBy(kp => kp.Value)
                                .Select(kvp => kvp.Key + ": " + kvp.Value.ToString())));

            Console.WriteLine("Map : {0}{1}", Environment.NewLine,
                string.Join(Environment.NewLine, 
                    map.Select(kvp => kvp.Key + ": " + string.Join(", ", kvp.Value))));

            //BackTracking
            var result = new List<String>();
            backTrace(endWord, beginWord, result, ref map, ref results);

            return results;
        }
        
        private void backTrace(String word, String start, List<String> list,
            ref Dictionary<String, List<String>> map,
            ref List<IList<String>> results)
        {
            if (word.Equals(start))
            {
                list.Insert(0, start);
                results.Add(new List<String>(list));
                list.RemoveAt(0);
                return;
            }
            list.Insert(0, word);
            if (map[word] != null)
            {
                foreach (var str in map[word])
                    backTrace(str, start, list, ref map, ref results);
            }
            list.RemoveAt(0);
        }

        // Solution 1. DFS. 
        // Got TLE
        public IList<IList<string>> FindLadders1(string beginWord, string endWord, IList<string> wordList)
        {
            var retLists = new List<IList<string>>();

            if (beginWord.Equals(endWord)) return retLists;

            var map = new Dictionary<string, int>(wordList.Count);
            for (var i = 0; i < wordList.Count; i++)
            {
                if (map.ContainsKey(wordList[i]))
                {
                    map[wordList[i]]++;
                }
                else
                {
                    map.Add(wordList[i], 1);
                }
            }

            var current = new List<string>();
            current.Add(beginWord);
            this.DFS(beginWord, endWord, ref map, ref current, ref retLists);
            return retLists;
        }

        private void DFS(string beginWord, string endWord, ref Dictionary<string,int> allWords, ref List<string> current, 
            ref List<IList<string>> retLists)
        {
            if (beginWord.Equals(endWord))
            {
                if (retLists.Count != 0)
                {
                    if (current.Count > retLists[0].Count)
                    {
                        return;
                    }
                    else if (current.Count < retLists[0].Count)
                    {
                        retLists = new List<IList<string>>();
                    }
                }
                
                retLists.Add(new List<string>(current));
                return;
            }

            for (var i = 0; i < beginWord.Length; i++)
            {
                for (var j = 0; j < 26; j++)
                {
                    var sb = new StringBuilder(beginWord);
                    sb[i] = (char)('a' + j);
                    var str = sb.ToString();
                    if (allWords.ContainsKey(str))
                    {
                        allWords[str]--;
                        if (allWords[str] == 0)
                        {
                            allWords.Remove(str);
                        }
                        current.Add(str);
                        this.DFS(str, endWord, ref allWords, ref current, ref retLists);
                        current.Remove(str);
                        if (allWords.ContainsKey(str))
                        {
                            allWords[str]++;
                        }
                        else
                        {
                            allWords.Add(str, 1);
                        }
                    }
                }
            }
        }

        private void Print(IList<IList<string>> lists)
        {
            foreach (var list in lists)
            {
                Console.WriteLine(String.Join(", ", list));
            }
        }
    }
}
