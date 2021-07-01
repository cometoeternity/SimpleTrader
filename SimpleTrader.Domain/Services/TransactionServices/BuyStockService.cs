using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IAccountService _accountService;

        public BuyStockService(IStockPriceService stockPriceService, IAccountService accountService)
        {
            _stockPriceService = stockPriceService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await _stockPriceService.GetPrice(symbol);
            double trasactionPrice = stockPrice * shares;
            if(trasactionPrice > buyer.Balance)
            {
                throw new InsufficientFundsException(buyer.Balance, trasactionPrice);
            }
            AssetTransaction transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchase = true
            };
            buyer.AssetTransactions.Add(transaction);
            buyer.Balance -= trasactionPrice;
            await _accountService.Update(buyer.Id, buyer);
            return buyer;
        }
    }
}
