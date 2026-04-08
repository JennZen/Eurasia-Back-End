using Eurasia.BusinessLogic.Core.Attraction;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.AttractionData;
using Eurasia.Domains.Models.Attraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Functions.Attraction
{
    public class AttractionFlow : AttractionAction, IAttractionAction
    {
        public List<AttractionDto> GetAll()
        {
            var attractions = base.GetAttractions();
            return attractions.Select(a => new AttractionDto
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

        public AttractionDto? GetById(int id)
        {
            var attraction = base.GetById(id);
            if (attraction == null) return null;

            return attraction;
        }

        public bool Create(AttractionDto dto)
        {
            var attraction = new AttractionData
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
            return base.Create(attraction);
        }

        public bool Update(AttractionDto dto)
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
    }
}