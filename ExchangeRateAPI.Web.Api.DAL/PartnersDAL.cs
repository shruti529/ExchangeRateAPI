using ExchangeRateAPI.Web.Api.Contracts;
using System.IO;
using Newtonsoft.Json;

namespace ExchangeRateAPI.Web.Api.DAL
{
    public class PartnersDAL : IPartnersDAL
    {
        private List<PartnerRate> partnerRates;

        public PartnersDAL()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "ExchangeRateAPI.Web.Api.DAL", "Data", "PartnerRates.json");
            var jsonData = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(jsonData))
            {
                partnerRates = JsonConvert.DeserializeObject<PartnerRateList>(jsonData).PartnerRates;
            }
            else
            {
                partnerRates = new List<PartnerRate>();
            }
        }       

        public List<PartnerRate> GetLatestExchangeRates(Country? country)
        {
            var rates = GetExchangeRates(country);
            if (rates.Count >=0)
            {
                var latesRates = new List<PartnerRate>();
                rates = rates.OrderByDescending(r => r.AcquiredDate).ToList();

                foreach (var rate in rates)
                {
                    if (!LaterDateRateExists(latesRates, rate))
                    {
                        latesRates.Add(rate);                        
                    }
                }

                return latesRates;
            }
            return rates;
        }

        public List<PartnerRate> GetExchangeRates(Country? country)
        {
            if (country == null)
            {
                return partnerRates;
            }

            if (IsInvalidCurrencyCode(country))
            {
                return new List<PartnerRate>();
            }
            return partnerRates.Where(r => r.Currency == country.CurrencyCode).ToList();
        }

        #region Private Methods
        private bool LaterDateRateExists(List<PartnerRate> rates, PartnerRate rate)
        {
            return rates.Any(r => r.DeliveryMethod == rate.DeliveryMethod && r.PaymentMethod == rate.PaymentMethod);
        }

        private bool IsInvalidCurrencyCode(Country country)
        {
            if (string.IsNullOrEmpty(country.CurrencyCode))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}