using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurasia.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eurasia.Domains.Entities.News
{
    public class NewsData: SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //ENUM CATEGORY public string Category { get; set; }
        [Required]
        [StringLength(100)]  
        public required string Title { get; set; }
        [Required]
        [StringLength(500)]
        public required string Description { get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishedAt { get; set; }
    }
}
