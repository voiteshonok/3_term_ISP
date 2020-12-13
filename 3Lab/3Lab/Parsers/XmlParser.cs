using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _3Lab
{
    class XmlParser
    {
        public Dictionary<string, string> Parse(string text)
        {
            Dictionary<string, string> keys;

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(text);

                keys = new Dictionary<string, string>();

                foreach (XmlNode key in xDoc.DocumentElement)
                {
                    keys.Add(key.Name, key.OuterXml);
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
                throw new NotSupportedException();
            };
        }

    }
}
