using ExchangeRateAPI.Web.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.DAL
{
    public class CountriesDAL : ICountriesDAL
    {
        private readonly List<Country> _countries;
        public CountriesDAL()
        {
            //Read from DataBase
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "ExchangeRateAPI.Web.Api.DAL", "Data", "Countries.json");
            var jsonData = File.ReadAllText(path);
            _countries = JsonConvert.DeserializeObject<List<Country>>(jsonData);
        }

        public bool IsCountryAvailable(string countryCode)
        {
            return _countries.Any(c => c.CountryCode.Equals(countryCode, StringComparison.OrdinalIgnoreCase));
        }

        public Country? GetCountry(string countryCode)
        {
            try
            {
                return _countries.FirstOrDefault(x => x.CountryCode.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }
    }
}
