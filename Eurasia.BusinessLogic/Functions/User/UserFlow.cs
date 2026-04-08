using Eurasia.BusinessLogic.Core.User;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.User;
using Eurasia.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Phone = u.Phone
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
                Phone = u.Phone
            };
        }

        public UserDto? Register(UserRegisterDto dto)
        {
            var existing = base.GetUserByEmail(dto.Email);
            if (existing != null) return null;

            var user = new UserData
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            bool created = base.CreateUser(user);
            if (!created) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Phone = user.Phone
            };
        }

        public UserDto? Login(UserLoginDto dto)
        {
            var user = base.GetUserByEmail(dto.Email);
            if (user == null) return null;

            var hash = HashPassword(dto.Password);
            if (user.PasswordHash != hash) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Phone = user.Phone
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
    }
}
