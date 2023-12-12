using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Contracts
{
    public interface ICountryImpl
    {
        public Country? GetCountry(string countryCode);
        public bool IsCountryAvailable(string countryCode);
    }
}
