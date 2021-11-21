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
    }
}
