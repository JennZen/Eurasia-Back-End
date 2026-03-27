
using Eurasia.BusinessLogic;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Enums.Eurasia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        internal ICountryAction _countries;
        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _countries = bl.GetMainInfoCountryActions();
        }


        [HttpGet("status")]
        public IActionResult Get()
        {
            return Ok("Session is active");
        }

        /*[HttpGet("continent")]
        public IActionResult Post([FromQuery] List<Continents> continents)
        {

            var allCountries = _countries.GetAllCountriesMainInfoDtos(continents);
            return Ok(allCountries);
        }*/
    }
}
