using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eurasia.Domains.Entities.Refs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.User
{
    public class UserData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; }

        [StringLength(500)]
        public string? AvatarUrl { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
