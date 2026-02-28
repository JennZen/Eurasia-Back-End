using Eurasia.BusinessLogic.Core.Country;
using Eurasia.BusinessLogic.Interface;
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
        public List<CountryMainInfoDto>  GetAllCountriesMainInfoDtos(List<Continents> continents)
        {
            var getCountriesMainInfo = GetCountryMainInfoDtos(continents);
            return getCountriesMainInfo;
        }

    }
}
