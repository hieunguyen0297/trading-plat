using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{
    public class Portfolio
    {
        public PortfolioStockModel PortfolioStock { get; set; }
        public StockModel Stock { get; set; }
    }
}
