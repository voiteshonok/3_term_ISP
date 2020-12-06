using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Lab
{
    class Logger
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        string source;
        string target;
        public Logger(string source, string target)
        {
            this.source = source;
            this.target = target;
            watcher = new FileSystemWatcher(source);
            watcher.Created += Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(100);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
        /// <summary>
        /// adding files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Created(object sender, FileSystemEventArgs e)
        {
            string time = DateTime.Now.ToString("dd/MM/yyyy/hh//mm//ss");
            Encryptor.Crypt(e.FullPath);
            Archivator.Compress(e.FullPath, $"{target}{time}.txt.gz");
            Archivator.Decompress($"{target}{time}.txt.gz");
            Encryptor.Decrypt($"{target}{time}.txt");
        }
    }
}
