using System;
using System.Collections.Generic;
using System.Text;

namespace _3Lab
{
    interface IParser
    {
        Dictionary<string, string> Parse(string text);
    }
}
