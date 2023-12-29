namespace ExchangeRateAPI.Web.Api.Contracts
{
    public class Country
    {
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public decimal AdjustmentValue { get; set; }
        public string RateAdjustmentStrategy { get; set; }
    }
}
