namespace ExchangeRateAPI.Web.Api.Contracts
{
    public class Country
    {
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public decimal FlatRate { get; set; }
        public string RateAdjustmentStrategy { get; set; }
        private IRateAdjustmentStrategy? _rateAdjustment { get; set; } = null;

        public T AdjustedRate<T>(PartnerRate partnerRate, IRateAdjustmentFactory rateAdjustmentFactory) where T : IComparable<T>
        {
            return GetRateAdjustmentStrategy(rateAdjustmentFactory).GetAdjustedRate<T>(partnerRate, this);
        }

        private IRateAdjustmentStrategy GetRateAdjustmentStrategy(IRateAdjustmentFactory rateAdjustmentFactory)
        {

            if (_rateAdjustment == null)
            {
                _rateAdjustment = rateAdjustmentFactory.CreateRateAdjustmentStrategy(RateAdjustmentStrategy);
            }

            return _rateAdjustment;
        }
    }
}
