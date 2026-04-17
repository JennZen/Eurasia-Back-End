using Eurasia.Domains.Entities.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Continent
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}
