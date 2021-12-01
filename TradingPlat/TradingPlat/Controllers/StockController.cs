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
            ViewBag.symbol = info.Symbol;

            //Return a view with the company information
            return View("StockDetails", info);
        }



        //Purchase stock process
        [HttpPost]
        public IActionResult PurchaseStock(int stockId, int userId, decimal price, int quantity, string symBol)
        {
            //Get balance and check balance to make sure user have enough money to buy stock
            if (ModelState.IsValid)
            {
                //Get balance
                decimal balance = db.GetAccountBalance(userId);
                //Calculate total amount user has to pay
                decimal total = quantity * price;

                if(total < balance)
                {
                    //Find stock in the Portfolio
                    PortfolioStockModel stock = db.FindStockInPortfolio(stockId, userId);
                    
                    //If stock not found (mean not own), then purchase the stock (mean insert new record)
                    if(stock == null)
                    {
                        //Make a new purchase
                        db.PurchaseStock(stockId, userId, price, quantity);
                        //Debit from the account balance
                        db.DebitAccountBalance(userId, total);
                    }
                    //If stock found (already own it), then purchase more shares (update new price and quantity)
                    else
                    {
                        //Calculate quantity
                        int totalQuantity = stock.Quantity + quantity;
                        //Calculate the average for share
                        decimal averagePrice = (stock.ExecutionPrice + price) / totalQuantity;
                        //Purchase more of the stock
                        db.PurchaseMoreShares(stockId, userId, averagePrice, totalQuantity);
                        //Update the account balance
                        db.DebitAccountBalance(userId, total);
                    }
                    
                    
                    //Send Viewbags to use in the confirmation page
                    ViewBag.order = "Buy";
                    ViewBag.price = price;
                    ViewBag.quantity = quantity;
                    ViewBag.symbol = symBol;
                    ViewBag.totalCost = total;

                    //Send a confirmation/error to user interface
                    return View("Confirmation");       
                }        
                else if(total > balance)
                {
                    //Set an error
                    ViewBag.error = "You don't have enough fund.";

                    //Send a confirmation/error to user interface
                    return View("Confirmation");
                }            
            }

            //Default return 
            return View();
        }

        //Implement the get portfolio method
        public IActionResult Portfolio()
        {
            if (ModelState.IsValid)
            {
                //Get the current signed in user
                string user = HttpContext.Session.GetString("_Name");

                if(user != null)
                {
                    //Get Id of the current loggin user
                    int userId = (int)HttpContext.Session.GetInt32("_Id");

                    //Get account balance
                    ViewBag.accountBalance = db.GetAccountBalance(userId);

                    //Send a view with a list of stocks they own
                    return View("Portfolio", db.GetStocksInPortfolio(userId) );
                }
                else
                {
                    //Tell them to sign in
                    return Redirect("/user/signin");
                }
            }
            //Default View
            return View();
        }
    }
}
