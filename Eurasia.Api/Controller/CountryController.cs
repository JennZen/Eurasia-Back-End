using Eurasia.BusinessLogic;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/session")]//incorrect route for the controller - should be "api/countries"
    [ApiController]
    public class AuthController : ControllerBase //incorrect name for the controller - should be CountryController    
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

        [HttpGet("continent")]
        public IActionResult Post([FromQuery] List<Continents> continents)
        {

            var allCountries = _countries.GetAllCountriesMainInfoDtos(continents);
            return Ok(allCountries);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countries.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CountryMainInfoDto? country = _countries.GetById(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CountryMainInfoDto country)
        {
            _countries.Create(country);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CountryMainInfoDto country)
        {
            country.Id = id;
            _countries.Update(country);
            return Ok();
        }
    }
}
