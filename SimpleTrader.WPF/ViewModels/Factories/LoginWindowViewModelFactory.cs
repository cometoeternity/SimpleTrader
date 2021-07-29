using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class LoginWindowViewModelFactory : ISimpleTraderViewModelFactory<LoginWindowViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginWindowViewModelFactory(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public LoginWindowViewModel CreateViewModel() => new LoginWindowViewModel(_authenticator, _renavigator);    
    }
}
