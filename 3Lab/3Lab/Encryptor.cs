using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3Lab
{
    static class Encryptor
    {
        private static DESCryptoServiceProvider cryptic;

        static Encryptor()
        {
            cryptic = new DESCryptoServiceProvider();

            cryptic.Key = Encoding.UTF8.GetBytes("ABCDEFGH");
            cryptic.IV = Encoding.UTF8.GetBytes("ABCDEFGH");
        }



        public static void Crypt(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                using (CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    crStream.Write(data, 0, data.Length);
                }
            }
        }


        public static void Decrypt(string path)
        {
            string data;

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(crStream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }

            using (FileStream fstream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(data);

                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
