using Eurasia.DataAccess.Context;
using Eurasia.Domains.Entities.News;

namespace Eurasia.BusinessLogic.Core.News
{
    public class NewsAction
    {
        private readonly NewsContext _db = new NewsContext();
        public List<NewsData>? GetAllNews()
        {
            return _db.News.ToList();
        }
        public NewsData? GetById(int id)
        {
            return _db.News.FirstOrDefault(c => c.Id == id);
        }
        public bool Create(NewsData news)
        {
            var existingNews = _db.News.FirstOrDefault(c => c.Id == news.Id);
            if (existingNews == null)
            {
                _db.News.Add(news);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(NewsData news)
        {
            var existing = _db.News.FirstOrDefault(c => c.Id == news.Id);
            if (existing != null)
            {
                existing.Title = news.Title;
                existing.Description = news.Description;
                existing.ImageUrl = news.ImageUrl;
                existing.PublishedAt = news.PublishedAt;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var existingNews = _db.News.FirstOrDefault(c => c.Id == id);
            if (existingNews != null)
            {
                _db.News.Remove(existingNews);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}