using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace _3Lab
{
    class ETLJsonOptions : ETLOptions
    {
        public ETLJsonOptions(string text) : base()
        {
            JsonParser js = new JsonParser();
            var keys = js.Parse(text);
            try
            {
                FolderOptions.SourceFolder = JsonParser.GetValue(keys["FolderOptions"], "SourceFolder");
            }
            catch { }
            try
            {
                FolderOptions.TargetFolder = JsonParser.GetValue(keys["FolderOptions"], "TargetFolder");
            }
            catch { }
            try
            {
                var bytes = Encoding.UTF8.GetBytes(JsonParser.GetValue(keys["EncryptOptions"], "key"));
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = bytes;
                EncryptOptions.key = bytes;
            }
            catch { }
            try
            {
                ArchiveOptions.CompressionLevel = (CompressionLevel)Int32.Parse(JsonParser.GetValue(keys["ArhiveOptions"], "CompressionLevel"));
            }
            catch { }
        }
    }
}
