using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace _3Lab
{
    class JsonParser
    {
        public Dictionary<string, string> Parse(string text)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();
            try
            {
                JsonDocument jDoc = JsonDocument.Parse(text);

                foreach (var key in jDoc.RootElement.EnumerateObject())
                {
                    keys.Add(key.Name, key.Value.ToString());
                    Console.WriteLine(key.Name + "\t" + key.Value.ToString());
                }
            }
            catch
            {
                throw new NotSupportedException();
            }
            return keys;
        }

        public static string GetValue(string text, string value)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();

            try
            {
                JsonDocument jDoc = JsonDocument.Parse(text);

                foreach (var key in jDoc.RootElement.EnumerateObject())
                {
                    keys.Add(key.Name, key.Value.ToString());
                }
                return keys[value];
            }
            catch
            {
                throw new NotSupportedException();
            };
        }
    }

}
