using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Admin
{
    public class AdminDashboardStatsDto
    {
        public int Countries { get; set; }
        public int Attractions { get; set; }
        public int News { get; set; }
        public int Users { get; set; }
    }
}

