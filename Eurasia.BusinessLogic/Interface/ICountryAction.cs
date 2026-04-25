using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Models.Country;
using System.Collections.Generic;

namespace Eurasia.BusinessLogic.Interface
{
    public interface ICountryAction
    {
        public List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<int>? continentIds = null);
        public List<CountryListDto> GetCountriesList();
        CountryMainInfoDto? GetById(int id);
        CountryMainInfoDto? Create(CreateCountryDto country);
        bool Update(CountryMainInfoDto country);
        bool Delete(int id);
    }
}
