using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using SimpleTrader.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRootSimpleTraderViewModelFactory _viewModelFactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand  UpdateCurrentViewModelCommand { get; } //readonly


        //С помощью этого конструктора при включении приложения будет сразу открываться
        //ViewType.Home
        public MainWindowViewModel(INavigator navigator, IRootSimpleTraderViewModelFactory viewModelFactory ,IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            _viewModelFactory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);

            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
