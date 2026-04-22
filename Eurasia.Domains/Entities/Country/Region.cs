using Eurasia.Domains.Entities.Refs;

namespace Eurasia.Domains.Entities.Country
{
    public class Region
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}
