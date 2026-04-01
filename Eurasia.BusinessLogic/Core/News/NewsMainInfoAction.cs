using Eurasia.Domains.Entities.News;

namespace Eurasia.BusinessLogic.Core.News
{
    public class NewsMainInfoAction
    {
        private static List<NewsData> _mockDb =
        [
            new NewsData
            {    Id = 0,
                //ENUM CATEGORY public string Category { get; set; }
                Title = "MOLDOVA NEWS",
                Description = "News...",
                ImageUrl = string.Empty,
                PublishedAt = DateTime.MinValue
            }
        ];
        public List<NewsData>? GetAllNews()
        {
            return _mockDb;
        }
        public NewsData? GetById(int id)
        {
            return _mockDb.FirstOrDefault(c => c.Id == id);
        }
        public bool Create(NewsData news)
        {
            var existingNews = _mockDb.FirstOrDefault(c => c.Id == news.Id);
            if (existingNews == null)
            {
                _mockDb.Add(news);
                return true;
            }
            return false;
        }
        public bool Update(NewsData news)
        {
            var existingNewsIndex = _mockDb.FindIndex(c => c.Id == news.Id);
            if(existingNewsIndex != -1)
            {
                _mockDb[existingNewsIndex] = news;
                return true;
            }

            return false;
        }
        public bool Delete(int id)
        {
            var existingNews = _mockDb.FirstOrDefault(c => c.Id == id);
            if (existingNews != null)
            {
                _mockDb.Remove(existingNews);
                return true;
            }
            return false;
        }
    }
}
