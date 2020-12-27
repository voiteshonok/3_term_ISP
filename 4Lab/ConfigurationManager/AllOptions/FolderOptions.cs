using ConfigurationManager.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3Lab
{
    class FolderOptions : Options
    {
        public string SourceFolder { get; set; } = @"C:\Users\ACER\Desktop\ConsoleApp2\\source";
        public string TargetFolder { get; set; } = @"C:\Users\ACER\Desktop\ConsoleApp2\\target";
    }
}
