using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using willtodo.Functions.Functions;
using willtodo.Test.Helpers;
using Xunit;

namespace willtodo.Test.Tests
{
    public class ScheduleFunctionTest
    {
        [Fact]
        public void ScheduleFunction_Should_LogMessage()
        {
            // Arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
            // Act
            ScheduledFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];
            // Assert
            Assert.Contains("Deleting task completed", message);
        }
    }
}
