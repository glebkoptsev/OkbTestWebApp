using OkbTestWebApp.Models;
using System.Threading.Tasks;

namespace OkbTestWebApp.Services
{
    public interface IDailyExchangeRatesService
    {
        public Task<DailyExchangeRatesModel> GetData();
    }
}
