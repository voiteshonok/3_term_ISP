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
        string path = "D:\\";
        public ETL()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();

            tracer = new Tracer(path);
            Thread loggerThread = new Thread(new ThreadStart(tracer.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            tracer.Stop();
        }
    }
}
