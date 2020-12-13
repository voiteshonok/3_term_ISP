using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace _3Lab
{
    class ETLXmlOptions : ETLOptions
    {
        public ETLXmlOptions(string text) : base()
        {
            XmlParser xml = new XmlParser();
            var keys = xml.Parse(text);
            try
            {
                FolderOptions.SourceFolder = XmlParser.GetValue(keys["FolderOptions"], "SourceFolder");
            }
            catch { }
            try
            {
                FolderOptions.TargetFolder = XmlParser.GetValue(keys["FolderOptions"], "TargetFolder");
            }
            catch { }
            try
            {
                var bytes = Encoding.UTF8.GetBytes(XmlParser.GetValue(keys["EncryptOptions"], "key"));
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = bytes;
                EncryptOptions.key = bytes;
            }
            catch { }
            try
            {
                ArchiveOptions.CompressionLevel = (CompressionLevel)Int32.Parse(XmlParser.GetValue(keys["ArhiveOptions"], "CompressionLevel"));
            }
            catch { }
        }
    }
}
