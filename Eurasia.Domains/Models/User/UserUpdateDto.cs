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
        public string? Name { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Phone { get; set; }
    }
}
