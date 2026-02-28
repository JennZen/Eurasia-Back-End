using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Eurasia.BusinessLogic.Core.Country
{
    public class CountryMainInfoAction
    {
        public List<CountryMainInfoDto> GetCountryMainInfoDtos(List<Continents> filterContinents)
        {
            List<CountryMainInfoDto> mockData = new List<CountryMainInfoDto>
            {
                new CountryMainInfoDto
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Молдова",
                    FlagUrl = "флаг МД",
                    Population = 12,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Summary = "Ещё лучше"
                },
                new CountryMainInfoDto
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Франция",
                    FlagUrl = "флаг ФР",
                    Population = 14,
                    Continents = new List<Continents> { Continents.Europe },
                    Summary = "Хорошо"
                },
                new CountryMainInfoDto
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Турция",
                    FlagUrl = "флаг Турции",
                    Population = 16,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Summary = "Лучше"
                }
            };


            return mockData.Where(country => country.Continents.Any(c => filterContinents.Contains(c))).ToList();
        }
    }
}
