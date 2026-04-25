using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Models.Country;

namespace Eurasia.BusinessLogic.Functions.Country
{
    public class CountryFlow : CountryAction, ICountryAction
    {
        public List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<int>? continentIds = null)
        {
            var countries = base.GetCountryDatas();

            if (continentIds != null && continentIds.Any())
            {
                countries = countries
                    .Where(c => c.Continents.Any(ct => continentIds.Contains(ct.Id)))
                    .ToList();
            }

            return countries.Select(country => new CountryMainInfoDto
            {
                Id = country.Id,
                Name = country.Name,
                FormalName = country.FormalName,
                FlagUrl = country.FlagUrl,
                Population = country.Population,

                Continents = country.Continents?.Select(c => c.Name).ToList(),
                Regions = country.Regions?.Select(r => r.Name).ToList(),
                Languages = country.Languages?.Select(l => l.Name).ToList(),

                Currency = country.Currency,
                Capital = country.Capital,
                GeographicalSize = country.GeographicalSize
            }).ToList();
        }

        public List<CountryListDto> GetCountriesList()
        { 
            var countries = base.GetCountryDatas();
            return countries.Select(country => new CountryListDto
            {
                Id = country.Id,
                Name = country.Name,
                FlagUrl = country.FlagUrl
            }).ToList();
        }

        public CountryMainInfoDto? Create(CreateCountryDto dto)
        {
            var country = new CountryData
            {
                Population = dto.Population,
                Name = dto.Name,
                FormalName = dto.FormalName,
                FlagUrl = dto.FlagUrl,
                Currency = dto.Currency,
                Capital = dto.Capital,
                GeographicalSize = dto.GeographicalSize,

                Languages = dto.Languages?
                    .Select(name => new Language { Name = name })
                    .ToList(),

                Regions = dto.Regions?
                    .Select(name => new Region { Name = name })
                    .ToList(),

                Continents = dto.Continents?
                    .Select(name => new Continent { Name = name })
                    .ToList()
            };

            var created = base.Create(country);
            if (created == null) return null;

            return new CountryMainInfoDto
            {
                Id = created.Id,
                Name = created.Name,
                FormalName = created.FormalName,
                FlagUrl = created.FlagUrl,
                Population = created.Population,

                Continents = created.Continents?.Select(c => c.Name).ToList(),
                Regions = created.Regions?.Select(r => r.Name).ToList(),
                Languages = created.Languages?.Select(l => l.Name).ToList(),

                Currency = created.Currency,
                Capital = created.Capital,
                GeographicalSize = created.GeographicalSize
            };
        }

        public CountryMainInfoDto? GetById(int id)
        {
            var country = base.GetById(id);

            if (country == null)
            {
                return null;
            }

            return new CountryMainInfoDto
            {
                Id = country.Id,
                Name = country.Name,
                FormalName = country.FormalName,
                FlagUrl = country.FlagUrl,
                Population = country.Population,

                Continents = country.Continents?.Select(c => c.Name).ToList(),
                Regions = country.Regions?.Select(r => r.Name).ToList(),
                Languages = country.Languages?.Select(l => l.Name).ToList(),

                Currency = country.Currency,
                Capital = country.Capital,
                GeographicalSize = country.GeographicalSize
            };
        }

        public bool Update(CountryMainInfoDto dto)
        {
            var existingCountry = base.GetById(dto.Id);

            if (existingCountry == null)
                return false;

            existingCountry.Name = dto.Name;
            existingCountry.FormalName = dto.FormalName;
            existingCountry.FlagUrl = dto.FlagUrl;
            existingCountry.Population = dto.Population;
            existingCountry.Currency = dto.Currency;
            existingCountry.Capital = dto.Capital;
            existingCountry.GeographicalSize = dto.GeographicalSize;

            existingCountry.Languages = dto.Languages?
                .Select(name => new Language { Name = name })
                .ToList();

            existingCountry.Regions = dto.Regions?
                .Select(name => new Region { Name = name })
                .ToList();

            existingCountry.Continents = dto.Continents?
                .Select(name => new Continent { Name = name })
                .ToList();

            return base.Update(existingCountry);
        }

        public bool Delete(int id)
        {
            return base.Delete(id);
        }
    }
}