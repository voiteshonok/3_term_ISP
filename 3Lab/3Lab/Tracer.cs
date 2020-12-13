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
        OptionsManager optionsManager;
        FileSystemWatcher watcher;
        bool enabled = true;
        string loggerPath;
        Logger logger;

        public Tracer(string path)
        {
            loggerPath = path + "logs.txt";
            File.Create(loggerPath).Close();
            logger = new Logger(loggerPath);
            optionsManager = new OptionsManager(path, logger);

            FolderOptions opt = optionsManager.GetOptions<FolderOptions>() as FolderOptions;
            Directory.CreateDirectory(opt.SourceFolder);
            Directory.CreateDirectory(opt.TargetFolder);

            watcher = new FileSystemWatcher(opt.SourceFolder);
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
            FolderOptions opt = optionsManager.GetOptions<FolderOptions>() as FolderOptions;
            watcher.EnableRaisingEvents = false;
            enabled = false;
            try
            {
                Directory.Delete(opt.SourceFolder, true);
            }
            catch { }
            try
            {
                Directory.Delete(opt.TargetFolder, true);
            }
            catch { }
            try
            {
                File.Delete(loggerPath);
            }
            catch { }
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

            Compress(e.FullPath, time);

            Decompress(time);

            Decrypt(time);
        }

        /// <summary>
        /// encrypting file by path
        /// </summary>
        /// <param name="path"></param>
        private void Encrypt(string path)
        {
            EncryptOptions encryptOptions = optionsManager.GetOptions<EncryptOptions>() as EncryptOptions;
            Encryptor.Crypt(path, encryptOptions);
            logger.Logging("crypted", path);
        }

        /// <summary>
        /// compressing file and moving to TargetFolder
        /// </summary>
        /// <param name="path"></param>
        /// <param name="time"></param>
        private void Compress(string path, string time)
        {
            ETLOptions options = optionsManager.GetOptions<ETLOptions>() as ETLOptions;
            string newPath = $"{options.FolderOptions.TargetFolder}{time}.txt.gz";
            Archivator.Compress(path, newPath, options.ArchiveOptions);
            logger.Logging($"compressed from {path} to {newPath}");
        }

        /// <summary>
        /// decompressing file in this folder
        /// </summary>
        /// <param name="time"></param>
        private void Decompress(string time)
        {
            ETLOptions options = optionsManager.GetOptions<ETLOptions>() as ETLOptions;
            string path = $"{options.FolderOptions.TargetFolder}{time}.txt.gz";
            Archivator.Decompress(path);
            logger.Logging("decompressed", path);
        }

        /// <summary>
        /// decrypting file
        /// </summary>
        /// <param name="time"></param>
        private void Decrypt(string time)
        {
            ETLOptions options = optionsManager.GetOptions<ETLOptions>() as ETLOptions;
            string path = $"{options.FolderOptions.TargetFolder}{time}.txt";
            Encryptor.Decrypt(path);
            logger.Logging("decrypted", path);
        }
    }
}
