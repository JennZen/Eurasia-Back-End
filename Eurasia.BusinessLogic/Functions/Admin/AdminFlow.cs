using Eurasia.BusinessLogic.Core.Admin;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.Admin;

namespace Eurasia.BusinessLogic.Functions.Admin
{
    public class AdminFlow : AdminAction, IAdminAction
    {
        public AdminDashboardStatsDto GetDashboardStats()
        {
            return new AdminDashboardStatsDto
            {
                Countries = base.CountCountries(),
                Attractions = base.CountAttractions(),
                News = base.CountNews(),
                Users = base.CountUsers()
            };
        }

        public List<RecentActionDto> GetRecentActions(int take)
        {
            var clamped = Math.Clamp(take, 1, 5);
            return base.CollectRecentActions(clamped);
        }
    }
}
