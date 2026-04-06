using Eurasia.DataAccess.Context;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;

namespace Eurasia.BusinessLogic.Core.Country
{
    public class CountryMainInfoAction
    {
        private readonly CountryContext _db = new CountryContext();



        public List<CountryData> GetCountryDatas(List<Continents> filterContinents)
        {
            return _db.Countries
                .AsEnumerable()
                .Where(country => country.Continents != null && country.Continents.Any(c => filterContinents.Contains(c)))
                .ToList();
        }

        public CountryData? Create(CountryData country)
        {
            var existingCountry = _db.Countries.Any(c => c.Id == country.Id);

            if (!existingCountry)
            {
                _db.Add(country);
                _db.SaveChanges();
                return country;
            }
            return null;
        }

        public CountryData? GetById(int id)
        {
            return _db.Countries.Find(id);
        }
        public bool Update(CountryData country)
        {
            var existingCountry = _db.Countries.Find(country.Id);
            if (existingCountry != null)
            {
                _db.Entry(existingCountry).CurrentValues.SetValues(country);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Delete(int id)
        {
            var existingCountry = _db.Countries.Find(id);

            if (existingCountry != null)
            {
                _db.Countries.Remove(existingCountry);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
