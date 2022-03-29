using Microsoft.AspNetCore.Mvc;
using OkbTestWebApp.Models;
using OkbTestWebApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkbTestWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        readonly IDailyExchangeRatesService RatesService;
        public ExchangeRatesController(IDailyExchangeRatesService ratesService)
        {
            RatesService = ratesService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetTickers()
        {
            return await RatesService.GetTickers();
            //return new List<string>();
            //return null;
        }

        [HttpGet("{id}")]
        public async Task<double?> GetValue(string id)
        {
            return await RatesService.GetValue(id);
        }
    }
}
