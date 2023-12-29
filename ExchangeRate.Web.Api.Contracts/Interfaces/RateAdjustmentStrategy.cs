using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Contracts
{
    public abstract class RateAdjustmentStrategy
    {
        protected Country _country { get; }
        protected RateAdjustmentStrategy(Country country)
        {
            _country = country;
        }
        public abstract T GetAdjustedRate<T>(PartnerRate partnerRate) where T : IComparable<T>;
    }
}
