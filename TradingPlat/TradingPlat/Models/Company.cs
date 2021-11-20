using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{

    public class Company
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string MarketCapitalization { get; set; }
        public string DividendPerShare { get; set; }
        public string AnalystTargetPrice { get; set; }
        public string _52WeekHigh { get; set; }
        public string _52WeekLow { get; set; }
        public decimal StockLastestPrice { get; set; }
        public string ChangeInPercent { get; set; }
    }

}
