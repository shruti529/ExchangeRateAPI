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
        public IRateAdjustmentStrategy? CreateRateAdjustmentStrategy(string strategy)
        {
            try
            {
                if (string.IsNullOrEmpty(strategy))
                {
                    return null;
                }
                return (IRateAdjustmentStrategy)Activator.CreateInstance(Type.GetType($"ExchangeRateAPI.Web.Api.Impl.{strategy}Strategy"));
            }
            catch
            {
                return null;
            }
        }
    }
}
