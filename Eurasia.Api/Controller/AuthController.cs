using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eurasia.Api.Controller
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        internal IAuthAction _auth;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var result = _auth.Login(dto.Email, dto.Password);

            if (result == null) return Unauthorized("Invalid email or password");
            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var result = _auth.Register(dto.Name, dto.Email, dto.Password);

            if (result == null) return BadRequest("User with this email already exists");
            return Ok(result);
        }
    }
}
