using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Contracts
{
    public interface IExchangeRateImpl
    {        
        public List<ExchangeRate> GetLatestExchangeRates(Country country);
    }
}
