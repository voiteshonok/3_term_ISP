using System.Collections.Generic;


namespace ConfigurationManager.Options
{
    public class DefaultOptions
    {
        public string sourceDirectoryPath = "D:\\SourceDirectory";
        public string targetDirectoryPath = "D:\\TargetDirectory";
        public int key = 12;
        public int id = 2;
        public string dataSource = ".\\SQLEXPRESS";
        public string initialCatalog = "AdventureWorks2016";
        public string integratedSecurity = "True";
        public string xmlDirectory = "D:\\";
        public DefaultOptions() { }
    }
}
