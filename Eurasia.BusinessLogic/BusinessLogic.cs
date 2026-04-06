using Eurasia.BusinessLogic.Functions.Attraction;
using Eurasia.BusinessLogic.Functions.Country;
using Eurasia.BusinessLogic.Interface;
using Eurasia.BusinessLogic.Functions.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurasia.BusinessLogic.Functions.User;

namespace Eurasia.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public ICountryAction GetMainInfoCountryActions()
        {
            return new CountryMainInfoFlow();
        }

        public INewsAction GetMainInfoNewsActions()
        { 
                return new NewsMainInfoFlow();
        }

        public IAttractionAction GetAttractionActions()
        {
            return new AttractionFlow();
        }
        public IUserAction GetUserActions()
        {
            return new UserFlow();
        }
    }
}