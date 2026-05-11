using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.Domains.Models.Quiz
{
    public class UserQuizRecordDto
    {
        public int MaxCountriesGuessed { get; set; }
        public int BestTimeSeconds { get; set; }
    }
}