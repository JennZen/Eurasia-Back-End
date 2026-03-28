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
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Молдова",
                    FormalName = "Республика Молдова",
                    FlagUrl = "флаг МД",
                    Population = 12,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Summary = "Ещё лучше"
                },
                new CountryData
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Франция",
                    FormalName = "Французская Республика",
                    FlagUrl = "флаг ФР",
                    Population = 14,
                    Continents = new List<Continents> { Continents.Europe },
                    Summary = "Хорошо"
                },
                new CountryData
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Name = "Турция",
                    FormalName = "Турецкая Республика",
                    FlagUrl = "флаг Турции",
                    Population = 16,
                    Continents = new List<Continents> { Continents.Asia, Continents.Europe },
                    Summary = "Лучше"
                }
            };


        /*????public List<CountryData> GetCountryDatas(List<Continents> filterContinents)
        {
            return _mockDb.Where(country => country.Continents.Any(c => filterContinents.Contains(c))).ToList();
        }*/

        public void Create(CountryData country)
        {
            _mockDb.Add(country);
        }
        public List<CountryData> GetAll()
        {
            return _mockDb;
        }

        public CountryData? GetById(string uuid)
        {
            return _mockDb.FirstOrDefault(c => c.Uuid == uuid);
        }
        public void Update(CountryData country)
        {
            var existingCountry = _mockDb.FirstOrDefault(c => c.Uuid == country.Uuid);

            if (existingCountry != null)
            {
                existingCountry.Name = country.Name;
                existingCountry.FormalName = country.FormalName;
                existingCountry.FlagUrl = country.FlagUrl;
                existingCountry.Population = country.Population;
                existingCountry.Continents = country.Continents;
                existingCountry.Summary = country.Summary;
            }
        }
        public void Delete(string uuid)
        {
            var existingCountry = _mockDb.FirstOrDefault(c => c.Uuid == uuid);
            if (existingCountry != null)
            {
                _mockDb.Remove(existingCountry);
            }
        }
    }
}
