using Eurasia.Domains.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IAdminAction
    {
        AdminDashboardStatsDto GetDashboardStats();
        List<RecentActionDto> GetRecentActions(int take);
    }
}
