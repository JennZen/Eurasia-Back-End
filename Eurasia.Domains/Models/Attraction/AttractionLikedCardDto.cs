using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Attraction
{
    public class AttractionLikedCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string City { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public string? CountryName { get; set; }
    }
}
