using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Entities.Relations;

namespace Eurasia.Domains.Entities.Language
{
    public class Language : SharedFields
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}