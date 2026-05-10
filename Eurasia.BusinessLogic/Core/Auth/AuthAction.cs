using Eurasia.BusinessLogic.Core.User;
using Eurasia.DataAccess.Context;
using Eurasia.Domains.Entities.User;

namespace Eurasia.BusinessLogic.Core.Auth
{
    public class AuthAction : UserAction
    {
        public UserData? Login(string email, string password)
        {
            var existingUser = GetUserByEmail(email);

            if(existingUser == null)
            {
                return null;
            }

            if (!VerifyPassword(password, existingUser.PasswordHash))
            {
                return null;
            }

            return existingUser;
        }

        public UserData? Register(string name, string email, string password)
        {
            var existingUser = GetUserByEmail(email);

            if (existingUser != null)
            {
                return null;
            }

            var newUser = new UserData
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (!CreateUser(newUser))
            {
                return null;
            }

            return newUser;
        }
    }
}