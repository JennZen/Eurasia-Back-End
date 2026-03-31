using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;

namespace Eurasia.BusinessLogic.Core.Country
{
    public class CountryMainInfoAction
    {
        private static List<CountryData> _mockDb =
            [
                new CountryData
                {
                    Id = 38,
                    Name = "Молдова",
                    FormalName = "Республика Молдова",
                    FlagUrl = "флаг МД",
                    Population = 12,
                    Continents = [Continents.Asia, Continents.Europe],
                    Currency = "Молдавский лей",
                    Regions = ["Восточная Европа"],
                    Capital = "Кишинёв",
                    GeographicalSize = 33846,
                    CountryLanguages = [ new CountryLanguage { Language = new Language { Name = "Romanian" } } ]
                },
                new CountryData
                {
                    Id = 3,
                    Name = "Франция",
                    FormalName = "Французская Республика",
                    FlagUrl = "флаг ФР",
                    Population = 14,
                    Continents = [ Continents.Europe ],
                    Currency = "Евро",
                    Regions = ["Западная Европа"],
                    Capital = "Париж",
                    GeographicalSize = 643801,
                    CountryLanguages = [ new CountryLanguage { Language = new Language { Name = "Французский" } } ]
                },
                new CountryData
                {
                    Id = 55,
                    Name = "Турция",
                    FormalName = "Турецкая Республика",
                    FlagUrl = "флаг Турции",
                    Population = 16,
                    Continents = [ Continents.Asia, Continents.Europe ],
                    Currency = "Турецкая лира",
                    Regions = ["Юго-Восточная Европа", "Западная Азия"],
                    Capital = "Анкара",
                    GeographicalSize = 783562,
                    CountryLanguages = [ new CountryLanguage { Language = new Language { Name = "Турецкий" } } ]
                }
            ];


        public List<CountryData> GetCountryDatas(List<Continents> filterContinents)
        {
            return _mockDb.Where(country => country.Continents.Any(c => filterContinents.Contains(c))).ToList();
        }

        public bool Create(CountryData country)
        {
            var existingCountry = _mockDb.FirstOrDefault(c => c.Id == country.Id);

            if (existingCountry == null)
            {
                _mockDb.Add(country);
                return true;
            }
            return false;
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
        public bool Delete(int id)
        {
            var existingCountry = _mockDb.FirstOrDefault(c => c.Id == id);
            if (existingCountry != null)
            {
                _mockDb.Remove(existingCountry);
                return true;
            }
            return false;
        }
    }
}
