using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private BuyWindowViewModel _buyWindowViewModel;
        private IBuyStockService _buyStockService;

        public BuyStockCommand(BuyWindowViewModel buyWindowViewModel, IBuyStockService buyStockService)
        {
            _buyWindowViewModel = buyWindowViewModel;
            _buyStockService = buyStockService;
        }

        public event EventHandler CanExecuteChanged;

    
        public bool CanExecute(object parameter) => true;
        

        public void Execute(object parameter)
        {
            try
            {
                _buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }, _buyWindowViewModel.Symbol, _buyWindowViewModel.SharesToBuy); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
