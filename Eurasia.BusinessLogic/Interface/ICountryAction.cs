using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic.Interface
{
    public interface ICountryAction
    {
        //List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents);
        List<CountryData> GetAll();
        CountryData? GetById(string uuid);
        void Create(CountryData country);
        void Update(CountryData country);
        void Delete(string uuid);
    }
}
