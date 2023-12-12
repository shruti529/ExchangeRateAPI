using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Impl
{
    public class AddFlatRateStrategy : IRateAdjustmentStrategy
    {
        public T GetAdjustedRate<T>(PartnerRate partnerRate, Country country) where T : IComparable<T>
        {
            return (T)Convert.ChangeType(Math.Round(Convert.ToDecimal(partnerRate.Rate) + Convert.ToDecimal(country.FlatRate), 2), typeof(T));
        }
    }
}
