using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
            return View();
        }

       
        //This is the way to fetch price
        public async Task<decimal> GetStockID()
        {
            var URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(result);
            decimal price = decimal.Parse((obj["Global Quote"]["05. price"]).ToString());
            return price;

            //ViewBag.ID = id;
            //return View();
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
