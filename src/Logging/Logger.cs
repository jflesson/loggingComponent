using System;
using System.Configuration;
using System.IO;

namespace Logging
{
    public class Logger : ILogger
    {
        public readonly string path;
        public readonly string logFileName;

        public Logger()
        {
            this.path = ConfigurationManager.AppSettings["path"];
            this.logFileName = ConfigurationManager.AppSettings["logFileName"];
        }
        public void LogInfo(string message)
        {
            LogMessage(message, "Info");
        }

        public void LogError(string error)
        {
            LogMessage(error, "Error");
        }

        private void LogMessage(string message, string type)
        {
            string log = $"[{DateTime.Now:HH:mm:ss}] - {type} - {message}";

            WriteLine(log);
        }

        private void WriteLine(string line)
        {
            string filename = $"{logFileName}-{DateTime.Now:ddMMyyyy}.log";
            string logPath = Path.Combine(path, filename);
            bool append = true;
            using (StreamWriter file =
                new StreamWriter(logPath, append))
            {
                file.WriteLine(line);
            }
        }
    }
}