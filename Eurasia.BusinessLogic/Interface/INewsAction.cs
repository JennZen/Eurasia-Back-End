using Eurasia.Domains.Entities.News;
using Eurasia.Domains.Models.Country;
using Eurasia.Domains.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Interface
{
    public interface INewsAction
    {
        public NewsData? GetById(int id);
        public void Create(NewsData news);
        public bool Update(NewsData country);
        public void Delete(int id);

    }
}
