using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eurasia.Domains.Entities.Country
{
    public class Region
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}
