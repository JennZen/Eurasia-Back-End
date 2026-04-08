using Eurasia.Domains.Entities;
using Eurasia.Domains.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Relations
{
    public class UserFavoriteCountry
    {
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
