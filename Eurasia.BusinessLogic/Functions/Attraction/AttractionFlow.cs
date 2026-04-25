using Eurasia.BusinessLogic.Core.Attraction;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.AttractionData;
using Eurasia.Domains.Models.Attraction;

namespace Eurasia.BusinessLogic.Functions.Attraction
{
    public class AttractionFlow : AttractionAction, IAttractionAction
    {
        public List<AttractionMainInfoDto> GetAll()
        {
            var attractions = base.GetAttractions();
            return attractions.Select(a => new AttractionMainInfoDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                FullDescription = a.FullDescription,
                Price = a.Price,
                BGUrl = a.BGUrl,
                ImageUrl = a.ImageUrl,
                City = a.City,
                Duration = a.Duration,
                BestTimeToVisit = a.BestTimeToVisit,
                OpeningHours = a.OpeningHours,
                Rating = a.Rating,
                NumberOfReviews = a.NumberOfReviews,
                CountryId = a.CountryId,
                CountryName = a.Country?.Name
            }).ToList();
        }

        public AttractionMainInfoDto? GetById(int id)
        {
            var attraction = base.GetById(id);
            if (attraction == null) return null;

            return attraction;
        }

        public bool Create(AttractionMainInfoDto dto)
        {
            var attraction = new AttractionData
            {
                Name = dto.Name,
                Description = dto.Description,
                FullDescription = dto.FullDescription ?? string.Empty,
                Price = dto.Price,
                BGUrl = dto.BGUrl ?? string.Empty,
                ImageUrl = dto.ImageUrl ?? string.Empty,
                City = dto.City ?? string.Empty,
                Duration = dto.Duration ?? string.Empty,
                BestTimeToVisit = dto.BestTimeToVisit ?? string.Empty,
                OpeningHours = dto.OpeningHours ?? string.Empty,
                Rating = dto.Rating,
                NumberOfReviews = dto.NumberOfReviews,
                CountryId = dto.CountryId
            };

            var created = base.Create(attraction);
            if (created == null) return false;

            dto.Id = created.Id;
            return true;
        }

        public bool Update(AttractionMainInfoDto dto)
        {
            var existing = base.GetById(dto.Id);

            if (existing == null) return false;
            var attractionToUpdate = new AttractionData
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                FullDescription = dto.FullDescription,
                Price = dto.Price,
                BGUrl = dto.BGUrl,
                ImageUrl = dto.ImageUrl,
                City = dto.City,
                Duration = dto.Duration,
                BestTimeToVisit = dto.BestTimeToVisit,
                OpeningHours = dto.OpeningHours,
                Rating = dto.Rating,
                NumberOfReviews = dto.NumberOfReviews,
                CountryId = dto.CountryId
            };

            return base.Update(attractionToUpdate);
        }

        public bool Delete(int id)
        {
            return base.Delete(id);
        }
        public List<AttractionCardDto> GetAllCards()
        {
            var attractions = base.GetAttractions();

            return attractions.Select(a => new AttractionCardDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                OpeningHours = a.OpeningHours,
                Rating = (double)a.Rating,
                NumberOfReviews = a.NumberOfReviews,
                CountryName = a.Country != null ? a.Country.Name : null
            }).ToList();
        }
    }
}