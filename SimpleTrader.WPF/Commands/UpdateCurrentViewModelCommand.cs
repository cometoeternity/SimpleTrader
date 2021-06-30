using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IRootSimpleTraderViewModelFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootSimpleTraderViewModelFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public bool CanExecute(object parameter) => true;
       

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                 _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }
    }
}
