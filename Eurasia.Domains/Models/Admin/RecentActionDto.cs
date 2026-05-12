using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Admin
{
    public class RecentActionDto
    {
        public string Type { get; set; } = "edit";
        public string Model { get; set; } = "";
        public int EntityId { get; set; }
        public string? Label { get; set; }
        public DateTime At { get; set; }
    }
}

