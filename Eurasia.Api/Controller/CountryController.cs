using Eurasia.BusinessLogic;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase  
    {
        internal ICountryAction _countries;
        public CountryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _countries = bl.GetMainInfoCountryActions();
        }

        [HttpGet("status")]
        public IActionResult Get()
        {
            return Ok("Session is active");
        }

        [HttpGet]
        public IActionResult Post([FromQuery] List<Continents> continents)
        {

            var allCountries = _countries.GetAllCountriesMainInfoDtos(continents);
            return Ok(allCountries);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success =_countries.Delete(id);
            if (!success) return NotFound($"Country with {id} was not found");

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CountryMainInfoDto? country = _countries.GetById(id);
            if (country == null)
            {
                return NotFound($"Country with {id} was not found");
            }

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CountryMainInfoDto country)
        {
            if (country == null) return BadRequest("Invalid data");

            bool success = _countries.Create(country);
            if (!success)
            {
                return Conflict(new { message = $"Country with ID {country.Id} already exists." });
            }

            return CreatedAtAction(nameof(GetById), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CountryMainInfoDto country)
        {
            country.Id = id;
            bool success = _countries.Update(country);
            
            if (!success)
            {
                return NotFound($"Country with ID {id} was not found");
            }

            return Ok(country);
        }
    }
}
