using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.DAL
{
    public interface ICountriesDAL
    {
        public Country? GetCountry(string countryCode);
        public bool IsCountryAvailable(string countryCode);
    }
}
