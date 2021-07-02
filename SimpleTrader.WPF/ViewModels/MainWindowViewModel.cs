using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }


        //С помощью этого конструктора при включении приложения будет сразу открываться
        //ViewType.Home
        public MainWindowViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
