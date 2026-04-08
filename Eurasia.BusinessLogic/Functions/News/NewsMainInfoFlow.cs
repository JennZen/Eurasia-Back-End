using Eurasia.BusinessLogic.Core.News;
using Eurasia.Domains.Entities.News;
using Eurasia.Domains.Models.News;
using Eurasia.BusinessLogic.Interface;

namespace Eurasia.BusinessLogic.Functions.News
{
    public class NewsMainInfoFlow : NewsMainInfoAction, INewsAction
    {
        public List<NewsMainInfoDto>? GetAllNews()
        {
            var newsList = base.GetAllNews();

            return newsList?.Select(news => new NewsMainInfoDto
            {
                Id = news.Id,
                Title = news.Title,
                Description = news.Description,
                ImageUrl = news.ImageUrl,
                PublishedAt = news.PublishedAt
            }).ToList();
        }
        public NewsMainInfoDto? GetById(int id)
        {
            var news = base.GetById(id);

            if (news == null) return null;

            return new NewsMainInfoDto
            {
                Id = news.Id,
                Title = news.Title,
                Description = news.Description,
                ImageUrl = news.ImageUrl,
                PublishedAt = news.PublishedAt
            };
        }
        public bool Create(NewsMainInfoDto newsDto)
        {
            var news = new NewsData
            {
                Id = newsDto.Id,
                Title = newsDto.Title,
                Description = newsDto.Description,
                ImageUrl = newsDto.ImageUrl,
                PublishedAt = newsDto.PublishedAt
            };

            return base.Create(news);
        }
        public bool Update(NewsMainInfoDto newsDto)
        {
            var existingNews = base.GetById(newsDto.Id);
            if (existingNews == null) return false;

            existingNews.Title = newsDto.Title;
            existingNews.Description = newsDto.Description;
            existingNews.ImageUrl = newsDto.ImageUrl;
            existingNews.PublishedAt = newsDto.PublishedAt;
            return base.Update(existingNews);
        }
        public bool Delete(int id)
        {
            return base.Delete(id);
        }
    }
}