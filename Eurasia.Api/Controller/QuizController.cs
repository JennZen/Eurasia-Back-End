using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.Quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Eurasia.Api.Controller
{
    [Route("api/quiz")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {
        internal IQuizAction _quiz;

        public QuizController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _quiz = bl.GetQuizActions();
        }

        [HttpGet("record/{userId}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetUserBestRecord(int userId)
        {
            var record = _quiz.GetUserBestRecord(userId);
            if (record == null) return NotFound($"No quiz record for user {userId} was found");

            return Ok(record);
        }

        [SwaggerBearer]
        [HttpPut("result")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult UpdateQuizResult([FromBody] UpdateQuizResultDto resultDto)
        {
            if (resultDto == null) return BadRequest("Invalid data");

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            bool success = _quiz.UpdateQuizResult(currentUserId, resultDto);

            return Ok(_quiz.GetUserBestRecord(currentUserId));
        }
    }
}
