using ModularisTest.Configuration;
using ModularisTest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Models
{
    public class FileLogger: ILogDestination
    {
        private string logFolder { get; set; }

        public FileLogger(string logDirectory)
        {
            logFolder = logDirectory;
        }
        public void Log(string message, MessageType type)
        {
            if (!Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);

            string logFileName = "LogFile" + DateTime.Now.ToShortDateString().Replace("/", ".") + ".txt";
            var fullPath = System.IO.Path.Combine(logFolder, logFileName);

            using (var file = new System.IO.StreamWriter(fullPath, true))
            {
                file.WriteLine(DateTime.Now.ToShortDateString() + " " + type + " " + message);
            }
        }
    }
}

