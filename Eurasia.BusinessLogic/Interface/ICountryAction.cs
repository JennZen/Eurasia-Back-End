using Eurasia.Domains.Models.Country;
using System.Collections.Generic;

namespace Eurasia.BusinessLogic.Interface
{
    public interface ICountryAction
    {
        //List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents);
        List<CountryMainInfoDto> GetAll();
        CountryMainInfoDto? GetById(string uuid);
        void Create(CountryMainInfoDto country);
        void Update(CountryMainInfoDto country);
        void Delete(string uuid);
    }
}
