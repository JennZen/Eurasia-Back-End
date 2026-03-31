using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;


namespace Eurasia.Domains.Entities.Country
{
    public class CountryData : SharedFields
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? FormalName { get; set; } 
        public string? FlagUrl { get; set; }
        public int Population { get; set; }
        public List<Continents>? Continents { get; set; }
        public string? Currency { get; set; }
        public List<string>? Regions { get; set; }
        public required string Capital { get; set; }
        public int GeographicalSize { get; set; }
        public List<CountryLanguage>? CountryLanguages { get; set; }
        public string? Summary { get; set; }
    }
}