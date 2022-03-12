using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<string>> Get()
        {
            var model = await RatesService.GetData();
            return model.Valute.Select(v => v.Value.ID).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<double?> Get(string id)
        {
            var model = await RatesService.GetData();
            return model.Valute.FirstOrDefault(v => v.Value.ID == id).Value?.Value;
        }
    }
}
