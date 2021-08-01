using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private readonly BuyWindowViewModel _buyWindowViewModel;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;

        public BuyStockCommand(BuyWindowViewModel buyWindowViewModel, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            _buyWindowViewModel = buyWindowViewModel;
            _buyStockService = buyStockService;
            _accountStore = accountStore;
        }

        public event EventHandler CanExecuteChanged;

    
        public bool CanExecute(object parameter) => true;
        

        public async void Execute(object parameter)
        {
            try
            {
               Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount, _buyWindowViewModel.Symbol, _buyWindowViewModel.SharesToBuy);
                _accountStore.CurrentAccount = account;
                MessageBox.Show("Seccess");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
