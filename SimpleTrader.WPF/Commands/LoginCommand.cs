using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginWindowViewModel loginWindowViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        { 
            _loginWindowViewModel = loginWindowViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;


        public async void Execute(object parameter)
        {
            bool success = await _authenticator.Login(_loginWindowViewModel.Username, parameter.ToString());

            if(success)
            {
                _renavigator.Renavigate();
            }
        }
    }
}
