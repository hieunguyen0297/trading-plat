using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{
    public class StockDBContext : DbContext
    {
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<PortfolioStockModel> PortfolioStocks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public string Path { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            Path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Stock.db");
            options.UseSqlite($"Data Source={Path}");
        } 
    }

}
