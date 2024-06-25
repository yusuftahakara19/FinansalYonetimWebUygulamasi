using BusinessLayer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dictionary<string, ExchangeRate>> GetExchangeRates()
        {
            var response = await _httpClient.GetAsync("https://demo7501354.mockable.io/kur-bilgileri");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(content);

            var rates = new Dictionary<string, ExchangeRate>();
            foreach (var rate in data["rates"])
            {
                var currency = rate.Path.ToString().Split('.')[1];
                var details = rate.First;
                var exchangeRate = new ExchangeRate
                {
                    Currency = currency,
                    Alis = details["alis"].Value<decimal>(),
                    Satis = details["satis"].Value<decimal>(),
                    Degisim = details["degisim"].Value<decimal>()
                };
                rates[currency] = exchangeRate;
            }

            return rates;
        }
    }

}
