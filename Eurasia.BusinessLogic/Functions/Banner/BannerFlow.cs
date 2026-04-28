using Eurasia.BusinessLogic.Core.Banner;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Models.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Functions.Banner
{
    public class BannerFlow : BannerAction, IBannerAction
    {
        public List<BannerDto> GetAll(int count)
        {
            return base.GetBanners(count).Select(c => new BannerDto
            {
                Id = c.Id,
                Title = c.Name,
                ImageUrl = c.FlagUrl,
                Population = c.Population.ToString(),
                Territory = $"{c.GeographicalSize}",
                Capital = c.Capital
            }).ToList();
        }

        public BannerDto? GetById(int id)
        {
            var c = base.GetById(id);
            if (c == null) return null;

            return new BannerDto
            {
                Id = c.Id,
                Title = c.Name,
                ImageUrl = c.FlagUrl,
                Population = c.Population.ToString(),
                Territory = $"{c.GeographicalSize}",
                Capital = c.Capital
            };
        }
    }
}
