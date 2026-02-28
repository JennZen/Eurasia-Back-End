using Eurasia.Domains.Entities.Refs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.City
{
    public class CityData : SharedFields
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
        public string Name {  get; set; }
        public int Population {  get; set; }
        public bool IsCapital { get; set; }

        public string CountryUuid { get; set; }
    }
}
