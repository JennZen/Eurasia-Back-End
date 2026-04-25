using Eurasia.Domains.Entities.AttractionData;
using Eurasia.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Eurasia.Domains.Models.Attraction;


namespace Eurasia.BusinessLogic.Core.Attraction
{
    public class AttractionAction
    {
        private readonly AttractionContext _db = new AttractionContext();

        public List<AttractionData> GetAttractions()
        {
            return _db.Attractions
                .Include(a => a.Country)
                .ToList();
        }

        public AttractionMainInfoDto? GetById(int id)
        {
            var attraction = _db.Attractions
                .Include(a => a.Country)
                .FirstOrDefault(a => a.Id == id);

            if (attraction == null) return null;
            return new AttractionMainInfoDto
            {
                Id = attraction.Id,
                Name = attraction.Name,
                Description = attraction.Description,
                FullDescription = attraction.FullDescription,
                Price = attraction.Price,
                BGUrl = attraction.BGUrl,
                ImageUrl = attraction.ImageUrl,
                City = attraction.City,
                Duration = attraction.Duration,
                BestTimeToVisit = attraction.BestTimeToVisit,
                OpeningHours = attraction.OpeningHours,
                Rating = attraction.Rating,
                NumberOfReviews = attraction.NumberOfReviews,
                CountryId = attraction.CountryId,
                CountryName = attraction.Country?.Name
            };
        }

        public AttractionData? Create(AttractionData attraction)
        {
            var existing = _db.Attractions
                .FirstOrDefault(a => a.Name == attraction.Name && a.CountryId == attraction.CountryId);

            if (existing != null)
                return null;

            _db.Attractions.Add(attraction);
            _db.SaveChanges();
            return attraction;
        }

        public bool Update(AttractionData attraction)
        {
            var existingAttraction = _db.Attractions.FirstOrDefault(a => a.Id == attraction.Id);
            if (existingAttraction != null)
            {
                existingAttraction.Name = attraction.Name;
                existingAttraction.Description = attraction.Description;
                existingAttraction.FullDescription = attraction.FullDescription;
                existingAttraction.Price = attraction.Price;
                existingAttraction.BGUrl = attraction.BGUrl;
                existingAttraction.ImageUrl = attraction.ImageUrl;
                existingAttraction.City = attraction.City;
                existingAttraction.Duration = attraction.Duration;
                existingAttraction.BestTimeToVisit = attraction.BestTimeToVisit;
                existingAttraction.OpeningHours = attraction.OpeningHours;
                existingAttraction.Rating = attraction.Rating;
                existingAttraction.NumberOfReviews = attraction.NumberOfReviews;
                existingAttraction.CountryId = attraction.CountryId;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = _db.Attractions.FirstOrDefault(a => a.Id == id);
            if (existing != null)
            {
                _db.Attractions.Remove(existing);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}