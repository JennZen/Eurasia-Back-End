using Eurasia.BusinessLogic;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
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

        [HttpGet]
        public IActionResult Get([FromQuery] List<int>? continentIds)
        {
            var allCountries = _countries.GetAllCountriesMainInfoDtos(continentIds);
            return Ok(allCountries);
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            var countriesList = _countries.GetCountriesList();
            
            return Ok(countriesList);
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
        public IActionResult Create([FromBody] CreateCountryDto country)
        {
            if (country == null) return BadRequest("Invalid data");

            var created = _countries.Create(country);
            if (created == null)
            {
                return Conflict(new { message = "Country already exists." });
            }

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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
