using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get 
            { 
                return _username; 
            }
            set 
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public ICommand LoginCommand { get; set; }

        public LoginWindowViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }
    }
}
