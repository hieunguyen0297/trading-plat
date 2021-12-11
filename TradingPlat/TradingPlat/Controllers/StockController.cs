using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        
        //Search for stocks by company name or stock symbol
        public IActionResult SearchStocks(string searchTerm)
        {
            List<StockModel> stocks;

            //If input field is empty, return a watchlist
            if (searchTerm == null || searchTerm.Trim().Length == 0)
            {
                return Redirect("WatchList");
            }
            //Otherwise, call SearchForStocks method that take a string of search term to find matched stocks
            else
            {
                stocks = db.SearchForStocks(searchTerm);
            }

            //If there is no matches, return an a View with message
            if(stocks.Count == 0)
            {
                return View("Empty");
            }
            //Found match stocks, return a View with stocks info
            else
            {
                return View("StockList", stocks);
            }
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

            if(info.Symbol == null)
            {
                return View("Error");
            }
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
                        decimal averagePrice = (stock.ExecutionPrice * stock.Quantity + total) / totalQuantity;
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

        //View the owned stock details in the portfolio
        public async Task<IActionResult> OwnedStockDetails(int id)
        {
            if (ModelState.IsValid)
            {               
                //Get the current signed in user
                string user = HttpContext.Session.GetString("_Name");

                if (user != null)
                {
                    //Get Id of the current loggin user                  
                    int userId = (int)HttpContext.Session.GetInt32("_Id");
                    Portfolio stockDetails = db.GetOwnedStockDetails(id, userId);

                    //Make a new instace of ExternalAPI class
                    ExternalAPI api = new ExternalAPI();

                    //Call api to get stock quote
                    StockQuote stock = await api.GetStockPrice(stockDetails.Stock.Symbol);
                    ViewBag.price = stock.Price;

                    return View("StockOwnedDetails", stockDetails);
                }
                else
                {
                    //Tell them to sign in
                    return Redirect("/user/signin");
                }
            }
            return View();         
        }

        //Implement the sell process
        public IActionResult SellStock(int stockId, int userId, decimal price, int quantity, string symBol)
        {
            if (ModelState.IsValid)
            {
                //Get total amount of money receive from the sell
                decimal TotalCreditReceive = price * quantity;

                //Implement the sell method
                db.SellStock(stockId, userId, quantity);

                //Update balance
                db.CreditAccountBalance(userId, TotalCreditReceive);

                //Send Viewbags to use in the confirmation page
                ViewBag.order = "Sell";
                ViewBag.price = price;
                ViewBag.quantity = quantity;
                ViewBag.symbol = symBol;
                ViewBag.totalCreditReceive = TotalCreditReceive;

                return View("Confirmation");
            }
            return View();
        }
    }
}
