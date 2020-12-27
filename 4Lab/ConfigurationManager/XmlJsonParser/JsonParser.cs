using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace ConfigurationManager.XmlJsonParser
{
    public class JsonParser
    {        
        // словарь хранит пары имя - значение
        public Dictionary<string, string> nodes = new Dictionary<string, string>();

        public Dictionary<string, string> Parse(string jsonPath)
        {
            try
            {
                JsonDocument jDoc = JsonDocument.Parse(File.ReadAllText(jsonPath));
                nodes = new Dictionary<string, string>();

                foreach (JsonProperty node in jDoc.RootElement.EnumerateObject())
                {
                    nodes.Add(node.Name, node.Value.ToString());
                }
            }
            catch
            {
                throw new KeyNotFoundException();
            }
                
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
                throw new KeyNotFoundException();
            };
        }
    }
}
