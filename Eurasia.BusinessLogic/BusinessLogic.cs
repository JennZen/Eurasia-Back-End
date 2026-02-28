using Eurasia.BusinessLogic.Functions.Country;
using Eurasia.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurasia.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public ICountryAction GetMainInfoCountryActions()
        {
            return new CountryAction();
        }
    }
}
