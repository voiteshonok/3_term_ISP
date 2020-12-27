using System.ServiceProcess;
using System.Threading;
using FileManager.FileActions;

namespace FileManager
{
    public partial class FileManagerService : ServiceBase
    {
        FileAction logger;
        public FileManagerService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new FileAction();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
