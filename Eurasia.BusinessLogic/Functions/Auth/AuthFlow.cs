using Eurasia.BusinessLogic.Core.Auth;
using Eurasia.BusinessLogic.Interface;
using Eurasia.BusinessLogic.Services;
using Eurasia.Domains.Models.User;

namespace Eurasia.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthAction, IAuthAction
    {
        private readonly TokenService _tokenService = new TokenService();

        public UserLoginDto? Login(string email, string password)
        {
            var existingUser = base.Login(email, password);
            if (existingUser == null) return null;

            var token = _tokenService.GenerateToken(existingUser.Id, existingUser.Name, existingUser.Role);

            return new UserLoginDto
            {
                Email = existingUser.Email,
                Token = token
            };
        }

        public UserRegisterDto? Register(string name, string email, string password)
        {
            var user = base.Register(name, email, password);
            if (user == null) return null;

            var token = _tokenService.GenerateToken(user.Id, user.Name, "User");

            return new UserRegisterDto
            {
                Name = user.Name,
                Email = user.Email,
                Token = token
            };
        }
    }
}