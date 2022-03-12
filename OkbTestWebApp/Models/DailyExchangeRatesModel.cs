using System;
using System.Collections.Generic;

namespace OkbTestWebApp.Models
{
    public class DailyExchangeRatesModel
    {
        public DateTime? Date { get; set; }
        public DateTime? PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime? Timestamp { get; set; }
        public Dictionary<string, Currency> Valute { get; set; }
    }
}
