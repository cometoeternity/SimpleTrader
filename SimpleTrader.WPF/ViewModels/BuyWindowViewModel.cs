﻿using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.ViewModels.Base;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyWindowViewModel : ViewModelBase
    {
        private string _symbol;
        public string Symbol
        {
            get 
            { 
                return _symbol; 
            }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private double _stockPrice;
        public double StockPrice
        {
            get
            { 
                return _stockPrice; 
            }
            set 
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
            }
        }

        private int _sharesToBuy;
        public int SharesToBuy
        {
            get
            {
                return _sharesToBuy; 
            }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice
        {
            get => SharesToBuy * StockPrice;   
        }


        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }

        public BuyWindowViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
        }
    }
}
