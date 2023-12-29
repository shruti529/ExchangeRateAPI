using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Impl
{
    public class AddFlatRateStrategy : RateAdjustmentStrategy
    {
        public AddFlatRateStrategy(Country country) : base(country)
        { }

        public override T GetAdjustedRate<T>(PartnerRate partnerRate)
        {
            return (T)Convert.ChangeType(Math.Round(Convert.ToDecimal(partnerRate.Rate) + Convert.ToDecimal(_country.AdjustmentValue), 2), typeof(T));
        }
    }
}
