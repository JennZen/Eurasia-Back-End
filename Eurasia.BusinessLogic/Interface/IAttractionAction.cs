using Eurasia.Domains.Models.Attraction;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IAttractionAction
    {
        List<AttractionMainInfoDto> GetAll();
        AttractionMainInfoDto? GetById(int id);
        bool Create(AttractionMainInfoDto attraction);
        bool Update(AttractionMainInfoDto attraction);
        bool Delete(int id);
        List<AttractionCardDto> GetAllCards();
    }
}
