using System;
using System.IO;

class Logger
{
    public static void LogMessage(string filePath, string message, string logLevel)
    {
        string logEntry = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] [{logLevel}] {message}";

        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(logEntry);
        }
    }
}

class Program
{
    static void Main()
    {
        Logger.LogMessage("application.log", "User logged in", "INFO");
        Logger.LogMessage("application.log", "Failed login attempt", "WARNING");
    }
}
