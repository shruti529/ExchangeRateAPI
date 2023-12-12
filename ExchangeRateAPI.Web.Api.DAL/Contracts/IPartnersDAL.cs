using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.DAL
{
    public interface IPartnersDAL
    {
        public List<PartnerRate> GetExchangeRates(Country? country);
        public List<PartnerRate> GetLatestExchangeRates(Country? country);
    }
}
