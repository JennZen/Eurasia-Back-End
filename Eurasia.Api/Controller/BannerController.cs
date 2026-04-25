using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.Banner;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/banners")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        internal IBannerAction _banners;

        public BannerController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _banners = bl.GetBannerActions();
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int count = 4)
        {
            return Ok(_banners.GetAll(count));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BannerDto? banner = _banners.GetById(id);
            if (banner == null) return NotFound($"No banner with id {id} was found");
            return Ok(banner);
        }
    }
}
