using Microsoft.Extensions.Configuration;
using OkbTestWebApp.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<string>> GetTickers()
        {
            var model = await GetData();
            return model.Valute.Select(v => v.Value.ID).ToArray();
        }

        public async Task<double?> GetValue(string id)
        {
            var model = await GetData();
            return model.Valute.FirstOrDefault(v => v.Value.ID == id).Value?.Value;
        }
    }
}
