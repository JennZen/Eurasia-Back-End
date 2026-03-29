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
        public int Id { get; set; }
        public string Name { get; set; }
        public string FormalName { get; set; }
        public string FlagUrl { get; set; }
        public int Population { get; set; }
        public List<Continents>? Continents { get; set; }
        public string Currency { get; set; }
        public List<string>? Regions { get; set; }
        public string Capital { get; set; }
        public int GeographicalSize { get; set; }
        public List<string>? Languages { get; set; }
    }
}
