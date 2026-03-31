using Eurasia.Domains.Enums.Eurasia;

namespace Eurasia.Domains.Models.Country
{
    public class CountryMainInfoDto
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
        public List<string>? Languages { get; set; }
    }
}
