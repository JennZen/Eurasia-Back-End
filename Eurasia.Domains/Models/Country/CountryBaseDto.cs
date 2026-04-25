using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurasia.Domains.Entities.Country;

namespace Eurasia.Domains.Models.Country
{
    public class CountryBaseDto
    {
        public required string Name { get; set; }
        public string? FormalName { get; set; }
        public string? FlagUrl { get; set; }
        public int Population { get; set; }

        public List<string>? Continents { get; set; }  
        public string? Currency { get; set; }

        public List<string>? Regions { get; set; }   
        public required string Capital { get; set; }
        public int GeographicalSize { get; set; }

        public List<string>? Languages { get; set; }  
    }
}
