using Eurasia.Domains.Enums.Eurasia;
using Eurasia.Domains.Models.Country;
using System.Collections.Generic;

namespace Eurasia.BusinessLogic.Interface
{
    public interface ICountryAction
    {
        List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents);
        CountryMainInfoDto? GetById(int id);
        CountryMainInfoDto? Create(CreateCountryDto country);
        bool Update(CountryMainInfoDto country);
        bool Delete(int id);
    }
}
