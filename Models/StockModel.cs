using System;
using System.ComponentModel;

namespace Brainscale.Stock.API.Models
{

    /*
     * 
Each trade is a JSON entry with the following keys:

id: The unique ID of the trade.
type: The trade type, either buy or sell.
user: The user responsible for the trade, a JSON entry:
id: The user's unique ID.
name: The user's name.
symbol: The stock symbol.
shares: The total number of shares traded. The traded shares value is between 10 and 30 shares, inclusive.
price: The price of one share of stock at the time of the trade (up to two places of decimal). The stock price is between 130.42 and 195.65 inclusive.
timestamp: The timestamp for the trade creation given in the format yyyy-MM-dd HH:mm:ss. The timezone is EST (UTC -4).
*/

    public class PriceModel
    {
        public string Symbol { get; set; }
        public double Highest { get; set; }
        public double Lowest { get; set; }
    }

    public class StockModel
    {
        public StockModel()
        {
            Start = DateTime.Now;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public Double Price { get; set; }
        public string Name { get; set; }
        public string TradeType { get; set; }
        public string Symbol { get; set; }
        public int Shares { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime Start { get; set; }
    }


}

