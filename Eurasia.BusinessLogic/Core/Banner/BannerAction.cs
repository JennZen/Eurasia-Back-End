using Eurasia.Domains.Entities.Country;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurasia.DataAccess.Context;


namespace Eurasia.BusinessLogic.Core.Banner
{
    public class BannerAction
    {
        private readonly CountryContext _db = new CountryContext();

        public List<CountryData> GetBanners(int count)
        {
            return _db.Countries
                .Include(c => c.Regions)
                .Take(count)
                .ToList();
        }

        public CountryData? GetById(int id)
        {
            return _db.Countries
                .Include(c => c.Regions)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
