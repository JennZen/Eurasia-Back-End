using Eurasia.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using Eurasia.Domains.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;
using Eurasia.Domains.Entities.Region;
using Eurasia.Domains.Entities.Continent;

namespace Eurasia.Domains.Entities.Country
{
    [Table("Countries")]
    public class CountryData : SharedFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(150)]
        public string? FormalName { get; set; }

        [Url]
        public string? FlagUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int Population { get; set; }
        public ICollection<Continent.Continent> Continents { get; set; } = new List<Continent.Continent>();

        [MaxLength(50)]
        public string? Currency { get; set; }

        public ICollection<Region.Region> Regions { get; set; } = new List<Region.Region>();

        [Required]
        [MaxLength(100)]
        public required string Capital { get; set; }

        [Range(0, int.MaxValue)]
        public int GeographicalSize { get; set; }

        public ICollection<Language.Language> Languages { get; set; } = new List<Language.Language>();

        [MaxLength(1000)]
        public string? Summary { get; set; }
    }
}