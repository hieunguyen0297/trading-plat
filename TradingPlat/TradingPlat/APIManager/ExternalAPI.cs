using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TradingPlat.Models;

namespace TradingPlat.APIManager
{
    public class ExternalAPI
    {
        private HttpClient _httpClient;
        public ExternalAPI()
        {
            _httpClient = new HttpClient();
  
        }

        //Get stock information from an external source API request
        public async Task<Company> GetStockInfor(string symbol)
        {

            Company company = null;

            //Sending request to third party API using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync($"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey=T496J6ATH5QH6NY9");

            //Call GetStockPrice method to get the latest price of the stock
            StockQuote stock = await GetStockPrice(symbol);

            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var Response = await Res.Content.ReadAsStringAsync();

                //Use  [JsonPropertyName("Wind")] to customize property name in Company class, 
                //Then use line below to convert Json object into model object
                //var outObject = JsonConvert.DeserializeObject<Company>(Response);

                //Wrap the response in a Json Object
                JObject obj = JObject.Parse(Response);

                if (obj["Note"] != null)
                {
                    return new Company();
                }

                //Get attributes from the JSON object
                string stockSymbol = obj["Symbol"].ToString();
                string name = obj["Name"].ToString();
                string description = obj["Description"].ToString();
                string exchange = obj["Exchange"].ToString();
                string sector = obj["Sector"].ToString();
                string industry = obj["Industry"].ToString();
                string address = obj["Address"].ToString();
                string marketcap = obj["MarketCapitalization"].ToString();
                string dividentPerShare = obj["DividendPerShare"].ToString();
                string analysisPrice = obj["AnalystTargetPrice"].ToString();
                string weekHigh = obj["52WeekHigh"].ToString();
                string weeklow = obj["52WeekLow"].ToString();

                //Set value for Company class's attributes
                company = new Company() { 
                    Symbol = stockSymbol, 
                    Name = name, 
                    Description = description, 
                    Exchange = exchange, 
                    Sector = sector, 
                    Industry = industry, 
                    Address = address, 
                    MarketCapitalization = marketcap, 
                    DividendPerShare = dividentPerShare, 
                    AnalystTargetPrice = analysisPrice, 
                    _52WeekHigh = weekHigh, 
                    _52WeekLow = weeklow,
                    StockLastestPrice = stock.Price,
                    ChangeInPercent = stock.ChangePercent
                };
            }
            return company;
        }

        //Get stock price by stock ticker
        public async Task<StockQuote> GetStockPrice(string symbol)
        {
            StockQuote stock = null;

            try
            {
                HttpResponseMessage Res = await _httpClient.GetAsync($"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey=T496J6ATH5QH6NY9");
                Res.EnsureSuccessStatusCode();
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = await Res.Content.ReadAsStringAsync();

                    //Wrap the response in a JSON Object
                    JObject obj = JObject.Parse(Response);

                    if(obj["Note"] != null)
                    {
                        return new StockQuote() { Symbol = null, Open = 0, High = 0, Low = 0, Price = 0, Change = 0, ChangePercent = null };
                    }

                    //Attract data from the JSON object
                    string stockSymbol = obj["Global Quote"]["01. symbol"].ToString();
                    decimal open = decimal.Parse(obj["Global Quote"]["02. open"].ToString());
                    decimal high = decimal.Parse(obj["Global Quote"]["03. high"].ToString());
                    decimal low = decimal.Parse(obj["Global Quote"]["04. low"].ToString());
                    decimal price = decimal.Parse(obj["Global Quote"]["05. price"].ToString());
                    decimal change = decimal.Parse(obj["Global Quote"]["09. change"].ToString());
                    string changePercent = obj["Global Quote"]["10. change percent"].ToString();

                    //Make a new StockQuote object
                    stock = new StockQuote()
                    {
                        Symbol = stockSymbol,
                        Open = open,
                        High = high,
                        Low = low,
                        Price = price,
                        Change = change,
                        ChangePercent = changePercent
                    };
                }
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            

            return stock;
        }
    }
}
