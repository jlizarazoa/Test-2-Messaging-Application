using ModularisTest.Interfaces;
using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Configuration
{
    public class LoggerConfiguration
    {
        private IReadOnlyCollection<string> Destinations = new List<string>();
        private HashSet<MessageType> MessageTypes = new HashSet<MessageType>();
        private string LogDirectory = string.Empty;

        private static LoggerConfiguration _instance;
        private static readonly object _lock = new object();

        private LoggerConfiguration()
        {
            Destinations = ConfigurationManager.AppSettings["LogDestinations"]?
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim())
                .ToList() ?? new List<string>();

            MessageTypes = ConfigurationManager.AppSettings["LogMessageTypes"]?
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(mt => mt.Trim())
                .Select(mt =>
                {
                    MessageType result;
                    return Enum.TryParse<MessageType>(mt, out result) ? result : (MessageType?)null;
                })
                .Where(mt => mt.HasValue)
                .Select(mt => mt.Value)
                .ToHashSet() ?? new HashSet<MessageType>();

            LogDirectory = ConfigurationManager.AppSettings["LogDirectory"] ?? string.Empty;

        }

        public static LoggerConfiguration Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoggerConfiguration();
                        }
                    }
                }
                return _instance;
            }
        }
        public IEnumerable<MessageType> GetEnabledMessageTypes()
        {
            return MessageTypes;
        }
        public IEnumerable<string> GetEnabledDestinations()
        {
            return Destinations;
        }
        public string GetLogDirectory()
        {
            return LogDirectory;
        }
    }
}
