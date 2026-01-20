using ModularisTest.Interfaces;
using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Destinations
{
    public class DatabaseLogger : ILogDestination
    {
        public string Message { get; set; }
        public string connectionString { get; set; }

        public DatabaseLogger() { }

        public void Log(string message, MessageType type)
        {
            Console.WriteLine($"Logging to database: {message} with type {type}");
        }
    }
}
