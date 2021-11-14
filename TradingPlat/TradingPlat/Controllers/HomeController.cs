﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TradingPlat.Models;

namespace TradingPlat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            List<StockModel> stocks = new List<StockModel>();
            using (var db = new StockDBContext())
            {
                stocks = db.Stocks.ToList();
            }
            return View("Index", stocks);
        }

        public IActionResult GetStockID(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
