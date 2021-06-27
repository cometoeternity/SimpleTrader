using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class BuyPriceService : IStokePriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient();
            string uri = "stock/real-time-price/" + symbol;
            StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

            if(stockPriceResult.Price == 0)
            {
                throw new InvalidSymbolException(symbol);
            }

            return stockPriceResult.Price;
        }
    }
}
