using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using Brainscale.Stock.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brainscale.Stock.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepo repo;

        
        public StocksController(IStockRepo repo)
        {
            this.repo = repo;
        }


        [HttpGet("/erase")]
        public IActionResult DeleteAll()
        {
            var Stocks = repo.DeleteAll();

            return new ObjectResult(Stocks);
        }


        [HttpGet("/trades")]
        public IActionResult GetAll()
        {
            var Stocks = repo.GetAll();
            if (!Stocks.Any())
                return new NoContentResult();

            return new ObjectResult(Stocks);
        }

        [HttpPost("/trades")]
        public StockModel Add(StockModel Stock)
        {
            return repo.Add(Stock);
        }

        [HttpGet("{symbol}/trades/{type?}")]
        public IActionResult GetStockBySymbolAndTypeAndDate(string symbol, [FromQuery]string type, [FromQuery]DateTime start, [FromQuery]DateTime end)
        {
            var Stocks = repo.GetStockBySymbolAndTypeAndDate(symbol, type, start, end);
            return Stocks == null ? NotFound() : (IActionResult)new ObjectResult(Stocks);

        }

        [HttpGet("/trades/users/{UserId}")]
        public IActionResult GetTradesByUser(int UserId)
        {
           
            var Stocks = repo.GetTradesByUser(UserId);
            if (!Stocks.Any())
                return new NoContentResult();

            return new ObjectResult(Stocks);
        }

        [HttpGet("{symbol}/price/")]
        public IActionResult GetStockByPriceHighToLow(string symbol, [FromQuery]DateTime start, [FromQuery]DateTime end)
        {
            var Stocks = repo.GetStockByPriceHighToLow(symbol, start, end);
            return Stocks == null ? NotFound() : (IActionResult)new ObjectResult(Stocks);
        }

    }
}
