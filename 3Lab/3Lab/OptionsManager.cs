using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _3Lab
{
    class OptionsManager
    {
        ETLOptions defaultOptions;
        ETLJsonOptions jsonOptions;
        ETLXmlOptions xmlOptions;
        bool jsonConfigured;
        bool xmlConfigured;
        Logger logger;

        public OptionsManager(string path, Logger logger)
        {
            this.logger = logger;
            defaultOptions = new ETLOptions();
            string options;
            try
            {
                using (StreamReader sr = new StreamReader($"{path}\\config.xml"))
                {
                    options = sr.ReadToEnd();
                    ///TODO убрать
                    Console.WriteLine("WWE");
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
                    ///TODO убрать
                    Console.WriteLine("Jsonnnns");
                }
                jsonConfigured = true;
                jsonOptions = new ETLJsonOptions(options);
            }
            catch
            {
                jsonConfigured = false;
            }
        }

        public Options GetOptions<T>()
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

        private Options SeekForOption<T>(ETLOptions options)
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
