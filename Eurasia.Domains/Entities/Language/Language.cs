using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Entities.Relations;

namespace Eurasia.Domains.Entities.Language
{
    public class Language : SharedFields
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
