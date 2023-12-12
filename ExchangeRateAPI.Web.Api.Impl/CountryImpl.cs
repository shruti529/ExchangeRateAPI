using ExchangeRateAPI.Web.Api.Contracts;
using ExchangeRateAPI.Web.Api.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Impl
{
    public class CountryImpl : ICountryImpl
    {
        private readonly ICountriesDAL _countriesDAL;
        public CountryImpl(ICountriesDAL countriesDAL)
        {
            _countriesDAL = countriesDAL;
        }

        public Country? GetCountry(string countryCode)
        {
            return _countriesDAL.GetCountry(countryCode);
        }

        public bool IsCountryAvailable(string countryCode)
        {
            return _countriesDAL.IsCountryAvailable(countryCode);
        }
    }
}
