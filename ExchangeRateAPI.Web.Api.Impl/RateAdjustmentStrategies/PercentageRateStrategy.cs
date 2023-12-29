using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Impl.RateAdjustmentStrategies
{
    public class PercentageRateStrategy : RateAdjustmentStrategy
    {
        public PercentageRateStrategy(Country country) : base(country)
        {
        }

        public override T GetAdjustedRate<T>(PartnerRate partnerRate)
        {
            return (T)Convert.ChangeType(Math.Round(Convert.ToDecimal(partnerRate.Rate) * Convert.ToDecimal(_country.AdjustmentValue * 100), 2), typeof(T));
        }
    }
}
