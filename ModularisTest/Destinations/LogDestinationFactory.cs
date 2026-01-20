using ModularisTest.Interfaces;
using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Destinations
{
    public class LogDestinationFactory
    {
        public static ILogDestination CreateLogDestination(string destinationType, string logDirectory = "")
        {
            switch (destinationType.ToLower())
            {
                case "file":
                    return new FileLogger(logDirectory);
                case "database":
                    return new DatabaseLogger();
                case "console":
                    return new ConsoleLogger();
                default:
                    throw new ArgumentException($"Unknown log destination type: {destinationType}");
            }
        }
    }
}
