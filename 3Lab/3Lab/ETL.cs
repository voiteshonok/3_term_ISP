using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3Lab
{
    public partial class ETL : ServiceBase
    {
        Tracer tracer;
        string source = "D:\\" + "Source\\";
        string target = "D:\\" + "Target\\";
        string log = "D:\\" + "logs.txt";
        public ETL()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();

            Directory.CreateDirectory(source);
            Directory.CreateDirectory(target);
            File.Create(log).Close();

            tracer = new Tracer(source, target, log);
            Thread loggerThread = new Thread(new ThreadStart(tracer.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            tracer.Stop();
        }
    }
}
