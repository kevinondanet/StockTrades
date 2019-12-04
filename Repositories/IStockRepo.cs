using System;
using System.Collections.Generic;
using Brainscale.Stock.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    public interface IStockRepo
    {
        StockModel Add(StockModel model);
        IEnumerable<StockModel> GetAll();
        StockModel GetById(int id);
        IEnumerable<StockModel> GetStockBySymbolAndTypeAndDate(string symbol, string type, DateTime start, DateTime end);
        PriceModel GetStockByPriceHighToLow(string symbol, DateTime start, DateTime end);
        IEnumerable<StockModel> GetTradesByUser(int userId);
        IEnumerable<StockModel> DeleteAll();
    }
}
