using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        internal IUserAction _users;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _users = bl.GetUserActions();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_users.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _users.GetById(id);
            if (user == null) return NotFound($"User with ID {id} not found");
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var user = _users.Register(dto);
            if (user == null) return Conflict(new { message = "User with this email already exists." });

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var user = _users.Login(dto);
            if (user == null) return Unauthorized(new { message = "Invalid email or password." });

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            bool success = _users.Update(id, dto);
            if (!success) return NotFound($"User with ID {id} not found");

            return Ok(_users.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _users.Delete(id);
            if (!success) return NotFound($"User with ID {id} not found");
            return NoContent();
        }

        [HttpGet("{id}/favorites/countries")]
        public IActionResult GetFavoriteCountries(int id)
        {
            return Ok(_users.GetFavoriteCountryIds(id));
        }

        [HttpPost("{id}/favorites/countries/{countryId}")]
        public IActionResult AddFavoriteCountry(int id, int countryId)
        {
            bool success = _users.AddFavoriteCountry(id, countryId);
            if (!success) return Conflict(new { message = "Already in favorites or user not found." });
            return Ok(new { message = "Country added to favorites." });
        }

        [HttpDelete("{id}/favorites/countries/{countryId}")]
        public IActionResult RemoveFavoriteCountry(int id, int countryId)
        {
            bool success = _users.RemoveFavoriteCountry(id, countryId);
            if (!success) return NotFound("Favorite not found.");
            return NoContent();
        }

        [HttpGet("{id}/favorites/attractions")]
        public IActionResult GetFavoriteAttractions(int id)
        {
            return Ok(_users.GetFavoriteAttractionIds(id));
        }

        [HttpPost("{id}/favorites/attractions/{attractionId}")]
        public IActionResult AddFavoriteAttraction(int id, int attractionId)
        {
            bool success = _users.AddFavoriteAttraction(id, attractionId);
            if (!success) return Conflict(new { message = "Already in favorites or user not found." });
            return Ok(new { message = "Attraction added to favorites." });
        }

        [HttpDelete("{id}/favorites/attractions/{attractionId}")]
        public IActionResult RemoveFavoriteAttraction(int id, int attractionId)
        {
            bool success = _users.RemoveFavoriteAttraction(id, attractionId);
            if (!success) return NotFound("Favorite not found.");
            return NoContent();
        }
    }
}
