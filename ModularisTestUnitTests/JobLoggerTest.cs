using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModularisTest;
using ModularisTest.Configuration;
using ModularisTest.Destinations;
using ModularisTest.Logger;
using ModularisTest.Models;
using System;
using System.Linq;

namespace ModularisTestUnitTests
{
    [TestClass]
    public class JobLoggerTest
    {
        private const string TestMessage = "Test Message";
        private const string WarningMessage = "Test Warning";
        private const string ErrorMessage = "Test Error";

        [TestMethod]
        public void JobLoggerBasicTest()
        {
            var jobLogger = new JobLoggerOld(true, true, true, true, true);
            JobLoggerOld.LogMessage(TestMessage, true, false, false);
            JobLoggerOld.LogMessage(WarningMessage, false, true, false);
            JobLoggerOld.LogMessage(ErrorMessage, false, false, true);
        }

        [TestMethod]
        public void JobLoggerRefactoredTest()
        {
            var config = LoggerConfiguration.Instance;
            var logger = new JobLogger(config);

            logger.LogMessage(TestMessage, MessageType.Message);
            logger.LogMessage(WarningMessage, MessageType.Warning);
            logger.LogMessage(ErrorMessage, MessageType.Error);
        }
    }
}