using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3Lab
{
    class Tracer
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        string sourceFolder;
        string targetFolder;
        string loggerPath;
        Logger logger;

        public Tracer(string source, string target, string loggerPath)
        {
            this.sourceFolder = source;
            this.targetFolder = target;
            this.loggerPath = loggerPath;
            logger = new Logger(loggerPath);
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

            Encrypt(e.FullPath);

            Compress(e.FullPath, $"{targetFolder}{time}.txt.gz");

            Decompress($"{targetFolder}{time}.txt.gz");

            Decrypt($"{targetFolder}{time}.txt");
        }

        private void Encrypt(string path)
        {
            Encryptor.Crypt(path);
            logger.Logging("crypted", path);
        }

        private void Compress(string path, string name)
        {
            Archivator.Compress(path, name);
            logger.Logging($"compressed from {path} to {name}");
        }

        private void Decompress(string path)
        {
            Archivator.Decompress(path);
            logger.Logging("decompressed", path);
        }

        private void Decrypt(string path)
        {
            Encryptor.Decrypt(path);
            logger.Logging("decrypted", path);
        }
    }
}
