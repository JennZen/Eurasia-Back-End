using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;

namespace Eurasia.BusinessLogic.Functions.Country
{
    public class CountryMainInfoFlow : CountryMainInfoAction, ICountryAction
    {
        public List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents)
        {
            var countries = base.GetCountryDatas(continents);
            return countries.Select(country => new CountryMainInfoDto
            {
                Id = country.Id,
                Name = country.Name,
                FormalName = country.FormalName,
                FlagUrl = country.FlagUrl,
                Population = country.Population,
                Continents = country.Continents,
                Currency = country.Currency,
                Regions = country.Regions,
                Capital = country.Capital,
                GeographicalSize = country.GeographicalSize,
                Languages = country.CountryLanguages?
                    .Select(cl => cl.Language?.Name ?? "")
                    .ToList() ?? new List<string>()
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
                Continents = dto.Continents,
                Currency = dto.Currency,
                Regions = dto.Regions,
                Capital = dto.Capital,
                GeographicalSize = dto.GeographicalSize,
                CountryLanguages = dto.Languages?.Select(langName => new CountryLanguage
                {
                    Language = new Language { Name = langName }
                }).ToList()
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
                Continents = created.Continents,
                Currency = created.Currency,
                Regions = created.Regions,
                Capital = created.Capital,
                GeographicalSize = created.GeographicalSize,
                Languages = created.CountryLanguages?.Select(cl => cl.Language.Name).ToList()
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
                Continents = country.Continents,
                Currency = country.Currency,
                Regions = country.Regions,
                Capital = country.Capital,
                GeographicalSize = country.GeographicalSize,
                Languages = country.CountryLanguages?.Select(cl => cl.Language.Name).ToList()
            };
        }
        public bool Update(CountryMainInfoDto country)
        {
            var existingCountry = base.GetById(country.Id);
            
            if (existingCountry != null)
            {
                existingCountry.Id = country.Id;
                existingCountry.Name = country.Name;
                existingCountry.FormalName = country.FormalName;
                existingCountry.FlagUrl = country.FlagUrl;
                existingCountry.Population = country.Population;
                existingCountry.Continents = country.Continents;
                existingCountry.Currency = country.Currency;
                existingCountry.Regions = country.Regions;
                existingCountry.Capital = country.Capital;
                existingCountry.GeographicalSize = country.GeographicalSize;
                existingCountry.CountryLanguages = country.Languages?
            .Select(name => new CountryLanguage
            {
                Language = new Language { Name = name }
            }).ToList() ?? [];

                return base.Update(existingCountry);
            }
            
            return false;
        }
        public bool Delete(int id)
        {
            return base.Delete(id);
        }

    }
}
