using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Language;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public bool Create(CountryMainInfoDto dto)
        {
            var country = new CountryData
            {
                Id = dto.Id,
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
            return base.Create(country);
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
                Languages = country.CountryLanguages.Select(cl => cl.Language.Name).ToList()
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
