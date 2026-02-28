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
        List<CountryMainInfoDto> GetAllCountriesMainInfoDtos(List<Continents> continents);
    }
}
