using Eurasia.BusinessLogic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        internal IAdminAction _admin;

        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _admin = bl.GetAdminActions();
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var stats = _admin.GetDashboardStats();
            return Ok(stats);
        }

        [HttpGet("recent")]
        public IActionResult GetRecent([FromQuery] int take = 10)
        {
            var recent = _admin.GetRecentActions(take);
            return Ok(recent);
        }
    }
}
