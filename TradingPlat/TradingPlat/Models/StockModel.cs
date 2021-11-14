using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{
    public class StockModel
    {
        [Key]
        public int StockID { get; set; }

        public string StockName { get; set; }

        public string Symbol { get; set; }

        public ICollection<PortfolioStockModel> PortfolioStocks { get; set; }
    }
}
