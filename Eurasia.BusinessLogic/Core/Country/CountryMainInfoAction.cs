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
        private static List<CountryData> _mockDb = new List<CountryData>
            {
                new CountryData
                {
                    Id = 38,
                    Name = "Молдова",
                    FormalName = "Республика Молдова",
                    FlagUrl = "флаг МД",
                    Population = 12,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Currency = "Молдавский лей",
                    Regions = new List<string> { "Восточная Европа"},
                    Capital = "Кишинёв",
                    GeographicalSize = 33846,
                    Languages = new List<string> { "Румынский" }
                },
                new CountryData
                {
                    Id = 3,
                    Name = "Франция",
                    FormalName = "Французская Республика",
                    FlagUrl = "флаг ФР",
                    Population = 14,
                    Continents = new List<Continents> { Continents.Europe },
                    Currency = "Евро",
                    Regions = new List<string> { "Западная Европа" },
                    Capital = "Париж",
                    GeographicalSize = 643801,
                    Languages = new List<string> { "Французский" }
                },
                new CountryData
                {
                    Id = 55,
                    Name = "Турция",
                    FormalName = "Турецкая Республика",
                    FlagUrl = "флаг Турции",
                    Population = 16,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Currency = "Турецкая лира",
                    Regions = new List<string> { "Юго-Восточная Европа", "Западная Азия" },
                    Capital = "Анкара",
                    GeographicalSize = 783562,
                    Languages = new List<string> { "Турецкий" }
                }
            };


        public List<CountryData> GetCountryDatas(List<Continents> filterContinents)
        {
            return _mockDb.Where(country => country.Continents.Any(c => filterContinents.Contains(c))).ToList();
        }

        public void Create(CountryData country)
        {
            _mockDb.Add(country);
        }

        public CountryData? GetById(int id)
        {
            return _mockDb.FirstOrDefault(c => c.Id == id);
        }
        public bool Update(CountryData country)
        {
            var existingCountryIndex = _mockDb.FindIndex(c => c.Id == country.Id);
            if (existingCountryIndex != -1)
            {
                _mockDb[existingCountryIndex] = country;
                return true;
            }

            return false;
        }
        public void Delete(int id)
        {
            var existingCountry = _mockDb.FirstOrDefault(c => c.Id == id);
            if (existingCountry != null)
            {
                _mockDb.Remove(existingCountry);
            }
        }
    }
}
