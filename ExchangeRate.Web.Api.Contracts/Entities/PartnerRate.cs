namespace ExchangeRateAPI.Web.Api.Contracts
{
    public class PartnerRate
    {
        public string? Currency { get; set; }
        public string? AcquiredDate { get; set; }
        public decimal? Rate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? DeliveryMethod { get; set; }
    }
}
