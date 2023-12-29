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
    public class ExchangeRateImpl : IExchangeRateImpl
    {
        private IRateAdjustmentFactory _rateadjustmentFactory;
        private IPartnersDAL _partnersDAL;
        public ExchangeRateImpl(IRateAdjustmentFactory rateAdjustmentFactory, IPartnersDAL partnersDAL)
        {
            _rateadjustmentFactory = rateAdjustmentFactory;
            _partnersDAL = partnersDAL;
        }
        

        public List<ExchangeRate> GetLatestExchangeRates(Country country)
        {
            var ret = new List<ExchangeRate>();
            var partnerRates = _partnersDAL.GetLatestExchangeRates(country);
            var strategy = _rateadjustmentFactory.CreateStrategy(country);

            foreach (var partnerRate in partnerRates)
            {
                var exchangeRate = new ExchangeRate
                {
                    CurrencyCode = country.CurrencyCode,
                    CountryCode = country.CountryCode,
                    PangeaRate = strategy.GetAdjustedRate<decimal>(partnerRate),
                    PaymentMethod = partnerRate.PaymentMethod,
                    DeliveryMethod = partnerRate.DeliveryMethod
                };
                ret.Add(exchangeRate);
            }

            return ret;
        }
    }
}
