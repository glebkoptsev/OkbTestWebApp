using OkbTestWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OkbTestWebApp.Services
{
    public interface IDailyExchangeRatesService
    {
        public Task<DailyExchangeRatesModel> GetData();

        public Task<IEnumerable<string>> GetTickers();

        public Task<double?> GetValue(string id);
    }
}
