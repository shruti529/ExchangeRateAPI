using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Contracts
{
    public interface IRateAdjustmentFactory
    {
        public RateAdjustmentStrategy CreateStrategy(Country strategy);
    }
}
