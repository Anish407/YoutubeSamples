using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YoutubeSamples.LogExecutionTime;
using static YoutubeSamples.LogExecutionTime.ExecutionTimeLoggerExtensions;


using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});
ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Example log message");

using var obj = new ExecutionTimeLogger<Program>(nameof(MockMethod), logger, LogLevel.Information);
{
    Console.WriteLine("helloo");
    Console.WriteLine("helloo");
    Console.WriteLine("helloo");
    Console.WriteLine("helloo");
    Console.WriteLine("helloo");
}





Console.Read();


Task MockMethod(int sleepTimeInSeconds) => Task.Delay(sleepTimeInSeconds);

