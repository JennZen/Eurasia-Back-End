using Eurasia.Domains.Entities.AttractionData;

using Eurasia.DataAccess.Context;


namespace Eurasia.BusinessLogic.Core.Attraction
{
    public class AttractionAction
    {
        private readonly AttractionContext _db = new AttractionContext();
        
        public List<AttractionData> GetAttractions()
        {
            return _db.Attractions.ToList();
        }

        public AttractionData? GetById(int id)
        {
            return _db.Attractions.FirstOrDefault(a => a.Id == id);
        }

        public bool Create(AttractionData attraction)
        {
            var existing = _db.Attractions.FirstOrDefault(a => a.Id == attraction.Id);

            if (existing == null)
            {
                _db.Attractions.Add(attraction);
                _db.SaveChanges();
                return true;
            }
            return false;
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
                existingAttraction.Country = attraction.Country;
                existingAttraction.CountryName = attraction.CountryName;
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
