using System;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace WampSharpDemo
{
    internal static class Program
    {
        static void InitLogs(string suffix = "")
        {
            var fileLogger = new RollingFileAppender
            {
                File = "WampSharpDemo.log" + suffix,
                AppendToFile = true,
                MaximumFileSize = "100MB",
                MaxSizeRollBackups = 1,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                Layout = new PatternLayout("%date{dd HH:mm:ss} [%5.10thread] %-5level [%10logger] %message%newline"),
                Threshold = Level.Info
            };
            fileLogger.ActivateOptions();
            BasicConfigurator.Configure(LogManager.GetRepository(), fileLogger);
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                InitLogs();
                var server = Server.Instance;
                //
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new WampSharpForm());
            }
            else
            {
                InitLogs(".client" + args[0]);
                int workTimeMillis = 85;
                if (args.Length > 1)
                {
                    workTimeMillis = int.Parse(args[1]);
                }
                ThreadPool.QueueUserWorkItem(state => new Client(() => false).SubscribeAndWait(workTimeMillis));
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ClientForm("Client " + args[0]));
            }
        }
    }
}