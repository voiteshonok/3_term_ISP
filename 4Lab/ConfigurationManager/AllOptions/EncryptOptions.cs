using ConfigurationManager.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Lab
{
    class EncryptOptions : Options
    {
        public byte[] key { get; set; } = Encoding.UTF8.GetBytes("ABCDEFGH");
    }
}
