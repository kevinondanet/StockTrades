using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brainscale.Stock.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    public class StockMemoryRepo : IStockRepo
    {
        private readonly List<StockModel> Stocks = new List<StockModel>();

        public StockMemoryRepo()
        {
            Stocks.Add(new StockModel { Id = 1, UserId = 1, Name = "Kevin", Start = new DateTime(2017, 10, 18), TimeStamp = new DateTime(2018, 10, 18), Symbol = "MSFT", TradeType = "Sell", Price = 23.50, Shares = 3});
            Stocks.Add(new StockModel { Id = 2, UserId = 2, Name = "Bill", Start = new DateTime(2018, 10, 18), TimeStamp = new DateTime(2018, 1, 18), Symbol = "AAPL", TradeType = "Sell", Price = 23.50, Shares = 6 });
            Stocks.Add(new StockModel { Id = 3, UserId = 3, Name = "Chris", Start = new DateTime(2019, 10, 18), TimeStamp = new DateTime(2019, 3, 18), Symbol = "AAPL", TradeType = "Sell", Price = 23.50, Shares = 5 });
            Stocks.Add(new StockModel { Id = 4, UserId = 4, Name = "Larry", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2016, 3, 18), Symbol = "AMZN", TradeType = "Buy", Price = 22.50, Shares = 9 });
            Stocks.Add(new StockModel { Id = 5, UserId = 5, Name = "Sam", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2018, 6, 18), Symbol = "NFLX", TradeType = "Sell", Price = 21.50, Shares = 6 });
            Stocks.Add(new StockModel { Id = 6, UserId = 6, Name = "Don", Start = new DateTime(2017, 10, 18), TimeStamp = new DateTime(2019, 10, 18), Symbol = "MSFT", TradeType = "Buy", Price = 23.50, Shares = 12 });
            Stocks.Add(new StockModel { Id = 7, UserId = 2, Name = "Bill", Start = new DateTime(201, 10, 18), TimeStamp = new DateTime(2018, 11, 18), Symbol = "WORK", TradeType = "Sell", Price = 124.50, Shares = 3 });
            Stocks.Add(new StockModel { Id = 8, UserId = 3, Name = "Chris", Start = new DateTime(2019, 10, 18), TimeStamp = new DateTime(2019, 8, 18), Symbol = "WORK", TradeType = "Sell", Price = 125.50, Shares = 4 });
            Stocks.Add(new StockModel { Id = 9, UserId = 3, Name = "Chris", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2018, 8, 18), Symbol = "WORK", TradeType = "Buy", Price = 124.50, Shares = 8 });
            Stocks.Add(new StockModel { Id = 10, UserId = 5, Name = "Sam", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2018, 3, 18), Symbol = "ESTC", TradeType = "Sell", Price = 242, Shares = 6 });
            Stocks.Add(new StockModel { Id = 11, UserId = 6, Name = "Don", Start = new DateTime(2017, 10, 18), TimeStamp = new DateTime(2019, 1, 18), Symbol = "MSFT", TradeType = "Buy", Price = 23.50, Shares = 11 });
            Stocks.Add(new StockModel { Id = 12, UserId = 2, Name = "Bill", Start = new DateTime(201, 10, 18), TimeStamp = new DateTime(2018, 12, 18), Symbol = "WORK", TradeType = "Sell", Price = 125.50, Shares = 20 });
            Stocks.Add(new StockModel { Id = 13, UserId = 2, Name = "Bill", Start = new DateTime(2019, 10, 18), TimeStamp = new DateTime(2019, 3, 18), Symbol = "WORK", TradeType = "Sell", Price = 122.50, Shares = 14 });
            Stocks.Add(new StockModel { Id = 14, UserId = 3, Name = "Chris", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2018, 2, 18), Symbol = "ESTC", TradeType = "Buy", Price = 242, Shares = 2 });
            Stocks.Add(new StockModel { Id = 15, UserId = 7, Name = "Bob", Start = new DateTime(2015, 10, 18), TimeStamp = new DateTime(2018, 2, 18), Symbol = "ESTC", TradeType = "Sell", Price = 242, Shares = 26 });

       }
        public IEnumerable<StockModel> GetAll()
        {
            return Stocks;
        }

        public IEnumerable<StockModel> DeleteAll()
        {
            Stocks.Clear();
            return Stocks;
        }

        public StockModel GetById(int id)
        {
            return Stocks.First(c => c.Id == id);
        }

        public IEnumerable<StockModel> GetTradesByUser(int userId)
        {
            return Stocks.Where(c => c.UserId == userId);
        }
 
        public StockModel Add(StockModel model)
        {
            model.Id = Stocks.Max(c => c.Id) + 1;
            Stocks.Add(model);
            return model;
        }


        public PriceModel GetStockByPriceHighToLow(string symbol, DateTime start, DateTime end) { 


            var results = Stocks.Where(x => x.Symbol.ToLower() == symbol.ToLower());
            if (results.Any())
            {
                var stocks = results.Where(x => x.TimeStamp >= start).Where(x => x.TimeStamp <= end);
                if (stocks.Any())
                {
                    var max = stocks.Max(r => r.Price);
                    var min = stocks.Min(r => r.Price);

                    return new PriceModel { Symbol = symbol, Highest = max, Lowest = min };
                } else
                {
                    return new PriceModel { Symbol = "There are no trades in the given date range", Highest = 0, Lowest = 0};
                }
            }

            return null; 
        }


        public IEnumerable<StockModel> GetStockBySymbolAndTypeAndDate(string symbol, string type, DateTime start, DateTime end)
        {
            var results = Stocks.Where(x => x.Symbol.ToLower() == symbol.ToLower()).Where(x => x.TimeStamp >= start).Where(x => x.TimeStamp <= end).Where(x => x.TradeType.ToLower() == type.ToLower()).ToList();
            if (results.Any())
            {
                return results;
            }
            else
            {
                return null;
            }
        }

    }
}
