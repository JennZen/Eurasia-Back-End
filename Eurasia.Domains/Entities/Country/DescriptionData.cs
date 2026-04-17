using Eurasia.Domains.Entities.Refs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Entities.Country
{
    public class DescriptionData: SharedFields
    {
        public int Id { get; set; }

        public string Content {  get; set; }

        public string BGUrl { get; set; }
    }
}
