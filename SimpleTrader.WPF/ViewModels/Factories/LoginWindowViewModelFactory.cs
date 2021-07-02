using SimpleTrader.WPF.State.Authenticators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class LoginWindowViewModelFactory : ISimpleTraderViewModelFactory<LoginWindowViewModel>
    {
        private readonly IAuthenticator _authenticator;

        public LoginWindowViewModelFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public LoginWindowViewModel CreateViewModel() => new LoginWindowViewModel(_authenticator);    
    }
}
