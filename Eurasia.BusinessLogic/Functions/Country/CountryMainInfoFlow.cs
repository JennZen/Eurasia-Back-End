using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Country;
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
        /*?????public List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents)
        {
            return GetCountryMainInfoDtos(continents);
        }*/

        public void Create(CountryMainInfoDto dto)
        {
            var country = new CountryData
            {
                Uuid = dto.Uuid,
                Name = dto.Name,
                FormalName = dto.FormalName,
                FlagUrl = dto.FlagUrl,
                Population = dto.Population,
                Continents = dto.Continents,
                Summary = dto.Summary,
                //???FormalName = dto.Name
            };
            base.Create(country);
        }
        public List<CountryMainInfoDto> GetAll()
        {
            var allCountries = base.GetAll();

            return allCountries.Select(country => new CountryMainInfoDto
            {
                Uuid = country.Uuid,
                Name = country.Name,
                FormalName = country.FormalName,
                FlagUrl = country.FlagUrl,
                Population = country.Population,
                Continents = country.Continents,
                Summary = country.Summary
            }).ToList();
        }
        public CountryMainInfoDto? GetById(string uuid)
        {
            var country = base.GetById(uuid);

            if (country == null)
            {
                return null;
            }

            return new CountryMainInfoDto
            {
                Uuid = country.Uuid,
                Name = country.Name,
                FormalName = country.FormalName,
                FlagUrl = country.FlagUrl,
                Population = country.Population,
                Continents = country.Continents,
                Summary = country.Summary
            };
        }
        public void Update(CountryMainInfoDto country)
        {
            var existingCountry = base.GetById(country.Uuid);
            
            if (existingCountry != null)
            {
                existingCountry.Uuid = country.Uuid;
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
            base.Delete(uuid);
        }

    }
}
