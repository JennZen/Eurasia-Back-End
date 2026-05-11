using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Quiz
{
    public class UpdateQuizResultDto
    {
        public int CountriesGuessed { get; set; }
        public int TimeSpentSeconds { get; set; }

        public int TotalCountries { get; set; }
    }
}
