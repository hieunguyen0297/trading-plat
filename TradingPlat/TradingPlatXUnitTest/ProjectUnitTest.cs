using System;
using Xunit;
using TradingPlat.APIManager;
using TradingPlat.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingPlat.Controllers;

namespace TradingPlatXUnitTest
{
    public class ProjectUnitTest
    {
        [Fact]
        public async Task TestGettingStockPriceFromAPIAsync()
        {
            //Arrange 
            var api = new ExternalAPI();
            var expect = new StockQuote() { Symbol = "AAPL", Open = 158.7350M, High = 64.2000M, Low = 157.8000M, Price = 163.7600M, Change = -1.0100M, ChangePercent = "-0.6130%" };
            //Act 
            var actual = await api.GetStockPrice("AAPL");
            //Assert
            Assert.Equal(expect.Open, actual.Open);
        }


        [Theory]
        [InlineData(1,2, 12.44, 10, "AAPL")]
        [InlineData(1, 2, 12.44, 10,"")]
        [InlineData(1, 2, 100000, 10, "")]
        [InlineData(1, 2, 12.44, 100000, "MSFT")]
        //Even though there is no exception in the application, but the test still give an error
        //Microsoft.Data.Sqlite.SqliteException : SQLite Error 1: 'no such table: Accounts'
        public void TestPurchaseStock(int stockId, int userId, decimal price, int quantity, string symBol)
        {
            //Arrange
            StockController stock = new StockController();
            //Act
            var result = stock.PurchaseStock(stockId, userId, price, quantity, symBol);
            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Theory]
        [InlineData("aapl")]
        [InlineData("a")]
        [InlineData("123")]
        [InlineData("   ")]
        //Microsoft.Data.Sqlite.SqliteException : SQLite Error 1: 'no such table: Stocks'
        public void TestSearchStocks(string symbol)
        {
            //Arrange
            StockController stockController = new StockController();
            //Act
            var result = stockController.SearchStocks(symbol);
            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }
    }
}
