using Eurasia.Domains.Enums.Eurasia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Country
{
    public class CountryMainInfoDto
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string FlagUrl { get; set; }
        public int Population { get; set; }
        public List<Continents>? Continents { get; set; }
        public string Summary { get; set; }
    }
}
