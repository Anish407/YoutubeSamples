using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace YoutubeSamples.LogExecutionTime
{
    public static class ExecutionTimeLoggerExtensions
    {
        public static ExecutionTimeLogger<T> LogElapsedSeconds<T>(
            this ILogger<T> logger,
            string message,
            LogLevel logLevel=LogLevel.Information)
         => new ExecutionTimeLogger<T>(message, logger, logLevel);
    }

    public class ExecutionTimeLogger<T> : IDisposable
    {
        public ExecutionTimeLogger(string message, ILogger<T> logger, LogLevel logLevel)
        {
            Message = message;
            Logger = logger;
            LogLevel = logLevel;
            Timer = Stopwatch.StartNew();
        }

        public string Message { get; }
        private ILogger<T> Logger { get; }
        private LogLevel LogLevel { get; }
        private Stopwatch Timer { get; }

        public void Dispose()
        {
            Console.WriteLine($"{Message} took {Timer.ElapsedMilliseconds}");
        }
    }
}
