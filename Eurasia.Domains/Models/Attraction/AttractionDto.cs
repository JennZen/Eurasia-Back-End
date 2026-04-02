using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Attraction
{
    public class AttractionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? FullDescription { get; set; }
        public decimal Price { get; set; }
        public string? BGUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string? City { get; set; }
        public string? Duration { get; set; }
        public string? BestTimeToVisit { get; set; }
        public string? OpeningHours { get; set; }
        public double Rating { get; set; }
        public int NumberOfReviews { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}