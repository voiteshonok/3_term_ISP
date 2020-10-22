using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Manager
    {
        public string CurrentDirectory { get; set; }

        public List<string> list { get; set; }

        public Manager(string cur)
        {
            CurrentDirectory = cur;
            MakeList();
        }

        public Manager():this(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory())){}

        public string this[int n]
        {
            get
            {
                return list[n];
            }
            set
            {
                list[n] = value;
            }
        }

        public void MakeList()
        {
            list = new List<string>();
            string[] directories = Directory.GetDirectories(CurrentDirectory);

            foreach (var dir in directories)
            {
                list.Add(Path.Combine(CurrentDirectory, dir));
            }
            string[] files = Directory.GetFiles(CurrentDirectory);
            foreach (var file in files)
            {
                list.Add(Path.Combine(CurrentDirectory, file));
            }
        }

        public void Back()
        {
            if (String.IsNullOrEmpty(Path.GetDirectoryName(CurrentDirectory)))
            {
                throw new ArgumentNullException();
            }
            CurrentDirectory = Path.GetDirectoryName(CurrentDirectory);
            MakeList();
        }

        public void GoToSelected(int selected)
        {
            if (Directory.Exists(list[selected]))
            {
                CurrentDirectory = list[selected];
                MakeList();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Search(string startPath, string pattern)
        {
            var ans = new List<string>();
            var queue = new Queue<string>();
            queue.Enqueue(startPath);
            var files = new Queue<string>();
            while (queue.Count != 0)
            {
                string curPath = queue.Dequeue();
                string[] directories;
                try
                {
                    directories = Directory.GetDirectories(curPath);
                }
                catch (System.UnauthorizedAccessException)
                {
                    continue;
                }
                foreach (var directory in directories)
                {
                    queue.Enqueue(Path.Combine(curPath, directory));
                    if (directory.Remove(0, directory.LastIndexOf('\\')).Contains(pattern))
                    {
                        ans.Add(Path.Combine(curPath, directory));
                    }
                }
                foreach (var file in Directory.GetFiles(curPath))
                {
                    if (Path.GetFileName(file).Contains(pattern))
                    {
                        files.Enqueue(Path.Combine(curPath, file));
                    }
                }
            }
            while (files.Count != 0)
            {
                ans.Add(files.Dequeue());
            }
            CurrentDirectory = startPath;
            list = ans;
        }
    }
}
