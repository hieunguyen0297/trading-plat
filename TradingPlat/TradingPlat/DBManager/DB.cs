using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlat.Models;

namespace TradingPlat.DBManager
{
    public class DB
    {
        private readonly StockDBContext _db;
        //Constructor for this StockDB class
        public DB() 
        {
            _db = new StockDBContext();
        }

        //Get a list of stocks
        public List<StockModel> GetStocks()
        {
            //Fetch the database to get a list of stocks, then return it back to controller
            List<StockModel> stocks = _db.Stocks.ToList();
            return stocks;
        }

        //Get one stock from database
        public StockModel GetStock(int id)
        {
            StockModel stock = _db.Stocks.Where(s => s.StockID == id).FirstOrDefault();
            return stock;
        }


        //Register a user
        public int RegisterUser(UserModel user)
        {  

            UserModel newUser = new UserModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password=user.Password
            };

            _db.Users.Add(newUser);

            int affected = _db.SaveChanges();

            return (affected);
        }


        //Find user by email
        public UserModel FindUserByEmail(string email)
        {
            //find user in the database
            var user = _db.Users.Where(u => u.Email == email).FirstOrDefault();
            return user;
        }
       

        //Find User by email and password
        public UserModel FindUserByEmailAndPassword(string email, string password)
        {
            UserModel user = _db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user;
        }

        //Find user in the Accounts table
        public Account FindUserInvestingAccountByUserId(int id)
        {
            Account account = _db.Accounts.Where(a => a.UserID == id).FirstOrDefault();
            return account;
        }



        //Add userId to Account table
        public int InsertNewAccountIntoAccountsTable(int id)
        {

            Account newAccount = new Account()
            {
                UserID = id,
                Balance = 100000.00M
            };

            _db.Accounts.Add(newAccount);

            int affected = _db.SaveChanges();

            return (affected);
        }


        //Get account balance 
        public decimal GetAccountBalance(int id)
        {
            Account account = _db.Accounts.Where(a => a.UserID == id).FirstOrDefault();
            decimal balance = account.Balance;

            return balance;
        }


        //Purchase stock
        public int PurchaseStock(int stockId, int userId, decimal price, int quantity)
        {
            PortfolioStockModel newRecord = new PortfolioStockModel()
            {
                StockID = stockId,
                UserID = userId,
                ExecutionPrice = price,
                Quantity = quantity
            };

            _db.PortfolioStocks.Add(newRecord);
            int afffected = _db.SaveChanges();
            return afffected;

        }
    }
}
