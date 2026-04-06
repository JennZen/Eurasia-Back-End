using Eurasia.Domains.Entities.Country;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eurasia.Domains.Entities.AttractionData
{
    public class AttractionData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string FullDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string BGUrl { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(50), MaxLength(50)]
        public string City { get; set; }

        [StringLength(20), MaxLength(20)]
        public string Duration { get; set; }

        [StringLength(20), MaxLength(20)]
        public string BestTimeToVisit { get; set; }

        [StringLength(20), MaxLength(20)]
        public string OpeningHours { get; set; }

        [Range(0.0, 5.0)]
        public double Rating { get; set; }

        public int NumberOfReviews { get; set; }

        [StringLength(50), MaxLength(50)]
        public string CountryName { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryData Country { get; set; }
    }
}