using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eurasia.Domains.Entities.Relations
{
    public class EurasiaQuizResult : SharedFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserData User { get; set; } = null!;

        public int CountriesGuessed { get; set; }

        public int TotalCountriesCount { get; set; }

        public int TimeSpentSeconds { get; set; }

    }
}