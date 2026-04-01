
namespace Eurasia.Domains.Models.News
{
    public class NewsMainInfoDto
    {
        public int Id { get; set; }

        //ENUM CATEGORY public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
