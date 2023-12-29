using ExchangeRateAPI.Web.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Impl
{
    public class RateAdjustmentFactory : IRateAdjustmentFactory
    {
        public RateAdjustmentStrategy? CreateStrategy(Country country)
        {
            try
            {
                return (RateAdjustmentStrategy)Activator.CreateInstance(Type.GetType($"ExchangeRateAPI.Web.Api.Impl.{country.RateAdjustmentStrategy}Strategy"), new object[] {country});
            }
            catch
            {
                return null;
            }
        }
    }
}
