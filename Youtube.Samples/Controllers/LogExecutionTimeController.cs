using Microsoft.AspNetCore.Mvc;
using static YoutubeSamples.LogExecutionTime.ExecutionTimeLoggerExtensions;

[ApiController]
[Route("api/[controller]")]
public class LogExecutionTimeController : ControllerBase
{
    public LogExecutionTimeController(ILogger<LogExecutionTimeController> logger)
    {
        Logger = logger;
    }

    public ILogger<LogExecutionTimeController> Logger { get; }

    [HttpGet("CheckLoggerExecutionTime")]
    public async Task<IActionResult> CheckLoggerExecutionTime()
    {
        using var _ = Logger.LogElapsedSeconds(nameof(CheckLoggerExecutionTime));
        await MockMethod(5);

        return Ok();
    }

    Task MockMethod(int sleepTimeInSeconds) => Task.Delay(sleepTimeInSeconds);
}