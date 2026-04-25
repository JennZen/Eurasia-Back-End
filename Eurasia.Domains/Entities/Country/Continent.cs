using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Country
{
    public class Continent
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}
