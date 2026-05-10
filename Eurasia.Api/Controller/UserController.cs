using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        internal IUserAction _users;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _users = bl.GetUserActions();
        }

        [HttpGet]
        [Authorize(Roles =  "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_users.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var user = _users.GetById(id);
            if (user == null) return NotFound($"User with ID {id} not found");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var currentUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            if (currentUserId != id && !User.IsInRole("Admin"))
            {
                return StatusCode(403, "You can only edit your own profile");
            }

            bool success = _users.Update(id, dto);
            if (!success) return NotFound($"User with ID {id} not found");

            return Ok(_users.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            bool success = _users.Delete(id);
            if (!success) return NotFound($"User with ID {id} not found");
            return NoContent();
        }

        [HttpGet("{id}/favorites/countries")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetFavoriteCountries(int id)
        {
            return Ok(_users.GetFavoriteCountries(id));
        }

        [HttpPost("{id}/favorites/countries/{countryId}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult AddFavoriteCountry(int id, int countryId)
        {
            bool success = _users.AddFavoriteCountry(id, countryId);
            if (!success) return Conflict(new { message = "Already in favorites or user not found." });
            return Ok(new { message = "Country added to favorites." });
        }

        [HttpDelete("{id}/favorites/countries/{countryId}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult RemoveFavoriteCountry(int id, int countryId)
        {
            bool success = _users.RemoveFavoriteCountry(id, countryId);
            if (!success) return NotFound("Favorite not found.");
            return NoContent();
        }

        [HttpGet("{id}/favorites/attractions")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetFavoriteAttractions(int id)
        {
            return Ok(_users.GetFavoriteAttractionIds(id));
        }

        [HttpPost("{id}/favorites/attractions/{attractionId}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult AddFavoriteAttraction(int id, int attractionId)
        {
            bool success = _users.AddFavoriteAttraction(id, attractionId);
            if (!success) return Conflict(new { message = "Already in favorites or user not found." });
            return Ok(new { message = "Attraction added to favorites." });
        }

        [HttpDelete("{id}/favorites/attractions/{attractionId}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult RemoveFavoriteAttraction(int id, int attractionId)
        {
            bool success = _users.RemoveFavoriteAttraction(id, attractionId);
            if (!success) return NotFound("Favorite not found.");
            return NoContent();
        }
    }
}
