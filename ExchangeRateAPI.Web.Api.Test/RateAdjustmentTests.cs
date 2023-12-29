using ExchangeRateAPI.Web.Api.Contracts;
using ExchangeRateAPI.Web.Api.Impl;
using Moq;

namespace ExchangeRateAPI.Web.Api.Test
{
    public class RateAdjustmentTests
    {
        [Fact]        
        public void AddFlatRateStrategySucceeds()
        {
            var country = new Country
            {
                AdjustmentValue = 10
            };
            var strategy = new AddFlatRateStrategy(country);
            var partnerRate = new PartnerRate()
            {
                Rate = 10
            };

            var ret = strategy.GetAdjustedRate<decimal>(partnerRate);
            Assert.NotNull(ret);
            Assert.Equal(ret, 20);
        }
    }
}