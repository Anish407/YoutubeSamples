using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static YoutubeSamples.LogExecutionTime.ExecutionTimeLoggerExtensions;

namespace Sample.Api.Controllers
{
    [ApiController]
    public class LogExecutionTimeController:ControllerBase
    {
        public LogExecutionTimeController(ILogger<LogExecutionTimeController> logger)
        {
            Logger = logger;
        }

        public ILogger<LogExecutionTimeController> Logger { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using  var _ = Logger.LogElapsedSeconds(nameof(LogExecutionTimeController.Get));
            {
                await MockMethod(5);
            }
           


            return Ok();
        }

        Task MockMethod(int sleepTimeInSeconds) => Task.Delay(sleepTimeInSeconds);
    }
}
