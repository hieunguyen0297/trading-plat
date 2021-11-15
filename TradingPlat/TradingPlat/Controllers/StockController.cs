using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlat.Models;

namespace TradingPlat.Controllers
{
    public class StockController : Controller
    {
        public IActionResult GetStocks()
        {
            List<StockModel> stocks = new List<StockModel>();
            using (var db = new StockDBContext())
            {
                stocks = db.Stocks.ToList();
            }
            return View("StockList", stocks);
           
        }
    }
}
