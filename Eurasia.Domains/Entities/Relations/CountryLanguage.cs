using Eurasia.Domains.Entities.Country;
using System.ComponentModel.DataAnnotations;

namespace Eurasia.Domains.Entities.Relations
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public CountryData Country { get; set; }
        public int LanguageId { get; set; }
        public required Language Language { get; set; }
    }
}