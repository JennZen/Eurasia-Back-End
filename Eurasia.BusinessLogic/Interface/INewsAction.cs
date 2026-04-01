using Eurasia.Domains.Models.News;

namespace Eurasia.BusinessLogic.Interface
{
    public interface INewsAction
    {
        public List<NewsMainInfoDto>? GetAllNews();
        public NewsMainInfoDto? GetById(int id);
        public bool Create(NewsMainInfoDto news);
        public bool Update(NewsMainInfoDto news);
        public bool Delete(int id);

    }
}
