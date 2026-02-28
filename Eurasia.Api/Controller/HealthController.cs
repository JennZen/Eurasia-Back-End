using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult Get()
        {
            var success = new
            {
                status = 200
            };
            return Ok(success);
        }
    }
}
