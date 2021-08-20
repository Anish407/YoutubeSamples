using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncDemoController : ControllerBase
    {

        [HttpGet("GetLikes")]
        public async Task<IActionResult> GetLikes()
        {
            await Task.Delay(2000);
            return Ok(new { result=100 });
        }

        [HttpGet("TotalFrnds")]
        public async Task<IActionResult> TotalFrnds()
        {
            await Task.Delay(2000);
            return Ok(new { result = 200 });
        }

        [HttpGet("TotalFollowers")]
        public async Task<IActionResult> TotalFollowers()
        {
            await Task.Delay(2000);
            throw new Exception(nameof(TotalFollowers));
            return Ok(new { result = 500 });
        }

    }
}
