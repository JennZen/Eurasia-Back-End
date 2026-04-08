using Eurasia.Domains.Entities.User;
using Eurasia.Domains.Entities.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Relations
{
    public class UserFavoriteAttraction
    {
        public int UserId { get; set; }
        public int AttractionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
