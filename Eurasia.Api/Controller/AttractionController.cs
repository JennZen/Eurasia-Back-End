using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.Attraction;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/attractions")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        internal IAttractionAction _attractions;

        public AttractionController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _attractions = bl.GetAttractionActions();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var attractions = _attractions.GetAll();
            return Ok(attractions);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var attraction = _attractions.GetById(id);
            if (attraction == null)
                return NotFound($"Attraction with ID {id} not found");

            return Ok(attraction);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttractionDto attraction)
        {
            if (attraction == null) return BadRequest("Invalid data");

            bool success = _attractions.Create(attraction);
            if (!success)
                return Conflict(new { message = $"Attraction with ID {attraction.Id} already exists." });

            return CreatedAtAction(nameof(GetById), new { id = attraction.Id }, attraction);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AttractionDto attraction)
        {
            attraction.Id = id;
            bool success = _attractions.Update(attraction);
            if (!success)
                return NotFound($"Attraction with ID {id} not found");

            return Ok(attraction);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _attractions.Delete(id);
            if (!success)
                return NotFound($"Attraction with ID {id} not found");

            return NoContent();
        }
    }
}
