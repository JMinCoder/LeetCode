using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    
    public class FileSystem
    {
        public void Test()
        {
            FileSystem obj = new FileSystem();
            IList<string> param_1 = obj.Ls("/");
            Console.WriteLine("Ls '/' : {0}", String.Join(",", param_1));

            obj.Mkdir("/a/b/c");
            obj.AddContentToFile("/a/b/c/d", "hello");

            param_1 = obj.Ls("/");
            Console.WriteLine("Ls '/' : {0}", String.Join(",", param_1));

            string param_4 = obj.ReadContentFromFile("/a/b/c/d");
            Console.WriteLine("File : {0}", param_4);
        }

        public File Root;
        public FileSystem()
        {
            Root = new File("/", true);
        }

        public IList<string> Ls(string path)
        {
            IList<string> res = new List<string>();

            var split = path.Split('/');
            var d = this.Root;
            string name = string.Empty;
            for (var i = 0; i < split.Length; i++)
            {
                //
                if (split[i].Length == 0) continue;
                if (!d.Children.ContainsKey(split[i])) return res;
                d = d.Children[split[i]];
                name = split[i];                
            }

            if (name != string.Empty) res.Add(name);
            if (d.IsDir)
            {
                foreach (var key in d.Children.Keys)
                {
                    res.Add(key);
                }
            }
            return res;
        }

        public void Mkdir(string path)
        {
            var split = path.Split('/');
            var d = this.Root;
            for (var i=1;i<split.Length;i++)
            {
                if (d.Children.ContainsKey(split[i]))
                {
                    if (!d.Children[split[i]].IsDir) throw new NotSupportedException();
                    d = d.Children[split[i]];
                }
                else
                {
                    var subDir = new File(split[i], true);
                    d.Children.Add(split[i], subDir);
                    d = subDir;
                }
            }
        }

        public void AddContentToFile(string filePath, string content)
        {
            var split = filePath.Split('/');
            var d = this.Root;
            for (var i = 1; i < split.Length; i++)
            {
                if (d.Children.ContainsKey(split[i]))
                {
                    if (d.Children[split[i]].IsDir)
                    {
                        d = d.Children[split[i]];
                    }
                    else
                    {
                        if (i != split.Length - 1) throw new NotSupportedException();
                        d.Children[split[i]].Content += content;
                    }
                }
                else
                {
                    if (i != split.Length -1) throw new NotSupportedException();
                    d.Children.Add(split[i], new File(split[i], false) { Content = content } );
                }
            }
        }

        public string ReadContentFromFile(string filePath)
        {
            var split = filePath.Split('/');
            var d = this.Root;
            for (var i = 1; i < split.Length; i++)
            {
                if (d.Children.ContainsKey(split[i]))
                {
                    if (d.Children[split[i]].IsDir)
                    {
                        d = d.Children[split[i]];
                    }
                    else
                    {
                        if (i != split.Length - 1) throw new NotSupportedException();
                        return d.Children[split[i]].Content;
                    }
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            return string.Empty;
        }

        public class File
        {
            public bool IsDir = false;
            public string Name;
            public Dictionary<string, File> Children = new Dictionary<string, File>();
            public string Content;

            public File(string name)
                : this(name, false)
            {
            }

            public File(string name, bool isDir)                
            {
                this.Name = name;
                this.IsDir = isDir;
                this.Content = string.Empty;
            }
        }
    }
}
