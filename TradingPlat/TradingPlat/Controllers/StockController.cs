using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ViewBag.id = id;
            //Get stock by ID
            StockModel stock = db.GetStock(id);

            //Make a new instace of ExternalAPI class
            ExternalAPI api = new ExternalAPI();

            //Call API to get the company stock information
            Company info = await api.GetStockInfor(stock.Symbol);

            //Return a view with the company information
            return View("StockDetails", info);
        }



        //Purchase stock process
        
        public IActionResult PurchaseStock(int stockId, int userId, decimal price, int quantity)
        {
            //ViewBag.stockId = stockId;
            //ViewBag.userId = userId;
            //ViewBag.price = price;
            //ViewBag.quantity = quantity;
            return View("Confirmation");
        }
    }
}
