using Eurasia.Domains.Models.User;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IAuthAction
    {
        public UserLoginDto? Login(string email, string password);
        public UserRegisterDto? Register(string name, string email, string password);
    }
}
