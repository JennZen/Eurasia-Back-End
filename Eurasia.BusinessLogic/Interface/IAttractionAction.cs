using Eurasia.Domains.Models.Attraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IAttractionAction
    {
        List<AttractionDto> GetAll();
        AttractionDto? GetById(int id);
        bool Create(AttractionDto attraction);
        bool Update(AttractionDto attraction);
        bool Delete(int id);
    }
}
