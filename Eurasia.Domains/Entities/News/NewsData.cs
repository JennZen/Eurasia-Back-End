using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurasia.Domains.Entities.Refs;

namespace Eurasia.Domains.Entities.News
{
    public class NewsData: SharedFields
    {
        public int Id { get; set; }

        //ENUM CATEGORY public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
