using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradingPlat.APIManager;
using TradingPlat.DBManager;
using TradingPlat.Models;

namespace TradingPlat.Controllers
{
    public class StockController : Controller
    {
        private DB db;
        //Generate a new instance of StockDB in the constructor
        public StockController()
        {
            db = new DB();
        }

        //Get a list of stock when user accessing the Stock List page
        public IActionResult WatchList()
        {
            return View("StockList", db.GetStocks());
        }

        //Get stock details
        public async Task<ActionResult> Details(int id)
        {
            
            //Get stock by ID
            StockModel stock = db.GetStock(id);

            //Make a new instace of ExternalAPI class
            ExternalAPI api = new ExternalAPI();

            //Call API to get the company stock information
            Company info = await api.GetStockInfor(stock.Symbol);

            //Set viewbag and send it to use somewhere else in the application
            ViewBag.id = id;
            ViewBag.latestPrice = info.StockLastestPrice;

            //Return a view with the company information
            return View("StockDetails", info);
        }



        //Purchase stock process
        [HttpPost]
        public IActionResult PurchaseStock(int stockId, int userId, decimal price, int quantity)
        {
            //Get balance and check balance to make sure user have enough money to buy stock
            if (ModelState.IsValid)
            {
                decimal balance = db.GetAccountBalance(userId);
                decimal total = quantity * price;
                if(total < balance)
                {
                    ViewBag.price = price;
                    ViewBag.quantity = quantity;
                    return View("Confirmation");       
                }        
                else if(total > balance)
                {
                    ViewBag.error = "You don't have enough fund.";
                    return View("Confirmation");
                }            
            }

            //Default return 
            return View();
        }
    }
}
