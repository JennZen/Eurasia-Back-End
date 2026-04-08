using Eurasia.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IUserAction
    {
        List<UserDto> GetAll();
        UserDto? GetById(int id);
        UserDto? Register(UserRegisterDto dto);
        UserDto? Login(UserLoginDto dto);
        bool Update(int id, UserUpdateDto dto);
        bool Delete(int id);

        List<int> GetFavoriteCountryIds(int userId);
        bool AddFavoriteCountry(int userId, int countryId);
        bool RemoveFavoriteCountry(int userId, int countryId);
        List<int> GetFavoriteAttractionIds(int userId);
        bool AddFavoriteAttraction(int userId, int attractionId);
        bool RemoveFavoriteAttraction(int userId, int attractionId);
    }
}
