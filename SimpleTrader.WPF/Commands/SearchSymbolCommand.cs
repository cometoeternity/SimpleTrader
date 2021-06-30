using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private BuyWindowViewModel _buyWindowViewModel;
        private IStockPriceService _stockPriceService;

        public event EventHandler CanExecuteChanged;

        public SearchSymbolCommand(BuyWindowViewModel buyWindowViewModel, IStockPriceService stockPriceService)
        {
            _buyWindowViewModel = buyWindowViewModel;
            _stockPriceService = stockPriceService;
        }

        public bool CanExecute(object parameter) => true;


        public async void Execute(object parameter)
        {
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_buyWindowViewModel.Symbol);
                _buyWindowViewModel.StockPrice = stockPrice;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
