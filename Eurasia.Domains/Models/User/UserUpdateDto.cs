using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.User
{
    public class UserUpdateDto
    {
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? AvatarUrl { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
