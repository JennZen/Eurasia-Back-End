using Eurasia.Domains.Entities.City;
using Eurasia.Domains.Entities.Refs;
using Eurasia.Domains.Enums.Eurasia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Country
{
    public class CountryData: SharedFields
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string FormalName { get; set; }
        public string FlagUrl { get; set; }
        public int Population { get; set; }
        public List<Continents>? Continents { get; set; }
        //public List<CityData>? Cities { get; set; }
        public string Summary { get; set; }
        public DescriptionData Description { get; set; }
    }
}
