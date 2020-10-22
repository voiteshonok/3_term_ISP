using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public static class App
    {
        public static Manager leftList { get; set; }
        public static Manager rightList { get; set; }

        public static void InitializingManagers()
        {
            leftList = new Manager();
            
            rightList = new Manager();

        }

        public static void ChangeCurrentDirectory(string cur)
        {
            leftList = new Manager(cur);
        }
    }
}
