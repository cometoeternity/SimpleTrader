using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Base;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISimpleTraderViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand  UpdateCurrentViewModelCommand { get; } //как readonly


        //С помощью этого конструктора при включении приложения будет сразу открываться
        //ViewType.Home
        public MainWindowViewModel(INavigator navigator, ISimpleTraderViewModelFactory viewModelFactory ,IAuthenticator authenticator)
        {
            _navigator = navigator;
            _authenticator = authenticator;
            _viewModelFactory = viewModelFactory;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
