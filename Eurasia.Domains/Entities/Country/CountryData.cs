using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public List<Continents>? Continents { get; set; }

        [MaxLength(50)]
        public string? Currency { get; set; }

        public List<string>? Regions { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Capital { get; set; }

        [Range(0, int.MaxValue)]
        public int GeographicalSize { get; set; }

        public List<CountryLanguage>? CountryLanguages { get; set; }

        [MaxLength(1000)]
        public string? Summary { get; set; }
    }
}