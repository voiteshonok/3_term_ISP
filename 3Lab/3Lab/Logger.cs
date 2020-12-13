using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Lab
{
    class Logger
    {
        private string path { get; }

        public Logger(string path)
        {
            this.path = path;
        }

        public void Logging(params string[] message)
        {
            using (var sr = new StreamWriter(path, true))
            {
                for (int i = 0; i < message.Length; ++i)
                {
                    sr.Write($"{message[i]} ");
                }
                sr.Write("\n");
            }
        }
    }
}
