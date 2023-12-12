using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ExchangeRateAPI.Web.Api.Contracts;

namespace ExchangeRateAPI.Web.API
{
    [ApiController]
    [Route("api")]

    public class ExchangeRateController : Controller
    {
        private IExchangeRateImpl _exchangeRateImpl;
        private ICountryImpl _countryImpl;

        public ExchangeRateController(IExchangeRateImpl exchangeRateImpl, ICountryImpl countryImpl)
        {  
            _exchangeRateImpl = exchangeRateImpl;
            _countryImpl = countryImpl;
        }


        [HttpGet("exchange-rates")]
        public ActionResult<IEnumerable<ExchangeRate>> GetExchangeRates([FromQuery] string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                return BadRequest(new { error = "Country code is required" });

            if (!_countryImpl.IsCountryAvailable(countryCode))
                return NotFound(new { error = $"No exchange rates found for {countryCode}" });
        
            var country = _countryImpl.GetCountry(countryCode);
            if (country == null)
            {
                return BadRequest();
            }

            var rates = _exchangeRateImpl.GetLatestExchangeRates(country);
            if (rates.Count == 0)
                return NotFound(new { error = $"No exchange rates found for {country}" });

            return Ok(rates);
        }
    }
}
