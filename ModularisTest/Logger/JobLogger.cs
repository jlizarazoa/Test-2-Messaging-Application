using ModularisTest.Configuration;
using ModularisTest.Interfaces;
using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Logger
{
    public class JobLogger
    {
        private IEnumerable<MessageType> messageTypes;
        private IReadOnlyCollection<ILogDestination> _destinations;
        private LoggerConfiguration _configuration;

        public JobLogger(LoggerConfiguration configuration)
        {
            _configuration = configuration;

            var destinationTypes = configuration.GetEnabledDestinations();
            _destinations = destinationTypes
                .Select(dt => Destinations.LogDestinationFactory.CreateLogDestination(dt, configuration.GetLogDirectory()))
                .ToList()
                .AsReadOnly();

            messageTypes = configuration.GetEnabledMessageTypes();
        }

        public void LogMessage(string message, MessageType type)
        {
            if (!messageTypes.Contains(type))
                throw new Exception("Message type not configured to be logged.");

            if (_destinations == null || _destinations.Count == 0)
                throw new Exception("No log destinations configured.");

            if (string.IsNullOrWhiteSpace(message))
                return;


            foreach (var destination in _destinations)
            {
                destination.Log(message, type);
            }
        }

    }
}
