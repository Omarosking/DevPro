using System;
using System.IO;
using Xunit;

public class LoggerTests
{
    private readonly string testLogFilePath = "test.log";

    [Fact]
    public void LogMessage_ShouldCreateLogFileAndWriteMessage()
    {
        // Arrange
        if (File.Exists(testLogFilePath))
        {
            File.Delete(testLogFilePath);
        }

        // Act
        Logger.LogMessage(testLogFilePath, "Test message", "INFO");

        // Assert
        Assert.True(File.Exists(testLogFilePath));

        string logContents = File.ReadAllText(testLogFilePath);
        Assert.Contains("[INFO] Test message", logContents);
    }

    [Fact]
    public void LogMessage_ShouldAppendMessageToExistingLogFile()
    {
        // Arrange
        if (!File.Exists(testLogFilePath))
        {
            using (StreamWriter writer = File.CreateText(testLogFilePath))
            {
                writer.WriteLine("Existing log entry");
            }
        }

        // Act
        Logger.LogMessage(testLogFilePath, "Another message", "ERROR");

        // Assert
        Assert.True(File.Exists(testLogFilePath));

        string logContents = File.ReadAllText(testLogFilePath);
        Assert.Contains("Existing log entry", logContents);
        Assert.Contains("[ERROR] Another message", logContents);
    }
}
