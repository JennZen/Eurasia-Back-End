using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Attraction
{
    public class AttractionCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string OpeningHours { get; set; }
        public double Rating { get; set; }
        public int NumberOfReviews { get; set; }
        public string CountryName { get; set; }
    }
}
