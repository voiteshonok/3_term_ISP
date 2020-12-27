using System.IO;
using System;
using ConfigurationManager.Options;
using ConfigurationManager.XmlJsonParser;
using _3Lab;

namespace ConfigurationManager
{
    public class OptionsManager
    {
        ETLOptions defaultOptions;
        ETLJsonOptions jsonOptions;
        ETLXmlOptions xmlOptions;
        bool jsonConfigured;
        bool xmlConfigured;

        public OptionsManager()
        {
            AppDomain path = AppDomain.CurrentDomain;
            defaultOptions = new ETLOptions();
            string options;
            try
            {
                using (StreamReader sr = new StreamReader($"{path}\\config.xml"))
                {
                    options = sr.ReadToEnd();
                }
                xmlConfigured = true;
                xmlOptions = new ETLXmlOptions(options);
            }
            catch
            {
                xmlConfigured = false;
            }
            try
            {
                using (StreamReader sr = new StreamReader($"{path}\\appsettings.json"))
                {
                    options = sr.ReadToEnd();
                }
                jsonConfigured = true;
                jsonOptions = new ETLJsonOptions(options);
            }
            catch
            {
                jsonConfigured = false;
            }
        }

        public dbOptions GetOptions<T>()
        {
            if (xmlConfigured)
            {
                return SeekForOption<T>(xmlOptions);
            }
            else if (jsonConfigured)
            {
                return SeekForOption<T>(jsonOptions);
            }
            else
            {
                return SeekForOption<T>(defaultOptions);
            }
        }

        private dbOptions SeekForOption<T>(ETLOptions options)
        {
            if (typeof(T) == typeof(ETLOptions))
            {
                return options;
            }
            try
            {
                return options.GetType().GetProperty(typeof(T).Name).GetValue(options, null) as Options;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}

