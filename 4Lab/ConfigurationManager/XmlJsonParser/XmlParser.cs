using System.Collections.Generic;
using System.Xml;

namespace ConfigurationManager.XmlJsonParser
{
    public class XmlParser
    {
        // словарь хранит пары имя - значение
        public Dictionary<string, string> nodes;

        public Dictionary<string, string>  Parse(string xmlPath)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xmlPath);
                nodes = new Dictionary<string, string>();

                foreach (XmlNode node in xDoc.DocumentElement)
                {
                    nodes.Add(node.Name, node.InnerText);
                }
            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }

        public static string GetValue(string text, string value)
        {
            Dictionary<string, string> keys;

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(text);

                keys = new Dictionary<string, string>();

                foreach (XmlNode key in xDoc.DocumentElement)
                {
                    keys.Add(key.Name, key.InnerText);
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
