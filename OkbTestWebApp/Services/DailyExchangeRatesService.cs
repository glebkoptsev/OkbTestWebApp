using Microsoft.Extensions.Configuration;
using OkbTestWebApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OkbTestWebApp.Services
{
    public class DailyExchangeRatesService : IDailyExchangeRatesService
    {
        private IHttpClientFactory ClientFactory { get; set; }
        private string URL { get; set; }
        public DailyExchangeRatesService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            ClientFactory = clientFactory;
            URL = config.GetValue(typeof(string), "DailyExchangeRatesURL").ToString();
        }

        public async Task<DailyExchangeRatesModel> GetData()
        {
            using var client = ClientFactory.CreateClient();
            var response = await client.GetAsync(URL);
            var json = await response?.Content?.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            return JsonSerializer.Deserialize<DailyExchangeRatesModel>(json);
        }
    }
}
