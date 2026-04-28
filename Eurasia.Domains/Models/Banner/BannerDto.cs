using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Banner
{
    public class BannerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Population { get; set; }
        public string? Territory { get; set; }
        public string? Capital { get; set; }
    }
}
