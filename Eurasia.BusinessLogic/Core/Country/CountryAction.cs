using Eurasia.Domains.Entities.Country;
using Microsoft.EntityFrameworkCore;

namespace Eurasia.BusinessLogic.Core.Country
{
    public class CountryAction
    {
        private readonly CountryContext _db = new CountryContext();

        public List<CountryData> GetCountryDatas()
        {
            return _db.Countries
                .Include(c => c.Languages)
                .Include(c => c.Regions)
                .Include(c => c.Continents)
                .ToList();
        }

        public CountryData Create(CountryData country)
        {
            var existingCountry = _db.Countries.FirstOrDefault(c => c.Name == country.Name);
            if (existingCountry != null)
                return existingCountry;

            var languageNames = country.Languages?.Select(x => x.Name).ToList() ?? new();
            var regionNames = country.Regions?.Select(x => x.Name).ToList() ?? new();
            var continentNames = country.Continents?.Select(x => x.Name).ToList() ?? new();

            country.Languages = _db.Language
                .Where(l => languageNames.Contains(l.Name))
                .ToList();

            country.Regions = _db.Regions
                .Where(r => regionNames.Contains(r.Name))
                .ToList();

            country.Continents = _db.Continents
                .Where(c => continentNames.Contains(c.Name))
                .ToList();

            _db.Countries.Add(country);
            _db.SaveChanges();

            return country;
        }

        public CountryData? GetById(int id)
        {
            return _db.Countries
                .Include(c => c.Languages)
                .Include(c => c.Regions)
                .Include(c => c.Continents)
                .FirstOrDefault(c => c.Id == id);
        }
        public bool Update(CountryData country)
        {
            var existingCountry = _db.Countries
                .Include(c => c.Languages)
                .Include(c => c.Regions)
                .Include(c => c.Continents)
                .FirstOrDefault(c => c.Id == country.Id);

            if (existingCountry == null)
                return false;

            existingCountry.Name = country.Name;
            existingCountry.FormalName = country.FormalName;
            existingCountry.FlagUrl = country.FlagUrl;
            existingCountry.Population = country.Population;
            existingCountry.Currency = country.Currency;
            existingCountry.Capital = country.Capital;
            existingCountry.GeographicalSize = country.GeographicalSize;
            existingCountry.Summary = country.Summary;

            var languageNames = country.Languages?.Select(x => x.Name).ToList() ?? new();
            var regionNames = country.Regions?.Select(x => x.Name).ToList() ?? new();
            var continentNames = country.Continents?.Select(x => x.Name).ToList() ?? new();

            existingCountry.Languages = _db.Language
                .Where(l => languageNames.Contains(l.Name))
                .ToList();

            existingCountry.Regions = _db.Regions
                .Where(r => regionNames.Contains(r.Name))
                .ToList();

            existingCountry.Continents = _db.Continents
                .Where(c => continentNames.Contains(c.Name))
                .ToList();

            _db.SaveChanges();
            return true;
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
