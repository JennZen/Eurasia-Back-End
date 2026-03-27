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

namespace Eurasia.BusinessLogic.Functions.Country
{
    public class CountryAction : CountryMainInfoAction, ICountryAction
    {
        /*?????public List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents)
        {
            return GetCountryMainInfoDtos(continents);
        }*/

        public void Create(CountryData country)
        {
            base.Create(country);
        }
        public List<CountryData> GetAll()
        {
            return base.GetAll();
        }

        public CountryData? GetById(string uuid)
        {
            return base.GetById(uuid);
        }
        public void Update(CountryData country)
        {
            base.Update(country);
        }
        public void Delete(string uuid)
        {
            base.Delete(uuid);  
        }

    }
}
