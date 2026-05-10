using Eurasia.BusinessLogic.Core.Attraction;
using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Core.User;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.User;
using Eurasia.Domains.Models.Attraction;
using Eurasia.Domains.Models.Country;
using Eurasia.Domains.Models.User;

namespace Eurasia.BusinessLogic.Functions.User
{
    public class UserFlow : UserAction, IUserAction
    {
        public List<UserDto> GetAll()
        {
            return base.GetUsers().Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                AvatarUrl = u.AvatarUrl,
                Phone = u.Phone,
                Role = u.Role
            }).ToList();
        }

        public UserDto? GetById(int id)
        {
            var u = base.GetUserById(id);
            if (u == null) return null;

            return new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                AvatarUrl = u.AvatarUrl,
                Phone = u.Phone,
                Role = u.Role
            };
        }
        public bool Update(int id, UserUpdateDto dto)
        {
            var user = base.GetUserById(id);
            if (user == null) return false;

            if (dto.Name != null) user.Name = dto.Name;
            if (dto.AvatarUrl != null) user.AvatarUrl = dto.AvatarUrl;
            if (dto.Phone != null) user.Phone = dto.Phone;

            return base.UpdateUser(user);
        }

        public bool Delete(int id)
        {
            return base.DeleteUser(id);
        }
        public List<CountryLikedCardDto> GetFavoriteCountries(int userId)
        {
            var ids = base.GetFavoriteCountryIds(userId);
            var countryAction = new CountryAction();
            return countryAction.GetCountryDatas()
                .Where(c => ids.Contains(c.Id))
                .Select(c => new CountryLikedCardDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    FlagUrl = c.FlagUrl,
                    Capital = c.Capital,
                    Population = c.Population,
                    GeographicalSize = c.GeographicalSize,
                    Region = c.Regions?.FirstOrDefault()?.Name
                }).ToList();
        }
        public List<AttractionLikedCardDto> GetFavoriteAttractionIds(int userId)
        {
            var ids = base.GetFavoriteAttractionIds(userId);
            var attractionAction = new AttractionAction();
            return attractionAction.GetAttractions()
                .Where(a => ids.Contains(a.Id))
                .Select(a => new AttractionLikedCardDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    City = a.City,
                    Rating = a.Rating,
                    Price = a.Price,
                    CountryName = a.Country?.Name
                }).ToList();
        }
    }
}
