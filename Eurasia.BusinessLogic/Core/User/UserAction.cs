using Eurasia.DataAccess.Context;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Entities.User;
using System.Security.Cryptography;
using System.Text;


namespace Eurasia.BusinessLogic.Core.User
{
    public class UserAction
    {
        private readonly UserContext _db = new UserContext();

        protected static string HashPassword(string password)
        {
            // It will need to be converted to symmetric encryption as we were taught in TSI
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public List<UserData> GetUsers()
        {
            return _db.Users.ToList();
        }

        public UserData? GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserData? GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool CreateUser(UserData user)
        {
            var existing = _db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existing != null) return false;

            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateUser(UserData user)
        {
            var existing = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existing == null) return false;

            existing.Name = user.Name;
            existing.AvatarUrl = user.AvatarUrl;
            existing.Phone = user.Phone;
            existing.UpdatedAt = DateTime.UtcNow;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var existing = _db.Users.FirstOrDefault(u => u.Id == id);
            if (existing == null) return false;

            _db.Users.Remove(existing);
            _db.SaveChanges();
            return true;
        }

        public List<int> GetFavoriteCountryIds(int userId)
        {
            return _db.UserFavoriteCountries
                .Where(f => f.UserId == userId)
                .Select(f => f.CountryId)
                .ToList();
        }

        public bool AddFavoriteCountry(int userId, int countryId)
        {
            var exists = _db.UserFavoriteCountries
                .Any(f => f.UserId == userId && f.CountryId == countryId);
            if (exists) return false;

            _db.UserFavoriteCountries.Add(new UserFavoriteCountry
            {
                UserId = userId,
                CountryId = countryId,
                CreatedAt = DateTime.UtcNow
            });
            _db.SaveChanges();
            return true;
        }

        public bool RemoveFavoriteCountry(int userId, int countryId)
        {
            var fav = _db.UserFavoriteCountries
                .FirstOrDefault(f => f.UserId == userId && f.CountryId == countryId);
            if (fav == null) return false;

            _db.UserFavoriteCountries.Remove(fav);
            _db.SaveChanges();
            return true;
        }

        public List<int> GetFavoriteAttractionIds(int userId)
        {
            return _db.UserFavoriteAttractions
                .Where(f => f.UserId == userId)
                .Select(f => f.AttractionId)
                .ToList();
        }

        public bool AddFavoriteAttraction(int userId, int attractionId)
        {
            var exists = _db.UserFavoriteAttractions
                .Any(f => f.UserId == userId && f.AttractionId == attractionId);
            if (exists) return false;

            _db.UserFavoriteAttractions.Add(new UserFavoriteAttraction
            {
                UserId = userId,
                AttractionId = attractionId,
                CreatedAt = DateTime.UtcNow
            });
            _db.SaveChanges();
            return true;
        }

        public bool RemoveFavoriteAttraction(int userId, int attractionId)
        {
            var fav = _db.UserFavoriteAttractions
                .FirstOrDefault(f => f.UserId == userId && f.AttractionId == attractionId);
            if (fav == null) return false;

            _db.UserFavoriteAttractions.Remove(fav);
            _db.SaveChanges();
            return true;
        }
    }
}
