using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.News;
using Eurasia.Domains.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Core.News
{
    public class NewsMainInfoAction: INewsAction
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
        public void Create(NewsData news)
        {
            _mockDb.Add(news);
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
        public void Delete(int id)
        {
            var existingNews = _mockDb.FirstOrDefault(c => c.Id == id);
            if (existingNews != null)
            {
                _mockDb.Remove(existingNews);
            }
        }
    }
}
