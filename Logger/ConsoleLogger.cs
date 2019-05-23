using System;

namespace Logger
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            Console.WriteLine($"Message logged: {message}");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
