using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.News;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        internal INewsAction _news;
        public NewsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _news = bl.GetMainInfoNewsActions();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var allCountries = _news.GetAllNews();
            return Ok(allCountries);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _news.Delete(id);
            if (!success) return NotFound($"No news with {id} were found");

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            NewsMainInfoDto? news = _news.GetById(id);
            if (news == null)
            {
                return NotFound($"No news with {id} were found");
            }

            return Ok(news);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewsMainInfoDto newsDto)
        {
            if (newsDto == null) return BadRequest("Invalid data");

            bool success = _news.Create(newsDto);
            if (!success)
            {
                return Conflict(new { message = $"News with ID {newsDto.Id} already exist." });
            }

            return CreatedAtAction(nameof(GetById), new { id = newsDto.Id }, newsDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, NewsMainInfoDto newsDto)
        {
            newsDto.Id = id;
            bool success = _news.Update(newsDto);

            if (!success)
            {
                return NotFound($"Country with ID {id} not found");
            }

            return Ok(newsDto);
        }
    }
}
