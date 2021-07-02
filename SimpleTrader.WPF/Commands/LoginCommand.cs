using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;
        private readonly IAuthenticator _authenticator;

        public LoginCommand(LoginWindowViewModel loginWindowViewModel, IAuthenticator authenticator)
        {
            _loginWindowViewModel = loginWindowViewModel;
            _authenticator = authenticator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;


        public async void Execute(object parameter)
        {
            bool success = await _authenticator.Login(_loginWindowViewModel.Username, parameter.ToString());
        }
    }
}
