using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{
    public class PortfolioStockModel
    {
        
        public int Id { get; set; }
        public int StockID { get; set; }
        public int UserID { get; set; }
        public decimal ExecutionPrice { get; set; }
        public int Quantity { get; set; }

        public StockModel Stock { get; set; }
        public UserModel User { get; set; }
    }
}
