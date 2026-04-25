using Eurasia.Domains.Models.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eurasia.BusinessLogic.Interface
{
    public interface IBannerAction
    {
        public List<BannerDto> GetAll(int count);
        public BannerDto? GetById(int id);
    }
}
